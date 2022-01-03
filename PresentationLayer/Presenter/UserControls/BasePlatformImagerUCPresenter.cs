using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.CommonMethods;
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
        FlowLayoutPanel _flpMain;

        IWindoorModel _windoorModel;
        IMainPresenter _mainPresenter;

        CommonFunctions _commonfunc = new CommonFunctions();

        public BasePlatformImagerUCPresenter(IBasePlatformImagerUC basePlatformImagerUC)
        {
            _basePlatformImagerUC = basePlatformImagerUC;
            _flpMain = _basePlatformImagerUC.GetFlpMain();
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

        private Control FindFrameControl(string frameName, int _frameID)
        {
            Control frame = new Control();
            var frameUC = _commonfunc.GetAll(_flpMain, frameName);
            foreach (IFrameUC fr in frameUC)
            {
                if (fr.frameID == _frameID)
                {
                    frame = ((UserControl)fr);
                }
            }
            return frame;
        }

        private void _basePlatformImagerUC_basePlatformPaintEventRaised(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            UserControl basePL = (UserControl)sender;
            FlowLayoutPanel _flpMain = (FlowLayoutPanel)basePL.Controls[0];
            //dito ilagay ang drawing ng red-arrowlines
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int ctrl_Y = 35;
            float zoom = _windoorModel.WD_zoom_forImageRenderer;

            Pen redP = new Pen(Color.Red);
            redP.Width = 3.5f;

            //Font dmnsion_font = new Font("Segoe UI", 12, FontStyle.Bold);
            Font dmnsion_font_wd = new Font("Segoe UI", 22, FontStyle.Bold);
            Font dmnsion_font_ht = new Font("Segoe UI", 17, FontStyle.Bold);

            //if (zoom == 0.26f)
            //{
            //    dmnsion_font_wd = new Font("Segoe UI", (20 * zoom) + 2, FontStyle.Bold);
            //    dmnsion_font_ht = new Font("Segoe UI", (20 * zoom) + 2, FontStyle.Bold);
            //}
            //else if (zoom == 0.17f)
            //{
            //    dmnsion_font_wd = new Font("Segoe UI", (20 * zoom) + 4, FontStyle.Bold);
            //    dmnsion_font_ht = new Font("Segoe UI", (20 * zoom) + 4, FontStyle.Bold);
            //}
            //else if (zoom == 0.13f)
            //{
            //    dmnsion_font_wd = new Font("Segoe UI", (20 * zoom) + 5, FontStyle.Bold);
            //    dmnsion_font_ht = new Font("Segoe UI", (20 * zoom) + 5, FontStyle.Bold);
            //}
            //else if (zoom == 0.10f)
            //{
            //    dmnsion_font_wd = new Font("Segoe UI", (20 * zoom) + 6, FontStyle.Bold);
            //    dmnsion_font_ht = new Font("Segoe UI", (20 * zoom) + 6, FontStyle.Bold);
            //}
            //else if (zoom == 0.50f)
            //{
            //    dmnsion_font_wd = new Font("Segoe UI", (40 * zoom) - 3, FontStyle.Bold);
            //    dmnsion_font_ht = new Font("Segoe UI", (40 * zoom) - 3, FontStyle.Bold);
            //}
            //else if (zoom == 1.0f)
            //{
            //    dmnsion_font_wd = new Font("Segoe UI", (20 * zoom) - 3, FontStyle.Bold);
            //    dmnsion_font_ht = new Font("Segoe UI", (20 * zoom) - 3, FontStyle.Bold);
            //}

            int total_panel = 0, total_mpanel = 0;
            foreach (IFrameModel frame in _windoorModel.lst_frame)
            {
                total_panel += frame.Lst_Panel.Count();
                total_mpanel += frame.Lst_MultiPanel.Count();
                foreach (IMultiPanelModel mpnl in frame.Lst_MultiPanel)
                {
                    total_panel += mpnl.MPanelLst_Panel.Count();
                }
            }

            if (total_panel > 1 || total_mpanel >= 1)
            {
                decimal[,] actual_arr_wd_locX = new decimal[total_panel, 2];
                decimal[,] actual_arr_ht_locY = new decimal[total_panel, 2];
                int ndx = 0;

                if (total_panel > 1 && total_mpanel == 0)
                {
                    foreach (IFrameModel frame in _windoorModel.lst_frame)
                    {
                        foreach (IPanelModel pnl in frame.Lst_Panel)
                        {
                            Control ctrl = FindFrameControl(frame.Frame_Name, frame.Frame_ID);
                            string Wd_decimal_str = "0." + pnl.Panel_DisplayWidthDecimal;
                            string Ht_decimal_str = "0." + pnl.Panel_DisplayHeightDecimal;

                            decimal DispWd_dec = (decimal)pnl.Panel_DisplayWidth + Convert.ToDecimal(Wd_decimal_str);
                            decimal DispHt_dec = (decimal)pnl.Panel_DisplayHeight + Convert.ToDecimal(Ht_decimal_str);

                            actual_arr_wd_locX[ndx, 0] = DispWd_dec;
                            actual_arr_ht_locY[ndx, 0] = DispHt_dec;

                            actual_arr_wd_locX[ndx, 1] = ctrl.PointToScreen(((Form)_mainPresenter.GetMainView()).Location).X;// ((Form)_mainPresenter.GetMainView()).PointToClient(ctrl.Location).X; //ctrl.Location.X;
                            actual_arr_ht_locY[ndx, 1] = ctrl.PointToScreen(((Form)_mainPresenter.GetMainView()).Location).Y;// ((Form)_mainPresenter.GetMainView()).PointToClient(ctrl.Location).X; //ctrl.Location.X;
                            ndx++;
                        }
                    }
                }
                else if (total_mpanel >= 1)
                {
                    foreach (IFrameModel frame in _windoorModel.lst_frame)
                    {
                        foreach (IMultiPanelModel mpnl in frame.Lst_MultiPanel)
                        {
                            foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                            {
                                Control ctrl = mpnl.MPanelLst_Objects.Find(obj => obj.Name == pnl.Panel_Name);
                                string Wd_decimal_str = "0." + pnl.Panel_DisplayWidthDecimal;

                                string Ht_decimal_str = "0." + pnl.Panel_DisplayHeightDecimal;

                                decimal DispWd_dec = (decimal)pnl.Panel_DisplayWidth + Convert.ToDecimal(Wd_decimal_str);
                                decimal DispHt_dec = (decimal)pnl.Panel_DisplayHeight + Convert.ToDecimal(Ht_decimal_str);

                                actual_arr_wd_locX[ndx, 0] = DispWd_dec;
                                actual_arr_ht_locY[ndx, 0] = DispHt_dec;

                                actual_arr_wd_locX[ndx, 1] = ctrl.PointToScreen(((Form)_mainPresenter.GetMainView()).Location).X;// ((Form)_mainPresenter.GetMainView()).PointToClient(ctrl.Location).X; //ctrl.Location.X;
                                actual_arr_ht_locY[ndx, 1] = ctrl.PointToScreen(((Form)_mainPresenter.GetMainView()).Location).Y;// ((Form)_mainPresenter.GetMainView()).PointToClient(ctrl.Location).X; //ctrl.Location.X;
                                ndx++;
                            }
                        }
                    }
                }


                List<decimal> wds = _mainPresenter.basePlatform_MainPresenter.WidthList_ToPaint(_windoorModel.WD_width, actual_arr_wd_locX);
                List<decimal> hts = _mainPresenter.basePlatform_MainPresenter.HeightList_ToPaint(_windoorModel.WD_height, actual_arr_ht_locY);

                float locX = 0;
                foreach (decimal wd in wds)
                {
                    string dmnsion_w = wd.ToString();

                    if (dmnsion_w.Contains(".0"))
                    {
                        dmnsion_w = dmnsion_w.Replace(".0", "");
                    }

                    float DispWd_float = float.Parse(dmnsion_w);

                    PointF dmnsion_w_startP = new PointF(_flpMain.Location.X + (locX * _windoorModel.WD_zoom_forImageRenderer),
                                                         (ctrl_Y - 17));// * _windoorModel.WD_zoom);
                    PointF dmnsion_w_endP = new PointF((_flpMain.Location.X - 3) + ((locX + DispWd_float) * _windoorModel.WD_zoom_forImageRenderer),
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

                    if (_flpMain.Controls.OfType<IFrameImagerUC>().Where(fr => fr.thisVisible == true).Count() > 0)
                    {
                        g.DrawLines(redP, arrwhd_pnts_W1);
                        g.DrawLine(redP, dmnsion_w_startP, dmnsion_w_endP);
                        g.DrawLines(redP, arrwhd_pnts_W2);
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
                }

                float locY = 0;
                foreach (decimal ht in hts)
                {
                    //arrow for HEIGHT
                    string dmnsion_h = ht.ToString();
                    float DispHt_float = float.Parse(dmnsion_h);

                    PointF dmnsion_h_startP = new PointF(70 - 17, _flpMain.Location.Y + (locY * _windoorModel.WD_zoom_forImageRenderer));
                    PointF dmnsion_h_endP = new PointF(70 - 17, (_flpMain.Location.Y - 3) + ((locY + DispHt_float) * _windoorModel.WD_zoom_forImageRenderer));

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

                    if (_flpMain.Controls.OfType<IFrameImagerUC>().Where(fr => fr.thisVisible == true).Count() > 0)
                    {
                        g.DrawLines(redP, arrwhd_pnts_H1);
                        g.DrawLine(redP, dmnsion_h_startP, dmnsion_h_endP);
                        g.DrawLines(redP, arrwhd_pnts_H2);
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
                }
            }
            else if (total_panel == 1 && total_mpanel == 0)
            {
                string dmnsion_w = _windoorModel.WD_width.ToString();
                Point dmnsion_w_startP = new Point(_flpMain.Location.X, ctrl_Y - 17);
                Point dmnsion_w_endP = new Point(_flpMain.Location.X + _flpMain.Width - 3, ctrl_Y - 17);

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

                if (_flpMain.Controls.OfType<IFrameImagerUC>().Where(fr => fr.thisVisible == true).Count() > 0)
                {
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
                }
                //arrow for WIDTH


                //arrow for HEIGHT
                string dmnsion_h = _windoorModel.WD_height.ToString();
                Point dmnsion_h_startP = new Point(70 - 17, _flpMain.Location.Y);
                Point dmnsion_h_endP = new Point(70 - 17, _flpMain.Location.Y + (_flpMain.Height - 3));

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

                if (_flpMain.Controls.OfType<IFrameImagerUC>().Where(fr => fr.thisVisible == true).Count() > 0)
                {
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
                }
                //arrow for HEIGHT
            }

            Bitmap bm = new Bitmap(basePL.Size.Width, basePL.Size.Height);
            basePL.DrawToBitmap(bm, new Rectangle(0, 0, basePL.Size.Width, basePL.Size.Height));

            _windoorModel.WD_image = bm;
            //bm.Save(@"C:\Users\KMDI\Pictures\Saved Pictures\2.png");
        }

        public IBasePlatformImagerUC GetBasePlatformImagerUC()
        {
            _basePlatformImagerUC.ThisBinding(CreateBindingDictionary());
            return _basePlatformImagerUC;
        }

        public void BringToFront_baseImager()
        {
            _basePlatformImagerUC.BringToFront_baseImager();
        }

        public void SendToBack_baseImager()
        {
            _basePlatformImagerUC.SendToBack_baseImager();
        }

        public IBasePlatformImagerUCPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IBasePlatformImagerUC, BasePlatformImagerUC>()
                .RegisterType<IBasePlatformImagerUCPresenter, BasePlatformImagerUCPresenter>();
            BasePlatformImagerUCPresenter imagerUCP = unityC.Resolve<BasePlatformImagerUCPresenter>();
            imagerUCP._windoorModel = windoorModel;
            imagerUCP._mainPresenter = mainPresenter;
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

        public void Invalidate_flpMain()
        {
            _basePlatformImagerUC.GetFlpMain().Invalidate();
        }

        public void DeleteControl(UserControl frameImagerUC)
        {
            _flpMain.Controls.Remove(frameImagerUC);
        }
    }
}
