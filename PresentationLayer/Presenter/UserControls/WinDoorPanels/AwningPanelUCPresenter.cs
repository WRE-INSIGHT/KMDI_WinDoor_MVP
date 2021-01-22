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

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class AwningPanelUCPresenter : IAwningPanelUCPresenter, IPresenterCommon
    {
        IAwningPanelUC _awningPanelUC;

        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;
        private IFrameModel _frameModel;

        private IMultiPanelModel _multiPanelModel;
        private IMultiPanelMullionUCPresenter _multiPanelUCP;

        bool _initialLoad;

        public AwningPanelUCPresenter(IAwningPanelUC awningPanelUC)
        {
            _awningPanelUC = awningPanelUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _awningPanelUC.awningPanelUCPaintEventRaised += OnAwningPanelUCPaintEventRaised;
            _awningPanelUC.awningPanelUCMouseEnterEventRaised += _awningPanelUC_awningPanelUCMouseEnterEventRaised;
            _awningPanelUC.awningPanelUCMouseLeaveEventRaised += _awningPanelUC_awningPanelUCMouseLeaveEventRaised;
            _awningPanelUC.awningPanelUCSizeChangedEventRaised += _awningPanelUC_awningPanelUCSizeChangedEventRaised;
            _awningPanelUC.deleteToolStripClickedEventRaised += _awningPanelUC_deleteToolStripClickedEventRaised;
        }

        private void _awningPanelUC_deleteToolStripClickedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_Visibility = false;
            _frameModel.FrameProp_Height -= 148;
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
        }

        private void _awningPanelUC_awningPanelUCSizeChangedEventRaised(object sender, EventArgs e)
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

        private void _awningPanelUC_awningPanelUCMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            _awningPanelUC.InvalidateThis();
        }

        private void _awningPanelUC_awningPanelUCMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            _awningPanelUC.InvalidateThis();
        }

        Color color = Color.Black;
        private void OnAwningPanelUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl awning = (UserControl)sender;

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(color, w), new Rectangle(0,
                                                           0,
                                                           awning.ClientRectangle.Width - w,
                                                           awning.ClientRectangle.Height - w));

            Color col = Color.Black;
            g.DrawRectangle(new Pen(col, w), new Rectangle(10,
                                                           10,
                                                           (awning.ClientRectangle.Width - 20) - w,
                                                           (awning.ClientRectangle.Height - 20) - w));

            g.DrawRectangle(new Pen(col, 3), new Rectangle(15,
                                                           15,
                                                           (awning.ClientRectangle.Width - 30) - w,
                                                           (awning.ClientRectangle.Height - 30) - w));


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
        }

        public IAwningPanelUC GetAwningPanelUC()
        {
            _initialLoad = true;
            _awningPanelUC.ThisBinding(CreateBindingDictionary());
            return _awningPanelUC;
        }


        public IAwningPanelUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                      IPanelModel panelModel, 
                                                      IFrameModel frameModel,
                                                      IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IAwningPanelUC, AwningPanelUC>()
                .RegisterType<IAwningPanelUCPresenter, AwningPanelUCPresenter>();
            AwningPanelUCPresenter awningUCP = unityC.Resolve<AwningPanelUCPresenter>();
            awningUCP._panelModel = panelModel;
            awningUCP._frameModel = frameModel;
            awningUCP._mainPresenter = mainPresenter;

            return awningUCP;
        }

        public IAwningPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelMullionUCPresenter multiPanelUCP)
        {
            unityC
                .RegisterType<IAwningPanelUC, AwningPanelUC>()
                .RegisterType<IAwningPanelUCPresenter, AwningPanelUCPresenter>();
            AwningPanelUCPresenter awningUCP = unityC.Resolve<AwningPanelUCPresenter>();
            awningUCP._panelModel = panelModel;
            awningUCP._frameModel = frameModel;
            awningUCP._mainPresenter = mainPresenter;
            awningUCP._multiPanelModel = multiPanelModel;
            awningUCP._multiPanelUCP = multiPanelUCP;

            return awningUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
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
