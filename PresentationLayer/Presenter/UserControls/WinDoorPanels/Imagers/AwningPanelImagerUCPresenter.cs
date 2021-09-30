using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers
{
    public class AwningPanelImagerUCPresenter : IAwningPanelImagerUCPresenter
    {
        IAwningPanelImagerUC _awningPanelImagerUC;

        private IPanelModel _panelModel;

        private IFrameImagerUCPresenter _frameImagerUCP;

        private IMultiPanelMullionImagerUCPresenter _multiPanelMullionImagerUCP;
        private IMultiPanelTransomImagerUCPresenter _multiPanelTransomImagerUCP;

        public AwningPanelImagerUCPresenter(IAwningPanelImagerUC awningPanelImagerUC)
        {
            _awningPanelImagerUC = awningPanelImagerUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _awningPanelImagerUC.awningPanelImagerUCPaintEventRaised += _awningPanelImagerUC_awningPanelImagerUCPaintEventRaised;
            _awningPanelImagerUC.awningPanelImagerUCVisibleChangedEventRaised += _awningPanelImagerUC_awningPanelImagerUCVisibleChangedEventRaised;
        }

        private void _awningPanelImagerUC_awningPanelImagerUCVisibleChangedEventRaised(object sender, EventArgs e)
        {
            if (((UserControl)sender).Visible == false)
            {
                if (_frameImagerUCP != null)
                {
                    _frameImagerUCP.DeleteControl((UserControl)_awningPanelImagerUC);
                }
                else if (_multiPanelMullionImagerUCP != null)
                {
                    _multiPanelMullionImagerUCP.DeleteControl((UserControl)_awningPanelImagerUC);
                }
                else if (_multiPanelTransomImagerUCP != null)
                {
                    _multiPanelTransomImagerUCP.DeleteControl((UserControl)_awningPanelImagerUC);
                }
            }
        }

        private void _awningPanelImagerUC_awningPanelImagerUCPaintEventRaised(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            UserControl awning = (UserControl)sender;

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color col = Color.Black;
            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            int font_size = 30,
                outer_line = 10,
                inner_line = 15;

            if (_panelModel.PanelImageRenderer_Zoom == 0.28f)
            {
                font_size = 25;
            }
            else if (_panelModel.PanelImageRenderer_Zoom == 0.19f)
            {
                font_size = 15;
                outer_line = 5;
                inner_line = 8;
            }
            else if (_panelModel.PanelImageRenderer_Zoom == 0.14f)
            {
                font_size = 13;
                outer_line = 3;
                inner_line = 7;
            }
            else if (_panelModel.PanelImageRenderer_Zoom == 0.10f)
            {
                font_size = 8;
                outer_line = 3;
                inner_line = 7;
            }

            g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                           0,
                                                           awning.ClientRectangle.Width - w,
                                                           awning.ClientRectangle.Height - w));

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
        }

        public IAwningPanelImagerUC GetAwningPanelUC()
        {
            _awningPanelImagerUC.ThisBinding(CreateBindingDictionary());
            return _awningPanelImagerUC;
        }


        public IAwningPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IPanelModel panelModel,
                                                            IFrameImagerUCPresenter frameImagerUCP)
        {
            unityC
                .RegisterType<IAwningPanelImagerUC, AwningPanelImagerUC>()
                .RegisterType<IAwningPanelImagerUCPresenter, AwningPanelImagerUCPresenter>();
            AwningPanelImagerUCPresenter awningImagerUCP = unityC.Resolve<AwningPanelImagerUCPresenter>();
            awningImagerUCP._panelModel = panelModel;
            awningImagerUCP._frameImagerUCP = frameImagerUCP;

            return awningImagerUCP;
        }

        public IAwningPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                            IPanelModel panelModel, 
                                                            IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP)
        {
            unityC
                .RegisterType<IAwningPanelImagerUC, AwningPanelImagerUC>()
                .RegisterType<IAwningPanelImagerUCPresenter, AwningPanelImagerUCPresenter>();
            AwningPanelImagerUCPresenter awningImagerUCP = unityC.Resolve<AwningPanelImagerUCPresenter>();
            awningImagerUCP._panelModel = panelModel;
            awningImagerUCP._multiPanelMullionImagerUCP = multiPanelMullionImagerUCP;

            return awningImagerUCP;
        }

        public IAwningPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                            IPanelModel panelModel, 
                                                            IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP)
        {
            unityC
                .RegisterType<IAwningPanelImagerUC, AwningPanelImagerUC>()
                .RegisterType<IAwningPanelImagerUCPresenter, AwningPanelImagerUCPresenter>();
            AwningPanelImagerUCPresenter awningImagerUCP = unityC.Resolve<AwningPanelImagerUCPresenter>();
            awningImagerUCP._panelModel = panelModel;
            awningImagerUCP._multiPanelTransomImagerUCP = multiPanelTransomImagerUCP;

            return awningImagerUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Dock", new Binding("Dock", _panelModel, "Panel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelImageRenderer_Width", new Binding("Width", _panelModel, "PanelImageRenderer_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelImageRenderer_Height", new Binding("Height", _panelModel, "PanelImageRenderer_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelImageRenderer_Margin", new Binding("Margin", _panelModel, "PanelImageRenderer_Margin", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Orient", new Binding("pnl_Orientation", _panelModel, "Panel_Orient", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Placement", new Binding("Panel_Placement", _panelModel, "Panel_Placement", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }
    }
}
