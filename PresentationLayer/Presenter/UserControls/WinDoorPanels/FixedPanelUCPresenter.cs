using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.Frame;
using Unity;
using System.Windows.Forms;
using CommonComponents;
using System.Drawing;
using System.Drawing.Drawing2D;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.UserControls.Dividers;
using ServiceLayer.Services.DividerServices;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Presenter.UserControls.Dividers.Imagers;
using PresentationLayer.Views.UserControls;

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
            _fixedPanelUC.fixedPanelUCSizeChangedEventRaised += new EventHandler(OnFixedPanelUCSizeChangedEventRaised);
            _fixedPanelUC.deleteToolStripClickedEventRaised += _fixedPanelUC_deleteToolStripClickedEventRaised;
            _fixedPanelUC.fixedPanelUCPaintEventRaised += _fixedPanelUC_fixedPanelUCPaintEventRaised;
            _fixedPanelUC.fixedPanelMouseLeaveEventRaised += _fixedPanelUC_fixedPanelMouseLeaveEventRaised;
            _fixedPanelUC.fixedPanelMouseEnterEventRaised += _fixedPanelUC_fixedPanelMouseEnterEventRaised;
            _tmr.Tick += _tmr_Tick;
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

        Color color = Color.Black;

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

            Font drawFont = new Font("Times New Roman", font_size);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            g.DrawString("F", drawFont, new SolidBrush(Color.Black), fixedpnl.ClientRectangle, drawFormat);

            RectangleF rect = new RectangleF(0, 
                                            (fixedpnl.ClientRectangle.Height / 2) + 15,
                                            fixedpnl.ClientRectangle.Width,
                                            10);

            g.DrawString("P" + _panelModel.PanelGlass_ID + "-" + _panelModel.Panel_GlassThickness.ToString(),
                         new Font("Segoe UI", 8.0f, FontStyle.Bold),
                         new SolidBrush(Color.Black),
                         rect,
                         drawFormat);

            g.DrawRectangle(new Pen(color, w), new Rectangle(0,
                                                             0,
                                                             fixedpnl.ClientRectangle.Width - w,
                                                             fixedpnl.ClientRectangle.Height - w));

            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(outer_line,
                                                                   outer_line,
                                                                   (fixedpnl.ClientRectangle.Width - (outer_line * 2)) - w,
                                                                   (fixedpnl.ClientRectangle.Height - (outer_line * 2)) - w));

            if (_panelModel.Panel_Orient == true)
            {
                g.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(inner_line,
                                                                       inner_line,
                                                                       (fixedpnl.ClientRectangle.Width - (inner_line * 2)) - w,
                                                                       (fixedpnl.ClientRectangle.Height - (inner_line * 2)) - w));

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

        private void _fixedPanelUC_deleteToolStripClickedEventRaised(object sender, EventArgs e)
        {
            #region Delete TransomUC
            if (_multiPanelModel != null &&
                _multiPanelModel.MPanel_DividerEnabled &&
                _panelModel.Panel_Placement != "Last")
            {
                int this_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((UserControl)_fixedPanelUC);

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

                _multiPanelModel.MPanelProp_Height -= (173 + 1); //+1 on margin (divProperties)
                _frameModel.FrameProp_Height -= (173 + 1); //+1 on margin (divProperties)
            }

            #endregion

            #region Delete Fixed

            if (_multiPanelModel != null)
            {
                _multiPanelModel.DeleteControl_MPanelLstObjects((UserControl)_fixedPanelUC, _frameModel.Frame_Type.ToString());
                _multiPanelModel.Reload_PanelMargin();
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

            //_panelModel.Panel_Visibility = false;

            _frameModel.FrameProp_Height -= (228 + 1); //+1 on margin (PanelProperties)

            _mainPresenter.DeductPanelGlassID();
            _mainPresenter.SetPanelGlassID();
            _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
            #endregion
        }

        private void OnFixedPanelUCSizeChangedEventRaised(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!_initialLoad)
            //    {
            //int thisWd = 0,
            //    thisHt = 0,
            //    pnlModelWd = _panelModel.Panel_Width,
            //    pnlModelHt = _panelModel.Panel_Height;

            //        if (_multiPanelModel != null) 
            //        {
            //            if (_multiPanelModel.MPanel_Type == "Mullion")
            //            {
            //                thisWd = (int)(((UserControl)sender).Width / _panelModel.Panel_Zoom);
            //                thisHt = (int)(pnlModelHt * _panelModel.Panel_Zoom);
            //            }
            //            else if (_multiPanelModel.MPanel_Type == "Transom")
            //            {
            //                thisWd = (int)(pnlModelWd * _panelModel.Panel_Zoom);
            //                thisHt = (int)(((UserControl)sender).Height / _panelModel.Panel_Zoom);
            //            }
            //        }
            //        else
            //        {
            //            thisWd = (int)((UserControl)sender).Width;
            //            thisHt = (int)((UserControl)sender).Height;
            //        }

            //        if (prev_Width != pnlModelWd || thisWd != pnlModelWd)
            //        {
            //            _panelModel.Panel_Width = thisWd;
            //            _WidthChange = true;
            //        }
            //        if (prev_Height != pnlModelHt || thisHt != pnlModelHt)
            //        {
            //            _panelModel.Panel_Height = thisHt;
            //            _HeightChange = true;
            //        }
            //    }

            //    prev_Width = _panelModel.Panel_Width;
            //    prev_Height = _panelModel.Panel_Height;

            //    _tmr.Start();
            //    ((UserControl)sender).Invalidate();
            //    _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
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
            
            return panelBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }

        //for Testing
        //public IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IFrameModel frameModel)
        //{ 
        //    unityC
        //        .RegisterType<IFixedPanelUC, FixedPanelUC>()
        //        .RegisterType<IFixedPanelUCPresenter, FixedPanelUCPresenter>();
        //    FixedPanelUCPresenter fixedPanelUCP = unityC.Resolve<FixedPanelUCPresenter>();
        //    fixedPanelUCP._panelModel = panelModel;
        //    fixedPanelUCP._frameModel = frameModel;

        //    return fixedPanelUCP;
        //}
    }
}
