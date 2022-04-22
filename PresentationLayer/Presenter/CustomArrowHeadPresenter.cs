using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class CustomArrowHeadPresenter : ICustomArrowHeadPresenter
    {
        ICustomArrowHeadView _customArrowHead;

        private IUnityContainer _unityC;
        private ICustomArrowHeadUCPresenter _customArrowHeadUCP;
        private IWindoorModel _windoorModel;
        private IMainPresenter _mainPresenter;
        private IBasePlatformImagerUCPresenter _basePlatformImagerUCPresenter;

        private List<ICustomArrowHeadUCPresenter> _lst_arrowUCP = new List<ICustomArrowHeadUCPresenter>();

        private Panel _customArrowHeadPnlWD;
        private Panel _customArrowHeadPnlHT;
        private PictureBox _pboxFrame;

        private int _arrowWD_count;
        public int ArrowWD_Count
        {
            get
            {
                return _arrowWD_count;
            }
            set
            {
                _arrowWD_count = value;
                if (_arrowWD_count == 0)
                {
                    _customArrowHeadPnlWD.Visible = false;
                }
                else if (_arrowWD_count > 0)
                {
                    _customArrowHeadPnlWD.Visible = true;
                }
            }
        }

        private int _arrowHT_count;
        public int ArrowHT_Count
        {
            get
            {
                return _arrowHT_count;
            }
            set
            {
                _arrowHT_count = value;
                if (_arrowHT_count == 0)
                {
                    _customArrowHeadPnlHT.Visible = false;
                }
                else if (_arrowHT_count > 0)
                {
                    _customArrowHeadPnlHT.Visible = true;
                }
            }
        }

        public CustomArrowHeadPresenter(ICustomArrowHeadView customArrowHead,
                                        ICustomArrowHeadUCPresenter customArrowHeadUCP,
                                        IBasePlatformImagerUCPresenter basePlatformImagerUCPresenter)
        {
            _customArrowHeadUCP = customArrowHeadUCP;
            _customArrowHead = customArrowHead;
            _customArrowHeadPnlWD = _customArrowHead.GetPnlArrowWD();
            _customArrowHeadPnlHT = _customArrowHead.GetPnlArrowHT();
            _pboxFrame = _customArrowHead.GetPbox();
            _basePlatformImagerUCPresenter = basePlatformImagerUCPresenter;

            subscribeToEventSetup();
        }

        private void subscribeToEventSetup()
        {
            _customArrowHead.BtnAddArrowHeadHeightCkickEventRaised += _customArrowHead_BtnAddArrowHeadHeightCkickEventRaised;
            _customArrowHead.BtnAddArrowHeadWidthCkickEventRaised += _customArrowHead_BtnAddArrowHeadWidthCkickEventRaised;
            _customArrowHead.BtnSaveCustomArrowCkickEventRaised += _customArrowHead_BtnSaveCustomArrowCkickEventRaised;
            _customArrowHead.CustomArrowHeadViewLoadEventRaised += _customArrowHead_CustomArrowHeadViewLoadEventRaised;
            _customArrowHead.pnl_CustomArrowPaintEventRaised += _customArrowHead_pnl_CustomArrowPaintEventRaised;
        }

        private void _customArrowHead_pnl_CustomArrowPaintEventRaised(object sender, PaintEventArgs e)
        {
            Panel basePL = (Panel)sender;
            PictureBox pbox = (PictureBox)basePL.Controls[0];
            //dito ilagay ang drawing ng red-arrowlines
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            int ctrl_Y = 35;
            float zoom = _windoorModel.WD_zoom_forImageRenderer;

            Pen redP = new Pen(Color.Red);
            redP.Width = 3.5f;

            Font dmnsion_font_wd = new Font("Segoe UI", 22, FontStyle.Bold);
            Font dmnsion_font_ht = new Font("Segoe UI", 17, FontStyle.Bold);

            int total_frame = _windoorModel.lst_frame.Count;
            int total_panel = 0, total_mpanel = 0;
            foreach (IFrameModel frame in _windoorModel.lst_frame)
            {
                total_panel += frame.Lst_Panel.Count;
                total_mpanel += frame.Lst_MultiPanel.Count;
                foreach (IMultiPanelModel mpnl in frame.Lst_MultiPanel)
                {
                    total_panel += mpnl.MPanelLst_Panel.Count;
                }
            }

            if (total_panel > 1 || total_mpanel >= 1)
            {
                float locX = 0;
                foreach (decimal wd in _windoorModel.lst_wd_redArrowLines)
                {
                    locX += Draw_Arrow_Width(wd, e, locX, dmnsion_font_wd, ctrl_Y);
                }

                float locY = 0;
                foreach (decimal ht in _windoorModel.lst_ht_redArrowLines)
                {
                    locY += Draw_Arrow_Height(ht, e, locY, dmnsion_font_ht, ctrl_Y);
                }
            }
            else if (total_panel == 1 && total_mpanel == 0)
            {
                string dmnsion_w = _windoorModel.WD_width.ToString();
                Point dmnsion_w_startP = new Point(pbox.Location.X, ctrl_Y - 17);
                Point dmnsion_w_endP = new Point(pbox.Location.X + pbox.Width - 3, ctrl_Y - 17);

                Size s = TextRenderer.MeasureText(dmnsion_w, dmnsion_font_wd);
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

                //if (_flpMain.Controls.OfType<IFrameImagerUC>().Where(fr => fr.thisVisible == true).Count() > 0)
                //{
                g.DrawLines(redP, arrwhd_pnts_W1);
                g.DrawLine(redP, dmnsion_w_startP, dmnsion_w_endP);
                g.DrawLines(redP, arrwhd_pnts_W2);
                TextRenderer.DrawText(g,
                                      dmnsion_w,
                                      dmnsion_font_wd,
                                      new Rectangle(new Point((int)(mid - (s.Width / 2)), (ctrl_Y - s.Height) / 2),
                                                    new Size(s.Width, s.Height)),
                                      Color.Black,
                                      Color.White,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                //}
                //arrow for WIDTH


                //arrow for HEIGHT
                string dmnsion_h = _windoorModel.WD_height.ToString();
                Point dmnsion_h_startP = new Point(70 - 17, pbox.Location.Y);
                Point dmnsion_h_endP = new Point(70 - 17, pbox.Location.Y + (pbox.Height - 3));

                Size s2 = TextRenderer.MeasureText(dmnsion_h, dmnsion_font_ht);
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

                //if (_flpMain.Controls.OfType<IFrameImagerUC>().Where(fr => fr.thisVisible == true).Count() > 0)
                //{
                g.DrawLines(redP, arrwhd_pnts_H1);
                g.DrawLine(redP, dmnsion_h_startP, dmnsion_h_endP);
                g.DrawLines(redP, arrwhd_pnts_H2);
                TextRenderer.DrawText(g,
                                      dmnsion_h,
                                      dmnsion_font_ht,
                                      new Rectangle(new Point((70 - s2.Width) / 2, (int)(mid2 - (s2.Height / 2))),
                                                    new Size(s2.Width, s2.Height)),
                                      Color.Black,
                                      Color.White,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                //}
                //arrow for HEIGHT
            }

        }

        private void _customArrowHead_CustomArrowHeadViewLoadEventRaised(object sender, EventArgs e)
        {

            _mainPresenter.basePlatformWillRenderImg_MainPresenter.SetWdFlpImage();
            _customArrowHead.ThisBinding(CreateBindingDictionary());
        }

        private void _customArrowHead_BtnSaveCustomArrowCkickEventRaised(object sender, EventArgs e)
        { 
            List<decimal> lst_arrowWdLength = new List<decimal>();
            List<decimal> lst_arrowHtLength = new List<decimal>();
             
            foreach (Control arrow_Wd in _customArrowHeadPnlWD.Controls)
            { 
                lst_arrowWdLength.Add(((ICustomArrowHeadUC)arrow_Wd).Arrow_Size); 
            }

            foreach (Control arrow_Ht in _customArrowHeadPnlHT.Controls)
            {
                lst_arrowHtLength.Add(((ICustomArrowHeadUC)arrow_Ht).Arrow_Size);
            }


            if (lst_arrowWdLength.Count > 0 &&
                lst_arrowHtLength.Count > 0)
            {
                _windoorModel.lst_wd_redArrowLines = lst_arrowWdLength;
                _windoorModel.lst_ht_redArrowLines = lst_arrowHtLength;
                 
                MessageBox.Show("Saved");
            }

        }
        private void _customArrowHead_BtnAddArrowHeadWidthCkickEventRaised(object sender, EventArgs e)
        {
            ICustomArrowHeadUCPresenter CustomArrowHeadUCPresenter = _customArrowHeadUCP.GetNewInstance(_unityC, this, _windoorModel);
            _lst_arrowUCP.Add(CustomArrowHeadUCPresenter);
            UserControl CustomArrowHeadUC = (UserControl)CustomArrowHeadUCPresenter.GetCustomArrowUC();
            CustomArrowHeadUC.Dock = DockStyle.Top;
            _customArrowHeadPnlWD.Controls.Add(CustomArrowHeadUC);
            CustomArrowHeadUC.BringToFront();
            ArrowWD_Count++;
            _windoorModel.Lbl_ArrowWdCount++;
            CustomArrowHeadUCPresenter.GetCustomArrowUC().ArrowCountWD = ArrowWD_Count;

        }

        private void _customArrowHead_BtnAddArrowHeadHeightCkickEventRaised(object sender, EventArgs e)
        {
            ICustomArrowHeadUCPresenter CustomArrowHeadUCPresenter1 = _customArrowHeadUCP.GetNewInstance(_unityC, this, _windoorModel);
            _lst_arrowUCP.Add(CustomArrowHeadUCPresenter1);
            UserControl CustomArrowHeadUC = (UserControl)CustomArrowHeadUCPresenter1.GetCustomArrowUC();
            CustomArrowHeadUC.Dock = DockStyle.Top;
            _customArrowHeadPnlHT.Controls.Add(CustomArrowHeadUC);
            CustomArrowHeadUC.BringToFront();
            ArrowHT_Count++;
            _windoorModel.Lbl_ArrowHtCount++;
            CustomArrowHeadUCPresenter1.GetCustomArrowUC().ArrowCountHT = ArrowHT_Count;

        }

        public ICustomArrowHeadView GetICustomArrowHeadView()
        {
            return _customArrowHead;
        }
        public void Remove_ArrowHeadUCP(ICustomArrowHeadUCPresenter CustomArrowHeadUCP)
        {
            _lst_arrowUCP.Remove(CustomArrowHeadUCP);
        }

        public void ComputeTotalArrowLenght()
        {
            decimal totalArrowWdLength = 0,
                    totalArrowHtLength = 0;

            foreach (ICustomArrowHeadUCPresenter ArrowHead in _lst_arrowUCP)
            {
                Control CustomArrowHead = ((UserControl)ArrowHead.GetCustomArrowUC()).Parent;

                if (CustomArrowHead.Name == "pnl_ArrowHeight")
                {
                    totalArrowHtLength += ArrowHead.GetCustomArrowUC().Arrow_Size;
                }
                else if (CustomArrowHead.Name == "pnl_ArrowWidth")
                {
                    totalArrowWdLength += ArrowHead.GetCustomArrowUC().Arrow_Size;
                }
            }

            _customArrowHead.SetLblTotalArrowLength_Text(totalArrowWdLength.ToString(), totalArrowHtLength.ToString());

        }

        private float Draw_Arrow_Width(decimal wd, PaintEventArgs e, float locX, Font dmnsion_font_wd, int ctrl_Y)
        {
            Graphics g = e.Graphics;

            string dmnsion_w = wd.ToString();

            if (dmnsion_w.Contains(".0"))
            {
                dmnsion_w = dmnsion_w.Replace(".0", "");
            }

            float DispWd_float = float.Parse(dmnsion_w);

            PointF dmnsion_w_startP = new PointF(_pboxFrame.Location.X + (locX * _windoorModel.WD_zoom),
                                                 (ctrl_Y - 17));// * _windoorModel.WD_zoom);
            PointF dmnsion_w_endP = new PointF((_pboxFrame.Location.X - 3) + ((locX + DispWd_float) * _windoorModel.WD_zoom),
                                               (ctrl_Y - 17)); // * _windoorModel.WD_zoom);

            Size s = TextRenderer.MeasureText(dmnsion_w, dmnsion_font_wd);
            double mid = (dmnsion_w_startP.X + dmnsion_w_endP.X) / 2;

            //arrow for WIDTH
            PointF[] arrwhd_pnts_W1 =
            {
                            new PointF(dmnsion_w_startP.X + 10,dmnsion_w_startP.Y - 10),
                            dmnsion_w_startP,
                            new PointF(dmnsion_w_startP.X + 10,dmnsion_w_startP.Y + 10),
                    };

            PointF[] arrwhd_pnts_W2 =
            {
                            new PointF(dmnsion_w_endP.X - 10, dmnsion_w_endP.Y - 10),
                            dmnsion_w_endP,
                            new PointF(dmnsion_w_endP.X - 10, dmnsion_w_endP.Y + 10)
                        };

            if (_windoorModel.lst_frame.Count > 0)
            {
                g.DrawLines(new Pen(Color.Red, 3.5f), arrwhd_pnts_W1);
                g.DrawLine(new Pen(Color.Red, 3.5f), dmnsion_w_startP, dmnsion_w_endP);
                g.DrawLines(new Pen(Color.Red, 3.5f), arrwhd_pnts_W2);
                TextRenderer.DrawText(g,
                                      dmnsion_w,
                                      dmnsion_font_wd,
                                      new Rectangle(new Point((int)(mid - (s.Width / 2)), (ctrl_Y - s.Height) / 2),
                                                    new Size(s.Width, s.Height)),
                                      Color.Black,
                                      SystemColors.Control,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            //arrow for WIDTH
            locX += DispWd_float;

            return locX;
        }

        private float Draw_Arrow_Height(decimal ht, PaintEventArgs e, float locY, Font dmnsion_font_ht, int ctrl_Y)
        {
            //arrow for HEIGHT
            Graphics g = e.Graphics;

            string dmnsion_h = ht.ToString();
            float DispHt_float = float.Parse(dmnsion_h);

            PointF dmnsion_h_startP = new PointF(70 - 17, _pboxFrame.Location.Y + (locY * _windoorModel.WD_zoom));
            PointF dmnsion_h_endP = new PointF(70 - 17, (_pboxFrame.Location.Y - 3) + ((locY + DispHt_float) * _windoorModel.WD_zoom));

            if (dmnsion_h.Contains(".0"))
            {
                dmnsion_h = dmnsion_h.Replace(".0", "");
            }

            Size s2 = TextRenderer.MeasureText(dmnsion_h, dmnsion_font_ht);

            double mid2 = (dmnsion_h_startP.Y + dmnsion_h_endP.Y) / 2;

            PointF[] arrwhd_pnts_H1 =
            {
                        new PointF(dmnsion_h_startP.X - 10,dmnsion_h_startP.Y + 10),
                        dmnsion_h_startP,
                        new PointF(dmnsion_h_startP.X + 10,dmnsion_h_startP.Y + 10),
                    };

            PointF[] arrwhd_pnts_H2 =
            {
                        new PointF(dmnsion_h_endP.X - 10, dmnsion_h_endP.Y - 10),
                        dmnsion_h_endP,
                        new PointF(dmnsion_h_endP.X + 10, dmnsion_h_endP.Y - 10)
                    };

            if (_windoorModel.lst_frame.Count > 0)
            {
                g.DrawLines(new Pen(Color.Red, 3.5f), arrwhd_pnts_H1);
                g.DrawLine(new Pen(Color.Red, 3.5f), dmnsion_h_startP, dmnsion_h_endP);
                g.DrawLines(new Pen(Color.Red, 3.5f), arrwhd_pnts_H2);
                TextRenderer.DrawText(g,
                                      dmnsion_h,
                                      dmnsion_font_ht,
                                      new Rectangle(new Point((70 - s2.Width) / 2, (int)(mid2 - (s2.Height / 2))),
                                                    new Size(s2.Width, s2.Height)),
                                      Color.Black,
                                      SystemColors.Control,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            //arrow for HEIGHT
            locY += DispHt_float;

            return locY;
        }




        public ICustomArrowHeadPresenter GetNewInstance(IUnityContainer unityC,
                                                        ICustomArrowHeadUCPresenter customArrowHeadUC,
                                                        IWindoorModel windoorModel,
                                                        IMainPresenter mainPresenter)
        {
            unityC
                  .RegisterType<ICustomArrowHeadPresenter, CustomArrowHeadPresenter>()
                  .RegisterType<ICustomArrowHeadView, CustomArrowHeadView>();
            CustomArrowHeadPresenter CustomArrow = unityC.Resolve<CustomArrowHeadPresenter>();
            CustomArrow._unityC = unityC;
            CustomArrow._customArrowHeadUCP = customArrowHeadUC;
            CustomArrow._windoorModel = windoorModel;
            CustomArrow._mainPresenter = mainPresenter;
            return CustomArrow;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Lbl_ArrowWdCount", new Binding("Text", _windoorModel, "Lbl_ArrowWdCount", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Lbl_ArrowHtCount", new Binding("Text", _windoorModel, "Lbl_ArrowHtCount", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Pnl_ArrowHeightVisibility", new Binding("Visible", _windoorModel, "Pnl_ArrowHeightVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Pnl_ArrowWidthVisibility", new Binding("Visible", _windoorModel, "Pnl_ArrowWidthVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("pboxFrame", new Binding("Image", _windoorModel, "WD_flpImage", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

    }
}
