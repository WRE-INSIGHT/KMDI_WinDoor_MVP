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
        private IMultiPanelMullionImagerUCPresenter _multiPanelMullionImagerUCP;
        private IMultiPanelTransomImagerUCPresenter _multiPanelTransomImagerUCP;

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
                else if (_multiPanelMullionImagerUCP != null)
                {
                    _multiPanelMullionImagerUCP.DeleteControl((UserControl)_casementImagerUC);
                }
                else if (_multiPanelTransomImagerUCP != null)
                {
                    _multiPanelTransomImagerUCP.DeleteControl((UserControl)_casementImagerUC);
                }
            }
        }

        private void _casementImagerUC_casementPanelImagerUCPaintEventRaised(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            UserControl casement = (UserControl)sender;

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
                                                           casement.ClientRectangle.Width - w,
                                                           casement.ClientRectangle.Height - w));

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

        public ICasementPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                              IPanelModel panelModel,
                                                              IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP)
        {
            unityC
                .RegisterType<ICasementPanelImagerUC, CasementPanelImagerUC>()
                .RegisterType<ICasementPanelImagerUCPresenter, CasementPanelImagerUCPresenter>();
            CasementPanelImagerUCPresenter casementImagerUCP = unityC.Resolve<CasementPanelImagerUCPresenter>();
            casementImagerUCP._panelModel = panelModel;
            casementImagerUCP._multiPanelMullionImagerUCP = multiPanelMullionImagerUCP;

            return casementImagerUCP;
        }

        public ICasementPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                              IPanelModel panelModel, 
                                                              IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP)
        {
            unityC
                .RegisterType<ICasementPanelImagerUC, CasementPanelImagerUC>()
                .RegisterType<ICasementPanelImagerUCPresenter, CasementPanelImagerUCPresenter>();
            CasementPanelImagerUCPresenter casementImagerUCP = unityC.Resolve<CasementPanelImagerUCPresenter>();
            casementImagerUCP._panelModel = panelModel;
            casementImagerUCP._multiPanelTransomImagerUCP = multiPanelTransomImagerUCP;

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
            panelBinding.Add("PanelImageRenderer_Margin", new Binding("Margin", _panelModel, "PanelImageRenderer_Margin", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Orient", new Binding("pnl_Orientation", _panelModel, "Panel_Orient", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Placement", new Binding("Panel_Placement", _panelModel, "Panel_Placement", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }
    }
}
