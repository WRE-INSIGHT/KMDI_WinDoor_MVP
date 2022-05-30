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
    public class SlidingPanelImagerUCPresenter : ISlidingPanelImagerUCPresenter
    {
        ISlidingPanelImagerUC _slidingPanelImagerUC;

        private IPanelModel _panelModel;

        private IFrameImagerUCPresenter _frameImagerUCP;

        private IMultiPanelMullionImagerUCPresenter _multiPanelMullionImagerUCP;
        private IMultiPanelTransomImagerUCPresenter _multiPanelTransomImagerUCP;

        public SlidingPanelImagerUCPresenter(ISlidingPanelImagerUC slidingPanelImagerUC)
        {
            _slidingPanelImagerUC = slidingPanelImagerUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _slidingPanelImagerUC.slidingPanelImagerUCPaintEventRaised += _slidingPanelImagerUC_slidingPanelImagerUCPaintEventRaised;
            _slidingPanelImagerUC.slidingPanelImagerUCVisibleChangedEventRaised += _slidingPanelImagerUC_slidingPanelImagerUCVisibleChangedEventRaised;
        }

        private void _slidingPanelImagerUC_slidingPanelImagerUCVisibleChangedEventRaised(object sender, EventArgs e)
        {
            if (((UserControl)sender).Visible == false)
            {
                if (_frameImagerUCP != null)
                {
                    _frameImagerUCP.DeleteControl((UserControl)_slidingPanelImagerUC);
                }
                else if (_multiPanelMullionImagerUCP != null)
                {
                    _multiPanelMullionImagerUCP.DeleteControl((UserControl)_slidingPanelImagerUC);
                }
                else if (_multiPanelTransomImagerUCP != null)
                {
                    _multiPanelTransomImagerUCP.DeleteControl((UserControl)_slidingPanelImagerUC);
                }
            }
        }

        private void _slidingPanelImagerUC_slidingPanelImagerUCPaintEventRaised(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            UserControl sliding = (UserControl)sender;

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color col = Color.Black;
            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            int //font_size = 30,
                outer_line = 10,
                inner_line = 15;

            if (_panelModel.PanelImageRenderer_Zoom == 0.28f)
            {
                //font_size = 25;
            }
            else if (_panelModel.PanelImageRenderer_Zoom == 0.19f)
            {
                //font_size = 15;
                outer_line = 5;
                inner_line = 8;
            }
            else if (_panelModel.PanelImageRenderer_Zoom == 0.14f)
            {
                //font_size = 13;
                outer_line = 3;
                inner_line = 7;
            }
            else if (_panelModel.PanelImageRenderer_Zoom == 0.10f)
            {
                //font_size = 8;
                outer_line = 3;
                inner_line = 7;
            }

            g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                           0,
                                                           sliding.ClientRectangle.Width - w,
                                                           sliding.ClientRectangle.Height - w));

            g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line,
                                                           outer_line,
                                                           (sliding.ClientRectangle.Width - (outer_line * 2)) - w,
                                                           (sliding.ClientRectangle.Height - (outer_line * 2)) - w));

            g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line,
                                                           inner_line,
                                                           (sliding.ClientRectangle.Width - (inner_line * 2)) - w,
                                                           (sliding.ClientRectangle.Height - (inner_line * 2)) - w));

            Point sashPoint = new Point(sliding.ClientRectangle.X + 25, sliding.ClientRectangle.Y);

            Pen dgrayPen = new Pen(Color.DimGray);
            dgrayPen.DashStyle = DashStyle.Dash;
            dgrayPen.Width = 3;

            int sashW = sliding.Width - 25,
                sashH = sliding.Height;

            float arwStart_x1 = sashPoint.X + (sashW / 20),
                  center_y1 = sashPoint.Y + (sashH / 2),
                  arwEnd_x2 = ((sashPoint.X + sashW) - arwStart_x1) + (sashW / 20),
                  arwHeadUp_x3,
                  arwHeadUp_y3 = center_y1 - (center_y1 / 4),
                  arwHeadUp_x4,
                  arwHeadUp_y4 = center_y1 + (center_y1 / 4);


            if (_panelModel.Panel_Orient == true)
            {
                arwHeadUp_x3 = sashPoint.X + arwStart_x1 + (sashW / 10);
                arwHeadUp_x4 = sashPoint.X + arwStart_x1 + (sashW / 10);

                g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x3, arwHeadUp_y3),
                                                 new PointF(arwStart_x1, center_y1));
                g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x4, arwHeadUp_y4),
                                                 new PointF(arwStart_x1, center_y1));
            }
            else if (_panelModel.Panel_Orient == false)
            {
                arwHeadUp_x3 = ((sashPoint.X + sashW) - arwStart_x1) - (sashW / 10);
                arwHeadUp_x4 = ((sashPoint.X + sashW) - arwStart_x1) - (sashW / 10);

                g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x3, arwHeadUp_y3),
                                                 new PointF(arwEnd_x2, center_y1));
                g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x4, arwHeadUp_y4),
                                                 new PointF(arwEnd_x2, center_y1));
            }

            g.DrawLine(new Pen(Color.Black), new PointF(arwStart_x1, center_y1),
                                             new PointF(arwEnd_x2, center_y1));
        }

        public ISlidingPanelImagerUC GetSlidingPanelImagerUC()
        {
            _slidingPanelImagerUC.ThisBinding(CreateBindingDictionary());
            return _slidingPanelImagerUC;
        }


        public ISlidingPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                             IPanelModel panelModel,
                                                             IFrameImagerUCPresenter frameImagerUCP)
        {
            unityC
                .RegisterType<ISlidingPanelImagerUC, SlidingPanelImagerUC>()
                .RegisterType<ISlidingPanelImagerUCPresenter, SlidingPanelImagerUCPresenter>();
            SlidingPanelImagerUCPresenter slidingImagerUCP = unityC.Resolve<SlidingPanelImagerUCPresenter>();
            slidingImagerUCP._panelModel = panelModel;
            slidingImagerUCP._frameImagerUCP = frameImagerUCP;

            return slidingImagerUCP;
        }

        public ISlidingPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                             IPanelModel panelModel, 
                                                             IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP)
        {
            unityC
                .RegisterType<ISlidingPanelImagerUC, SlidingPanelImagerUC>()
                .RegisterType<ISlidingPanelImagerUCPresenter, SlidingPanelImagerUCPresenter>();
            SlidingPanelImagerUCPresenter slidingImagerUCP = unityC.Resolve<SlidingPanelImagerUCPresenter>();
            slidingImagerUCP._panelModel = panelModel;
            slidingImagerUCP._multiPanelMullionImagerUCP = multiPanelMullionImagerUCP;

            return slidingImagerUCP;
        }

        public ISlidingPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                             IPanelModel panelModel, 
                                                             IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP)
        {
            unityC
                .RegisterType<ISlidingPanelImagerUC, SlidingPanelImagerUC>()
                .RegisterType<ISlidingPanelImagerUCPresenter, SlidingPanelImagerUCPresenter>();
            SlidingPanelImagerUCPresenter slidingImagerUCP = unityC.Resolve<SlidingPanelImagerUCPresenter>();
            slidingImagerUCP._panelModel = panelModel;
            slidingImagerUCP._multiPanelTransomImagerUCP = multiPanelTransomImagerUCP;

            return slidingImagerUCP;
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
