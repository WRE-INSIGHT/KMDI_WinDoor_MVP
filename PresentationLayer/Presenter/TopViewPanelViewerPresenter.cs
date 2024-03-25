using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class TopViewPanelViewerPresenter : ITopViewPanelViewerPresenter
    {
        ITopViewPanelViewer _topViewPanelViewer;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IWindoorModel _windoorModel;
        private ITopViewPresenter _topviewPresenter;

        PictureBox _pboxFrame;
        Panel _pnlPanelling;


        public TopViewPanelViewerPresenter(ITopViewPanelViewer topViewPanelViewer)
        {
            _topViewPanelViewer = topViewPanelViewer;

            _pboxFrame = _topViewPanelViewer.GetTopViewPictureBox();

            SubscribeToEventSetUp();
        }
        private void SubscribeToEventSetUp()
        {
            _topViewPanelViewer.TopViewPanelViewLoadEventRaised += _topViewPanelViewer_TopViewPanelViewLoadEventRaised;
            _topViewPanelViewer.pnlSlidingArrowPaintEventRaised += _topViewPanelViewer_pnlSlidingArrowPaintEventRaised;
        }

        private void _topViewPanelViewer_pnlSlidingArrowPaintEventRaised(object sender, PaintEventArgs e)
        {
            Panel basePL = (Panel)sender;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            int pnl_width = basePL.Width,
                pnl_height = basePL.Height,

                locX = 70,
                width_reduce = 140;

            Rectangle pnl_rectangle = new Rectangle(locX, 0,
                                                    pnl_width - width_reduce, pnl_height - 2);

         //   g.DrawRectangle(new Pen(Color.Black, 1), pnl_rectangle);

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
            if (total_panel > 1 || total_mpanel >= 1) //multiplePanel
            {
                int TotalArrowWidthBounds = basePL.Width - 70,
                    TotalArrowHeightBounds = basePL.Height - 35;


                foreach (KeyValuePair<int, decimal> KV_WD in _windoorModel.Dictionary_wd_redArrowLines)
                {
                    pnl_rectangle.Width = (pnl_width - width_reduce) / 2;
                    g.DrawRectangle(new Pen(Color.Red, 1), pnl_rectangle);

                    pnl_rectangle.X += (pnl_width - width_reduce) / 2;
                    //  decimal WidthPercentage = KV_WD.Value / _windoorModel.WD_width,
                    //          FinalWidth = WidthPercentage * TotalArrowWidthBounds;
                    //  locX = Draw_Arrow_Width(KV_WD.Value, FinalWidth, e, locX, dmnsion_font_wd, ctrl_Y);
                }
              // foreach (KeyValuePair<int, decimal> KV_Ht in _windoorModel.Dictionary_ht_redArrowLines)
              // {
              //   //  decimal HeightPercentage = KV_Ht.Value / _windoorModel.WD_height,
              //   //          Finalheight = HeightPercentage * TotalArrowHeightBounds;
              //     //   locY = Draw_Arrow_Height(KV_Ht.Value, Finalheight, e, locY, dmnsion_font_ht, ctrl_Y);
              // }
            }


              
            //    Panel basePL = (Panel)sender;
            //    PictureBox pbox = (PictureBox)basePL.Controls[0];
            //    //dito ilagay ang drawing ng red-arrowlines
            //    Graphics g = e.Graphics;
            //    g.SmoothingMode = SmoothingMode.HighQuality;
            //
            //    int ctrl_Y = 35;
            //    float zoom = _windoorModel.WD_zoom_forImageRenderer;
            //
            //    Pen redP = new Pen(Color.Red);
            //    redP.Width = 3.5f;
            //
            //    Font dmnsion_font_wd = new Font("Segoe UI", 22, FontStyle.Bold);
            //    Font dmnsion_font_ht = new Font("Segoe UI", 17, FontStyle.Bold);
            //
            //    int total_frame = _windoorModel.lst_frame.Count;
            //    int total_panel = 0, total_mpanel = 0;
            //    foreach(IFrameModel frame in _windoorModel.lst_frame)
            //    {
            //        total_panel += frame.Lst_Panel.Count;
            //        total_mpanel += frame.Lst_MultiPanel.Count;
            //        foreach(IMultiPanelModel mpnl in frame.Lst_MultiPanel)
            //        {
            //            total_panel += mpnl.MPanelLst_Panel.Count;
            //        }
            //    }
            //
            //    if(total_panel > 1 || total_mpanel >=1) //multiplePanel
            //    {
            //        int TotalArrowWidthBounds = basePL.Width - 70,
            //            TotalArrowHeightBounds = basePL.Height - 35;
            //
            //        float locX = 0;
            //        foreach(KeyValuePair<int, decimal> KV_WD in _windoorModel.Dictionary_wd_redArrowLines)
            //        {
            //            decimal WidthPercentage = KV_WD.Value / _windoorModel.WD_width,
            //                    FinalWidth = WidthPercentage * TotalArrowWidthBounds;
            //            locX = Draw_Arrow_Width(KV_WD.Value, FinalWidth, e, locX, dmnsion_font_wd, ctrl_Y);
            //        }
            //        float locY = 0;
            //        foreach(KeyValuePair<int, decimal> KV_Ht in _windoorModel.Dictionary_ht_redArrowLines)
            //        {
            //            decimal HeightPercentage = KV_Ht.Value / _windoorModel.WD_height,
            //                    Finalheight = HeightPercentage * TotalArrowHeightBounds;
            //         //   locY = Draw_Arrow_Height(KV_Ht.Value, Finalheight, e, locY, dmnsion_font_ht, ctrl_Y);
            //        }
            //    }
            //    else if (total_panel == 1 && total_mpanel == 0) // panel
            //    {
            //        string dmnsion_w = _windoorModel.WD_width.ToString();
            //        Point dmnsion_w_startP = new Point(pbox.Location.X, ctrl_Y - 17);
            //        Point dmnsion_w_endP = new Point(pbox.Location.X + pbox.Width - 3, ctrl_Y - 17);
            //
            //        Size s = TextRenderer.MeasureText(dmnsion_w, dmnsion_font_wd);
            //        double mid = (dmnsion_w_startP.X + dmnsion_w_endP.X) / 2;
            //
            //        //arrow for WIDTH
            //        Point[] arrwhd_pnts_W1 =
            //        {
            //            new Point(dmnsion_w_startP.X, dmnsion_w_startP.Y - 10),
            //            dmnsion_w_startP,
            //            new Point(dmnsion_w_startP.X, dmnsion_w_startP.Y + 10),
            //        };
            //        Point[] arrwhd_pnts_W2 =
            //        {
            //            new Point(dmnsion_w_endP.X, dmnsion_w_endP.Y - 10),
            //            dmnsion_w_endP,
            //            new Point(dmnsion_w_endP.X, dmnsion_w_endP.Y + 10)
            //        };
            //
            //        g.DrawLines(redP, arrwhd_pnts_W1);
            //        g.DrawLine(redP, dmnsion_w_startP, dmnsion_w_endP);
            //        g.DrawLines(redP, arrwhd_pnts_W2);
            //        TextRenderer.DrawText(g,
            //                              dmnsion_w,
            //                              dmnsion_font_wd,
            //                              new Rectangle(new Point((int)(mid - (s.Width / 2)), (ctrl_Y - s.Height) / 2),
            //                                            new Size(s.Width, s.Height)),
            //                              Color.Black,
            //                              Color.White,
            //                              TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            //        //arrow for WIDTH
            //
            //        //arrow for HEIGHT
            //    //    string dmnsion_h = _windoorModel.WD_height.ToString();
            //    //    Point dmnsion_h_startP = new Point(70 - 17, pbox.Location.Y);
            //    //    Point dmnsion_h_endP = new Point(70 - 17, pbox.Location.Y + (pbox.Height - 3));
            //    //
            //    //    Size s2 = TextRenderer.MeasureText(dmnsion_h, dmnsion_font_ht);
            //    //    double mid2 = (dmnsion_h_startP.Y + dmnsion_h_endP.Y) / 2;
            //    //
            //    //    Point[] arrwhd_pnts_H1 =
            //    //    {
            //    //        new Point(dmnsion_h_startP.X - 10, dmnsion_h_startP. Y + 10),
            //    //        dmnsion_h_startP,
            //    //        new Point(dmnsion_h_endP.X + 10, dmnsion_h_endP.Y - 10)
            //    //    };
            //    //
            //    //    Point[] arrwhd_pnts_H2 =
            //    //    {
            //    //        new Point(dmnsion_h_endP.X - 10, dmnsion_h_endP.Y - 10),
            //    //        dmnsion_h_endP,
            //    //        new Point(dmnsion_h_endP.X + 10, dmnsion_h_endP .Y - 10)
            //    //    };
            //    //    g.DrawLines(redP, arrwhd_pnts_H1);
            //    //    g.DrawLine(redP, dmnsion_h_startP, dmnsion_h_endP);
            //    //    g.DrawLines(redP, arrwhd_pnts_H2);
            //    //    TextRenderer.DrawText(g,
            //    //                          dmnsion_h,
            //    //                          dmnsion_font_ht,
            //    //                          new Rectangle(new Point((70 - s.Width) / 2, (int)(mid2 - (s2.Height / 2))),
            //    //                                        new Size(s2.Width, s2.Height)),
            //    //                          Color.Black,
            //    //                          Color.White,
            //    //                          TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            //        //arrow for Height
            //    }
            //    Bitmap bm = new Bitmap(basePL.Size.Width, basePL.Size.Height);
            //  //  basePL.DrawToBitmap(bm, new Rectangle(0, 0, basePL.Size.Width, basePL.Size.Height));
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

            PointF dmnsion_w_startP = new PointF((_pboxFrame.Location.X + locX ),// * _windoorModel.WD_zoom),
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
        private void _topViewPanelViewer_TopViewPanelViewLoadEventRaised(object sender, EventArgs e)
        {
            PictureBox pbox_Topview = (PictureBox)_topViewPanelViewer.GetTopViewPictureBox();
            int points_for_topview = _topviewPresenter.TotalPoints;
            Console.WriteLine("Viewer Points: " + points_for_topview);

            if(points_for_topview == 12)
            {
                pbox_Topview.Image = Properties.Resources.Combination1;
            }
            else if (points_for_topview == 10)
            {
                pbox_Topview.Image = Properties.Resources.Combination2;
            }
            else if (points_for_topview == 8)
            {
                pbox_Topview.Image = Properties.Resources.Combination3;
            }
            else if (points_for_topview == 14)
            {
                pbox_Topview.Image = Properties.Resources.Combination4;
            }

                pbox_Topview.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public ITopViewPanelViewer GetSetTopViewSlidingPanellingView()
        {
            return _topViewPanelViewer;
        }
        public ITopViewPanelViewerPresenter CreateNewInstance(IUnityContainer unityC,
                                                        IMainPresenter mainPresenter,
                                                        ITopViewPresenter topviewPresenter,
                                                        IWindoorModel windoorModel)
        {
            unityC
                .RegisterType<ITopViewPanelViewer, TopViewPanelViewer>()
                .RegisterType<ITopViewPanelViewerPresenter, TopViewPanelViewerPresenter>();
            TopViewPanelViewerPresenter TopView = unityC.Resolve<TopViewPanelViewerPresenter>();
            TopView._unityC = unityC;
            TopView._mainPresenter = mainPresenter;
            TopView._topviewPresenter = topviewPresenter;
            TopView._windoorModel = windoorModel;

            return TopView; 
        }
    }
}
