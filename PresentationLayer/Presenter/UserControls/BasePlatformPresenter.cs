﻿using CommonComponents;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
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
            List<int> lst_of_inserted_locX_indices = new List<int>();

            for (int i = 0; i < arr_locX.Length; i++)
            {
                int curr_locX = arr_locX[i],
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
                        indx_of_locXIndex = lst_of_inserted_locX_indices[indx_of_locX],
                        wd_to_compare = arr_wd[indx_of_locXIndex];
                    if (curr_wd < wd_to_compare)
                    {
                        lst_wd[indx_of_locX] = curr_wd;
                    }
                }
            }

            int total_wd = 0,
                curr_lst_wd = 0;
            for (int i = 0; i < lst_wd.Count; i++)
            {
                curr_lst_wd = lst_wd[i];
                total_wd += curr_lst_wd;
                if (total_wd <= flpMain_width)
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
            List<int> lst_of_inserted_locY_indices = new List<int>();

            for (int i = 0; i < arr_locY.Length; i++)
            {
                int curr_locY = arr_locY[i],
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
                        indx_of_locYIndex = lst_of_inserted_locY_indices[indx_of_locY],
                        ht_to_compare = arr_ht[indx_of_locYIndex];
                    if (curr_ht < ht_to_compare)
                    {
                        lst_ht[indx_of_locY] = curr_ht;
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

        public IBasePlatformPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel)
        {
            unityC
                .RegisterType<IBasePlatformUC, BasePlatformUC>()
                .RegisterType<IBasePlatformPresenter, BasePlatformPresenter>();
            BasePlatformPresenter basePlatformUCP = unityC.Resolve<BasePlatformPresenter>();
            basePlatformUCP._windoorModel = windoorModel;
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
