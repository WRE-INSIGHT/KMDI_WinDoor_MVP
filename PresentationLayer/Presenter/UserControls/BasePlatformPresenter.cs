using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.CommonMethods;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class BasePlatformPresenter : IBasePlatformPresenter, IPresenterCommon
    {
        IBasePlatformUC _basePlatfomrUC;
        FlowLayoutPanel _flpMain;

        IWindoorModel _windoorModel;
        IMainPresenter _mainPresenter;

        CommonFunctions _commonfunc = new CommonFunctions();

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

        private void OnbasePlatformPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl basePL = (UserControl)sender;
            //dito ilagay ang drawing ng red-arrowlines
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int ctrl_Y = 35;
            Pen redP = new Pen(Color.Red);
            redP.Width = 3.5f;
            Font dmnsion_font_wd = new Font("Segoe UI", (20 * _windoorModel.WD_zoom) + 2, FontStyle.Bold);

            Font dmnsion_font_ht = new Font("Segoe UI", (20 * _windoorModel.WD_zoom) + 2, FontStyle.Bold);

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

                List<decimal> wds = WidthList_ToPaint(_windoorModel.WD_width, actual_arr_wd_locX);
                List<decimal> hts = HeightList_ToPaint(_windoorModel.WD_height, actual_arr_ht_locY);

                float locX = 0;
                foreach (decimal wd in wds)
                {
                    string dmnsion_w = wd.ToString();

                    if (dmnsion_w.Contains(".0"))
                    {
                        dmnsion_w = dmnsion_w.Replace(".0", "");
                        dmnsion_font_wd = new Font("Segoe UI", (20 * _windoorModel.WD_zoom) + 2, FontStyle.Bold);
                    }
                    else
                    {
                        dmnsion_font_wd = new Font("Segoe UI", (20 * _windoorModel.WD_zoom) - 3, FontStyle.Bold);
                        if (_windoorModel.WD_zoom == 0.26f)
                        {
                            dmnsion_font_wd = new Font("Segoe UI", (20 * _windoorModel.WD_zoom) + 2, FontStyle.Bold);
                        }
                    }

                    float DispWd_float = float.Parse(dmnsion_w);

                    PointF dmnsion_w_startP = new PointF(_flpMain.Location.X + (locX * _windoorModel.WD_zoom),
                                                         (ctrl_Y - 17));// * _windoorModel.WD_zoom);
                    PointF dmnsion_w_endP = new PointF((_flpMain.Location.X - 3) + ((locX + DispWd_float) * _windoorModel.WD_zoom),
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

                    if (_flpMain.Controls.OfType<IFrameUC>().Where(fr => fr.thisVisible == true).Count() > 0)
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

                    PointF dmnsion_h_startP = new PointF(70 - 17, _flpMain.Location.Y + (locY * _windoorModel.WD_zoom));
                    PointF dmnsion_h_endP = new PointF(70 - 17, (_flpMain.Location.Y - 3) + ((locY + DispHt_float) * _windoorModel.WD_zoom));

                    if (dmnsion_h.Contains(".0"))
                    {
                        dmnsion_h = dmnsion_h.Replace(".0", "");
                        dmnsion_font_ht = new Font("Segoe UI", (20 * _windoorModel.WD_zoom) + 2, FontStyle.Bold);
                    }
                    else
                    {
                        dmnsion_font_ht = new Font("Segoe UI", (20 * _windoorModel.WD_zoom) - 3, FontStyle.Bold);
                        if (_windoorModel.WD_zoom == 0.26f)
                        {
                            dmnsion_font_ht = new Font("Segoe UI", (20 * _windoorModel.WD_zoom) + 2, FontStyle.Bold);
                        }
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

                    if (_flpMain.Controls.OfType<IFrameUC>().Where(fr => fr.thisVisible == true).Count() > 0)
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

                if (_flpMain.Controls.OfType<IFrameUC>().Where(fr => fr.thisVisible == true).Count() > 0)
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

                if (_flpMain.Controls.OfType<IFrameUC>().Where(fr => fr.thisVisible == true).Count() > 0)
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
            }
        }

        public IBasePlatformUC getBasePlatformViewUC()
        {
            _basePlatfomrUC.ThisBinding(CreateBindingDictionary());
            return _basePlatfomrUC;
        }

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


        int TotalSumWD;
        public List<int> lst_wd_toPaint(int flpMain_width, List<int> lst_ctrlWds)
        {

            List<int> lst_wd = new List<int>();
            List<int> Arrange_lst_wd = new List<int>();
            Arrange_lst_wd = lst_ctrlWds.OrderBy(x => x).ToList();

            for (int i = 0; i < lst_ctrlWds.Count; i++)
            {
                TotalSumWD += Arrange_lst_wd[i];



                if (flpMain_width < TotalSumWD)
                {
                    break;
                }
                else
                {
                    lst_wd.Add(Arrange_lst_wd[i]);
                }
            }


            return lst_wd;


        }


        int TotalSumHeight;
        public List<int> lst_ht_toPaint(int flpMain_height, List<int> lst_ctrlHts)
        {
            List<int> lst_ht = new List<int>();
            List<int> Arrange_lst_Height = new List<int>();
            Arrange_lst_Height = lst_ctrlHts.OrderBy(x => x).ToList();



            for (int i = 0; i < Arrange_lst_Height.Count; i++)
            {
                TotalSumHeight += Arrange_lst_Height[i];



                if (flpMain_height < TotalSumHeight)
                {
                    break;
                }
                else
                {
                    lst_ht.Add(Arrange_lst_Height[i]);
                }
            }



            return lst_ht;
        }


        public List<decimal> WidthList_ToPaint(int flpMain_width, decimal[,] arr_wd_locX)
        {
            List<decimal> Width_List = new List<decimal>();

            decimal[] arr_wd = new decimal[arr_wd_locX.GetLength(0)];
            decimal[] arr_locX = new decimal[arr_wd_locX.GetLength(0)];

            for (int i = 0; i < arr_wd_locX.GetLength(0); i++)
            {
                arr_wd[i] = arr_wd_locX[i, 0];
            }

            for (int i = 0; i < arr_wd_locX.GetLength(0) ; i++)
            {
                arr_locX[i] = arr_wd_locX[i, 1];
            }

            Array.Sort(arr_locX, arr_wd);

            List<decimal> lst_wd = new List<decimal>();
            List<decimal> lst_of_inserted_locX = new List<decimal>();
            List<int> lst_of_inserted_locX_indices = new List<int>();

            for (int i = 0; i < arr_locX.Length; i++)
            {
                decimal curr_locX = arr_locX[i],
                        curr_wd = arr_wd[i];
                if (lst_of_inserted_locX.Contains(curr_locX) == false)
                {
                    lst_wd.Add(curr_wd);
                    lst_of_inserted_locX.Add(curr_locX);
                    lst_of_inserted_locX_indices.Add(i);
                }
                else if (lst_of_inserted_locX.Contains(curr_locX) == true)
                {
                    int indx_of_locX = lst_of_inserted_locX.IndexOf(curr_locX),
                        indx_of_locXIndex = lst_of_inserted_locX_indices[indx_of_locX];
                    decimal wd_to_compare = arr_wd[indx_of_locXIndex];
                    if (curr_wd < wd_to_compare)
                    {
                        lst_wd[indx_of_locX] = curr_wd;
                    }
                }
            }

            decimal total_wd = 0,
                    curr_lst_wd = 0;
            for (int i = 0; i < lst_wd.Count; i++)
            {
                curr_lst_wd = lst_wd[i];
                total_wd += curr_lst_wd;
                if (total_wd <= flpMain_width || total_wd-2 <= flpMain_width)
                {
                    Width_List.Add(curr_lst_wd);
                }
                else if (total_wd > flpMain_width)
                {
                    total_wd -= curr_lst_wd;
                }
            }

            return Width_List;
        }

        public List<decimal> HeightList_ToPaint(int flpMain_height, decimal[,] arr_ht_locY)
        {
            List<decimal> Height_List = new List<decimal>();

            decimal[] arr_ht = new decimal[arr_ht_locY.GetLength(0)];
            decimal[] arr_locY = new decimal[arr_ht_locY.GetLength(0)];

            for (int i = 0; i < arr_ht_locY.GetLength(0); i++)
            {
                arr_ht[i] = arr_ht_locY[i, 0];
            }

            for (int i = 0; i < arr_ht_locY.GetLength(0); i++)
            {
                arr_locY[i] = arr_ht_locY[i, 1];
            }

            Array.Sort(arr_locY, arr_ht);

            List<decimal> lst_ht = new List<decimal>();
            List<decimal> lst_of_inserted_locY = new List<decimal>();
            List<int> lst_of_inserted_locY_indices = new List<int>();

            for (int i = 0; i < arr_locY.Length; i++)
            {
                decimal curr_locY = arr_locY[i],
                        curr_ht = arr_ht[i];
                if (lst_of_inserted_locY.Contains(curr_locY) == false)
                {
                    lst_ht.Add(curr_ht);
                    lst_of_inserted_locY.Add(curr_locY);
                    lst_of_inserted_locY_indices.Add(i);
                }
                else if (lst_of_inserted_locY.Contains(curr_locY) == true)
                {
                    int indx_of_locY = lst_of_inserted_locY.IndexOf(curr_locY),
                        indx_of_locYIndex = lst_of_inserted_locY_indices[indx_of_locY];

                    decimal ht_to_compare = arr_ht[indx_of_locYIndex];
                    if (curr_ht < ht_to_compare)
                    {
                        lst_ht[indx_of_locY] = curr_ht;
                    }
                }
            }

            decimal total_ht = 0,
                    curr_lst_ht = 0;
            for (int i = 0; i < lst_ht.Count; i++)
            {
                curr_lst_ht = lst_ht[i];
                total_ht += curr_lst_ht;
                if (total_ht <= flpMain_height || total_ht - 2 <= flpMain_height)
                {
                    Height_List.Add(curr_lst_ht);
                }
                else if (total_ht > flpMain_height)
                {
                    total_ht -= curr_lst_ht;
                }
            }

            return Height_List;
        }

        public void Invalidate_flpMain()
        {
            _flpMain.Invalidate();
        }

        public IBasePlatformPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IBasePlatformUC, BasePlatformUC>()
                .RegisterType<IBasePlatformPresenter, BasePlatformPresenter>();
            BasePlatformPresenter basePlatformUCP = unityC.Resolve<BasePlatformPresenter>();
            basePlatformUCP._windoorModel = windoorModel;
            basePlatformUCP._mainPresenter = mainPresenter;
            basePlatformUCP._basePlatfomrUC.ClearBinding((UserControl)_basePlatfomrUC);

            return basePlatformUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> basePlatformBinding = new Dictionary<string, Binding>();
            basePlatformBinding.Add("WD_width_4basePlatform", new Binding("Width", _windoorModel, "WD_width_4basePlatform", true, DataSourceUpdateMode.OnPropertyChanged));
            basePlatformBinding.Add("WD_height_4basePlatform", new Binding("Height", _windoorModel, "WD_height_4basePlatform", true, DataSourceUpdateMode.OnPropertyChanged));
            basePlatformBinding.Add("WD_visibility", new Binding("Visible", _windoorModel, "WD_visibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return basePlatformBinding;
        }

        public void ViewDeleteControl(UserControl control)
        {
            _flpMain.Controls.Remove(control);
        }

        public void Invalidate_flpMainControls()
        {
            foreach (IFrameUC frames in _flpMain.Controls)
            {
                frames.InvalidateThis();
                frames.InvalidateThisControls();
            }
        }
    }
}
