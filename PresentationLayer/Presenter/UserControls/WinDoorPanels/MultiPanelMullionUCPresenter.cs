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
        private IMultiPanelTransomUCPresenter _multiPanelTransomUCP;

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
        private ITransomUCPresenter _transomUCP;
        private IFrameUCPresenter _frameUCP;
        private IMultiPanelMullionUCPresenter _multiPanelMullionUCP;
        private IMultiPanelPropertiesUCPresenter _multiPropUCP_orig;  //Original Instance
        private IMultiPanelPropertiesUCPresenter _multiPropUCP2_given; //Given Instance

        private IDividerServices _divServices;
        private IPanelServices _panelServices;
        private IMultiPanelServices _multipanelServices;
        
        bool _initialLoad;

        private MultiPanelCommon _mpnlCommons = new MultiPanelCommon();

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
                                            ITransomUCPresenter transomUCP,
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
            _transomUCP = transomUCP;
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

        private int divSize = 0,
                    divID = 0;
        private void _multiPanelMullionUC_flpMultiDragDropEventRaised(object sender, DragEventArgs e)
        {

            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender; //Control na babagsakan
            string data = e.Data.GetData(e.Data.GetFormats()[0]) as string;

            int panelID = _mainPresenter.GetPanelCount() + 1,
                multiID = _mainPresenter.GetMultiPanelCount() + 1;

                divID = _mainPresenter.GetDividerCount() + 1;

            int multiPanel_boundsWD = fpnl.Width - 20,
                multiPanel_boundsHT = fpnl.Height - 20,
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
                int suggest_Wd = ((fpnl.Width - (divSize * _multiPanelModel.MPanel_Divisions)) / totalPanelCount),
                    suggest_HT = fpnl.Height;

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
                        IMultiPanelMullionUCPresenter multiUCP = GetNewInstance(_unityC,
                                                                                mPanelModel,
                                                                                _frameModel,
                                                                                _mainPresenter,
                                                                                _frameUCP,
                                                                                this,
                                                                                _multiPanelTransomUCP,
                                                                                multiPropUCP);
                        IMultiPanelMullionUC multiUC = multiUCP.GetMultiPanel();
                        fpnl.Controls.Add((UserControl)multiUC);
                        multiUCP.SetInitialLoadFalse();
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)multiUC, _frameModel.Frame_Type.ToString());

                        if (mPanelModel.MPanel_Placement == "Last")
                        {
                            _multiPanelModel.Fit_MyControls();
                        }
                        else if (mPanelModel.MPanel_Placement != "Last")
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
                                                                                        this,
                                                                                        _frameModel);
                            IMullionUC mullionUC = mullionUCP.GetMullion();
                            fpnl.Controls.Add((UserControl)mullionUC);
                            mullionUCP.SetInitialLoadFalse();
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                        }
                    }
                    else if (data.Contains("Transom"))
                    {
                        IMultiPanelTransomUCPresenter multiTransom = _multiPanelTransomUCP.GetNewInstance(_unityC,
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
                                                                                        this,
                                                                                        _frameModel);
                            IMullionUC mullionUC = mullionUCP.GetMullion();
                            fpnl.Controls.Add((UserControl)mullionUC);
                            mullionUCP.SetInitialLoadFalse();
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                        }
                    }
                }
            }
            else
            {
                int suggest_Wd = ((multiPanel_boundsWD - (divSize * _multiPanelModel.MPanel_Divisions)) / totalPanelCount),
                    suggest_HT = multiPanel_boundsHT;

                if (_multiPanelModel.MPanel_ParentModel != null)
                {
                    suggest_HT = multiPanel_boundsHT + 2;
                }

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
                                                                                    this,
                                                                                    _frameModel);
                        IMullionUC mullionUC = mullionUCP.GetMullion();
                        fpnl.Controls.Add((UserControl)mullionUC);
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                        mullionUCP.SetInitialLoadFalse();
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

        private void _multiPanelMullionUC_deleteClickedEventRaised(object sender, EventArgs e)
        {
            #region Delete TransomUC
            if (_multiPanelModel.MPanel_ParentModel != null &&
                _multiPanelModel.MPanel_Placement != "Last")
            {
                int this_indx = _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects.IndexOf((UserControl)_multiPanelMullionUC);

                Control divUC = _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects[this_indx + 1];
                _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects.Remove((UserControl)divUC);
                DeletePanel((UserControl)divUC);

                IDividerModel div = _multiPanelModel.MPanel_ParentModel.MPanelLst_Divider.Find(divd => divd.Div_Name == divUC.Name);
                div.Div_Visible = false;
            }
            #endregion

            #region Delete MultiPanel Mullion
            FlowLayoutPanel innerFlp = (FlowLayoutPanel)((UserControl)_multiPanelMullionUC).Controls[0];
            Control parent_ctrl = ((UserControl)_multiPanelMullionUC).Parent;

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
                _multiPanelModel.MPanel_ParentModel.DeleteControl_MPanelLstObjects((UserControl)_multiPanelMullionUC, 
                                                                                   _frameModel.Frame_Type.ToString(),
                                                                                   _multiPanelModel.MPanel_Placement);
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

            _multiPanelModel.MPanel_Parent.Controls.Remove((UserControl)_multiPanelMullionUC);
            
            if (_multiPanelModel.MPanel_Parent != null)
            {
                _multiPanelModel.MPanelProp_Height -= (129 + 3); // +3 for MultiPanelProperties' Margin;;
                _frameModel.FrameProp_Height -= (129 + 3);
            }

            if (_multiPanelModel.MPanel_ParentModel != null)
            {
                _multiPanelModel.MPanel_ParentModel.Object_Indexer();
                _multiPanelModel.MPanel_ParentModel.Reload_MultiPanelMargin();
                Last_ChildObj_Checker();
            }

            if (parent_ctrl.Name.Contains("flp_Multi"))
            {
                foreach (Control ctrl in parent_ctrl.Controls)
                {
                    ctrl.Invalidate();
                }
            }

            #endregion
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
            IMultiPanelModel parent_mpnl = _multiPanelModel.MPanel_ParentModel;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int pInnerX = 10,
                pInnerY = 10,
                pInnerWd = fpnl.ClientRectangle.Width - 20,
                pInnerHt = fpnl.ClientRectangle.Height - 20;

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

            if (_multiPanelModel.MPanel_Parent.GetType() == typeof(FrameUC))
            {
                for (int i = 0; i < corner_points.Length - 1; i += 2)
                {
                    g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                }

                bounds = new Rectangle(new Point(10, 10),
                                       new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));
            }
            else if (_multiPanelModel.MPanel_Parent.GetType() == typeof(FlowLayoutPanel)) //If MultiPanel
            {
                string parent_name = _multiPanelModel.MPanel_Parent.Name,
                       lvl2_parent_Type = "",
                       thisObj_placement = _multiPanelModel.MPanel_Placement,
                       parentObj_placement = _multiPanelModel.MPanel_ParentModel.MPanel_Placement;
                DockStyle parent_doxtyle = _multiPanelModel.MPanel_ParentModel.MPanel_Dock;
                int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1,
                    parent_mpnl_childObj_count = parent_mpnl.GetCount_MPanelLst_Object(),
                    indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;

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
                    wd_deduction = 20;
                    bounds_PointX = 10;
                    if (thisObj_placement == "First")
                    {
                        bounds_PointY = 10;
                        ht_deduction = (10 + (pixels_count + 1));
                    }
                    else if (thisObj_placement == "Last")
                    {
                        bounds_PointY = pixels_count + 2;
                        ht_deduction = (((pixels_count + 2) * 2)) - 1;
                    }
                    else if (thisObj_placement == "Somewhere in Between")
                    {
                        bounds_PointY = pixels_count + 2;
                        ht_deduction = (pixels_count + 2) * 2;
                        if (parent_doxtyle == DockStyle.None)
                        {
                            bounds_PointY = (pixels_count + 2 == 10) ? pixels_count + 2 : 10;
                            ht_deduction = 10 + (pixels_count + 1);
                        }
                    }
                }
                #endregion

                else if (parent_name.Contains("MultiMullion"))
                #region Parent is MultiPanel Mullion
                {
                    bounds_PointY = 10;
                    ht_deduction = 20;
                    if (thisObj_placement == "First")
                    {
                        bounds_PointX = 10;
                        wd_deduction = (10 + (pixels_count + 1));
                    }
                    else if (thisObj_placement == "Last")
                    {
                        bounds_PointX = pixels_count + 2;
                        wd_deduction = ((pixels_count + 2) * 2) - 1;
                    }
                    else if (thisObj_placement == "Somewhere in Between")
                    {
                        bounds_PointX = pixels_count + 2;
                        wd_deduction = (pixels_count + 2) * 2;
                    }
                }
                #endregion

                bounds = new Rectangle(new Point(bounds_PointX, bounds_PointY),
                                       new Size(fpnl.Width - wd_deduction,
                                                fpnl.Height - ht_deduction));
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


                #region MAIN GRAPHICS ALGORITHM
                if (parent_name.Contains("MultiMullion") &&
                    parent_doxtyle == DockStyle.Fill &&
                    thisObj_placement == "First")
                #region First Multi-Panel in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX, pInnerY + pInnerHt));

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Last")
                #region Last Multi-Panel in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between Multi-Panel in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "First")
                #region First Multi-Panel in a MAIN PLATFORM (MultiTransom)
                {

                    for (int i = 0; i < corner_points.Length - 5; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Last")
                #region Last Multi-Panel in a MAIN PLATFORM (MultiTransom)
                {
                    for (int i = 4; i < corner_points.Length - 1; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between Multi-Panel in a MAIN PLATFORM (MultiTransom)
                {
                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);
                }
                #endregion

                #endregion
            }

            g.FillRectangle(new SolidBrush(Color.MistyRose), bounds);
            g.DrawRectangle(new Pen(color, 1), bounds);

            Font drawFont = new Font("Segoe UI", 12); //* zoom);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Near;
            g.DrawString(_multiPanelModel.MPanel_Name + " (" + _multiPanelModel.MPanel_Divisions + ")", drawFont, new SolidBrush(Color.Black), bounds);
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

        public IMultiPanelMullionUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IMultiPanelModel multiPanelModel,
                                                            IFrameModel frameModel,
                                                            IMainPresenter mainPresenter,
                                                            IFrameUCPresenter frameUCP,
                                                            IMultiPanelMullionUCPresenter multiPanelMullionUCP,
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
            multiMullionUCP._multiPanelMullionUCP = multiPanelMullionUCP;
            multiMullionUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            multiMullionUCP._multiPropUCP2_given = multiPropUCP;

            return multiMullionUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> multiPanelBinding = new Dictionary<string, Binding>();
            multiPanelBinding.Add("MPanel_ID", new Binding("MPanel_ID", _multiPanelModel, "MPanel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Name", new Binding("Name", _multiPanelModel, "MPanel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
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


        private void Last_ChildObj_Checker() //last child of PARENT of this control
        {
            FlowLayoutPanel parentfpnl = (FlowLayoutPanel)_multiPanelModel.MPanel_Parent;

            if (_frameModel.Frame_Type.ToString().Contains("Window"))
            {
                divSize = 26;
            }
            else if (_frameModel.Frame_Type.ToString().Contains("Door"))
            {
                divSize = 33;
            }

            divID = _mainPresenter.GetDividerCount() + 1;

            Control last_ctrl = null;
            if (_multiPanelModel.MPanel_ParentModel.MPanelLst_Objects.Count() > 1)
            {
                last_ctrl = _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects.Last();
            }

            if (last_ctrl != null && !last_ctrl.Name.Contains("MullionUC"))
            {
                int divHT = 0, divWd = 0;
                DividerModel.DividerType divType = DividerModel.DividerType.Mullion;

                if (_multiPanelModel.MPanel_ParentModel.MPanel_Type == "Transom")
                {
                    divType = DividerModel.DividerType.Transom;
                    divHT = divSize;
                    divWd = parentfpnl.Width;
                }
                else if (_multiPanelModel.MPanel_ParentModel.MPanel_Type == "Mullion")
                {
                    divType = DividerModel.DividerType.Mullion;
                    divHT = parentfpnl.Height;
                    divWd = divSize;
                }

                IDividerModel divModel = _divServices.AddDividerModel(divWd,
                                                                      divHT,
                                                                      parentfpnl,
                                                                      (UserControl)_frameUCP.GetFrameUC(),
                                                                      divType,
                                                                      true,
                                                                      divID,
                                                                      _frameModel.Frame_Type.ToString());

                _frameModel.Lst_Divider.Add(divModel);
                _multiPanelModel.MPanel_ParentModel.MPanelLst_Divider.Add(divModel);

                if (_multiPanelModel.MPanel_ParentModel.MPanel_Type == "Transom")
                {
                    ITransomUCPresenter transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                                divModel,
                                                                                _multiPanelModel.MPanel_ParentModel,
                                                                                this,
                                                                                _frameModel);
                    ITransomUC transomUC = transomUCP.GetTransom();
                    parentfpnl.Controls.Add((UserControl)transomUC);
                    _multiPanelModel.MPanel_ParentModel.AddControl_MPanelLstObjects((UserControl)transomUC, _frameModel.Frame_Type.ToString());
                    transomUCP.SetInitialLoadFalse();
                }
                else if (_multiPanelModel.MPanel_ParentModel.MPanel_Type == "Mullion")
                {
                    IMullionUCPresenter mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                                divModel,
                                                                                _multiPanelModel.MPanel_ParentModel,
                                                                                this,
                                                                                _frameModel);
                    IMullionUC mullionUC = mullionUCP.GetMullion();
                    parentfpnl.Controls.Add((UserControl)mullionUC);
                    _multiPanelModel.MPanel_ParentModel.AddControl_MPanelLstObjects((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                    mullionUCP.SetInitialLoadFalse();
                }
            }
        }
    }
}