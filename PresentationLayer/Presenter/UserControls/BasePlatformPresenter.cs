﻿using CommonComponents;
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

            //if (basePlatform.Width > pnlMain.Width)
            //{
            //    cX = 5;
            //}
            //else
            //{
            //    cX -= 17;
            //}

            //if (basePlatform.Height > pnlMain.Height)
            //{
            //    cY = 5;
            //}
            //else
            //{
            //    cY -= 35;
            //}

            //basePlatform.Location = new Point(cX, cY);

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
            Font dmnsion_font = new Font("Segoe UI", (20 * _windoorModel.WD_zoom) + 2, FontStyle.Bold);

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
                int[,] actual_arr_wd_locX = new int[total_panel, 2];
                int[,] actual_arr_ht_locY = new int[total_panel, 2];
                int ndx = 0;

                if (total_panel > 1 && total_mpanel == 0)
                {
                    foreach (IFrameModel frame in _windoorModel.lst_frame)
                    {
                        foreach (IPanelModel pnl in frame.Lst_Panel)
                        {
                            Control ctrl = FindFrameControl(frame.Frame_Name, frame.Frame_ID);
                            actual_arr_wd_locX[ndx, 0] = pnl.Panel_DisplayWidth;
                            actual_arr_ht_locY[ndx, 0] = pnl.Panel_DisplayHeight;

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
                                actual_arr_wd_locX[ndx, 0] = pnl.Panel_DisplayWidth;
                                actual_arr_ht_locY[ndx, 0] = pnl.Panel_DisplayHeight;

                                actual_arr_wd_locX[ndx, 1] = ctrl.PointToScreen(((Form)_mainPresenter.GetMainView()).Location).X;// ((Form)_mainPresenter.GetMainView()).PointToClient(ctrl.Location).X; //ctrl.Location.X;
                                actual_arr_ht_locY[ndx, 1] = ctrl.PointToScreen(((Form)_mainPresenter.GetMainView()).Location).Y;// ((Form)_mainPresenter.GetMainView()).PointToClient(ctrl.Location).X; //ctrl.Location.X;
                                ndx++;
                            }
                        }
                    }
                }

                List<int> wds = WidthList_ToPaint(_windoorModel.WD_width, actual_arr_wd_locX);
                List<int> hts = HeightList_ToPaint(_windoorModel.WD_height, actual_arr_ht_locY);

                int locX = 0;
                foreach (int wd in wds)
                {
                    string dmnsion_w = wd.ToString();
                    PointF dmnsion_w_startP = new PointF(_flpMain.Location.X + (locX * _windoorModel.WD_zoom),
                                                         (ctrl_Y - 17));// * _windoorModel.WD_zoom);
                    PointF dmnsion_w_endP = new PointF((_flpMain.Location.X - 3) + ((locX + wd) * _windoorModel.WD_zoom),
                                                       (ctrl_Y - 17)); // * _windoorModel.WD_zoom);

                    Size s = TextRenderer.MeasureText(dmnsion_w, dmnsion_font);
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
                                              dmnsion_font,
                                              new Rectangle(new Point((int)(mid - (s.Width / 2)), (ctrl_Y - s.Height) / 2),
                                                            new Size(s.Width, s.Height)),
                                              Color.Black,
                                              SystemColors.Control,
                                              TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                    //arrow for WIDTH
                    locX += wd;
                }

                int locY = 0;
                foreach (int ht in hts)
                {
                    //arrow for HEIGHT
                    string dmnsion_h = ht.ToString();
                    PointF dmnsion_h_startP = new PointF(70 - 17, _flpMain.Location.Y + (locY * _windoorModel.WD_zoom));
                    PointF dmnsion_h_endP = new PointF(70 - 17, (_flpMain.Location.Y - 3) + ((locY + ht) * _windoorModel.WD_zoom));

                    Size s2 = TextRenderer.MeasureText(dmnsion_h, dmnsion_font);
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
                                              dmnsion_font,
                                              new Rectangle(new Point((70 - s2.Width) / 2, (int)(mid2 - (s2.Height / 2))),
                                                            new Size(s2.Width, s2.Height)),
                                              Color.Black,
                                              SystemColors.Control,
                                              TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                    //arrow for HEIGHT
                    locY += ht;
                }
            }
            else if (total_panel == 1 && total_mpanel == 0)
            {
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


        public List<int> WidthList_ToPaint(int flpMain_width, int[,] arr_wd_locX)
        {
            List<int> Width_List = new List<int>();

            int[] arr_wd = new int[arr_wd_locX.GetLength(0)];
            int[] arr_locX = new int[arr_wd_locX.GetLength(0)];

            for (int i = 0; i < arr_wd_locX.GetLength(0); i++)
            {
                arr_wd[i] = arr_wd_locX[i, 0];
            }

            for (int i = 0; i < arr_wd_locX.GetLength(0) ; i++)
            {
                arr_locX[i] = arr_wd_locX[i, 1];
            }

            Array.Sort(arr_locX, arr_wd);

            List<int> lst_wd = new List<int>();
            List<int> lst_of_inserted_locX = new List<int>();

            for (int i = 0; i < arr_locX.Length; i++)
            {
                if (lst_of_inserted_locX.Contains(arr_locX[i]) == false)
                {
                    lst_wd.Add(arr_wd[i]);
                    lst_of_inserted_locX.Add(arr_locX[i]);
                }
                else if (lst_of_inserted_locX.Contains(arr_locX[i]) == true)
                {
                    int ndx = lst_of_inserted_locX.IndexOf(arr_locX[i]);
                    if (arr_wd[i] < arr_wd[ndx])
                    {
                        lst_wd[ndx] = arr_wd[i];
                    }
                }
            }

            int total_wd = 0;
            for (int i = 0; i < lst_wd.Count; i++)
            {
                total_wd += lst_wd[i];
                if (total_wd <= flpMain_width)
                {
                    Width_List.Add(lst_wd[i]);
                }
                else if (total_wd > flpMain_width)
                {
                    total_wd -= lst_wd[i];
                }
            }

            return Width_List;
        }

        public List<int> HeightList_ToPaint(int flpMain_height, int[,] arr_ht_locY)
        {
            List<int> Height_List = new List<int>();

            int[] arr_ht = new int[arr_ht_locY.GetLength(0)];
            int[] arr_locY = new int[arr_ht_locY.GetLength(0)];

            for (int i = 0; i < arr_ht_locY.GetLength(0); i++)
            {
                arr_ht[i] = arr_ht_locY[i, 0];
            }

            for (int i = 0; i < arr_ht_locY.GetLength(0); i++)
            {
                arr_locY[i] = arr_ht_locY[i, 1];
            }

            Array.Sort(arr_locY, arr_ht);

            List<int> lst_ht = new List<int>();
            List<int> lst_of_inserted_locY = new List<int>();

            for (int i = 0; i < arr_locY.Length; i++)
            {
                if (lst_of_inserted_locY.Contains(arr_locY[i]) == false)
                {
                    lst_ht.Add(arr_ht[i]);
                    lst_of_inserted_locY.Add(arr_locY[i]);
                }
                else if (lst_of_inserted_locY.Contains(arr_locY[i]) == true)
                {
                    int ndx = lst_of_inserted_locY.IndexOf(arr_locY[i]);
                    if (arr_ht[i] < arr_ht[ndx])
                    {
                        lst_ht[ndx] = arr_ht[i];
                    }
                }
            }

            int total_ht = 0;
            for (int i = 0; i < lst_ht.Count; i++)
            {
                total_ht += lst_ht[i];
                if (total_ht <= flpMain_height)
                {
                    Height_List.Add(lst_ht[i]);
                }
                else if (total_ht > flpMain_height)
                {
                    total_ht -= lst_ht[i];
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
