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

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class CasementPanelUCPresenter : ICasementPanelUCPresenter, IPresenterCommon
    {
        ICasementPanelUC _casementUC;

        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;
        private IFrameModel _frameModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelMullionUCPresenter _multiPanelMullionUCP;
        private IMultiPanelTransomUCPresenter _multiPanelTransomUCP;
        private IFrameUCPresenter _frameUCP;

        bool _initialLoad;

        public CasementPanelUCPresenter(ICasementPanelUC casementUC)
        {
            _casementUC = casementUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _casementUC.casementPanelUCSizeChangedEventRaised += new EventHandler(OnCasementPanelUCSizeChangedEventRaised);
            _casementUC.casementPanelUCPaintEventRaised += new PaintEventHandler(OnCasementPanelUCPaintEventRaised);
            _casementUC.casementPanelUCMouseEnterEventRaised += new EventHandler(OnCasementPanelUCMouseEnterEventRaised);
            _casementUC.casementPanelUCMouseLeaveEventRaised += new EventHandler(OnCasementPanelUCMouseLeaveEventRaised);
            _casementUC.deleteToolStripClickedEventRaised += new EventHandler(OnDeleteToolStripClickedEventRaised);
        }

        private void OnDeleteToolStripClickedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_Visibility = false;
            _frameModel.FrameProp_Height -= 148;

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

            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
        }

        private void OnCasementPanelUCMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            _casementUC.InvalidateThis();
        }

        private void OnCasementPanelUCMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            _casementUC.InvalidateThis();
        }

        Color color = Color.Black;

        private void OnCasementPanelUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl casement = (UserControl)sender;

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(color, w), new Rectangle(0,
                                                           0,
                                                           casement.ClientRectangle.Width - w,
                                                           casement.ClientRectangle.Height - w));

            Color col = Color.Black;
            g.DrawRectangle(new Pen(col, w), new Rectangle(10,
                                                           10,
                                                           (casement.ClientRectangle.Width - 20) - w,
                                                           (casement.ClientRectangle.Height - 20) - w));

            g.DrawRectangle(new Pen(col, 3), new Rectangle(15,
                                                           15,
                                                           (casement.ClientRectangle.Width - 30) - w,
                                                           (casement.ClientRectangle.Height - 30) - w));

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
        }

        private void OnCasementPanelUCSizeChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (!_initialLoad)
                {
                    int thisWd = ((UserControl)sender).Width,
                        thisHt = ((UserControl)sender).Height,
                        pnlModelWd = _panelModel.Panel_Width,
                        pnlModelHt = _panelModel.Panel_Height;

                    if (thisWd != pnlModelWd)
                    {
                        _panelModel.Panel_Width = thisWd;
                    }
                    if (thisHt != pnlModelHt)
                    {
                        _panelModel.Panel_Height = thisHt;
                    }
                }
                ((UserControl)sender).Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            return casementUCP;
        }

        public ICasementPanelUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                        IPanelModel panelModel, 
                                                        IFrameModel frameModel, 
                                                        IMainPresenter mainPresenter, 
                                                        IMultiPanelModel multiPanelModel, 
                                                        IMultiPanelMullionUCPresenter multiPanelUCP)
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

            return casementUCP;
        }

        public ICasementPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelTransomUCPresenter multiTransomUCP)
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

            return casementUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Name", new Binding("Name", _panelModel, "Panel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Dock", new Binding("Dock", _panelModel, "Panel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Width", new Binding("Width", _panelModel, "Panel_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Height", new Binding("Height", _panelModel, "Panel_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Orient", new Binding("pnl_Orientation", _panelModel, "Panel_Orient", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Margin", new Binding("Margin", _panelModel, "Panel_Margin", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }

    }
}
