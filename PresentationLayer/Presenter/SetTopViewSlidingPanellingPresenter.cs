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
    public class SetTopViewSlidingPanellingPresenter : ISetTopViewSlidingPanellingPresenter
    {
        ISetTopViewSlidingPanellingView _setTopViewSlidingPanelling;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IWindoorModel _windoorModel;
        //private IItemInfoUCPresenter _itemInfoUCP;

        PictureBox _pboxFrame;
        Panel _pnlPanelling;

        int pnlLeftCounter = 0,
            pnlRightCounter = 0,
            line_X_Distance,
            pnlCount;
        string lineLocation;


        public SetTopViewSlidingPanellingPresenter(ISetTopViewSlidingPanellingView setTopViewSlidingPanelling)
        {
            _setTopViewSlidingPanelling = setTopViewSlidingPanelling;

            _pboxFrame = _setTopViewSlidingPanelling.GetPbox();
            _pnlPanelling = _setTopViewSlidingPanelling.GetPnlPannelling();
            SubscribeToEventSetUp();
        }

        private void SubscribeToEventSetUp()
        {
            _setTopViewSlidingPanelling.SetTopViewSlidingPanellingViewLoadEventRaised += _setTopViewSlidingPanelling_SetTopViewSlidingPanellingViewLoadEventRaised;
            _setTopViewSlidingPanelling.pnlSlidingArrowPaintEventRaised += _setTopViewSlidingPanelling_pnlSlidingArrowPaintEventRaised;
            _setTopViewSlidingPanelling.pnlPanellingPaintEventRaised += _setTopViewSlidingPanelling_pnlPanellingPaintEventRaised;
            _setTopViewSlidingPanelling.btnAddLeftLineClickEventRaised += _setTopViewSlidingPanelling_btnAddLeftLineClickEventRaised;
            _setTopViewSlidingPanelling.btnMinusLeftLineClickEventRaised += _setTopViewSlidingPanelling_btnMinusLeftLineClickEventRaised;
            _setTopViewSlidingPanelling.btnAddRightLineClickEventRaised += _setTopViewSlidingPanelling_btnAddRightLineClickEventRaised;
            _setTopViewSlidingPanelling.btnMinusRightLineClickEventRaised += _setTopViewSlidingPanelling_btnMinusRightLineClickEventRaised;
        }

        private void _setTopViewSlidingPanelling_btnMinusRightLineClickEventRaised(object sender, EventArgs e)
        {
            if (pnlRightCounter != 0)
            {
                pnlRightCounter -= 1;
                _mainPresenter.frameModel_MainPresenter.Frame_FoldAndSlideTopViewRightCount = pnlRightCounter;
                _pnlPanelling.Invalidate();
                //_mainPresenter.basePlatformWillRenderImg_MainPresenter.Invalidate_flpMain();
                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            }
        }

        private void _setTopViewSlidingPanelling_btnAddRightLineClickEventRaised(object sender, EventArgs e)
        {
            lineLocation = "Right";
            foreach (IFrameModel fr in _windoorModel.lst_frame)
            {
                foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                {
                    if (mpnl.MPanel_DividerEnabled == false)
                    {
                        pnlCount = mpnl.MPanelLst_Panel.Count;
                    }

                }
            }
            if (pnlCount > (pnlLeftCounter + pnlRightCounter))
            {
                pnlRightCounter += 1;

                _mainPresenter.frameModel_MainPresenter.Frame_FoldAndSlideTopViewRightCount = pnlRightCounter;
                //_mainPresenter.basePlatformWillRenderImg_MainPresenter.Invalidate_flpMain();
                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                _pnlPanelling.Invalidate();
            }
        }

        private void _setTopViewSlidingPanelling_btnMinusLeftLineClickEventRaised(object sender, EventArgs e)
        {
            //if ((pnlLeftCounter + pnlRightCounter) != 0)
            //{
            //    _windoorModel.WD_SlidingTopViewVisibility = true;
            //    _windoorModel.WD_pboxImagerHeight = 50;
            //}
            //else
            //{
            //    _windoorModel.WD_SlidingTopViewVisibility = false;
            //    _windoorModel.WD_pboxImagerHeight = 100;
            //}
            //Console.WriteLine(_windoorModel.WD_SlidingTopViewVisibility);
            SetImagerHeight();

            if (pnlLeftCounter != 0)
            {
                pnlLeftCounter -= 1;
                _mainPresenter.frameModel_MainPresenter.Frame_FoldAndSlideTopViewLeftCount = pnlLeftCounter;
                //_mainPresenter.basePlatformWillRenderImg_MainPresenter.Invalidate_flpMain();
                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                _pnlPanelling.Invalidate();

            }

        }

        private void _setTopViewSlidingPanelling_btnAddLeftLineClickEventRaised(object sender, EventArgs e)
        {
            lineLocation = "Left";
            foreach (IFrameModel fr in _windoorModel.lst_frame)
            {
                foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                {
                    if (mpnl.MPanel_DividerEnabled == false)
                    {
                        pnlCount = mpnl.MPanelLst_Panel.Count;
                    }

                }
            }

            //if ((pnlLeftCounter + pnlRightCounter) != 0)
            //{
            //    _windoorModel.WD_SlidingTopViewVisibility = true;
            //    _windoorModel.WD_pboxImagerHeight = 50;
            //}
            //else
            //{
            //    _windoorModel.WD_SlidingTopViewVisibility = false;
            //    _windoorModel.WD_pboxImagerHeight = 100;
            //}
            //Console.WriteLine(_windoorModel.WD_SlidingTopViewVisibility);
            SetImagerHeight();

            if (pnlCount > (pnlLeftCounter + pnlRightCounter))
            {
                pnlLeftCounter += 1;
                _mainPresenter.frameModel_MainPresenter.Frame_FoldAndSlideTopViewLeftCount = pnlLeftCounter;
                _pnlPanelling.Invalidate();
                //_mainPresenter.basePlatformWillRenderImg_MainPresenter.Invalidate_flpMain();
                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();

            }


        }

        private void _setTopViewSlidingPanelling_pnlPanellingPaintEventRaised(object sender, PaintEventArgs e)
        {
            Panel basePL = (Panel)sender;
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (lineLocation != null)
            {
                int line_LtR_Y = _pnlPanelling.Height - 10;
                if (pnlCount != 0)
                {
                    line_X_Distance = _pnlPanelling.Width / pnlCount;
                }
                int InitialDistance = 50;
                g.DrawLine(new Pen(Color.Black, 5), new Point(InitialDistance, line_LtR_Y), new Point(_pnlPanelling.Width - 10, line_LtR_Y));

                for (int a = 0; a < pnlLeftCounter; a++)
                {
                    int x1 = InitialDistance,
                        x2 = InitialDistance + (line_X_Distance / 2);

                    if (a % 2 == 0)
                    {
                        g.DrawLine(new Pen(Color.Black, 5), new Point(x1, line_LtR_Y - 10), new Point(x2, 10));
                    }
                    else
                    {
                        g.DrawLine(new Pen(Color.Black, 5), new Point(x2, line_LtR_Y - 10), new Point(x1, 10));
                    }
                    //Console.WriteLine(x1 + "\n" + x2 + "\n\n");
                    InitialDistance = x2;
                }
                if (pnlCount != 0)
                {
                    line_X_Distance = -System.Math.Abs(_pnlPanelling.Width / pnlCount);
                }
                InitialDistance = _pnlPanelling.Width - 20;
                for (int a = 0; a < pnlRightCounter; a++)
                {


                    int x1 = InitialDistance,
                        x2 = InitialDistance + (line_X_Distance / 2);


                    if (a % 2 == 0)
                    {
                        g.DrawLine(new Pen(Color.Black, 5), new Point(x1, line_LtR_Y - 10), new Point(x2, 10));
                    }
                    else
                    {
                        g.DrawLine(new Pen(Color.Black, 5), new Point(x2, line_LtR_Y - 10), new Point(x1, 10));
                    }
                    //Console.WriteLine(x1 + "\n" + x2 + "\n\n");
                    InitialDistance = x2;
                }
            }
            if ((pnlLeftCounter + pnlRightCounter) != 0)
            {
                Bitmap bm = new Bitmap(basePL.Size.Width, basePL.Size.Height);
                basePL.DrawToBitmap(bm, new Rectangle(0, 0, basePL.Size.Width, basePL.Size.Height));

                _windoorModel.WD_SlidingTopViewImage = bm;
                _windoorModel.WD_SlidingTopViewVisibility = true;
            }
            else
            {
                _windoorModel.WD_SlidingTopViewVisibility = false;
            }
        }

        private void _setTopViewSlidingPanelling_pnlSlidingArrowPaintEventRaised(object sender, PaintEventArgs e)
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
                    decimal WidthPercentage = KV_Wd.Value / _windoorModel.WD_width,
                            FinalWidth = WidthPercentage * TotalArrowWidthBounds;
                    locX = Draw_Arrow_Width(KV_Wd.Value, FinalWidth, e, locX, dmnsion_font_wd, ctrl_Y);
                }

                float locY = 0;
                foreach (KeyValuePair<int, decimal> KV_Ht in _windoorModel.Dictionary_ht_redArrowLines)
                {
                    decimal HeightPercentage = KV_Ht.Value / _windoorModel.WD_height,
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
            Bitmap bm = new Bitmap(basePL.Size.Width, basePL.Size.Height);
            basePL.DrawToBitmap(bm, new Rectangle(0, 0, basePL.Size.Width, basePL.Size.Height));
            //bm.Save(@"C:\Users\Minrivel\Pictures\Saved Pictures\2.png", ImageFormat.Png);

        }

        private void _setTopViewSlidingPanelling_SetTopViewSlidingPanellingViewLoadEventRaised(object sender, System.EventArgs e)
        {
            //if ((pnlLeftCounter + pnlRightCounter) != 0)
            //{
            //    _windoorModel.WD_SlidingTopViewVisibility = true;
            //    _windoorModel.WD_pboxImagerHeight = 50;
            //}
            //else
            //{
            //    _windoorModel.WD_SlidingTopViewVisibility = false;
            //    _windoorModel.WD_pboxImagerHeight = 100; 
            //}
            //Console.WriteLine(_windoorModel.WD_SlidingTopViewVisibility);

            _mainPresenter.frameModel_MainPresenter.Frame_FoldAndSlideTopViewRightCount = 0;
            _mainPresenter.frameModel_MainPresenter.Frame_FoldAndSlideTopViewLeftCount = 0;

            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();

            SetImagerHeight();
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.SetWdFlpImage();
            _setTopViewSlidingPanelling.ThisBinding(CreateBindingDictionary());
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

        private void SetImagerHeight()
        {
            if ((pnlLeftCounter + pnlRightCounter) > 0)
            {
                _windoorModel.WD_SlidingTopViewVisibility = true;
                _windoorModel.WD_pboxImagerHeight = 180;
                // _itemInfoUCP.GetItemInfoUC().PboxItemImagerHeight = 180;
            }
            else
            {
                _windoorModel.WD_SlidingTopViewVisibility = false;
                _windoorModel.WD_pboxImagerHeight = 240;

                //_itemInfoUCP.GetItemInfoUC().PboxItemImagerHeight = 240;
            }
            //Console.WriteLine(_windoorModel.WD_SlidingTopViewVisibility);
            //Console.WriteLine(_itemInfoUCP.GetItemInfoUC().PboxItemImagerHeight);

        }


        public ISetTopViewSlidingPanellingView GetSetTopViewSlidingPanellingView()
        {
            return _setTopViewSlidingPanelling;
        }
        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("pboxFrame", new Binding("Image", _windoorModel, "WD_flpImage", true, DataSourceUpdateMode.OnPropertyChanged));
            return binding;
        }

        public ISetTopViewSlidingPanellingPresenter CreateNewInstance(IUnityContainer unityC,
                                                                      IMainPresenter mainPresenter,
                                                                      IWindoorModel windoorModel)
        //IItemInfoUCPresenter itemInfoUCP)
        {
            unityC
                .RegisterType<ISetTopViewSlidingPanellingView, SetTopViewSlidingPanellingView>()
                .RegisterType<ISetTopViewSlidingPanellingPresenter, SetTopViewSlidingPanellingPresenter>();
            SetTopViewSlidingPanellingPresenter TopView = unityC.Resolve<SetTopViewSlidingPanellingPresenter>();
            TopView._unityC = unityC;
            TopView._mainPresenter = mainPresenter;
            TopView._windoorModel = windoorModel;
            // TopView._itemInfoUCP = itemInfoUCP;

            return TopView;
        }
    }
}
