using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views.UserControls;
using ModelLayer.Model.Quotation.WinDoor;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class BasePlatformPresenter : IBasePlatformPresenter
    {
        IBasePlatformUC _basePlatfomrUC;
        FlowLayoutPanel _flpMain;

        IWindoorModel _windoorModel;

        private bool will_render_img;

        public BasePlatformPresenter(IBasePlatformUC basePlatformUC)
        {
            _basePlatfomrUC = basePlatformUC;
            _flpMain = _basePlatfomrUC.GetFlpMain();
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _basePlatfomrUC.basePlatformPaintEventRaised += new PaintEventHandler(OnbasePlatformPaintEventRaised);
            _basePlatfomrUC.basePlatformSizeChangedEventRaised += new EventHandler(OnbasePlatformSizeChangedEventRaised);
            _basePlatfomrUC.flpFrameDragDropPaintEventRaised += new PaintEventHandler(OnflpFrameDragDropPaintEventRaised);
            _basePlatfomrUC.basePlatformLoadEventRaised += new EventHandler(OnbasePlatformLoadEventRaised);
        }

        private void OnbasePlatformLoadEventRaised(object sender, EventArgs e)
        {
            //_basePlatfomrUC.ThisBinding(CreateBindingDictionary_basePlaform());
        }

        private Dictionary<string, Binding> CreateBindingDictionary_basePlaform()
        {
            Dictionary<string, Binding> basePlatformBinding = new Dictionary<string, Binding>();
            basePlatformBinding.Add("WD_width_4basePlatform", new Binding("Width", _windoorModel, "WD_width_4basePlatform", true, DataSourceUpdateMode.OnPropertyChanged));
            basePlatformBinding.Add("WD_height_4basePlatform", new Binding("Height", _windoorModel, "WD_height_4basePlatform", true, DataSourceUpdateMode.OnPropertyChanged));
            basePlatformBinding.Add("WD_visibility", new Binding("Visible", _windoorModel, "WD_visibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return basePlatformBinding;
        }

        private void OnflpFrameDragDropPaintEventRaised(object sender, PaintEventArgs e)
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

        private void OnbasePlatformSizeChangedEventRaised(object sender, EventArgs e)
        {
            if (will_render_img == false)
            {
                UserControl basePlatform = (UserControl)sender;
                Panel pnlMain = (Panel)basePlatform.Parent;
                int cX, cY;
                cX = (pnlMain.Width - basePlatform.Width) / 2;
                cY = (pnlMain.Height - basePlatform.Height) / 2;

                if (cX <= 30 && cY <= 30)
                {
                    basePlatform.Location = new Point(60, 60);
                }
                else if (cX <= 30)
                {
                    basePlatform.Location = new Point(60, cY);
                }
                else if (cY <= 30)
                {
                    basePlatform.Location = new Point(cX, 60);
                }
                else
                {
                    basePlatform.Location = new Point(cX - 17, cY - 35);
                }
            }
        }

        private void OnbasePlatformPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl basePL = (UserControl)sender;
            //dito ilagay ang drawing ng red-arrowlines
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int ctrl_Y = 35;
            Pen redP = new Pen(Color.Red);
            redP.Width = 3.5f;
            Font dmnsion_font = new Font("Segoe UI", 20, FontStyle.Bold);

            string dmnsion_w = _flpMain.Width.ToString();
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

            if (_flpMain.Controls.OfType<IFrameUC>().Where(fr => fr.thisVisible == true).Count() > 0)
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
                                      SystemColors.Control,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            //arrow for WIDTH


            //arrow for HEIGHT
            string dmnsion_h = _flpMain.Height.ToString();
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

            if (_flpMain.Controls.OfType<IFrameUC>().Where(fr => fr.thisVisible == true).Count() > 0)
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
                                      SystemColors.Control,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            //arrow for HEIGHT

            if (will_render_img)
            {
                Bitmap bm = new Bitmap(basePL.Size.Width, basePL.Size.Height);
                basePL.DrawToBitmap(bm, new Rectangle(0, 0, basePL.Size.Width, basePL.Size.Height));
                _windoorModel.WD_image = bm;
            }
            
            //Set_WDImage(g, basePL);
        }

        private void Set_WDImage(Graphics g, UserControl basePL)
        {
            
            Bitmap bm = new Bitmap(basePL.Size.Width, basePL.Size.Height);
            basePL.DrawToBitmap(bm, new Rectangle(0, 0, basePL.Size.Width, basePL.Size.Height));
            _windoorModel.WD_image = bm;
        }

        public IBasePlatformUC getBasePlatformViewUC()
        {
            return _basePlatfomrUC;
        }

        public IBasePlatformUC getBasePlatformViewUC(bool willRenderImg)
        {
            _basePlatfomrUC.ThisBinding(CreateBindingDictionary_basePlaform());
            will_render_img = willRenderImg;
            return _basePlatfomrUC;
        }

        //public void SetBasePlatformSize(int wd, int ht)
        //{
        //    _basePlatfomrUC.bp_Width = wd;
        //    _basePlatfomrUC.bp_Height = ht;
        //}

        public void AddFrame(IFrameUC frame)
        {
            _flpMain.Controls.Add((UserControl)frame);
        }

        public void InvalidateBasePlatform()
        {
            _basePlatfomrUC.InvalidateThis();
        }

        public void PerformLayoutBasePlatform()
        {
            _basePlatfomrUC.PerformLayoutThis();
        }

        public List<int> lst_wd_toPaint(int flpMain_width, List<int> lst_ctrlWds)
        {
            List<int> lst_wd = new List<int>();

            return lst_wd;
        }

        public List<int> lst_ht_toPaint(int flpMain_height, List<int> lst_ctrlHts)
        {
            List<int> lst_ht = new List<int>();

            return lst_ht;
        }

        public void Invalidate_flpMain()
        {
            _flpMain.Invalidate();
        }

        public void DeleteFrameUC(IFrameUC frameUC)
        {
            _flpMain.Controls.Remove((UserControl)frameUC);
        }

        public void SetWindoorModel(IWindoorModel windoorModel)
        {
            _windoorModel = windoorModel;
            _basePlatfomrUC.ClearBinding((UserControl)_basePlatfomrUC);
            _basePlatfomrUC.ThisBinding(CreateBindingDictionary_basePlaform());
        }

        public IBasePlatformPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel)
        {
            unityC
                .RegisterType<IBasePlatformUC, BasePlatformUC>()
                .RegisterType<IBasePlatformPresenter, BasePlatformPresenter>();
            BasePlatformPresenter basePlatformUCP = unityC.Resolve<BasePlatformPresenter>();
            basePlatformUCP._windoorModel = windoorModel;
            basePlatformUCP._basePlatfomrUC.ClearBinding((UserControl)_basePlatfomrUC);
            //basePlatformUCP._basePlatfomrUC.ThisBinding(CreateBindingDictionary_basePlaform());

            return basePlatformUCP;
        }
    }
}
