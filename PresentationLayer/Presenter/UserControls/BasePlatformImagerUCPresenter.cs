using CommonComponents;
using ModelLayer.Model.Quotation.Divider;
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

            float zoom = _windoorModel.WD_zoom_forImageRenderer;

            foreach (IFrameModel frame in _windoorModel.lst_frame)
            {
                int flocX = 0, flocY = 0,
                    frame_pads_all = frame.FrameImageRenderer_Padding_int.All;

                Draw_Frame(e, frame, new Point(flocX, flocY));

                flocX += frame.Frame_Width;
                flocY += frame.Frame_Height;

                if (frame.Lst_Panel.Count == 1)
                {
                    int plocX = 0, plocY = 0;

                    Draw_Panel(e, frame.Lst_Panel[0], new Point(plocX + frame_pads_all, plocY + frame_pads_all));
                }
                else if (frame.Lst_MultiPanel.Count >= 1)
                {
                    foreach (IMultiPanelModel mpnl in frame.Lst_MultiPanel)
                    {
                        int mlocX = 0, mlocY = 0,
                            objLocX = 0, objLocY = 0;

                        if (mpnl.MPanel_Parent.Name.Contains("Frame"))
                        {
                            mlocX += frame_pads_all;
                            mlocY += frame_pads_all;

                            Draw_MultiPanel(e, mpnl, new Point(mlocX, mlocY));

                            if (mpnl.MPanel_Type == "Mullion")
                            {
                                foreach (Control ctrl in mpnl.MPanelLst_Objects)
                                {
                                    if (ctrl.Name.Contains("PanelUC_"))
                                    {
                                        IPanelModel panelModel = mpnl.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name);
                                        objLocX += mlocX; //addition of frame_pads and div wd
                                        objLocY = mlocY;

                                        Draw_Panel(e, panelModel, new Point(objLocX, objLocY));

                                        objLocX += panelModel.PanelImageRenderer_Width;
                                    }
                                    else if (ctrl.Name.Contains("MullionUC_"))
                                    {
                                        IDividerModel divModel = mpnl.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name);
                                        int locY_deduct = 0;

                                        if (zoom == 1.0f)
                                        {
                                            locY_deduct = 10;
                                        }
                                        else if (zoom == 0.50f)
                                        {
                                            locY_deduct = 5;
                                        }

                                        Draw_Divider(e, divModel, new Point(objLocX, objLocY - locY_deduct));
                                    }
                                }
                            }
                            else if (mpnl.MPanel_Type == "Transom")
                            {
                                foreach (Control ctrl in mpnl.MPanelLst_Objects)
                                {
                                    if (ctrl.Name.Contains("PanelUC_"))
                                    {
                                        IPanelModel panelModel = mpnl.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name);
                                        objLocX = mlocX; //addition of frame_pads and div wd
                                        objLocY += mlocY;

                                        Draw_Panel(e, panelModel, new Point(objLocX, objLocY));

                                        objLocY += panelModel.PanelImageRenderer_Height;
                                    }
                                    else if (ctrl.Name.Contains("TransomUC_"))
                                    {
                                        IDividerModel divModel = mpnl.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name);
                                        int locX_deduct = 0;

                                        if (zoom == 1.0f)
                                        {
                                            locX_deduct = 10;
                                        }
                                        else if (zoom == 0.50f)
                                        {
                                            locX_deduct = 5;
                                        }

                                        Draw_Divider(e, divModel, new Point(objLocX - locX_deduct, objLocY));
                                    }
                                }
                            }
                        }
                        else if (mpnl.MPanel_Parent.Name.Contains("Multi"))
                        {

                        }
                    }
                }
            }

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

        private void _basePlatformImagerUC_basePlatformPaintEventRaised(object sender, PaintEventArgs e)
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
                                              SystemColors.Control,
                                              TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    //}
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
                                              SystemColors.Control,
                                              TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    //}
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

            Bitmap bm = new Bitmap(basePL.Size.Width, basePL.Size.Height);
            basePL.DrawToBitmap(bm, new Rectangle(0, 0, basePL.Size.Width, basePL.Size.Height));

            _windoorModel.WD_image = bm;
            //bm.Save(@"C:\Users\KMDI\Pictures\Saved Pictures\2.png");
        }

        private void Draw_Frame(PaintEventArgs e, IFrameModel frameModel, Point fPoint)
        {
            Pen blkPen = new Pen(Color.Black);
            Graphics g = e.Graphics;

            int fr_pads = frameModel.FrameImageRenderer_Padding_int.All;

            Rectangle pnl_inner = new Rectangle(new Point(fr_pads, fr_pads),
                                                new Size(frameModel.FrameImageRenderer_Width - (fr_pads * 2),
                                                         frameModel.FrameImageRenderer_Height - (fr_pads * 2)));

            g.SmoothingMode = SmoothingMode.AntiAlias;


            int pInnerX = pnl_inner.Location.X,
            pInnerY = pnl_inner.Location.Y,
            pInnerWd = pnl_inner.Width,
            pInnerHt = pnl_inner.Height;

            Point[] corner_points = new[]
            {
                new Point(fPoint.X, fPoint.Y),
                new Point(pInnerX, pInnerY),
                new Point(frameModel.FrameImageRenderer_Width, fPoint.Y),
                new Point(pInnerX + pInnerWd, pInnerY),
                new Point(fPoint.X, frameModel.FrameImageRenderer_Height),
                new Point(pInnerX, pInnerY + pInnerHt),
                new Point(frameModel.FrameImageRenderer_Width, frameModel.FrameImageRenderer_Height),
                new Point(pInnerX + pInnerWd,pInnerY + pInnerHt)
            };

            for (int i = 0; i < corner_points.Length - 1; i += 2)
            {
                g.DrawLine(blkPen, corner_points[i], corner_points[i + 1]);
            }

            //if (pfr.Controls.Count == 0)
            //{
                g.DrawRectangle(blkPen, pnl_inner);
            //}

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(fPoint.X,
                                                                   fPoint.Y,
                                                                   frameModel.Frame_Width - w,
                                                                   frameModel.Frame_Height - w));
        }

        private void Draw_Panel(PaintEventArgs e, IPanelModel panelModel, Point Ppoint)
        {
            Graphics g = e.Graphics;
            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            int client_wd = 0, client_ht = 0;

            client_wd = panelModel.PanelImageRenderer_Width;
            client_ht = panelModel.PanelImageRenderer_Height;

            Rectangle panel_bounds = new Rectangle(Ppoint, new Size(client_wd, client_ht));

            g.SmoothingMode = SmoothingMode.HighQuality;

            int font_size = 30,
                outer_line = 10,
                inner_line = 15;

            if (panelModel.PanelImageRenderer_Zoom == 0.28f)
            {
                font_size = 25;
            }
            else if (panelModel.PanelImageRenderer_Zoom == 0.19f)
            {
                font_size = 15;
                outer_line = 5;
                inner_line = 8;
            }
            else if (panelModel.PanelImageRenderer_Zoom == 0.14f)
            {
                font_size = 13;
                outer_line = 3;
                inner_line = 7;
            }
            else if (panelModel.PanelImageRenderer_Zoom == 0.10f)
            {
                font_size = 8;
                outer_line = 3;
                inner_line = 7;
            }

            Rectangle outer_bounds = new Rectangle(Ppoint.X,
                                                   Ppoint.Y,
                                                   client_wd - w,
                                                   client_ht - w);

            g.DrawRectangle(new Pen(Color.Black, w), outer_bounds);
            g.FillRectangle(Brushes.DarkGray, outer_bounds);

            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(Ppoint.X + outer_line,
                                                                   Ppoint.Y + outer_line,
                                                                   (client_wd - (outer_line * 2)) - w,
                                                                   (client_ht - (outer_line * 2)) - w));

            

            if (panelModel.Panel_Type == "Fixed Panel")
            {
                if (panelModel.Panel_Orient == true)
                {
                    g.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(Ppoint.X + inner_line,
                                                                           Ppoint.Y + inner_line,
                                                                           (client_wd - (inner_line * 2)) - w,
                                                                           (client_ht - (inner_line * 2)) - w));

                }

                Font drawFont = new Font("Times New Roman", font_size);// * zoom);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString("F", drawFont, new SolidBrush(Color.Black), panel_bounds, drawFormat);
            }
            else if (panelModel.Panel_Type == "Casement Panel")
            {
                g.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(Ppoint.X + inner_line,
                                                                       Ppoint.Y + inner_line,
                                                                       (client_wd - (inner_line * 2)) - w,
                                                                       (client_ht - (inner_line * 2)) - w));

                Point sashPoint = new Point(Ppoint.X, Ppoint.Y);

                Pen dgrayPen = new Pen(Color.DimGray);
                dgrayPen.DashStyle = DashStyle.Dash;
                dgrayPen.Width = 3;

                int sashW = client_wd,
                    sashH = client_ht;

                if (panelModel.Panel_Orient == true)//Left
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + sashW, sashPoint.Y),
                                             new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))),
                                         new Point(sashPoint.X + sashW, sashPoint.Y + sashH));
                }
                else if (panelModel.Panel_Orient == false)//Right
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                         new Point(sashPoint.X + sashW, (sashPoint.Y + (sashH / 2))));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + sashW, (sashPoint.Y + (sashH / 2))),
                                         new Point(sashPoint.X, sashH + sashPoint.Y));
                }
            }
            else if (panelModel.Panel_Type == "Awning Panel")
            {
                g.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(Ppoint.X + inner_line,
                                                                       Ppoint.Y + inner_line,
                                                                       (client_wd - (inner_line * 2)) - w,
                                                                       (client_ht - (inner_line * 2)) - w));

                Point sashPoint = new Point(Ppoint.X, Ppoint.Y);

                Pen dgrayPen = new Pen(Color.DimGray);
                dgrayPen.DashStyle = DashStyle.Dash;
                dgrayPen.Width = 3;

                int sashW = client_wd,
                    sashH = client_ht;

                if (panelModel.Panel_Orient == true)
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                         new Point(sashPoint.X + (sashW / 2), sashPoint.Y + sashH));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW / 2), sashPoint.Y + sashH),
                                         new Point(sashPoint.X + sashW, sashPoint.Y));
                }
                else if (panelModel.Panel_Orient == false)
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y + sashH),
                                     new Point(sashPoint.X + (sashW / 2), sashPoint.Y));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW / 2), sashPoint.Y),
                                         new Point(sashPoint.X + sashW, sashH + sashPoint.Y));
                }
            }
            else if (panelModel.Panel_Type == "Sliding Panel")
            {
                g.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(Ppoint.X + inner_line,
                                                                       Ppoint.Y + inner_line,
                                                                       (client_wd - (inner_line * 2)) - w,
                                                                       (client_ht - (inner_line * 2)) - w));
                Point sashPoint = new Point(Ppoint.X + 25, Ppoint.Y);

                int sashW = client_wd,
                    sashH = client_ht;

                float arwStart_x1 = sashPoint.X + (sashW / 20),
                      center_y1 = sashPoint.Y + (sashH / 2),
                      arwEnd_x2 = ((sashPoint.X + sashW) - arwStart_x1) + (sashW / 20),
                      arwHeadUp_x3,
                      arwHeadUp_y3 = center_y1 - (center_y1 / 4),
                      arwHeadUp_x4,
                      arwHeadUp_y4 = center_y1 + (center_y1 / 4);


                if (panelModel.Panel_Orient == true)
                {
                    arwHeadUp_x3 = sashPoint.X + arwStart_x1 + (sashW / 10);
                    arwHeadUp_x4 = sashPoint.X + arwStart_x1 + (sashW / 10);

                    g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x3, arwHeadUp_y3),
                                                     new PointF(arwStart_x1, center_y1));
                    g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x4, arwHeadUp_y4),
                                                     new PointF(arwStart_x1, center_y1));
                }
                else if (panelModel.Panel_Orient == false)
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
        }

        private void Draw_MultiPanel(PaintEventArgs e, IMultiPanelModel mpanelModel, Point Mpoint)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float zoom = mpanelModel.MPanelImageRenderer_Zoom;

            int client_wd = mpanelModel.MPanelImageRenderer_Width, 
                client_ht = mpanelModel.MPanelImageRenderer_Height;

            Rectangle mpnl_bounds = new Rectangle(Mpoint, new Size(client_wd, client_ht));
            SolidBrush mpnl_sBrush = new SolidBrush(Color.MistyRose);

            if (mpanelModel.MPanel_Type == "Mullion")
            {
                mpnl_sBrush = new SolidBrush(Color.MistyRose);
            }
            else if (mpanelModel.MPanel_Type == "Transom")
            {
                mpnl_sBrush = new SolidBrush(SystemColors.ActiveCaption);
            }

            g.FillRectangle(mpnl_sBrush, mpnl_bounds);
            g.DrawRectangle(new Pen(Color.Black, 1), mpnl_bounds);
        }

        private void Draw_Divider(PaintEventArgs e, IDividerModel divModel, Point Dpoint)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.HighQuality;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            IMultiPanelModel parent_mpnl = divModel.Div_MPanelParent;

            int client_wd = divModel.DivImageRenderer_Width,
                client_ht = divModel.DivImageRenderer_Height;

            Rectangle div_rect = new Rectangle(Dpoint.X,
                                               Dpoint.Y,
                                               client_wd - w,
                                               client_ht - w);

            SolidBrush div_sBrush = new SolidBrush(Color.RosyBrown);

            if (divModel.Div_Type == DividerModel.DividerType.Mullion)
            {
                div_sBrush = new SolidBrush(Color.RosyBrown);
            }
            else if (divModel.Div_Type == DividerModel.DividerType.Transom)
            {
                div_sBrush = new SolidBrush(Color.PowderBlue);
            }

            g.FillRectangle(div_sBrush, div_rect);
            g.DrawRectangle(new Pen(Color.Black, w), div_rect);
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
