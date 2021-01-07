using CommonComponents;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class BasePlatformImagerUCPresenter : IBasePlatformImagerUCPresenter, IPresenterCommon
    {
        IBasePlatformImagerUC _basePlatformImagerUC;

        IWindoorModel _windoorModel;

        public BasePlatformImagerUCPresenter(IBasePlatformImagerUC basePlatformImagerUC)
        {
            _basePlatformImagerUC = basePlatformImagerUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _basePlatformImagerUC.basePlatformPaintEventRaised += _basePlatformImagerUC_basePlatformPaintEventRaised;
            _basePlatformImagerUC.flpFrameDragDropPaintEventRaised += _basePlatformImagerUC_flpFrameDragDropPaintEventRaised;
            _basePlatformImagerUC.basePlatformSizeChangedEventRaised += _basePlatformImagerUC_basePlatformSizeChangedEventRaised;
        }

        private void _basePlatformImagerUC_basePlatformSizeChangedEventRaised(object sender, EventArgs e)
        {
            _basePlatformImagerUC.InvalidateThis();
        }

        private void _basePlatformImagerUC_flpFrameDragDropPaintEventRaised(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color col = Color.Black;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                           0,
                                                           pnl.ClientRectangle.Width - w,
                                                           pnl.ClientRectangle.Height - w));
        }

        private void _basePlatformImagerUC_basePlatformPaintEventRaised(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            UserControl basePL = (UserControl)sender;
            FlowLayoutPanel _flpMain = (FlowLayoutPanel)basePL.Controls[0];
            //dito ilagay ang drawing ng red-arrowlines
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;


            int ctrl_Y = 35;
            Pen redP = new Pen(Color.Red);
            redP.Width = 3.5f;
            Font dmnsion_font = new Font("Segoe UI", 20, FontStyle.Bold);

            string dmnsion_w = _windoorModel.WD_width.ToString();
            Point dmnsion_w_startP = new Point(_flpMain.Location.X, ctrl_Y - 17);
            Point dmnsion_w_endP = new Point(_flpMain.Location.X + _flpMain.Width - 3, ctrl_Y - 17);

            Size s = TextRenderer.MeasureText(dmnsion_w, dmnsion_font);
            double mid = (dmnsion_w_startP.X + dmnsion_w_endP.X) / 2;

            //arrow for WIDTH
            Point[] arrwhd_pnts_W1 =
            {
                new Point(dmnsion_w_startP.X + 10,dmnsion_w_startP.Y - 10),
                dmnsion_w_startP,
                new Point(dmnsion_w_startP.X + 10,dmnsion_w_startP.Y + 10),
            };

            Point[] arrwhd_pnts_W2 =
            {
                new Point(dmnsion_w_endP.X - 10, dmnsion_w_endP.Y - 10),
                dmnsion_w_endP,
                new Point(dmnsion_w_endP.X - 10, dmnsion_w_endP.Y + 10)
            };
            ;

            if (_flpMain.Controls.OfType<IFrameImagerUC>().Where(fr => fr.thisVisible == true).Count() > 0)
            {
                g.DrawLines(redP, arrwhd_pnts_W1);
                g.DrawLine(redP, dmnsion_w_startP, dmnsion_w_endP);
                g.DrawLines(redP, arrwhd_pnts_W2);
                TextRenderer.DrawText(g,
                                      dmnsion_w,
                                      dmnsion_font,
                                      new Rectangle(new Point((int)(mid - (s.Width / 2)), (ctrl_Y - s.Height) / 2),
                                                    new Size(s.Width, s.Height)),
                                      Color.Black,
                                      Color.White,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            //arrow for WIDTH

            //arrow for HEIGHT
            string dmnsion_h = _windoorModel.WD_height.ToString();
            Point dmnsion_h_startP = new Point(70 - 17, _flpMain.Location.Y);
            Point dmnsion_h_endP = new Point(70 - 17, _flpMain.Location.Y + (_flpMain.Height - 3));

            Size s2 = TextRenderer.MeasureText(dmnsion_h, dmnsion_font);
            double mid2 = (dmnsion_h_startP.Y + dmnsion_h_endP.Y) / 2;

            Point[] arrwhd_pnts_H1 =
            {
                    new Point(dmnsion_h_startP.X - 10,dmnsion_h_startP.Y + 10),
                    dmnsion_h_startP,
                    new Point(dmnsion_h_startP.X + 10,dmnsion_h_startP.Y + 10),
                };

            Point[] arrwhd_pnts_H2 =
            {
                    new Point(dmnsion_h_endP.X - 10, dmnsion_h_endP.Y - 10),
                    dmnsion_h_endP,
                    new Point(dmnsion_h_endP.X + 10, dmnsion_h_endP.Y - 10)
                };

            if (_flpMain.Controls.OfType<IFrameImagerUC>().Where(fr => fr.thisVisible == true).Count() > 0)
            {
                g.DrawLines(redP, arrwhd_pnts_H1);
                g.DrawLine(redP, dmnsion_h_startP, dmnsion_h_endP);
                g.DrawLines(redP, arrwhd_pnts_H2);
                TextRenderer.DrawText(g,
                                      dmnsion_h,
                                      dmnsion_font,
                                      new Rectangle(new Point((70 - s2.Width) / 2, (int)(mid2 - (s2.Height / 2))),
                                                    new Size(s2.Width, s2.Height)),
                                      Color.Black,
                                      Color.White,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            //arrow for HEIGHT

            Bitmap bm = new Bitmap(basePL.Size.Width, basePL.Size.Height);
            basePL.DrawToBitmap(bm, new Rectangle(0, 0, basePL.Size.Width, basePL.Size.Height));

            _windoorModel.WD_image = bm;
        }

        public IBasePlatformImagerUC GetBasePlatformImagerUC()
        {
            _basePlatformImagerUC.ThisBinding(CreateBindingDictionary());
            return _basePlatformImagerUC;
        }

        public IBasePlatformImagerUCPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel)
        {
            unityC
                .RegisterType<IBasePlatformImagerUC, BasePlatformImagerUC>()
                .RegisterType<IBasePlatformImagerUCPresenter, BasePlatformImagerUCPresenter>();
            BasePlatformImagerUCPresenter imagerUCP = unityC.Resolve<BasePlatformImagerUCPresenter>();
            imagerUCP._windoorModel = windoorModel;
            imagerUCP._basePlatformImagerUC.ClearBinding((UserControl)_basePlatformImagerUC);

            return imagerUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> basePlatformBinding = new Dictionary<string, Binding>();
            basePlatformBinding.Add("WD_width_4basePlatform_forImageRenderer", new Binding("Width", _windoorModel, "WD_width_4basePlatform_forImageRenderer", true, DataSourceUpdateMode.OnPropertyChanged));
            basePlatformBinding.Add("WD_height_4basePlatform_forImageRenderer", new Binding("Height", _windoorModel, "WD_height_4basePlatform_forImageRenderer", true, DataSourceUpdateMode.OnPropertyChanged));
            basePlatformBinding.Add("WD_visibility", new Binding("Visible", _windoorModel, "WD_visibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return basePlatformBinding;
        }

        public void InvalidateBasePlatform()
        {
            _basePlatformImagerUC.InvalidateThis();
        }

        public void AddFrame(IFrameImagerUC frameImagerUC)
        {
            FlowLayoutPanel _flpMain = _basePlatformImagerUC.GetFlpMain();
            _flpMain.Controls.Add((UserControl)frameImagerUC);
        }
    }
}
