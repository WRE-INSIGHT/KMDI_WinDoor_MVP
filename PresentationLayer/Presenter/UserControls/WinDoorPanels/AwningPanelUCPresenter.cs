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

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class AwningPanelUCPresenter : IAwningPanelUCPresenter, IPresenterCommon
    {
        IAwningPanelUC _awningPanelUC;

        private IPanelModel _panelModel;
        private IFrameModel _frameModel;

        public AwningPanelUCPresenter(IAwningPanelUC awningPanelUC)
        {
            _awningPanelUC = awningPanelUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _awningPanelUC.awningPanelUCPaintEventRaised += new PaintEventHandler(OnAwningPanelUCPaintEventRaised);
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

            g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y + sashH),
                                 new Point(sashPoint.X + (sashW / 2), sashPoint.Y));
            g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW / 2), sashPoint.Y),
                                 new Point(sashPoint.X + sashW, sashH + sashPoint.Y));

        }

        public IAwningPanelUC GetAwningPanelUC()
        {
            _awningPanelUC.ThisBinding(CreateBindingDictionary());
            return _awningPanelUC;
        }


        public IAwningPanelUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IFrameModel frameModel)
        {
            unityC
                .RegisterType<IAwningPanelUC, AwningPanelUC>()
                .RegisterType<IAwningPanelUCPresenter, AwningPanelUCPresenter>();
            AwningPanelUCPresenter awningUCP = unityC.Resolve<AwningPanelUCPresenter>();
            awningUCP._panelModel = panelModel;
            awningUCP._frameModel = frameModel;

            return awningUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_Dock", new Binding("Dock", _panelModel, "Panel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Width", new Binding("Width", _panelModel, "Panel_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Height", new Binding("Height", _panelModel, "Panel_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Orient", new Binding("pnl_Orientation", _panelModel, "Panel_Orient", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }
    }
}
