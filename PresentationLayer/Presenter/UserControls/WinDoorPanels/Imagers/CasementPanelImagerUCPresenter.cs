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
    public class CasementPanelImagerUCPresenter : ICasementPanelImagerUCPresenter
    {
        ICasementPanelImagerUC _casementImagerUC;

        private IPanelModel _panelModel;

        private IFrameImagerUCPresenter _frameImagerUCP;

        public CasementPanelImagerUCPresenter(ICasementPanelImagerUC casementImagerUC)
        {
            _casementImagerUC = casementImagerUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _casementImagerUC.casementPanelImagerUCPaintEventRaised += _casementImagerUC_casementPanelImagerUCPaintEventRaised;
            _casementImagerUC.casementPanelImagerUCVisibleChangedEventRaised += _casementImagerUC_casementPanelImagerUCVisibleChangedEventRaised;
        }

        private void _casementImagerUC_casementPanelImagerUCVisibleChangedEventRaised(object sender, EventArgs e)
        {
            if (((UserControl)sender).Visible == false)
            {
                if (_frameImagerUCP != null)
                {
                    _frameImagerUCP.DeleteControl((UserControl)_casementImagerUC);
                }
            }
        }

        private void _casementImagerUC_casementPanelImagerUCPaintEventRaised(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            UserControl casement = (UserControl)sender;

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
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
                                         new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))));
                g.DrawLine(dgrayPen, new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))),
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

        public ICasementPanelImagerUC GetCasementPanelImagerUC()
        {
            _casementImagerUC.ThisBinding(CreateBindingDictionary());
            return _casementImagerUC;
        }

        public ICasementPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                              IPanelModel panelModel,
                                                              IFrameImagerUCPresenter frameImagerUCP)
        {
            unityC
                .RegisterType<ICasementPanelImagerUC, CasementPanelImagerUC>()
                .RegisterType<ICasementPanelImagerUCPresenter, CasementPanelImagerUCPresenter>();
            CasementPanelImagerUCPresenter casementImagerUCP = unityC.Resolve<CasementPanelImagerUCPresenter>();
            casementImagerUCP._panelModel = panelModel;
            casementImagerUCP._frameImagerUCP = frameImagerUCP;

            return casementImagerUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Dock", new Binding("Dock", _panelModel, "Panel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelImageRenderer_Width", new Binding("Width", _panelModel, "PanelImageRenderer_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelImageRenderer_Height", new Binding("Height", _panelModel, "PanelImageRenderer_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            //panelBinding.Add("Panel_Orient", new Binding("pnl_Orientation", _panelModel, "Panel_Orient", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }
    }
}
