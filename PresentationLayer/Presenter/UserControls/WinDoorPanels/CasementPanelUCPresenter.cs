using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using ModelLayer.Model.Quotation.Panel;
using Unity;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.UserControls.Dividers;
using ServiceLayer.Services.DividerServices;
using PresentationLayer.Presenter.UserControls.Dividers.Imagers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;

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


        bool _initialLoad;

        private CommonFunctions _commonFunctions = new CommonFunctions();
        Timer _tmr = new Timer();

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
            _casementUC.casementPanelUCSizeChangedEventRaised += new EventHandler(OnCasementPanelUCSizeChangedEventRaised);
            _casementUC.casementPanelUCPaintEventRaised += new PaintEventHandler(OnCasementPanelUCPaintEventRaised);
            _casementUC.casementPanelUCMouseEnterEventRaised += new EventHandler(OnCasementPanelUCMouseEnterEventRaised);
            _casementUC.casementPanelUCMouseLeaveEventRaised += new EventHandler(OnCasementPanelUCMouseLeaveEventRaised);
            _casementUC.deleteToolStripClickedEventRaised += new EventHandler(OnDeleteToolStripClickedEventRaised);
            _tmr.Tick += _tmr_Tick;
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
            #region Delete TransomUC
            if (_multiPanelModel != null &&
                _multiPanelModel.MPanel_DividerEnabled &&
                _panelModel.Panel_Placement != "Last")
            {
                int this_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((UserControl)_casementUC);

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

            #region Delete Casement

            if (_multiPanelModel != null)
            {
                _multiPanelModel.DeleteControl_MPanelLstObjects((UserControl)_casementUC, _frameModel.Frame_Type.ToString());
                _multiPanelModel.Reload_PanelMargin();
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
                                                        _multiTransomImagerUCP);
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

            #endregion
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
                                                           casement.ClientRectangle.Width - w,
                                                           casement.ClientRectangle.Height - w));

            Color col = Color.Black;
            g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line,
                                                           outer_line,
                                                           (casement.ClientRectangle.Width - (outer_line * 2)) - w,
                                                           (casement.ClientRectangle.Height - (outer_line * 2)) - w));

            g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line,
                                                           inner_line,
                                                           (casement.ClientRectangle.Width - (inner_line * 2)) - w,
                                                           (casement.ClientRectangle.Height - (inner_line * 2)) - w));

            Point sashPoint = new Point(casement.ClientRectangle.X, casement.ClientRectangle.Y);

            Pen dgrayPen = new Pen(Color.DimGray);
            dgrayPen.DashStyle = DashStyle.Dash;
            dgrayPen.Width = 3;

            int sashW = casement.Width,
                sashH = casement.Height;

            if (_panelModel.Panel_Orient == true)//Left
            {
                g.DrawLine(dgrayPen, new Point(sashPoint.X + sashW, sashPoint.Y),
                                         new Point(sashPoint.X, (sashPoint.Y + ( sashH / 2))));
                g.DrawLine(dgrayPen, new Point(sashPoint.X, (sashPoint.Y + ( sashH/ 2))),
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

        int prev_Width = 0,
            prev_Height = 0;
        private void OnCasementPanelUCSizeChangedEventRaised(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!_initialLoad)
            //    {
            //        int thisWd = ((UserControl)sender).Width,
            //            thisHt = ((UserControl)sender).Height,
            //            pnlModelWd = _panelModel.Panel_Width,
            //            pnlModelHt = _panelModel.Panel_Height;

            //        if (thisWd != pnlModelWd || prev_Width != pnlModelWd)
            //        {
            //            _panelModel.Panel_Width = thisWd;
            //            _WidthChange = true;
            //        }
            //        if (thisHt != pnlModelHt || prev_Height != pnlModelHt)
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

            return panelBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }

    }
}
