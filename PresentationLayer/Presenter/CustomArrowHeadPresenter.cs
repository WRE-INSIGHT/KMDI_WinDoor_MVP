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
using System.Linq;
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
        private Panel _customArrowHeadPnl;
        private PictureBox _pboxFrame;

        private int _arrowId;
        private List<ICustomArrowHeadUC> lst_arrowWd = new List<ICustomArrowHeadUC>();
        private List<ICustomArrowHeadUC> lst_arrowHt = new List<ICustomArrowHeadUC>();



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
            _customArrowHeadPnl = _customArrowHead.GetPnlCustomArrow();
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

            if (total_panel > 1 || total_mpanel >= 1) // multiplePanel
            {
                int TotalArrowWidthBounds = basePL.Width - 70,
                    TotalArrowHeightBounds = basePL.Height - 35;

                float locX = 0;
                foreach (KeyValuePair<int, decimal> KV_Wd in _windoorModel.Dictionary_wd_redArrowLines)
                {
                    decimal WidthPercentage = KV_Wd.Value / _customArrowHead.Lbl_ArrowWidthLength,
                            FinalWidth = WidthPercentage * TotalArrowWidthBounds;
                    locX = Draw_Arrow_Width(KV_Wd.Value, FinalWidth, e, locX, dmnsion_font_wd, ctrl_Y);
                }

                float locY = 0;
                foreach (KeyValuePair<int, decimal> KV_Ht in _windoorModel.Dictionary_ht_redArrowLines)
                {
                    decimal HeightPercentage = KV_Ht.Value / _customArrowHead.Lbl_ArrowHeightLength,
                            Finalheight = HeightPercentage * TotalArrowHeightBounds;
                    locY = Draw_Arrow_Height(KV_Ht.Value, Finalheight, e, locY, dmnsion_font_ht, ctrl_Y);
                }
            }
            else if (total_panel == 1 && total_mpanel == 0) // panel
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

            if (_windoorModel.Dictionary_ht_redArrowLines.Count > 0)
            {
                foreach (KeyValuePair<int, decimal> arrowHt in _windoorModel.Dictionary_ht_redArrowLines)
                {
                    ICustomArrowHeadUCPresenter CustomArrowHeadUCPresenter1 = _customArrowHeadUCP.GetNewInstance(_unityC, this, _windoorModel);
                    _lst_arrowUCP.Add(CustomArrowHeadUCPresenter1);
                    UserControl CustomArrowHeadUC = (UserControl)CustomArrowHeadUCPresenter1.GetCustomArrowUC();
                    CustomArrowHeadUCPresenter1.GetCustomArrowUC().ArrowHeadName = "Height";
                    CustomArrowHeadUC.Dock = DockStyle.Top;
                    _customArrowHeadPnlHT.Controls.Add(CustomArrowHeadUC);
                    CustomArrowHeadUC.BringToFront();
                    (CustomArrowHeadUC as ICustomArrowHeadUC).SetNudMaxValue();
                    (CustomArrowHeadUC as ICustomArrowHeadUC).Arrow_Size = arrowHt.Value;
                    _windoorModel.Lbl_ArrowHtCount = _windoorModel.Dictionary_ht_redArrowLines.Count;
                    ArrowHT_Count++;
                    CustomArrowHeadUCPresenter1.GetCustomArrowUC().ArrowCountHT = ArrowHT_Count;
                    lst_arrowHt.Add(CustomArrowHeadUC as ICustomArrowHeadUC);
                    _arrowId++;
                    CustomArrowHeadUCPresenter1.GetCustomArrowUC().ArrowId = _arrowId;
                }
            }

            if (_windoorModel.Dictionary_wd_redArrowLines.Count > 0)
            {
                foreach (KeyValuePair<int, decimal> arrowWd in _windoorModel.Dictionary_wd_redArrowLines)
                {
                    ICustomArrowHeadUCPresenter CustomArrowHeadUCPresenter = _customArrowHeadUCP.GetNewInstance(_unityC, this, _windoorModel);
                    _lst_arrowUCP.Add(CustomArrowHeadUCPresenter);
                    UserControl CustomArrowHeadUC = (UserControl)CustomArrowHeadUCPresenter.GetCustomArrowUC();
                    CustomArrowHeadUCPresenter.GetCustomArrowUC().ArrowHeadName = "Width";
                    CustomArrowHeadUC.Dock = DockStyle.Top;
                    _customArrowHeadPnlWD.Controls.Add(CustomArrowHeadUC);
                    CustomArrowHeadUC.BringToFront();
                    (CustomArrowHeadUC as ICustomArrowHeadUC).SetNudMaxValue();
                    (CustomArrowHeadUC as ICustomArrowHeadUC).Arrow_Size = arrowWd.Value;
                    _windoorModel.Lbl_ArrowWdCount = _windoorModel.Dictionary_wd_redArrowLines.Count;
                    ArrowWD_Count++;
                    CustomArrowHeadUCPresenter.GetCustomArrowUC().ArrowCountWD = ArrowWD_Count;
                    lst_arrowWd.Add(CustomArrowHeadUC as ICustomArrowHeadUC);
                    _arrowId++;
                    CustomArrowHeadUCPresenter.GetCustomArrowUC().ArrowId = _arrowId;
                }
            }



        }

        private void _customArrowHead_BtnSaveCustomArrowCkickEventRaised(object sender, EventArgs e)
        {
            Dictionary<int, decimal> lst_arrowWdLength = new Dictionary<int, decimal>();
            Dictionary<int, decimal> lst_arrowHtLength = new Dictionary<int, decimal>();

            foreach (ICustomArrowHeadUC arrow_Wd in lst_arrowWd.OrderBy(x => x.ArrowId))
            {

                lst_arrowWdLength.Add(arrow_Wd.ArrowId, ((ICustomArrowHeadUC)arrow_Wd).Arrow_Size);
            }

            foreach (ICustomArrowHeadUC arrow_Ht in lst_arrowHt.OrderBy(x => x.ArrowId))
            {
                lst_arrowHtLength.Add(arrow_Ht.ArrowId, ((ICustomArrowHeadUC)arrow_Ht).Arrow_Size);
            }


            if (lst_arrowWdLength.Count > 0 &&
                lst_arrowHtLength.Count > 0)
            {
                _windoorModel.Dictionary_wd_redArrowLines = lst_arrowWdLength;
                _windoorModel.Dictionary_ht_redArrowLines = lst_arrowHtLength;
                _customArrowHeadPnl.Invalidate();
                _customArrowHead.SetBtnSaveBackColor(Color.ForestGreen);
            }
        }
        private void _customArrowHead_BtnAddArrowHeadWidthCkickEventRaised(object sender, EventArgs e)
        {
            ICustomArrowHeadUCPresenter CustomArrowHeadUCPresenter = _customArrowHeadUCP.GetNewInstance(_unityC, this, _windoorModel);
            _lst_arrowUCP.Add(CustomArrowHeadUCPresenter);
            UserControl CustomArrowHeadUC = (UserControl)CustomArrowHeadUCPresenter.GetCustomArrowUC();
            CustomArrowHeadUCPresenter.GetCustomArrowUC().ArrowHeadName = "Width";
            CustomArrowHeadUC.Dock = DockStyle.Top;
            _customArrowHeadPnlWD.Controls.Add(CustomArrowHeadUC);
            CustomArrowHeadUC.BringToFront();
            ArrowWD_Count++;
            CustomArrowHeadUCPresenter.GetCustomArrowUC().ArrowCountWD = ArrowWD_Count; //Left NUD
            _windoorModel.Lbl_ArrowWdCount++; // Left Btn Add
            _arrowId++;
            CustomArrowHeadUCPresenter.GetCustomArrowUC().ArrowId = _arrowId;
            lst_arrowWd.Add(CustomArrowHeadUC as ICustomArrowHeadUC);
            (CustomArrowHeadUC as ICustomArrowHeadUC).SetNudMaxValue();
            _customArrowHead.SetBtnSaveBackColor(SystemColors.Control);
        }

        private void _customArrowHead_BtnAddArrowHeadHeightCkickEventRaised(object sender, EventArgs e)
        {
            ICustomArrowHeadUCPresenter CustomArrowHeadUCPresenter1 = _customArrowHeadUCP.GetNewInstance(_unityC, this, _windoorModel);
            _lst_arrowUCP.Add(CustomArrowHeadUCPresenter1);
            UserControl CustomArrowHeadUC = (UserControl)CustomArrowHeadUCPresenter1.GetCustomArrowUC();
            CustomArrowHeadUCPresenter1.GetCustomArrowUC().ArrowHeadName = "Height";
            CustomArrowHeadUC.Dock = DockStyle.Top;
            _customArrowHeadPnlHT.Controls.Add(CustomArrowHeadUC);
            CustomArrowHeadUC.BringToFront();
            ArrowHT_Count++;
            CustomArrowHeadUCPresenter1.GetCustomArrowUC().ArrowCountHT = ArrowHT_Count; //Left NUD
            _windoorModel.Lbl_ArrowHtCount++; // Left Btn Add
            _arrowId++;
            CustomArrowHeadUCPresenter1.GetCustomArrowUC().ArrowId = _arrowId;
            lst_arrowHt.Add(CustomArrowHeadUC as ICustomArrowHeadUC);
            (CustomArrowHeadUC as ICustomArrowHeadUC).SetNudMaxValue();
            _customArrowHead.SetBtnSaveBackColor(SystemColors.Control);
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
            decimal arrowWidthLength = 0,
                    arrowHeightLength = 0;

            foreach (ICustomArrowHeadUCPresenter ArrowHead in _lst_arrowUCP)
            {
                Control CustomArrowHead = ((UserControl)ArrowHead.GetCustomArrowUC()).Parent;

                if (CustomArrowHead.Name == "pnl_ArrowHeight")
                {
                    arrowHeightLength += ArrowHead.GetCustomArrowUC().Arrow_Size;
                }
                else if (CustomArrowHead.Name == "pnl_ArrowWidth")
                {
                    arrowWidthLength += ArrowHead.GetCustomArrowUC().Arrow_Size;
                }
            }

            _customArrowHead.Lbl_ArrowWidthLength = arrowWidthLength;
            _customArrowHead.Lbl_ArrowHeightLength = arrowHeightLength;

            if (_customArrowHead.Lbl_ArrowHeightLength == _windoorModel.WD_height)
            {
                _customArrowHead.SetLblTotalArrowLengthHeight_BackColor(Color.ForestGreen);
            }
            else
            {
                _customArrowHead.SetLblTotalArrowLengthHeight_BackColor(Color.IndianRed);
            }

            if (_customArrowHead.Lbl_ArrowWidthLength == _windoorModel.WD_width)
            {
                _customArrowHead.SetLblTotalArrowLengthWidth_BackColor(Color.ForestGreen);
            }
            else
            {
                _customArrowHead.SetLblTotalArrowLengthWidth_BackColor(Color.IndianRed);
            }
        }



        private float Draw_Arrow_Width(decimal txt_width, decimal actual_width, PaintEventArgs e, float locX, Font dmnsion_font_wd, int ctrl_Y)
        {
            Graphics g = e.Graphics;

            string dmnsion_w = txt_width.ToString();

            if (dmnsion_w.Contains(".0"))
            {
                dmnsion_w = dmnsion_w.Replace(".0", "");
            }

            float DispWd_float = (float)actual_width;

            PointF dmnsion_w_startP = new PointF(_pboxFrame.Location.X + locX,// * _windoorModel.WD_zoom),
                                                 (ctrl_Y - 17));// * _windoorModel.WD_zoom);
            PointF dmnsion_w_endP = new PointF((_pboxFrame.Location.X - 3) + (locX + DispWd_float),// * _windoorModel.WD_zoom),
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

        private float Draw_Arrow_Height(decimal txt_height, decimal actual_height, PaintEventArgs e, float locY, Font dmnsion_font_ht, int ctrl_Y)
        {
            //arrow for HEIGHT
            Graphics g = e.Graphics;

            string dmnsion_h = txt_height.ToString();
            float DispHt_float = (float)actual_height;

            PointF dmnsion_h_startP = new PointF(70 - 17, _pboxFrame.Location.Y + locY);// * _windoorModel.WD_zoom));
            PointF dmnsion_h_endP = new PointF(70 - 17, (_pboxFrame.Location.Y - 3) + locY + DispHt_float);// * _windoorModel.WD_zoom));

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

        public void remove_Lst_arrowHt(ICustomArrowHeadUC customArrowHeadUc)
        {
            lst_arrowHt.Remove(customArrowHeadUc);
        }

        public void remove_Lst_arrowWd(ICustomArrowHeadUC customArrowHeadUc)
        {
            lst_arrowWd.Remove(customArrowHeadUc);
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
            binding.Add("pboxFrame", new Binding("Image", _windoorModel, "WD_flpImage", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

    }
}
