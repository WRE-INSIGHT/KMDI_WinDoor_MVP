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
    public class MultiPanelTransomUCPresenter : IMultiPanelTransomUCPresenter, IPresenterCommon
    {
        IMultiPanelTransomUC _multiPanelTransomUC;
        private IMultiPanelMullionUCPresenter _multiMullionUCP; //Original Instance
        private IMultiPanelMullionUCPresenter _multiMullionUCP_given; //Given Instance

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
        private ITransomUCPresenter _transomUCP;
        private IFrameUCPresenter _frameUCP;
        private IMultiPanelTransomUCPresenter _multiPanelTransomUCP;
        private IMultiPanelPropertiesUCPresenter _multiPropUCP_orig;  //Original Instance
        private IMultiPanelPropertiesUCPresenter _multiPropUCP2_given; //Given Instance

        private IDividerServices _divServices;
        private IPanelServices _panelServices;
        private IMultiPanelServices _multipanelServices;

        bool _initialLoad;

        private MultiPanelCommon _mpnlCommons = new MultiPanelCommon();

        public MultiPanelTransomUCPresenter(IMultiPanelTransomUC multiPanelTransomUC,
                                            IFixedPanelUCPresenter fixedUCP,
                                            ICasementPanelUCPresenter casementUCP,
                                            IAwningPanelUCPresenter awningUCP,
                                            ISlidingPanelUCPresenter slidingUCP,
                                            IPanelServices panelServices,
                                            IMultiPanelServices multipanelServices,
                                            IPanelPropertiesUCPresenter panelPropertiesUCP,
                                            IfrmDimensionPresenter frmDimensionPresenter,
                                            IFixedPanelImagerUCPresenter fixedImagerUCP,
                                            ITransomUCPresenter transomUCP,
                                            IDividerServices divServices,
                                            IMultiPanelMullionUCPresenter multiMullionUCP,
                                            IMultiPanelPropertiesUCPresenter multiPropUCP_orig)
        {
            _multiPanelTransomUC = multiPanelTransomUC;
            _fixedUCP = fixedUCP;
            _casementUCP = casementUCP;
            _awningUCP = awningUCP;
            _slidingUCP = slidingUCP;
            _panelServices = panelServices;
            _multipanelServices = multipanelServices;
            _panelPropertiesUCP = panelPropertiesUCP;
            _frmDimensionPresenter = frmDimensionPresenter;
            _fixedImagerUCP = fixedImagerUCP;
            _transomUCP = transomUCP;
            _divServices = divServices;
            _multiMullionUCP = multiMullionUCP;
            _multiPropUCP_orig = multiPropUCP_orig;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _multiPanelTransomUC.flpMulltiPaintEventRaised += _multiPanelTransomUC_flpMulltiPaintEventRaised;
            _multiPanelTransomUC.flpMultiDragDropEventRaised += _multiPanelTransomUC_flpMultiDragDropEventRaised;
            _multiPanelTransomUC.flpMultiMouseEnterEventRaised += _multiPanelTransomUC_flpMultiMouseEnterEventRaised;
            _multiPanelTransomUC.flpMultiMouseLeaveEventRaised += _multiPanelTransomUC_flpMultiMouseLeaveEventRaised;
            _multiPanelTransomUC.divCountClickedEventRaised += _multiPanelTransomUC_divCountClickedEventRaised;
            _multiPanelTransomUC.deleteClickedEventRaised += _multiPanelTransomUC_deleteClickedEventRaised;
            _multiPanelTransomUC.multiMullionSizeChangedEventRaised += _multiPanelTransomUC_multiMullionSizeChangedEventRaised; ;
        }

        private void _multiPanelTransomUC_multiMullionSizeChangedEventRaised(object sender, EventArgs e)
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

        private void _multiPanelTransomUC_flpMultiDragDropEventRaised(object sender, DragEventArgs e)
        {
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender; //Control na babagsakan
            string data = e.Data.GetData(e.Data.GetFormats()[0]) as string;

            int panelID = _mainPresenter.GetPanelCount() + 1,
                multiID = _mainPresenter.GetMultiPanelCount() + 1,
                divID = _mainPresenter.GetDividerCount() + 1;

            int multiPanel_boundsWD = fpnl.Width - 20,
                multiPanel_boundsHT = fpnl.Height - 20,
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

            if (data.Contains("Multi-Panel")) //if Multi-Panel
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
                    
                    IMultiPanelModel mPanelModel = _multipanelServices.AddMultiPanelModel(_frmDmRes_Width,
                                                                                          _frmDmRes_Height,
                                                                                          fpnl,
                                                                                          (UserControl)_frameUCP.GetFrameUC(),
                                                                                          true,
                                                                                          flow,
                                                                                          multiID,
                                                                                          DockStyle.None,
                                                                                          _multiPanelModel.GetNextIndex(),
                                                                                          _multiPanelModel);
                    _frameModel.Lst_MultiPanel.Add(mPanelModel);
                    _multiPanelModel.MPanelLst_MultiPanel.Add(mPanelModel);
                    _multiPanelModel.Reload_MultiPanelMargin();

                    IMultiPanelPropertiesUCPresenter multiPropUCP = _multiPropUCP_orig.GetNewInstance(_unityC, mPanelModel, _mainPresenter);
                    _multiPropUCP2_given.GetMultiPanelPropertiesFLP().Controls.Add((UserControl)multiPropUCP.GetMultiPanelPropertiesUC());

                    _frameModel.FrameProp_Height += (129 + 3); // +3 for MultiPanelProperties' Margin
                    _multiPanelModel.MPanelProp_Height += (129 + 3);

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
                        IMultiPanelMullionUCPresenter multiUCP = _multiMullionUCP.GetNewInstance(_unityC,
                                                                                                 mPanelModel,
                                                                                                 _frameModel,
                                                                                                 _mainPresenter,
                                                                                                 _frameUCP,
                                                                                                 this,
                                                                                                 multiPropUCP);
                        IMultiPanelMullionUC multiUC = multiUCP.GetMultiPanel();
                        fpnl.Controls.Add((UserControl)multiUC);
                        multiUCP.SetInitialLoadFalse();
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)multiUC , _frameModel.Frame_Type.ToString());
                        if (mPanelModel.MPanel_Placement == "Last")
                        {
                            _multiPanelModel.Fit_MyControls();
                        }
                        else if (mPanelModel.MPanel_Placement != "Last")
                        {
                            IDividerModel divModel = _divServices.AddDividerModel(fpnl.Width,
                                                                      divSize,
                                                                      fpnl,
                                                                      (UserControl)_frameUCP.GetFrameUC(),
                                                                      DividerModel.DividerType.Transom,
                                                                      true,
                                                                      divID,
                                                                      _frameModel.Frame_Type.ToString());

                            _frameModel.Lst_Divider.Add(divModel);
                            _multiPanelModel.MPanelLst_Divider.Add(divModel);

                            ITransomUCPresenter transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                                        divModel,
                                                                                        _multiPanelModel,
                                                                                        this,
                                                                                        _frameModel);
                            ITransomUC transomUC = transomUCP.GetTransom();
                            fpnl.Controls.Add((UserControl)transomUC);
                            transomUCP.SetInitialLoadFalse();
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)transomUC, _frameModel.Frame_Type.ToString());
                        }
                    }
                    else if (data.Contains("Transom"))
                    {
                        IMultiPanelTransomUCPresenter multiTransom = GetNewInstance(_unityC,
                                                                                    mPanelModel,
                                                                                    _frameModel,
                                                                                    _mainPresenter,
                                                                                    _frameUCP,
                                                                                    this,
                                                                                    multiPropUCP);
                        IMultiPanelTransomUC multiUC = multiTransom.GetMultiPanel();
                        fpnl.Controls.Add((UserControl)multiUC);
                        multiTransom.SetInitialLoadFalse();
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)multiUC, _frameModel.Frame_Type.ToString());
                        if (mPanelModel.MPanel_Placement == "Last")
                        {
                            _multiPanelModel.Fit_MyControls();
                        }
                        else if (mPanelModel.MPanel_Placement != "Last")
                        {
                            IDividerModel divModel = _divServices.AddDividerModel(fpnl.Width,
                                                                                  divSize,
                                                                                  fpnl,
                                                                                  (UserControl)_frameUCP.GetFrameUC(),
                                                                                  DividerModel.DividerType.Transom,
                                                                                  true,
                                                                                  divID,
                                                                                  _frameModel.Frame_Type.ToString());

                            _frameModel.Lst_Divider.Add(divModel);
                            _multiPanelModel.MPanelLst_Divider.Add(divModel);

                            ITransomUCPresenter transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                                        divModel,
                                                                                        _multiPanelModel,
                                                                                        this,
                                                                                        _frameModel);
                            ITransomUC transomUC = transomUCP.GetTransom();
                            fpnl.Controls.Add((UserControl)transomUC);
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)transomUC, _frameModel.Frame_Type.ToString());
                            transomUCP.SetInitialLoadFalse();
                        }
                    }
                }
            }
            else
            {
                int suggest_Wd = multiPanel_boundsWD,
                    suggest_HT = ((multiPanel_boundsHT - (divSize * _multiPanelModel.MPanel_Divisions)) / totalPanelCount);

                if (_multiPanelModel.MPanel_ParentModel != null)
                {
                    suggest_Wd = multiPanel_boundsWD + 2;
                }

                _frmDimensionPresenter.SetPresenters(this);
                _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.AddPanelIntoMultiPanel;
                _frmDimensionPresenter.SetHeight();
                _frmDimensionPresenter.SetValues(suggest_Wd, suggest_HT);
                _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                bool frmResult = _frmDimensionPresenter.GetfrmResult();

                IFramePropertiesUC framePropUC = _mainPresenter.GetFrameProperties(_frameModel.Frame_ID);

                if (!frmResult)
                {
                    _panelModel = _panelServices.AddPanelModel(_frmDmRes_Width,
                                                               _frmDmRes_Height,
                                                               fpnl,
                                                               (UserControl)_frameUCP.GetFrameUC(),
                                                               (UserControl)framePropUC,
                                                               (UserControl)_multiPanelTransomUC,
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
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)fixedUC, _frameModel.Frame_Type.ToString());
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
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)casementUC, _frameModel.Frame_Type.ToString());
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
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)awningUC, _frameModel.Frame_Type.ToString());
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
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)slidingUC, _frameModel.Frame_Type.ToString());
                        slidingUCP.SetInitialLoadFalse();

                        //ISlidingPanelImagerUCPresenter slidingImagerUCP = _slidingImagerUCP.GetNewInstance(_unityC, _panelModel);
                        //ISlidingPanelImagerUC slidingImagerUC = slidingImagerUCP.GetSlidingPanelImagerUC();
                        //pnl_inner_willRenderImg.Controls.Add((UserControl)slidingImagerUC);
                    }

                    if (_panelModel.Panel_Placement == "Last")
                    {
                        _multiPanelModel.Fit_MyControls();
                    }
                    else if (_panelModel.Panel_Placement != "Last")
                    {
                        IDividerModel divModel = _divServices.AddDividerModel(fpnl.Width,
                                                                              divSize,
                                                                              fpnl,
                                                                              (UserControl)_frameUCP.GetFrameUC(),
                                                                              DividerModel.DividerType.Transom,
                                                                              true,
                                                                              divID,
                                                                              _frameModel.Frame_Type.ToString());

                        _frameModel.Lst_Divider.Add(divModel);
                        _multiPanelModel.MPanelLst_Divider.Add(divModel);

                        ITransomUCPresenter transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                                    divModel,
                                                                                    _multiPanelModel,
                                                                                    this,
                                                                                    _frameModel);
                        ITransomUC transomUC = transomUCP.GetTransom();
                        fpnl.Controls.Add((UserControl)transomUC);
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)transomUC, _frameModel.Frame_Type.ToString());
                        transomUCP.SetInitialLoadFalse();
                    }
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
        }

        private void _multiPanelTransomUC_deleteClickedEventRaised(object sender, EventArgs e)
        {
            FlowLayoutPanel innerFlp = (FlowLayoutPanel)((UserControl)_multiPanelTransomUC).Controls[0];
            Control parent_ctrl = ((UserControl)_multiPanelTransomUC).Parent;

            var multiPanels = _mpnlCommons.GetAll(innerFlp, "MultiPanel");
            foreach (var mpnl in multiPanels)
            {
                _multiPanelModel.MPanelProp_Height -= (129 + 3);
                _frameModel.FrameProp_Height -= (129 + 3); // +3 for MultiPanelProperties' Margin
            }

            var panels = _mpnlCommons.GetAll(innerFlp, "PanelUC");
            foreach (var pnl in panels)
            {
                _multiPanelModel.MPanelProp_Height -= 148;
                _frameModel.FrameProp_Height -= 148;
            }

            _multiPanelModel.MPanel_Visibility = false;
            if (_multiPanelModel.MPanel_ParentModel != null)
            {
                _multiPanelModel.MPanel_ParentModel.DeleteControl_MPanelLstObjects((UserControl)_multiPanelTransomUC, _frameModel.Frame_Type.ToString());
            }

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
            }
            foreach (IDividerModel div in _multiPanelModel.MPanelLst_Divider.Where(div => div.Div_Visible == true))
            {
                div.Div_Visible = false;
            }
            foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel.Where(mpnl => mpnl.MPanel_Visibility == true))
            {
                mpnl.MPanel_Visibility = false;
            }

            _multiPanelModel.MPanel_Parent.Controls.Remove((UserControl)_multiPanelTransomUC);

            if (_multiPanelModel.MPanel_Parent != null)
            {
                _multiPanelModel.MPanelProp_Height -= (129 + 3);
                _frameModel.FrameProp_Height -= (129 + 3); // +3 for MultiPanelProperties' Margin;
            }

            if (parent_ctrl.Name.Contains("flp_Multi"))
            {
                foreach (Control ctrl in parent_ctrl.Controls)
                {
                    ctrl.Invalidate();
                }
            }
        }
        
        private void _multiPanelTransomUC_divCountClickedEventRaised(object sender, EventArgs e)
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

        private void _multiPanelTransomUC_flpMultiMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            _multiPanelTransomUC.InvalidateFlp();
        }

        private void _multiPanelTransomUC_flpMultiMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            _multiPanelTransomUC.InvalidateFlp();
        }

        Color color = Color.Black;
        private void _multiPanelTransomUC_flpMulltiPaintEventRaised(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int pInnerX = 10,
                pInnerY = 10,
                pInnerWd = fpnl.ClientRectangle.Width - 20,
                pInnerHt = fpnl.ClientRectangle.Height - 20;

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

            GraphicsPath gpath = new GraphicsPath();
            Rectangle bounds = new Rectangle();
            Pen pen = new Pen(Color.Black, 2);

            IMultiPanelModel parent_mpnl = _multiPanelModel.MPanel_ParentModel;

            if (_multiPanelModel.MPanel_Parent.GetType() == typeof(FrameUC)) //if inside Frame
            {
                for (int i = 0; i < corner_points.Length - 1; i += 2)
                {
                    g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                }

                bounds = new Rectangle(new Point(10, 10),
                                       new Size(fpnl.ClientRectangle.Width - 20,
                                                fpnl.ClientRectangle.Height - 20));
            }
            else if (_multiPanelModel.MPanel_Parent.GetType() == typeof(FlowLayoutPanel)) //If MultiPanel
            {
                if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                {
                    if (_multiPanelModel.MPanel_Parent.Name.Contains("MultiTransom"))
                    #region means if the Parent of this object is `MultiTransom`
                    {
                        if (_multiPanelModel.MPanel_ParentModel.MPanel_Dock == DockStyle.Fill)
                        #region means the platform that contains this object is a MAIN PLATFORM 
                        {
                            if (_multiPanelModel.MPanel_Placement == "First")
                            #region this objects placement on the Multi-Panel object is "FIRST"
                            {
                                Rectangle topbounds = new Rectangle(new Point(0, 0),
                                                                    new Size(fpnl.Width, 10));

                                g.FillRectangle(new SolidBrush(SystemColors.Control), topbounds);

                                for (int i = 0; i < corner_points.Length - 5; i += 2)
                                {
                                    g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                                }

                                bounds = new Rectangle(new Point(10, 10),
                                                       new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 19));

                                int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;

                                if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                {
                                    Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider
                                    int lineHT = (fpnl.Height - 8) + 18,
                                        lineWd = fpnl.ClientRectangle.Width - 6;

                                    List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                  fpnl.Height,
                                                                                                                  nxt_obj.Name,
                                                                                                                  _multiPanelModel.MPanel_Placement);

                                    if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                    {
                                        gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                        gpath.AddCurve(thisDrawingPoints[1]);
                                        gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                        gpath.AddCurve(thisDrawingPoints[3]);

                                        g.DrawPath(pen, gpath);
                                        g.FillPath(Brushes.PowderBlue, gpath);
                                    }
                                }
                                else
                                {
                                    Rectangle botbounds = new Rectangle(new Point(10, fpnl.Height - 18),
                                                                        new Size(fpnl.Width - 20, 18));
                                    g.DrawRectangle(new Pen(Color.Black, 1), botbounds);
                                    g.FillRectangle(new SolidBrush(SystemColors.ActiveCaption), new Rectangle(new Point(botbounds.X + 1, botbounds.Y),
                                                                                                              new Size(botbounds.Size.Width - 2, botbounds.Height)));
                                }
                            }
                            #endregion

                            else if (_multiPanelModel.MPanel_Placement == "Last")
                            #region this objects placement on the Multi-Panel object is "LAST"
                            {
                                Rectangle botbounds = new Rectangle(new Point(0, fpnl.Height - 11),
                                                                    new Size(fpnl.Width, 11));

                                g.FillRectangle(new SolidBrush(SystemColors.Control), botbounds);

                                for (int i = 4; i < corner_points.Length - 1; i += 2)
                                {
                                    g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                                }

                                bounds = new Rectangle(new Point(10, 10),
                                                       new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));

                                int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                if (parent_mpnl.GetCount_MPanelLst_Object() > indx_PrevObj)
                                {
                                    Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];

                                    if ((prev_obj.Name.Contains("Transom") ||
                                         prev_obj.Name.Contains("Mullion")) &&
                                         !prev_obj.Name.Contains("MultiPanel")) //Divider
                                    {
                                        List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                      fpnl.Height,
                                                                                                                      prev_obj.Name,
                                                                                                                      _multiPanelModel.MPanel_Placement);

                                        gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                        gpath.AddCurve(thisDrawingPoints[1]);
                                        gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                        gpath.AddCurve(thisDrawingPoints[3]);

                                        g.DrawPath(pen, gpath);
                                        g.FillPath(Brushes.PowderBlue, gpath);
                                    }
                                }
                            }
                            #endregion

                            else if (_multiPanelModel.MPanel_Placement == "Somewhere in Between")
                            #region #region this objects placement on the Multi-Panel object is "Somewhere in Between"
                            {
                                int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];

                                if ((prev_obj.Name.Contains("Transom") ||
                                     prev_obj.Name.Contains("Mullion")) &&
                                     !prev_obj.Name.Contains("MultiPanel")) //Divider
                                {
                                    List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                  fpnl.Height,
                                                                                                                  prev_obj.Name,
                                                                                                                  _multiPanelModel.MPanel_Placement);

                                    gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                    gpath.AddCurve(thisDrawingPoints[1]);
                                    gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                    gpath.AddCurve(thisDrawingPoints[3]);

                                    g.DrawPath(pen, gpath);
                                    g.FillPath(Brushes.PowderBlue, gpath);
                                    bounds = new Rectangle(new Point(10, 10),
                                                           new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 11));
                                }

                                //Check if has nxt_obj to Draw the nxt transom Obj
                                int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;
                                if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                {
                                    Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider
                                    int lineHT = (fpnl.Height - 8) + 18,
                                        lineWd = fpnl.ClientRectangle.Width - 6;

                                    List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                  fpnl.Height,
                                                                                                                  nxt_obj.Name,
                                                                                                                  _multiPanelModel.MPanel_Placement);

                                    if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                    {
                                        GraphicsPath gpath2 = new GraphicsPath();

                                        List<Point[]> thisDrawingPoints2 = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                       fpnl.Height,
                                                                                                                       nxt_obj.Name,
                                                                                                                       _multiPanelModel.MPanel_Placement,
                                                                                                                       true);

                                        gpath2.AddLine(thisDrawingPoints2[0][0], thisDrawingPoints2[0][1]);
                                        gpath2.AddCurve(thisDrawingPoints2[1]);
                                        gpath2.AddLine(thisDrawingPoints2[2][0], thisDrawingPoints2[2][1]);
                                        gpath2.AddCurve(thisDrawingPoints2[3]);

                                        g.DrawPath(pen, gpath2);
                                        g.FillPath(Brushes.PowderBlue, gpath2);

                                        bounds = new Rectangle(new Point(10, 10),
                                                               new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));
                                    }
                                }
                            }
                            #endregion
                        }
                        #endregion

                        else if (_multiPanelModel.MPanel_Dock == DockStyle.None)
                        #region means that the platform that contains this object is a SUB-PLATFORM
                        {
                            if (_multiPanelModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Type == "Mullion")
                            #region Checking of 2nd level ParentModel if "Mullion"
                            {
                                if (_multiPanelModel.MPanel_ParentModel.MPanel_Placement == "First")
                                #region Checking the placement of the Parent Control if "First"
                                {
                                    if (_multiPanelModel.MPanel_Placement == "First")
                                    {
                                        Rectangle topbounds = new Rectangle(new Point(0, 0),
                                                                            new Size(fpnl.Width, 10));

                                        g.FillRectangle(new SolidBrush(SystemColors.Control), topbounds);

                                        g.DrawLine(Pens.Black, new Point(0, 0), new Point(pInnerX, pInnerY));

                                        bounds = new Rectangle(new Point(10, 10),
                                                               new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 19));

                                        GraphicsPath gpath_forMullion_RightSide = new GraphicsPath();

                                        List<Point[]> thisDrawingPoints_forMullion_RightSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                                           fpnl.Height,
                                                                                                                                           "Mullion",
                                                                                                                                           _multiPanelModel.MPanel_ParentModel.MPanel_Placement); //4th parameter must be the placement of the parent control
                                        gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0],
                                                                          new Point(thisDrawingPoints_forMullion_RightSide[0][1].X,
                                                                                    thisDrawingPoints_forMullion_RightSide[0][1].Y + 20));
                                        Point[] new_botCurve = new Point[3];
                                        new_botCurve[0] = new Point(thisDrawingPoints_forMullion_RightSide[1][0].X,
                                                                    thisDrawingPoints_forMullion_RightSide[1][0].Y + 20); // add 20 units to hide the curvature
                                        new_botCurve[1] = new Point(thisDrawingPoints_forMullion_RightSide[1][1].X,
                                                                    thisDrawingPoints_forMullion_RightSide[1][1].Y + 20);
                                        new_botCurve[2] = new Point(thisDrawingPoints_forMullion_RightSide[1][2].X,
                                                                    thisDrawingPoints_forMullion_RightSide[1][2].Y + 20);
                                        gpath_forMullion_RightSide.AddCurve(new_botCurve);
                                        gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                                        gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                                        g.DrawPath(pen, gpath_forMullion_RightSide);
                                        g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                                        int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;

                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                        {
                                            Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider
                                            int lineHT = (fpnl.Height - 8) + 18,
                                                lineWd = fpnl.ClientRectangle.Width - 6;

                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          nxt_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                                gpath.AddCurve(thisDrawingPoints[1]);
                                                gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                                gpath.AddCurve(thisDrawingPoints[3]);

                                                g.DrawPath(pen, gpath);
                                                g.FillPath(Brushes.PowderBlue, gpath);
                                            }
                                        }
                                        else
                                        {
                                            Rectangle botbounds = new Rectangle(new Point(10, fpnl.Height - 18),
                                                                                new Size(fpnl.Width - 20, 18));
                                            g.DrawRectangle(new Pen(Color.Black, 1), botbounds);
                                            g.FillRectangle(new SolidBrush(SystemColors.ActiveCaption), new Rectangle(new Point(botbounds.X + 1, botbounds.Y),
                                                                                                                      new Size(botbounds.Size.Width - 2, botbounds.Height)));
                                        }
                                    }
                                    else if (_multiPanelModel.MPanel_Placement == "Last")
                                    {
                                        Rectangle botbounds = new Rectangle(new Point(0, fpnl.Height - 11),
                                                                        new Size(fpnl.Width, 11));

                                        g.FillRectangle(new SolidBrush(SystemColors.Control), botbounds);

                                        g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height), new Point(pInnerX, pInnerY + pInnerHt));

                                        bounds = new Rectangle(new Point(10, 10),
                                                               new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));

                                        GraphicsPath gpath_forMullion_RightSide = new GraphicsPath();

                                        List<Point[]> thisDrawingPoints_forMullion_RightSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                                           fpnl.Height,
                                                                                                                                           "Mullion",
                                                                                                                                           _multiPanelModel.MPanel_ParentModel.MPanel_Placement);//4th parameter must be the placement of the parent control
                                        gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                                        gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                                        gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                                        gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                                        g.DrawPath(pen, gpath_forMullion_RightSide);
                                        g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                                        g.DrawCurve(new Pen(Color.PowderBlue, 2), thisDrawingPoints_forMullion_RightSide[3]);

                                        int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_PrevObj)
                                        {
                                            Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];

                                            if ((prev_obj.Name.Contains("Transom") ||
                                                 prev_obj.Name.Contains("Mullion")) &&
                                                 !prev_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                              fpnl.Height,
                                                                                                                              prev_obj.Name,
                                                                                                                              _multiPanelModel.MPanel_Placement);

                                                gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                                gpath.AddCurve(thisDrawingPoints[1]);
                                                gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                                gpath.AddCurve(thisDrawingPoints[3]);

                                                g.DrawPath(pen, gpath);
                                                g.FillPath(Brushes.PowderBlue, gpath);
                                            }
                                        }
                                    }
                                    else if (_multiPanelModel.MPanel_Placement == "Somewhere in Between")
                                    {

                                        GraphicsPath gpath_forMullion_RightSide = new GraphicsPath();

                                        List<Point[]> thisDrawingPoints_forMullion_RightSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                                           fpnl.Height,
                                                                                                                                           "Mullion",
                                                                                                                                           _multiPanelModel.MPanel_ParentModel.MPanel_Placement);//4th parameter must be the placement of the parent control
                                        gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                                        Point[] new_botCurve = new Point[3];
                                        new_botCurve[0] = new Point(thisDrawingPoints_forMullion_RightSide[1][0].X,
                                                                    thisDrawingPoints_forMullion_RightSide[1][0].Y + 20); // add 20 units to hide the curvature
                                        new_botCurve[1] = new Point(thisDrawingPoints_forMullion_RightSide[1][1].X,
                                                                    thisDrawingPoints_forMullion_RightSide[1][1].Y + 20);
                                        new_botCurve[2] = new Point(thisDrawingPoints_forMullion_RightSide[1][2].X,
                                                                    thisDrawingPoints_forMullion_RightSide[1][2].Y + 20);
                                        gpath_forMullion_RightSide.AddCurve(new_botCurve);
                                        gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                                        Point[] new_topCurve = new Point[3];
                                        new_topCurve[0] = new Point(thisDrawingPoints_forMullion_RightSide[3][0].X,
                                                                    thisDrawingPoints_forMullion_RightSide[3][0].Y - 20); // deduct 20 units to hide the curvature
                                        new_topCurve[1] = new Point(thisDrawingPoints_forMullion_RightSide[3][1].X,
                                                                    thisDrawingPoints_forMullion_RightSide[3][1].Y - 20);
                                        new_topCurve[2] = new Point(thisDrawingPoints_forMullion_RightSide[3][2].X,
                                                                    thisDrawingPoints_forMullion_RightSide[3][2].Y - 20);
                                        gpath_forMullion_RightSide.AddCurve(new_topCurve);

                                        g.DrawPath(pen, gpath_forMullion_RightSide);
                                        g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                                        int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                        Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];

                                        if ((prev_obj.Name.Contains("Transom") ||
                                             prev_obj.Name.Contains("Mullion")) &&
                                             !prev_obj.Name.Contains("MultiPanel")) //Divider
                                        {
                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          prev_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                            gpath.AddCurve(thisDrawingPoints[1]);
                                            gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                            gpath.AddCurve(thisDrawingPoints[3]);

                                            g.DrawPath(pen, gpath);
                                            g.FillPath(Brushes.PowderBlue, gpath);
                                            bounds = new Rectangle(new Point(10, 10),
                                                                   new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 11));
                                        }

                                        //Check if has nxt_obj to Draw the nxt transom Obj
                                        int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;
                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                        {
                                            Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider
                                            int lineHT = (fpnl.Height - 8) + 18,
                                                lineWd = fpnl.ClientRectangle.Width - 6;

                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          nxt_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                GraphicsPath gpath2 = new GraphicsPath();

                                                List<Point[]> thisDrawingPoints2 = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                               fpnl.Height,
                                                                                                                               nxt_obj.Name,
                                                                                                                               _multiPanelModel.MPanel_Placement,
                                                                                                                               true);

                                                gpath2.AddLine(thisDrawingPoints2[0][0], thisDrawingPoints2[0][1]);
                                                gpath2.AddCurve(thisDrawingPoints2[1]);
                                                gpath2.AddLine(thisDrawingPoints2[2][0], thisDrawingPoints2[2][1]);
                                                gpath2.AddCurve(thisDrawingPoints2[3]);

                                                g.DrawPath(pen, gpath2);
                                                g.FillPath(Brushes.PowderBlue, gpath2);

                                                bounds = new Rectangle(new Point(10, 10),
                                                                       new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));
                                            }
                                        }
                                    }
                                }
                                #endregion

                                else if (_multiPanelModel.MPanel_ParentModel.MPanel_Placement == "Somewhere in Between")
                                #region Checking the placement of the Parent Control if "Somewhere in Between"
                                {
                                    if (_multiPanelModel.MPanel_Placement == "First")
                                    {
                                        Rectangle topbounds = new Rectangle(new Point(0, 0),
                                                                            new Size(fpnl.Width, 10));

                                        g.FillRectangle(new SolidBrush(SystemColors.Control), topbounds);

                                        bounds = new Rectangle(new Point(10, 10),
                                                               new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 19));

                                        GraphicsPath gpath_forMullion_LeftSide = new GraphicsPath();

                                        List<Point[]> thisDrawingPoints_forMullion_LeftSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                                           fpnl.Height,
                                                                                                                                           "Mullion",
                                                                                                                                           _multiPanelModel.MPanel_ParentModel.MPanel_Placement); //4th parameter must be the placement of the parent control
                                        gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0],
                                                                          new Point(thisDrawingPoints_forMullion_LeftSide[0][1].X,
                                                                                    thisDrawingPoints_forMullion_LeftSide[0][1].Y + 20));
                                        Point[] new_botCurve = new Point[3];
                                        new_botCurve[0] = new Point(thisDrawingPoints_forMullion_LeftSide[1][0].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[1][0].Y + 20); // add 20 units to hide the curvature
                                        new_botCurve[1] = new Point(thisDrawingPoints_forMullion_LeftSide[1][1].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[1][1].Y + 20);
                                        new_botCurve[2] = new Point(thisDrawingPoints_forMullion_LeftSide[1][2].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[1][2].Y + 20);
                                        gpath_forMullion_LeftSide.AddCurve(new_botCurve);
                                        gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                                        gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                                        g.DrawPath(pen, gpath_forMullion_LeftSide);
                                        g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                                        GraphicsPath gpath_forMullion_RightSide = new GraphicsPath();

                                        List<Point[]> thisDrawingPoints_forMullion_RightSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                                           fpnl.Height,
                                                                                                                                           "Mullion",
                                                                                                                                           "First"); // Apply the string "First" on the 4th params to get the right side mullion
                                        gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0],
                                                                          new Point(thisDrawingPoints_forMullion_RightSide[0][1].X,
                                                                                    thisDrawingPoints_forMullion_RightSide[0][1].Y + 20));
                                        Point[] new_botCurve2 = new Point[3];
                                        new_botCurve2[0] = new Point(thisDrawingPoints_forMullion_RightSide[1][0].X,
                                                                    thisDrawingPoints_forMullion_RightSide[1][0].Y + 20); // add 20 units to hide the curvature
                                        new_botCurve2[1] = new Point(thisDrawingPoints_forMullion_RightSide[1][1].X,
                                                                    thisDrawingPoints_forMullion_RightSide[1][1].Y + 20);
                                        new_botCurve2[2] = new Point(thisDrawingPoints_forMullion_RightSide[1][2].X,
                                                                    thisDrawingPoints_forMullion_RightSide[1][2].Y + 20);
                                        gpath_forMullion_RightSide.AddCurve(new_botCurve2);
                                        gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                                        gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                                        g.DrawPath(pen, gpath_forMullion_RightSide);
                                        g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                                        int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;

                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                        {
                                            Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider
                                            int lineHT = (fpnl.Height - 8) + 18,
                                                lineWd = fpnl.ClientRectangle.Width - 6;

                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          nxt_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                                gpath.AddCurve(thisDrawingPoints[1]);
                                                gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                                gpath.AddCurve(thisDrawingPoints[3]);

                                                g.DrawPath(pen, gpath);
                                                g.FillPath(Brushes.PowderBlue, gpath);
                                            }
                                        }
                                        else
                                        {
                                            Rectangle botbounds = new Rectangle(new Point(10, fpnl.Height - 18),
                                                                                new Size(fpnl.Width - 20, 18));
                                            g.DrawRectangle(new Pen(Color.Black, 1), botbounds);
                                            g.FillRectangle(new SolidBrush(SystemColors.ActiveCaption), new Rectangle(new Point(botbounds.X + 1, botbounds.Y),
                                                                                                                      new Size(botbounds.Size.Width - 2, botbounds.Height)));
                                        }
                                    }
                                    else if (_multiPanelModel.MPanel_Placement == "Last")
                                    {
                                        Rectangle botbounds = new Rectangle(new Point(0, fpnl.Height - 11),
                                                                        new Size(fpnl.Width, 11));

                                        g.FillRectangle(new SolidBrush(SystemColors.Control), botbounds);

                                        bounds = new Rectangle(new Point(10, 10),
                                                               new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));

                                        GraphicsPath gpath_forMullion_LeftSide = new GraphicsPath();

                                        List<Point[]> thisDrawingPoints_forMullion_LeftSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                                           fpnl.Height,
                                                                                                                                           "Mullion",
                                                                                                                                           _multiPanelModel.MPanel_ParentModel.MPanel_Placement);//4th parameter must be the placement of the parent control
                                        gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                                        gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                                        gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                                        gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                                        g.DrawPath(pen, gpath_forMullion_LeftSide);
                                        g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                                        g.DrawCurve(new Pen(Color.PowderBlue, 2), thisDrawingPoints_forMullion_LeftSide[3]);


                                        GraphicsPath gpath_forMullion_RightSide = new GraphicsPath();

                                        List<Point[]> thisDrawingPoints_forMullion_RightSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                                           fpnl.Height,
                                                                                                                                           "Mullion",
                                                                                                                                           "First");
                                        gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                                        gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                                        gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                                        gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                                        gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                                        g.DrawPath(pen, gpath_forMullion_RightSide);
                                        g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                                        g.DrawCurve(new Pen(Color.PowderBlue, 2), thisDrawingPoints_forMullion_RightSide[3]);


                                        int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_PrevObj)
                                        {
                                            Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];

                                            if ((prev_obj.Name.Contains("Transom") ||
                                                 prev_obj.Name.Contains("Mullion")) &&
                                                 !prev_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                              fpnl.Height,
                                                                                                                              prev_obj.Name,
                                                                                                                              _multiPanelModel.MPanel_Placement);

                                                gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                                gpath.AddCurve(thisDrawingPoints[1]);
                                                gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                                gpath.AddCurve(thisDrawingPoints[3]);

                                                g.DrawPath(pen, gpath);
                                                g.FillPath(Brushes.PowderBlue, gpath);
                                            }
                                        }
                                    }
                                    else if (_multiPanelModel.MPanel_Placement == "Somewhere in Between")
                                    {
                                        GraphicsPath gpath_forMullion_LeftSide = new GraphicsPath();

                                        List<Point[]> thisDrawingPoints_forMullion_LeftSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                                           fpnl.Height,
                                                                                                                                           "Mullion",
                                                                                                                                           _multiPanelModel.MPanel_ParentModel.MPanel_Placement);//4th parameter must be the placement of the parent control
                                        gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                                        Point[] new_botCurve = new Point[3];
                                        new_botCurve[0] = new Point(thisDrawingPoints_forMullion_LeftSide[1][0].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[1][0].Y + 20); // add 20 units to hide the curvature
                                        new_botCurve[1] = new Point(thisDrawingPoints_forMullion_LeftSide[1][1].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[1][1].Y + 20);
                                        new_botCurve[2] = new Point(thisDrawingPoints_forMullion_LeftSide[1][2].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[1][2].Y + 20);
                                        gpath_forMullion_LeftSide.AddCurve(new_botCurve);
                                        gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                                        Point[] new_topCurve = new Point[3];
                                        new_topCurve[0] = new Point(thisDrawingPoints_forMullion_LeftSide[3][0].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[3][0].Y - 20); // deduct 20 units to hide the curvature
                                        new_topCurve[1] = new Point(thisDrawingPoints_forMullion_LeftSide[3][1].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[3][1].Y - 20);
                                        new_topCurve[2] = new Point(thisDrawingPoints_forMullion_LeftSide[3][2].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[3][2].Y - 20);
                                        gpath_forMullion_LeftSide.AddCurve(new_topCurve);

                                        g.DrawPath(pen, gpath_forMullion_LeftSide);
                                        g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);


                                        GraphicsPath gpath_forMullion_RightSide = new GraphicsPath();

                                        List<Point[]> thisDrawingPoints_forMullion_RightSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                                           fpnl.Height,
                                                                                                                                           "Mullion",
                                                                                                                                           "First");// Apply the string "First" on the 4th params to get the right side mullion
                                        gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                                        Point[] new_botCurve2 = new Point[3];
                                        new_botCurve2[0] = new Point(thisDrawingPoints_forMullion_RightSide[1][0].X,
                                                                    thisDrawingPoints_forMullion_RightSide[1][0].Y + 20); // add 20 units to hide the curvature
                                        new_botCurve2[1] = new Point(thisDrawingPoints_forMullion_RightSide[1][1].X,
                                                                    thisDrawingPoints_forMullion_RightSide[1][1].Y + 20);
                                        new_botCurve2[2] = new Point(thisDrawingPoints_forMullion_RightSide[1][2].X,
                                                                    thisDrawingPoints_forMullion_RightSide[1][2].Y + 20);
                                        gpath_forMullion_RightSide.AddCurve(new_botCurve2);
                                        gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                                        Point[] new_topCurve2 = new Point[3];
                                        new_topCurve2[0] = new Point(thisDrawingPoints_forMullion_RightSide[3][0].X,
                                                                    thisDrawingPoints_forMullion_RightSide[3][0].Y - 20); // deduct 20 units to hide the curvature
                                        new_topCurve2[1] = new Point(thisDrawingPoints_forMullion_RightSide[3][1].X,
                                                                    thisDrawingPoints_forMullion_RightSide[3][1].Y - 20);
                                        new_topCurve2[2] = new Point(thisDrawingPoints_forMullion_RightSide[3][2].X,
                                                                    thisDrawingPoints_forMullion_RightSide[3][2].Y - 20);
                                        gpath_forMullion_RightSide.AddCurve(new_topCurve2);

                                        g.DrawPath(pen, gpath_forMullion_RightSide);
                                        g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);


                                        int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                        Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];

                                        if ((prev_obj.Name.Contains("Transom") ||
                                             prev_obj.Name.Contains("Mullion")) &&
                                             !prev_obj.Name.Contains("MultiPanel")) //Divider
                                        {
                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          prev_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                            gpath.AddCurve(thisDrawingPoints[1]);
                                            gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                            gpath.AddCurve(thisDrawingPoints[3]);

                                            g.DrawPath(pen, gpath);
                                            g.FillPath(Brushes.PowderBlue, gpath);
                                            bounds = new Rectangle(new Point(10, 10),
                                                                   new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 11));
                                        }

                                        //Check if has nxt_obj to Draw the nxt transom Obj
                                        int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;
                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                        {
                                            Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider
                                            int lineHT = (fpnl.Height - 8) + 18,
                                                lineWd = fpnl.ClientRectangle.Width - 6;

                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          nxt_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                GraphicsPath gpath2 = new GraphicsPath();

                                                List<Point[]> thisDrawingPoints2 = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                               fpnl.Height,
                                                                                                                               nxt_obj.Name,
                                                                                                                               _multiPanelModel.MPanel_Placement,
                                                                                                                               true);

                                                gpath2.AddLine(thisDrawingPoints2[0][0], thisDrawingPoints2[0][1]);
                                                gpath2.AddCurve(thisDrawingPoints2[1]);
                                                gpath2.AddLine(thisDrawingPoints2[2][0], thisDrawingPoints2[2][1]);
                                                gpath2.AddCurve(thisDrawingPoints2[3]);

                                                g.DrawPath(pen, gpath2);
                                                g.FillPath(Brushes.PowderBlue, gpath2);

                                                bounds = new Rectangle(new Point(10, 10),
                                                                       new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));
                                            }
                                        }
                                    }
                                }
                                #endregion

                                else if (_multiPanelModel.MPanel_ParentModel.MPanel_Placement == "Last")
                                #region Checking the placement of the Parent Control if "Last"
                                {
                                    if (_multiPanelModel.MPanel_Placement == "First")
                                    {
                                        Rectangle topbounds = new Rectangle(new Point(0, 0),
                                                                            new Size(fpnl.Width, 10));

                                        g.FillRectangle(new SolidBrush(SystemColors.Control), topbounds);
                                        g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0), new Point(pInnerX + pInnerWd, pInnerY));

                                        bounds = new Rectangle(new Point(10, 10),
                                                               new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 19));

                                        GraphicsPath gpath_forMullion_LeftSide = new GraphicsPath();

                                        List<Point[]> thisDrawingPoints_forMullion_LeftSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                                           fpnl.Height,
                                                                                                                                           "Mullion",
                                                                                                                                           _multiPanelModel.MPanel_ParentModel.MPanel_Placement); //4th parameter must be the placement of the parent control
                                        gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0],
                                                                          new Point(thisDrawingPoints_forMullion_LeftSide[0][1].X,
                                                                                    thisDrawingPoints_forMullion_LeftSide[0][1].Y + 20));
                                        Point[] new_botCurve = new Point[3];
                                        new_botCurve[0] = new Point(thisDrawingPoints_forMullion_LeftSide[1][0].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[1][0].Y + 20); // add 20 units to hide the curvature
                                        new_botCurve[1] = new Point(thisDrawingPoints_forMullion_LeftSide[1][1].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[1][1].Y + 20);
                                        new_botCurve[2] = new Point(thisDrawingPoints_forMullion_LeftSide[1][2].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[1][2].Y + 20);
                                        gpath_forMullion_LeftSide.AddCurve(new_botCurve);
                                        gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                                        gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                                        g.DrawPath(pen, gpath_forMullion_LeftSide);
                                        g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                                        int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;

                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                        {
                                            Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider
                                            int lineHT = (fpnl.Height - 8) + 18,
                                                lineWd = fpnl.ClientRectangle.Width - 6;

                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          nxt_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                                gpath.AddCurve(thisDrawingPoints[1]);
                                                gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                                gpath.AddCurve(thisDrawingPoints[3]);

                                                g.DrawPath(pen, gpath);
                                                g.FillPath(Brushes.PowderBlue, gpath);
                                            }
                                        }
                                        else
                                        {
                                            Rectangle botbounds = new Rectangle(new Point(10, fpnl.Height - 18),
                                                                                new Size(fpnl.Width - 20, 18));
                                            g.DrawRectangle(new Pen(Color.Black, 1), botbounds);
                                            g.FillRectangle(new SolidBrush(SystemColors.ActiveCaption), new Rectangle(new Point(botbounds.X + 1, botbounds.Y),
                                                                                                                      new Size(botbounds.Size.Width - 2, botbounds.Height)));
                                        }
                                    }
                                    else if (_multiPanelModel.MPanel_Placement == "Last")
                                    {
                                        Rectangle botbounds = new Rectangle(new Point(0, fpnl.Height - 11),
                                                                            new Size(fpnl.Width, 11));

                                        g.FillRectangle(new SolidBrush(SystemColors.Control), botbounds);

                                        g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                                               new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                                        bounds = new Rectangle(new Point(10, 10),
                                                               new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));

                                        GraphicsPath gpath_forMullion_LeftSide = new GraphicsPath();

                                        List<Point[]> thisDrawingPoints_forMullion_LeftSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                                           fpnl.Height,
                                                                                                                                           "Mullion",
                                                                                                                                           _multiPanelModel.MPanel_ParentModel.MPanel_Placement); //4th parameter must be the placement of the parent control
                                        gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                                        gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                                        gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                                        gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                                        g.DrawPath(pen, gpath_forMullion_LeftSide);
                                        g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                                        g.DrawCurve(new Pen(Color.PowderBlue, 2), thisDrawingPoints_forMullion_LeftSide[3]);

                                        int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_PrevObj)
                                        {
                                            Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];

                                            if ((prev_obj.Name.Contains("Transom") ||
                                                 prev_obj.Name.Contains("Mullion")) &&
                                                 !prev_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                              fpnl.Height,
                                                                                                                              prev_obj.Name,
                                                                                                                              _multiPanelModel.MPanel_Placement);

                                                gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                                gpath.AddCurve(thisDrawingPoints[1]);
                                                gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                                gpath.AddCurve(thisDrawingPoints[3]);

                                                g.DrawPath(pen, gpath);
                                                g.FillPath(Brushes.PowderBlue, gpath);
                                            }
                                        }
                                    }
                                    else if (_multiPanelModel.MPanel_Placement == "Somewhere in Between")
                                    {
                                        GraphicsPath gpath_forMullion_LeftSide = new GraphicsPath();

                                        List<Point[]> thisDrawingPoints_forMullion_LeftSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                                           fpnl.Height,
                                                                                                                                           "Mullion",
                                                                                                                                           _multiPanelModel.MPanel_ParentModel.MPanel_Placement); //4th parameter must be the placement of the parent control
                                        gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0],
                                                                          new Point(thisDrawingPoints_forMullion_LeftSide[0][1].X,
                                                                                    thisDrawingPoints_forMullion_LeftSide[0][1].Y + 20));
                                        Point[] new_botCurve = new Point[3];
                                        new_botCurve[0] = new Point(thisDrawingPoints_forMullion_LeftSide[1][0].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[1][0].Y + 20); // add 20 units to hide the curvature
                                        new_botCurve[1] = new Point(thisDrawingPoints_forMullion_LeftSide[1][1].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[1][1].Y + 20);
                                        new_botCurve[2] = new Point(thisDrawingPoints_forMullion_LeftSide[1][2].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[1][2].Y + 20);
                                        gpath_forMullion_LeftSide.AddCurve(new_botCurve);
                                        gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                                        Point[] new_topCurve = new Point[3];
                                        new_topCurve[0] = new Point(thisDrawingPoints_forMullion_LeftSide[3][0].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[3][0].Y - 20); // deduct 20 units to hide the curvature
                                        new_topCurve[1] = new Point(thisDrawingPoints_forMullion_LeftSide[3][1].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[3][1].Y - 20);
                                        new_topCurve[2] = new Point(thisDrawingPoints_forMullion_LeftSide[3][2].X,
                                                                    thisDrawingPoints_forMullion_LeftSide[3][2].Y - 20);
                                        gpath_forMullion_LeftSide.AddCurve(new_topCurve);

                                        g.DrawPath(pen, gpath_forMullion_LeftSide);
                                        g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                                        int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                        Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];

                                        if ((prev_obj.Name.Contains("Transom") ||
                                             prev_obj.Name.Contains("Mullion")) &&
                                             !prev_obj.Name.Contains("MultiPanel")) //Divider
                                        {
                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          prev_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                            gpath.AddCurve(thisDrawingPoints[1]);
                                            gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                            gpath.AddCurve(thisDrawingPoints[3]);

                                            g.DrawPath(pen, gpath);
                                            g.FillPath(Brushes.PowderBlue, gpath);
                                            bounds = new Rectangle(new Point(10, 10),
                                                                   new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 11));
                                        }

                                        //Check if has nxt_obj to Draw the nxt transom Obj
                                        int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;
                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                        {
                                            Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider
                                            int lineHT = (fpnl.Height - 8) + 18,
                                                lineWd = fpnl.ClientRectangle.Width - 6;

                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          nxt_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                GraphicsPath gpath2 = new GraphicsPath();

                                                List<Point[]> thisDrawingPoints2 = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                               fpnl.Height,
                                                                                                                               nxt_obj.Name,
                                                                                                                               _multiPanelModel.MPanel_Placement,
                                                                                                                               true);

                                                gpath2.AddLine(thisDrawingPoints2[0][0], thisDrawingPoints2[0][1]);
                                                gpath2.AddCurve(thisDrawingPoints2[1]);
                                                gpath2.AddLine(thisDrawingPoints2[2][0], thisDrawingPoints2[2][1]);
                                                gpath2.AddCurve(thisDrawingPoints2[3]);

                                                g.DrawPath(pen, gpath2);
                                                g.FillPath(Brushes.PowderBlue, gpath2);

                                                bounds = new Rectangle(new Point(10, 10),
                                                                       new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));
                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                            #endregion

                            else if (_multiPanelModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Type == "Transom")
                            #region Checking of 2nd level ParentModel if "Transom"
                            {
                                if (_multiPanelModel.MPanel_ParentModel.MPanel_Placement == "First")
                                #region checking the placement of the parent control if "FIRST"
                                {
                                    Rectangle leftbounds = new Rectangle(new Point(0, 0),
                                                                         new Size(10, fpnl.Height));
                                    g.FillRectangle(new SolidBrush(SystemColors.Control), leftbounds);

                                    g.DrawLine(Pens.Black, new Point(0, 0),
                                                           new Point(pInnerX, pInnerY));
                                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                                           new Point(pInnerX, pInnerY + pInnerHt));

                                    bounds = new Rectangle(new Point(10, 10),
                                                           new Size(fpnl.ClientRectangle.Width - 19, fpnl.ClientRectangle.Height - 20));


                                    int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;

                                    if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                    {
                                        Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider

                                        List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                      fpnl.Height,
                                                                                                                      nxt_obj.Name,
                                                                                                                      _multiPanelModel.MPanel_Placement);

                                        if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                        {
                                            gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                            gpath.AddCurve(thisDrawingPoints[1]);
                                            gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                            gpath.AddCurve(thisDrawingPoints[3]);

                                            g.DrawPath(pen, gpath);
                                            g.FillPath(Brushes.PowderBlue, gpath);
                                        }
                                    }
                                    else
                                    {
                                        Rectangle rightbounds = new Rectangle(new Point(fpnl.Width - 10, 10),
                                                                              new Size(18, fpnl.Height - 20));
                                        g.DrawRectangle(new Pen(Color.Black, 1), rightbounds);
                                        g.FillRectangle(new SolidBrush(Color.MistyRose), new Rectangle(new Point(rightbounds.X, rightbounds.Y + 1),
                                                                                                       new Size(rightbounds.Width, rightbounds.Height - 2)));
                                    }
                                }
                                #endregion
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion

                    else if (_multiPanelModel.MPanel_Parent.Name.Contains("MultiMullion"))
                    #region means if the Parent of this object is `MultiMullion`
                    {
                        if (_multiPanelModel.MPanel_ParentModel.MPanel_Dock == DockStyle.Fill)
                        #region means the platform that contains this object is a MAIN PLATFORM 
                        {
                            if (_multiPanelModel.MPanel_Placement == "First")
                            #region this objects's MPanel_Placement is "First"
                            {
                                Rectangle leftbounds = new Rectangle(new Point(0, 0),
                                                                     new Size(10, fpnl.Height));
                                g.FillRectangle(new SolidBrush(SystemColors.Control), leftbounds);

                                g.DrawLine(Pens.Black, new Point(0, 0),
                                                       new Point(pInnerX, pInnerY));
                                g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                                       new Point(pInnerX, pInnerY + pInnerHt));

                                bounds = new Rectangle(new Point(10, 10),
                                                       new Size(fpnl.ClientRectangle.Width - 19, fpnl.ClientRectangle.Height - 20));


                                int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;

                                if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                {
                                    Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider

                                    List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                  fpnl.Height,
                                                                                                                  nxt_obj.Name,
                                                                                                                  _multiPanelModel.MPanel_Placement);

                                    if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                    {
                                        gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                        gpath.AddCurve(thisDrawingPoints[1]);
                                        gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                        gpath.AddCurve(thisDrawingPoints[3]);

                                        g.DrawPath(pen, gpath);
                                        g.FillPath(Brushes.PowderBlue, gpath);
                                    }
                                }
                                else
                                {
                                    Rectangle rightbounds = new Rectangle(new Point(fpnl.Width - 10, 10),
                                                                          new Size(18, fpnl.Height - 20));
                                    g.DrawRectangle(new Pen(Color.Black, 1), rightbounds);
                                    g.FillRectangle(new SolidBrush(Color.MistyRose), new Rectangle(new Point(rightbounds.X, rightbounds.Y + 1),
                                                                                                   new Size(rightbounds.Width, rightbounds.Height - 2)));
                                }
                            }
                            #endregion

                            else if (_multiPanelModel.MPanel_Placement == "Last")
                            #region this object's MPanel_Placement is "Last"
                            {
                                Rectangle leftbounds = new Rectangle(new Point(11, 0),
                                                                    new Size(11, fpnl.Height));

                                g.FillRectangle(new SolidBrush(SystemColors.Control), leftbounds);

                                g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                                       new Point(pInnerX + pInnerWd, pInnerY));
                                g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                                       new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                                bounds = new Rectangle(new Point(10, 10),
                                                       new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));

                                int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                if (parent_mpnl.GetCount_MPanelLst_Object() > indx_PrevObj)
                                {
                                    Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];

                                    if ((prev_obj.Name.Contains("Transom") ||
                                         prev_obj.Name.Contains("Mullion")) &&
                                         !prev_obj.Name.Contains("MultiPanel")) //Divider
                                    {
                                        List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                      fpnl.Height,
                                                                                                                      prev_obj.Name,
                                                                                                                      _multiPanelModel.MPanel_Placement);

                                        gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                        gpath.AddCurve(thisDrawingPoints[1]);
                                        gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                        gpath.AddCurve(thisDrawingPoints[3]);

                                        g.DrawPath(pen, gpath);
                                        g.FillPath(Brushes.PowderBlue, gpath);
                                    }
                                }
                            }
                            #endregion

                            else if (_multiPanelModel.MPanel_Placement == "Somewhere in Between")
                            #region this object's MPanel_Placement is "Somewhere in Between"
                            {
                                int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];
                                if ((prev_obj.Name.Contains("Transom") ||
                                     prev_obj.Name.Contains("Mullion")) &&
                                     !prev_obj.Name.Contains("MultiPanel")) //Divider
                                {
                                    List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                  fpnl.Height,
                                                                                                                  prev_obj.Name,
                                                                                                                  _multiPanelModel.MPanel_Placement);

                                    gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                    gpath.AddCurve(thisDrawingPoints[1]);
                                    gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                    gpath.AddCurve(thisDrawingPoints[3]);

                                    g.DrawPath(pen, gpath);
                                    g.FillPath(Brushes.PowderBlue, gpath);
                                    bounds = new Rectangle(new Point(10, 10),
                                                           new Size(fpnl.ClientRectangle.Width - 11, fpnl.ClientRectangle.Height - 20));
                                }

                                //Check if has nxt_obj to Draw the nxt transom Obj
                                int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;
                                if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                {
                                    Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider
                                    int lineHT = (fpnl.Height - 8) + 18,
                                        lineWd = fpnl.ClientRectangle.Width - 6;

                                    List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                  fpnl.Height,
                                                                                                                  nxt_obj.Name,
                                                                                                                  _multiPanelModel.MPanel_Placement);

                                    if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                    {
                                        GraphicsPath gpath2 = new GraphicsPath();

                                        List<Point[]> thisDrawingPoints2 = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                       fpnl.Height,
                                                                                                                       nxt_obj.Name,
                                                                                                                       _multiPanelModel.MPanel_Placement,
                                                                                                                       true);

                                        gpath2.AddLine(thisDrawingPoints2[0][0], thisDrawingPoints2[0][1]);
                                        gpath2.AddCurve(thisDrawingPoints2[1]);
                                        gpath2.AddLine(thisDrawingPoints2[2][0], thisDrawingPoints2[2][1]);
                                        gpath2.AddCurve(thisDrawingPoints2[3]);

                                        g.DrawPath(pen, gpath2);
                                        g.FillPath(Brushes.PowderBlue, gpath2);

                                        bounds = new Rectangle(new Point(10, 10),
                                                               new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));
                                    }
                                }
                            }
                            #endregion

                        }
                        #endregion

                        else if (_multiPanelModel.MPanel_ParentModel.MPanel_Dock == DockStyle.None)
                        #region means that the platform that contains this object is a SUB-PLATFORM
                        {
                            if (_multiPanelModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Type == "Transom")
                            #region Checking of 2nd level ParentModel if "Transom"
                            {
                                if (_multiPanelModel.MPanel_ParentModel.MPanel_Placement == "First")
                                #region checking the placement of the parent control if "FIRST"
                                {
                                    GraphicsPath gpath_forTransom_Bottom = new GraphicsPath();

                                    List<Point[]> thisDrawingPoints_forTransom_Bottom = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                                    fpnl.Height,
                                                                                                                                    "Transom",
                                                                                                                                    _multiPanelModel.MPanel_ParentModel.MPanel_Placement);

                                    if (_multiPanelModel.MPanel_Placement == "First")
                                    #region this control's Placement is "First"
                                    {
                                        Rectangle leftbounds = new Rectangle(new Point(0, 0),
                                                                         new Size(10, fpnl.Height));
                                        g.FillRectangle(new SolidBrush(SystemColors.Control), leftbounds);

                                        g.DrawLine(Pens.Black, new Point(0, 0),
                                                               new Point(pInnerX, pInnerY));

                                        bounds = new Rectangle(new Point(10, 10),
                                                               new Size(fpnl.ClientRectangle.Width - 19, fpnl.ClientRectangle.Height - 20));

                                        gpath_forTransom_Bottom.AddLine(thisDrawingPoints_forTransom_Bottom[0][0], thisDrawingPoints_forTransom_Bottom[0][1]);
                                        Point[] new_RightCurve = new Point[3];
                                        new_RightCurve[0] = new Point(thisDrawingPoints_forTransom_Bottom[1][0].X + 20, // add 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Bottom[1][0].Y);
                                        new_RightCurve[1] = new Point(thisDrawingPoints_forTransom_Bottom[1][1].X + 20,
                                                                      thisDrawingPoints_forTransom_Bottom[1][1].Y);
                                        new_RightCurve[2] = new Point(thisDrawingPoints_forTransom_Bottom[1][2].X + 20,
                                                                      thisDrawingPoints_forTransom_Bottom[1][2].Y);
                                        gpath_forTransom_Bottom.AddCurve(new_RightCurve);
                                        gpath_forTransom_Bottom.AddLine(thisDrawingPoints_forTransom_Bottom[2][0], thisDrawingPoints_forTransom_Bottom[2][1]);
                                        gpath_forTransom_Bottom.AddCurve(thisDrawingPoints_forTransom_Bottom[3]);

                                        g.DrawPath(pen, gpath_forTransom_Bottom);
                                        g.FillPath(Brushes.PowderBlue, gpath_forTransom_Bottom);

                                        int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;

                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                        {
                                            Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider

                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          nxt_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                                gpath.AddCurve(thisDrawingPoints[1]);
                                                gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                                gpath.AddCurve(thisDrawingPoints[3]);

                                                g.DrawPath(pen, gpath);
                                                g.FillPath(Brushes.PowderBlue, gpath);
                                            }
                                        }
                                        else
                                        {
                                            Rectangle rightbounds = new Rectangle(new Point(fpnl.Width - 10, 10),
                                                                                  new Size(18, fpnl.Height - 20));
                                            g.DrawRectangle(new Pen(Color.Black, 1), rightbounds);
                                            g.FillRectangle(new SolidBrush(Color.MistyRose), new Rectangle(new Point(rightbounds.X, rightbounds.Y + 1),
                                                                                                           new Size(rightbounds.Width, rightbounds.Height - 2)));
                                        }
                                    }
                                    #endregion

                                    else if (_multiPanelModel.MPanel_Placement == "Last")
                                    #region this control's Placement is "Last"
                                    {
                                        Rectangle leftbounds = new Rectangle(new Point(11, 0),
                                                                             new Size(11, fpnl.Height));

                                        g.FillRectangle(new SolidBrush(SystemColors.Control), leftbounds);

                                        g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                                               new Point(pInnerX + pInnerWd, pInnerY));

                                        bounds = new Rectangle(new Point(10, 10),
                                                               new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));

                                        gpath_forTransom_Bottom.AddLine(thisDrawingPoints_forTransom_Bottom[0][0], thisDrawingPoints_forTransom_Bottom[0][1]);
                                        gpath_forTransom_Bottom.AddCurve(thisDrawingPoints_forTransom_Bottom[1]);
                                        gpath_forTransom_Bottom.AddLine(thisDrawingPoints_forTransom_Bottom[2][0], thisDrawingPoints_forTransom_Bottom[2][1]);
                                        Point[] new_LeftCurve = new Point[3];
                                        new_LeftCurve[0] = new Point(thisDrawingPoints_forTransom_Bottom[3][0].X - 20, // deduct 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Bottom[3][0].Y);
                                        new_LeftCurve[1] = new Point(thisDrawingPoints_forTransom_Bottom[3][1].X - 20,
                                                                      thisDrawingPoints_forTransom_Bottom[3][1].Y);
                                        new_LeftCurve[2] = new Point(thisDrawingPoints_forTransom_Bottom[3][2].X - 20,
                                                                      thisDrawingPoints_forTransom_Bottom[3][2].Y);
                                        gpath_forTransom_Bottom.AddCurve(new_LeftCurve);

                                        g.DrawPath(pen, gpath_forTransom_Bottom);
                                        g.FillPath(Brushes.PowderBlue, gpath_forTransom_Bottom);


                                        int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_PrevObj)
                                        {
                                            Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];

                                            if ((prev_obj.Name.Contains("Transom") ||
                                                 prev_obj.Name.Contains("Mullion")) &&
                                                 !prev_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                              fpnl.Height,
                                                                                                                              prev_obj.Name,
                                                                                                                              _multiPanelModel.MPanel_Placement);

                                                gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                                gpath.AddCurve(thisDrawingPoints[1]);
                                                gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                                gpath.AddCurve(thisDrawingPoints[3]);

                                                g.DrawPath(pen, gpath);
                                                g.FillPath(Brushes.PowderBlue, gpath);
                                            }
                                        }
                                    }
                                    #endregion

                                    else if (_multiPanelModel.MPanel_Placement == "Somewhere in Between")
                                    #region this control's Placement is "Somewhere in Between"
                                    {
                                        gpath_forTransom_Bottom.AddLine(thisDrawingPoints_forTransom_Bottom[0][0], thisDrawingPoints_forTransom_Bottom[0][1]);
                                        Point[] new_RightCurve = new Point[3];
                                        new_RightCurve[0] = new Point(thisDrawingPoints_forTransom_Bottom[1][0].X + 20, // add 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Bottom[1][0].Y);
                                        new_RightCurve[1] = new Point(thisDrawingPoints_forTransom_Bottom[1][1].X + 20,
                                                                      thisDrawingPoints_forTransom_Bottom[1][1].Y);
                                        new_RightCurve[2] = new Point(thisDrawingPoints_forTransom_Bottom[1][2].X + 20,
                                                                      thisDrawingPoints_forTransom_Bottom[1][2].Y);
                                        gpath_forTransom_Bottom.AddCurve(new_RightCurve);
                                        gpath_forTransom_Bottom.AddLine(thisDrawingPoints_forTransom_Bottom[2][0], thisDrawingPoints_forTransom_Bottom[2][1]);
                                        Point[] new_LeftCurve = new Point[3];
                                        new_LeftCurve[0] = new Point(thisDrawingPoints_forTransom_Bottom[3][0].X - 20, // deduct 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Bottom[3][0].Y);
                                        new_LeftCurve[1] = new Point(thisDrawingPoints_forTransom_Bottom[3][1].X - 20,
                                                                      thisDrawingPoints_forTransom_Bottom[3][1].Y);
                                        new_LeftCurve[2] = new Point(thisDrawingPoints_forTransom_Bottom[3][2].X - 20,
                                                                      thisDrawingPoints_forTransom_Bottom[3][2].Y);
                                        gpath_forTransom_Bottom.AddCurve(new_LeftCurve);

                                        g.DrawPath(pen, gpath_forTransom_Bottom);
                                        g.FillPath(Brushes.PowderBlue, gpath_forTransom_Bottom);


                                        int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                        Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];
                                        if ((prev_obj.Name.Contains("Transom") ||
                                             prev_obj.Name.Contains("Mullion")) &&
                                             !prev_obj.Name.Contains("MultiPanel")) //Divider
                                        {
                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          prev_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                            gpath.AddCurve(thisDrawingPoints[1]);
                                            gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                            gpath.AddCurve(thisDrawingPoints[3]);

                                            g.DrawPath(pen, gpath);
                                            g.FillPath(Brushes.PowderBlue, gpath);
                                            bounds = new Rectangle(new Point(10, 10),
                                                                   new Size(fpnl.ClientRectangle.Width - 11, fpnl.ClientRectangle.Height - 20));
                                        }

                                        //Check if has nxt_obj to Draw the nxt transom Obj
                                        int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;
                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                        {
                                            Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider
                                            int lineHT = (fpnl.Height - 8) + 18,
                                                lineWd = fpnl.ClientRectangle.Width - 6;

                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          nxt_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                GraphicsPath gpath2 = new GraphicsPath();

                                                List<Point[]> thisDrawingPoints2 = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                               fpnl.Height,
                                                                                                                               nxt_obj.Name,
                                                                                                                               _multiPanelModel.MPanel_Placement,
                                                                                                                               true);

                                                gpath2.AddLine(thisDrawingPoints2[0][0], thisDrawingPoints2[0][1]);
                                                gpath2.AddCurve(thisDrawingPoints2[1]);
                                                gpath2.AddLine(thisDrawingPoints2[2][0], thisDrawingPoints2[2][1]);
                                                gpath2.AddCurve(thisDrawingPoints2[3]);

                                                g.DrawPath(pen, gpath2);
                                                g.FillPath(Brushes.PowderBlue, gpath2);

                                                bounds = new Rectangle(new Point(10, 10),
                                                                       new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));
                                            }
                                        }
                                    }
                                    #endregion
                                }
                                #endregion

                                else if (_multiPanelModel.MPanel_ParentModel.MPanel_Placement == "Somewhere in Between")
                                #region checking the placement of the parent control if "SOMEWHERE IN BETWEEN"
                                {
                                    GraphicsPath gpath_forTransom_Top = new GraphicsPath();

                                    List<Point[]> thisDrawingPoints_forTransom_Top = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                                    fpnl.Height,
                                                                                                                                    "Transom",
                                                                                                                                    _multiPanelModel.MPanel_ParentModel.MPanel_Placement);
                                    GraphicsPath gpath_forTransom_Bottom = new GraphicsPath();

                                    List<Point[]> thisDrawingPoints_forTransom_Bottom = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                                    fpnl.Height,
                                                                                                                                    "Transom",
                                                                                                                                    "First");
                                    if (_multiPanelModel.MPanel_Placement == "First")
                                    #region this control's Placement is "First"
                                    {
                                        Rectangle leftbounds = new Rectangle(new Point(0, 0),
                                                                         new Size(10, fpnl.Height));
                                        g.FillRectangle(new SolidBrush(SystemColors.Control), leftbounds);

                                        bounds = new Rectangle(new Point(10, 10),
                                                               new Size(fpnl.ClientRectangle.Width - 19, fpnl.ClientRectangle.Height - 20));

                                        gpath_forTransom_Top.AddLine(thisDrawingPoints_forTransom_Top[0][0], thisDrawingPoints_forTransom_Top[0][1]);
                                        Point[] new_RightCurve = new Point[3];
                                        new_RightCurve[0] = new Point(thisDrawingPoints_forTransom_Top[1][0].X + 20, // add 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Top[1][0].Y);
                                        new_RightCurve[1] = new Point(thisDrawingPoints_forTransom_Top[1][1].X + 20,
                                                                      thisDrawingPoints_forTransom_Top[1][1].Y);
                                        new_RightCurve[2] = new Point(thisDrawingPoints_forTransom_Top[1][2].X + 20,
                                                                      thisDrawingPoints_forTransom_Top[1][2].Y);
                                        gpath_forTransom_Top.AddCurve(new_RightCurve);
                                        gpath_forTransom_Top.AddLine(thisDrawingPoints_forTransom_Top[2][0], thisDrawingPoints_forTransom_Top[2][1]);
                                        gpath_forTransom_Top.AddCurve(thisDrawingPoints_forTransom_Top[3]);

                                        g.DrawPath(pen, gpath_forTransom_Top);
                                        g.FillPath(Brushes.PowderBlue, gpath_forTransom_Top);


                                        gpath_forTransom_Bottom.AddLine(thisDrawingPoints_forTransom_Bottom[0][0], thisDrawingPoints_forTransom_Bottom[0][1]);
                                        Point[] new_RightCurve2 = new Point[3];
                                        new_RightCurve2[0] = new Point(thisDrawingPoints_forTransom_Bottom[1][0].X + 20, // add 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Bottom[1][0].Y);
                                        new_RightCurve2[1] = new Point(thisDrawingPoints_forTransom_Bottom[1][1].X + 20,
                                                                      thisDrawingPoints_forTransom_Bottom[1][1].Y);
                                        new_RightCurve2[2] = new Point(thisDrawingPoints_forTransom_Bottom[1][2].X + 20,
                                                                      thisDrawingPoints_forTransom_Bottom[1][2].Y);
                                        gpath_forTransom_Bottom.AddCurve(new_RightCurve2);
                                        gpath_forTransom_Bottom.AddLine(thisDrawingPoints_forTransom_Bottom[2][0], thisDrawingPoints_forTransom_Bottom[2][1]);
                                        gpath_forTransom_Bottom.AddCurve(thisDrawingPoints_forTransom_Bottom[3]);

                                        g.DrawPath(pen, gpath_forTransom_Bottom);
                                        g.FillPath(Brushes.PowderBlue, gpath_forTransom_Bottom);


                                        int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;

                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                        {
                                            Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider

                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          nxt_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                                gpath.AddCurve(thisDrawingPoints[1]);
                                                gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                                gpath.AddCurve(thisDrawingPoints[3]);

                                                g.DrawPath(pen, gpath);
                                                g.FillPath(Brushes.PowderBlue, gpath);
                                            }
                                        }
                                        else
                                        {
                                            Rectangle rightbounds = new Rectangle(new Point(fpnl.Width - 10, 10),
                                                                                  new Size(18, fpnl.Height - 20));
                                            g.DrawRectangle(new Pen(Color.Black, 1), rightbounds);
                                            g.FillRectangle(new SolidBrush(Color.MistyRose), new Rectangle(new Point(rightbounds.X, rightbounds.Y + 1),
                                                                                                           new Size(rightbounds.Width, rightbounds.Height - 2)));
                                        }
                                    }
                                    #endregion

                                    else if (_multiPanelModel.MPanel_Placement == "Last")
                                    #region this control's Placement is "Last"
                                    {
                                        Rectangle leftbounds = new Rectangle(new Point(11, 0),
                                                                             new Size(11, fpnl.Height));

                                        g.FillRectangle(new SolidBrush(SystemColors.Control), leftbounds);

                                        g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                                               new Point(pInnerX + pInnerWd, pInnerY));

                                        bounds = new Rectangle(new Point(10, 10),
                                                               new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));


                                        gpath_forTransom_Top.AddLine(thisDrawingPoints_forTransom_Top[0][0], thisDrawingPoints_forTransom_Top[0][1]);
                                        gpath_forTransom_Top.AddCurve(thisDrawingPoints_forTransom_Top[1]);
                                        gpath_forTransom_Top.AddLine(thisDrawingPoints_forTransom_Top[2][0], thisDrawingPoints_forTransom_Top[2][1]);
                                        Point[] new_LeftCurve = new Point[3];
                                        new_LeftCurve[0] = new Point(thisDrawingPoints_forTransom_Top[3][0].X - 20, // deduct 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Top[3][0].Y);
                                        new_LeftCurve[1] = new Point(thisDrawingPoints_forTransom_Top[3][1].X - 20,
                                                                      thisDrawingPoints_forTransom_Top[3][1].Y);
                                        new_LeftCurve[2] = new Point(thisDrawingPoints_forTransom_Top[3][2].X - 20,
                                                                      thisDrawingPoints_forTransom_Top[3][2].Y);
                                        gpath_forTransom_Top.AddCurve(new_LeftCurve);

                                        g.DrawPath(pen, gpath_forTransom_Top);
                                        g.FillPath(Brushes.PowderBlue, gpath_forTransom_Top);


                                        gpath_forTransom_Bottom.AddLine(thisDrawingPoints_forTransom_Bottom[0][0], thisDrawingPoints_forTransom_Bottom[0][1]);
                                        gpath_forTransom_Bottom.AddCurve(thisDrawingPoints_forTransom_Bottom[1]);
                                        gpath_forTransom_Bottom.AddLine(thisDrawingPoints_forTransom_Bottom[2][0], thisDrawingPoints_forTransom_Bottom[2][1]);
                                        Point[] new_LeftCurve2 = new Point[3];
                                        new_LeftCurve2[0] = new Point(thisDrawingPoints_forTransom_Bottom[3][0].X - 20, // deduct 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Bottom[3][0].Y);
                                        new_LeftCurve2[1] = new Point(thisDrawingPoints_forTransom_Bottom[3][1].X - 20,
                                                                      thisDrawingPoints_forTransom_Bottom[3][1].Y);
                                        new_LeftCurve2[2] = new Point(thisDrawingPoints_forTransom_Bottom[3][2].X - 20,
                                                                      thisDrawingPoints_forTransom_Bottom[3][2].Y);
                                        gpath_forTransom_Bottom.AddCurve(new_LeftCurve2);

                                        g.DrawPath(pen, gpath_forTransom_Bottom);
                                        g.FillPath(Brushes.PowderBlue, gpath_forTransom_Bottom);


                                        int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_PrevObj)
                                        {
                                            Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];

                                            if ((prev_obj.Name.Contains("Transom") ||
                                                 prev_obj.Name.Contains("Mullion")) &&
                                                 !prev_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                              fpnl.Height,
                                                                                                                              prev_obj.Name,
                                                                                                                              _multiPanelModel.MPanel_Placement);

                                                gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                                gpath.AddCurve(thisDrawingPoints[1]);
                                                gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                                gpath.AddCurve(thisDrawingPoints[3]);

                                                g.DrawPath(pen, gpath);
                                                g.FillPath(Brushes.PowderBlue, gpath);
                                            }
                                        }
                                    }
                                    #endregion

                                    else if (_multiPanelModel.MPanel_Placement == "Somewhere in Between")
                                    #region this control's Placement is "Somewhere in Between"
                                    {
                                        gpath_forTransom_Top.AddLine(thisDrawingPoints_forTransom_Top[0][0], thisDrawingPoints_forTransom_Top[0][1]);
                                        Point[] new_RightCurve = new Point[3];
                                        new_RightCurve[0] = new Point(thisDrawingPoints_forTransom_Top[1][0].X + 20, // add 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Top[1][0].Y);
                                        new_RightCurve[1] = new Point(thisDrawingPoints_forTransom_Top[1][1].X + 20,
                                                                      thisDrawingPoints_forTransom_Top[1][1].Y);
                                        new_RightCurve[2] = new Point(thisDrawingPoints_forTransom_Top[1][2].X + 20,
                                                                      thisDrawingPoints_forTransom_Top[1][2].Y);
                                        gpath_forTransom_Top.AddCurve(new_RightCurve);
                                        gpath_forTransom_Top.AddLine(thisDrawingPoints_forTransom_Top[2][0], thisDrawingPoints_forTransom_Top[2][1]);
                                        Point[] new_LeftCurve = new Point[3];
                                        new_LeftCurve[0] = new Point(thisDrawingPoints_forTransom_Top[3][0].X - 20, // deduct 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Top[3][0].Y);
                                        new_LeftCurve[1] = new Point(thisDrawingPoints_forTransom_Top[3][1].X - 20,
                                                                      thisDrawingPoints_forTransom_Top[3][1].Y);
                                        new_LeftCurve[2] = new Point(thisDrawingPoints_forTransom_Top[3][2].X - 20,
                                                                      thisDrawingPoints_forTransom_Top[3][2].Y);
                                        gpath_forTransom_Top.AddCurve(new_LeftCurve);

                                        g.DrawPath(pen, gpath_forTransom_Top);
                                        g.FillPath(Brushes.PowderBlue, gpath_forTransom_Top);


                                        gpath_forTransom_Bottom.AddLine(thisDrawingPoints_forTransom_Bottom[0][0], thisDrawingPoints_forTransom_Bottom[0][1]);
                                        Point[] new_RightCurve2 = new Point[3];
                                        new_RightCurve2[0] = new Point(thisDrawingPoints_forTransom_Bottom[1][0].X + 20, // add 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Bottom[1][0].Y);
                                        new_RightCurve2[1] = new Point(thisDrawingPoints_forTransom_Bottom[1][1].X + 20,
                                                                      thisDrawingPoints_forTransom_Bottom[1][1].Y);
                                        new_RightCurve2[2] = new Point(thisDrawingPoints_forTransom_Bottom[1][2].X + 20,
                                                                      thisDrawingPoints_forTransom_Bottom[1][2].Y);
                                        gpath_forTransom_Bottom.AddCurve(new_RightCurve2);
                                        gpath_forTransom_Bottom.AddLine(thisDrawingPoints_forTransom_Bottom[2][0], thisDrawingPoints_forTransom_Bottom[2][1]);
                                        Point[] new_LeftCurve2 = new Point[3];
                                        new_LeftCurve2[0] = new Point(thisDrawingPoints_forTransom_Bottom[3][0].X - 20, // deduct 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Bottom[3][0].Y);
                                        new_LeftCurve2[1] = new Point(thisDrawingPoints_forTransom_Bottom[3][1].X - 20,
                                                                      thisDrawingPoints_forTransom_Bottom[3][1].Y);
                                        new_LeftCurve2[2] = new Point(thisDrawingPoints_forTransom_Bottom[3][2].X - 20,
                                                                      thisDrawingPoints_forTransom_Bottom[3][2].Y);
                                        gpath_forTransom_Bottom.AddCurve(new_LeftCurve2);

                                        g.DrawPath(pen, gpath_forTransom_Bottom);
                                        g.FillPath(Brushes.PowderBlue, gpath_forTransom_Bottom);


                                        int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                        Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];
                                        if ((prev_obj.Name.Contains("Transom") ||
                                             prev_obj.Name.Contains("Mullion")) &&
                                             !prev_obj.Name.Contains("MultiPanel")) //Divider
                                        {
                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          prev_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                            gpath.AddCurve(thisDrawingPoints[1]);
                                            gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                            gpath.AddCurve(thisDrawingPoints[3]);

                                            g.DrawPath(pen, gpath);
                                            g.FillPath(Brushes.PowderBlue, gpath);
                                            bounds = new Rectangle(new Point(10, 10),
                                                                   new Size(fpnl.ClientRectangle.Width - 11, fpnl.ClientRectangle.Height - 20));
                                        }

                                        //Check if has nxt_obj to Draw the nxt transom Obj
                                        int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;
                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                        {
                                            Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider
                                            int lineHT = (fpnl.Height - 8) + 18,
                                                lineWd = fpnl.ClientRectangle.Width - 6;

                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          nxt_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                GraphicsPath gpath2 = new GraphicsPath();

                                                List<Point[]> thisDrawingPoints2 = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                               fpnl.Height,
                                                                                                                               nxt_obj.Name,
                                                                                                                               _multiPanelModel.MPanel_Placement,
                                                                                                                               true);

                                                gpath2.AddLine(thisDrawingPoints2[0][0], thisDrawingPoints2[0][1]);
                                                gpath2.AddCurve(thisDrawingPoints2[1]);
                                                gpath2.AddLine(thisDrawingPoints2[2][0], thisDrawingPoints2[2][1]);
                                                gpath2.AddCurve(thisDrawingPoints2[3]);

                                                g.DrawPath(pen, gpath2);
                                                g.FillPath(Brushes.PowderBlue, gpath2);

                                                bounds = new Rectangle(new Point(10, 10),
                                                                       new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));
                                            }
                                        }
                                    }
                                    #endregion
                                }
                                #endregion

                                else if (_multiPanelModel.MPanel_ParentModel.MPanel_Placement == "Last")
                                #region checking the placement of the parent control if "LAST"
                                {
                                    GraphicsPath gpath_forTransom_Top = new GraphicsPath();

                                    List<Point[]> thisDrawingPoints_forTransom_Top = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                                                                    fpnl.Height,
                                                                                                                                    "Transom",
                                                                                                                                    _multiPanelModel.MPanel_ParentModel.MPanel_Placement);
                                    if (_multiPanelModel.MPanel_Placement == "First")
                                    #region this control's Placement is "First"
                                    {
                                        Rectangle leftbounds = new Rectangle(new Point(0, 0),
                                                                         new Size(10, fpnl.Height));
                                        g.FillRectangle(new SolidBrush(SystemColors.Control), leftbounds);

                                        g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                                               new Point(pInnerX, pInnerY + pInnerHt));

                                        bounds = new Rectangle(new Point(10, 10),
                                                               new Size(fpnl.ClientRectangle.Width - 19, fpnl.ClientRectangle.Height - 20));

                                        gpath_forTransom_Top.AddLine(thisDrawingPoints_forTransom_Top[0][0], thisDrawingPoints_forTransom_Top[0][1]);
                                        Point[] new_RightCurve = new Point[3];
                                        new_RightCurve[0] = new Point(thisDrawingPoints_forTransom_Top[1][0].X + 20, // add 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Top[1][0].Y);
                                        new_RightCurve[1] = new Point(thisDrawingPoints_forTransom_Top[1][1].X + 20,
                                                                      thisDrawingPoints_forTransom_Top[1][1].Y);
                                        new_RightCurve[2] = new Point(thisDrawingPoints_forTransom_Top[1][2].X + 20,
                                                                      thisDrawingPoints_forTransom_Top[1][2].Y);
                                        gpath_forTransom_Top.AddCurve(new_RightCurve);
                                        gpath_forTransom_Top.AddLine(thisDrawingPoints_forTransom_Top[2][0], thisDrawingPoints_forTransom_Top[2][1]);
                                        gpath_forTransom_Top.AddCurve(thisDrawingPoints_forTransom_Top[3]);

                                        g.DrawPath(pen, gpath_forTransom_Top);
                                        g.FillPath(Brushes.PowderBlue, gpath_forTransom_Top);

                                        int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;

                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                        {
                                            Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider

                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          nxt_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                                gpath.AddCurve(thisDrawingPoints[1]);
                                                gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                                gpath.AddCurve(thisDrawingPoints[3]);

                                                g.DrawPath(pen, gpath);
                                                g.FillPath(Brushes.PowderBlue, gpath);
                                            }
                                        }
                                        else
                                        {
                                            Rectangle rightbounds = new Rectangle(new Point(fpnl.Width - 10, 10),
                                                                                  new Size(18, fpnl.Height - 20));
                                            g.DrawRectangle(new Pen(Color.Black, 1), rightbounds);
                                            g.FillRectangle(new SolidBrush(Color.MistyRose), new Rectangle(new Point(rightbounds.X, rightbounds.Y + 1),
                                                                                                           new Size(rightbounds.Width, rightbounds.Height - 2)));
                                        }
                                    }
                                    #endregion

                                    else if (_multiPanelModel.MPanel_Placement == "Last")
                                    #region this control's Placement is "Last"
                                    {
                                        Rectangle leftbounds = new Rectangle(new Point(11, 0),
                                                                             new Size(11, fpnl.Height));

                                        g.FillRectangle(new SolidBrush(SystemColors.Control), leftbounds);

                                        g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                                               new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                                        bounds = new Rectangle(new Point(10, 10),
                                                               new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));


                                        gpath_forTransom_Top.AddLine(thisDrawingPoints_forTransom_Top[0][0], thisDrawingPoints_forTransom_Top[0][1]);
                                        gpath_forTransom_Top.AddCurve(thisDrawingPoints_forTransom_Top[1]);
                                        gpath_forTransom_Top.AddLine(thisDrawingPoints_forTransom_Top[2][0], thisDrawingPoints_forTransom_Top[2][1]);
                                        Point[] new_LeftCurve = new Point[3];
                                        new_LeftCurve[0] = new Point(thisDrawingPoints_forTransom_Top[3][0].X - 20, // deduct 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Top[3][0].Y);
                                        new_LeftCurve[1] = new Point(thisDrawingPoints_forTransom_Top[3][1].X - 20,
                                                                      thisDrawingPoints_forTransom_Top[3][1].Y);
                                        new_LeftCurve[2] = new Point(thisDrawingPoints_forTransom_Top[3][2].X - 20,
                                                                      thisDrawingPoints_forTransom_Top[3][2].Y);
                                        gpath_forTransom_Top.AddCurve(new_LeftCurve);

                                        g.DrawPath(pen, gpath_forTransom_Top);
                                        g.FillPath(Brushes.PowderBlue, gpath_forTransom_Top);

                                        int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_PrevObj)
                                        {
                                            Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];

                                            if ((prev_obj.Name.Contains("Transom") ||
                                                 prev_obj.Name.Contains("Mullion")) &&
                                                 !prev_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                              fpnl.Height,
                                                                                                                              prev_obj.Name,
                                                                                                                              _multiPanelModel.MPanel_Placement);

                                                gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                                gpath.AddCurve(thisDrawingPoints[1]);
                                                gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                                gpath.AddCurve(thisDrawingPoints[3]);

                                                g.DrawPath(pen, gpath);
                                                g.FillPath(Brushes.PowderBlue, gpath);
                                            }
                                        }
                                    }
                                    #endregion

                                    else if (_multiPanelModel.MPanel_Placement == "Somewhere in Between")
                                    #region this control's Placement is "Somewhere in Between"
                                    {
                                        gpath_forTransom_Top.AddLine(thisDrawingPoints_forTransom_Top[0][0], thisDrawingPoints_forTransom_Top[0][1]);
                                        Point[] new_RightCurve = new Point[3];
                                        new_RightCurve[0] = new Point(thisDrawingPoints_forTransom_Top[1][0].X + 20, // add 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Top[1][0].Y);
                                        new_RightCurve[1] = new Point(thisDrawingPoints_forTransom_Top[1][1].X + 20,
                                                                      thisDrawingPoints_forTransom_Top[1][1].Y);
                                        new_RightCurve[2] = new Point(thisDrawingPoints_forTransom_Top[1][2].X + 20,
                                                                      thisDrawingPoints_forTransom_Top[1][2].Y);
                                        gpath_forTransom_Top.AddCurve(new_RightCurve);
                                        gpath_forTransom_Top.AddLine(thisDrawingPoints_forTransom_Top[2][0], thisDrawingPoints_forTransom_Top[2][1]);
                                        Point[] new_LeftCurve = new Point[3];
                                        new_LeftCurve[0] = new Point(thisDrawingPoints_forTransom_Top[3][0].X - 20, // deduct 20 units to hide the curvature
                                                                      thisDrawingPoints_forTransom_Top[3][0].Y);
                                        new_LeftCurve[1] = new Point(thisDrawingPoints_forTransom_Top[3][1].X - 20,
                                                                      thisDrawingPoints_forTransom_Top[3][1].Y);
                                        new_LeftCurve[2] = new Point(thisDrawingPoints_forTransom_Top[3][2].X - 20,
                                                                      thisDrawingPoints_forTransom_Top[3][2].Y);
                                        gpath_forTransom_Top.AddCurve(new_LeftCurve);

                                        g.DrawPath(pen, gpath_forTransom_Top);
                                        g.FillPath(Brushes.PowderBlue, gpath_forTransom_Top);

                                        int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;
                                        Control prev_obj = parent_mpnl.MPanelLst_Objects[indx_PrevObj];
                                        if ((prev_obj.Name.Contains("Transom") ||
                                             prev_obj.Name.Contains("Mullion")) &&
                                             !prev_obj.Name.Contains("MultiPanel")) //Divider
                                        {
                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          prev_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            gpath.AddLine(thisDrawingPoints[0][0], thisDrawingPoints[0][1]);
                                            gpath.AddCurve(thisDrawingPoints[1]);
                                            gpath.AddLine(thisDrawingPoints[2][0], thisDrawingPoints[2][1]);
                                            gpath.AddCurve(thisDrawingPoints[3]);

                                            g.DrawPath(pen, gpath);
                                            g.FillPath(Brushes.PowderBlue, gpath);
                                            bounds = new Rectangle(new Point(10, 10),
                                                                   new Size(fpnl.ClientRectangle.Width - 11, fpnl.ClientRectangle.Height - 20));
                                        }

                                        //Check if has nxt_obj to Draw the nxt transom Obj
                                        int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;
                                        if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                                        {
                                            Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider
                                            int lineHT = (fpnl.Height - 8) + 18,
                                                lineWd = fpnl.ClientRectangle.Width - 6;

                                            List<Point[]> thisDrawingPoints = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                          fpnl.Height,
                                                                                                                          nxt_obj.Name,
                                                                                                                          _multiPanelModel.MPanel_Placement);

                                            if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                                            {
                                                GraphicsPath gpath2 = new GraphicsPath();

                                                List<Point[]> thisDrawingPoints2 = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                                               fpnl.Height,
                                                                                                                               nxt_obj.Name,
                                                                                                                               _multiPanelModel.MPanel_Placement,
                                                                                                                               true);

                                                gpath2.AddLine(thisDrawingPoints2[0][0], thisDrawingPoints2[0][1]);
                                                gpath2.AddCurve(thisDrawingPoints2[1]);
                                                gpath2.AddLine(thisDrawingPoints2[2][0], thisDrawingPoints2[2][1]);
                                                gpath2.AddCurve(thisDrawingPoints2[3]);

                                                g.DrawPath(pen, gpath2);
                                                g.FillPath(Brushes.PowderBlue, gpath2);

                                                bounds = new Rectangle(new Point(10, 10),
                                                                       new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));
                                            }
                                        }
                                    }
                                    #endregion
                                }
                                #endregion
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }
            }

            g.FillRectangle(new SolidBrush(SystemColors.ActiveCaption), bounds);
            g.DrawRectangle(new Pen(color, 1), bounds);

            Font drawFont = new Font("Segoe UI", 12); //* zoom);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Near;
            g.DrawString(_multiPanelModel.MPanel_Name + " (" + _multiPanelModel.MPanel_Divisions + ")", drawFont, new SolidBrush(Color.Black), bounds);
        }

        public IMultiPanelTransomUC GetMultiPanel()
        {
            _initialLoad = true;
            _multiPanelTransomUC.ThisBinding(CreateBindingDictionary());
            return _multiPanelTransomUC;
        }

        public IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IMultiPanelModel multiPanelModel,
                                                            IFrameModel frameModel,
                                                            IMainPresenter mainPresenter,
                                                            IFrameUCPresenter frameUCP,
                                                            IMultiPanelPropertiesUCPresenter multiPropUCP)
        {
            unityC
                .RegisterType<IMultiPanelTransomUC, MultiPanelTransomUC>()
                .RegisterType<IMultiPanelTransomUCPresenter, MultiPanelTransomUCPresenter>();
            MultiPanelTransomUCPresenter multiTransomUCP = unityC.Resolve<MultiPanelTransomUCPresenter>();
            multiTransomUCP._unityC = unityC;
            multiTransomUCP._multiPanelModel = multiPanelModel;
            multiTransomUCP._frameModel = frameModel;
            multiTransomUCP._mainPresenter = mainPresenter;
            multiTransomUCP._frameUCP = frameUCP;
            multiTransomUCP._multiPropUCP2_given = multiPropUCP;

            return multiTransomUCP;
        }

        public IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IMultiPanelModel multiPanelModel,
                                                            IFrameModel frameModel,
                                                            IMainPresenter mainPresenter,
                                                            IFrameUCPresenter frameUCP,
                                                            IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                            IMultiPanelPropertiesUCPresenter multiPropUCP)
        {
            unityC
                .RegisterType<IMultiPanelTransomUC, MultiPanelTransomUC>()
                .RegisterType<IMultiPanelTransomUCPresenter, MultiPanelTransomUCPresenter>();
            MultiPanelTransomUCPresenter multiTransomUCP = unityC.Resolve<MultiPanelTransomUCPresenter>();
            multiTransomUCP._unityC = unityC;
            multiTransomUCP._multiPanelModel = multiPanelModel;
            multiTransomUCP._frameModel = frameModel;
            multiTransomUCP._mainPresenter = mainPresenter;
            multiTransomUCP._frameUCP = frameUCP;
            multiTransomUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            multiTransomUCP._multiPropUCP2_given = multiPropUCP;

            return multiTransomUCP;
        }

        public IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IMultiPanelModel multiPanelModel,
                                                            IFrameModel frameModel,
                                                            IMainPresenter mainPresenter,
                                                            IFrameUCPresenter frameUCP,
                                                            IMultiPanelMullionUCPresenter multiPanelMullionUCP,
                                                            IMultiPanelPropertiesUCPresenter multiPropUCP)
        {
            unityC
                .RegisterType<IMultiPanelTransomUC, MultiPanelTransomUC>()
                .RegisterType<IMultiPanelTransomUCPresenter, MultiPanelTransomUCPresenter>();
            MultiPanelTransomUCPresenter multiTransomUCP = unityC.Resolve<MultiPanelTransomUCPresenter>();
            multiTransomUCP._unityC = unityC;
            multiTransomUCP._multiPanelModel = multiPanelModel;
            multiTransomUCP._frameModel = frameModel;
            multiTransomUCP._mainPresenter = mainPresenter;
            multiTransomUCP._frameUCP = frameUCP;
            multiTransomUCP._multiMullionUCP_given = multiPanelMullionUCP;
            multiTransomUCP._multiPropUCP2_given = multiPropUCP;

            return multiTransomUCP;
        }

        public void frmDimensionResults(int frmDimension_numWd, int frmDimension_numHt)
        {
            _frmDmRes_Width = frmDimension_numWd;
            _frmDmRes_Height = frmDimension_numHt;
            _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
        }

        public void DeletePanel(UserControl obj)
        {
            _multiPanelTransomUC.DeletePanel(obj);
            if (obj.Name.Contains("PanelUC"))
            {
                _multiPanelModel.MPanelProp_Height -= 148;
            }
        }

        public void Invalidate_MultiPanelMullionUC()
        {
            _multiPanelTransomUC.InvalidateFlp();
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> multiPanelBinding = new Dictionary<string, Binding>();
            multiPanelBinding.Add("MPanel_ID", new Binding("MPanel_ID", _multiPanelModel, "MPanel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Dock", new Binding("Dock", _multiPanelModel, "MPanel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Width", new Binding("Width", _multiPanelModel, "MPanel_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Height", new Binding("Height", _multiPanelModel, "MPanel_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Visibility", new Binding("Visible", _multiPanelModel, "MPanel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return multiPanelBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }
    }
}
