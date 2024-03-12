using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.DataTables;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter
{
    public class TopViewPresenter : ITopViewPresenter
    {
        ITopView _topViewdesign;

        private IMainPresenter _mainPresenter;
        private IUnityContainer _unityC;
        private IPanelModel _panelModel;
        private IFrameModel _frameModel;
        private IWindoorModel _windoorModel;

       

        PictureBox _pboxFrame;

        int topview_pnlCount = 0,
            CursorLocX,
            CursorLocY,
            panelSelectedCount = 0,
            point_multiplier = 0,
            topview_track = 0; // for testing

        bool addpnltoList,
            addtrcktoList;

        Color pnlClickedColor = Color.Blue;
        List<int> Lst_PanelLineY = new List<int>();
        List<int> Lst_samePoints = new List<int>();
        List<int> Lst_multiplier = new List<int>();
        List<Rectangle> Lst_PanelRectangle = new List<Rectangle>();
        List<Rectangle> selectedPanelRectangles = new List<Rectangle>();
        List<int> Lst_Panelpointsystem = new List<int>();
        List<int> Lst_Paneltotal = new List<int>();

        public TopViewPresenter(ITopView topViewdesign)
        {
            _topViewdesign = topViewdesign;

            _pboxFrame = topViewdesign.GetPbox();

            SubscribeToEventSetup();
        }
        private void SubscribeToEventSetup()
        {
            _topViewdesign.TopViewSlidingViewLoadEventRaised += _topViewdesign_TopViewSlidingViewLoadEventRaised;
            _topViewdesign.FormTimerTickEventRaised += _topViewdesign_FormTimerTickEventRaised;
            _topViewdesign.TopViewPaintEventRaised += _topViewdesign_TopViewPaintEventRaised;
            _topViewdesign.TopViewSlidingViewButtonClickEventRaised += _topViewdesign_TopViewSlidingViewButtonClickEventRaised;
            _topViewdesign.TopViewSlidingViewMouseMoveEventRaised += _topViewdesign_TopViewSlidingViewMouseMoveEventRaised;
            _topViewdesign.TopViewSlidingViewMouseClickEventRaised += _topViewdesign_TopViewSlidingViewMouseClickEventRaised;
        }
        private void _topViewdesign_TopViewSlidingViewMouseClickEventRaised(object sender, MouseEventArgs e)
        {
            bool clickedOnPanel = false;
            try
            {
               
                    //Test
                    //  int sum = 0,
                    //      total = 0;
                    //
                    //  for (int a = 0; a < test_track; a++)
                    //  {
                    //      int multiplier_point = a + 1;
                    //      Console.WriteLine("Y " + (a + 1));
                    //
                    //      if (a == 0 || a % 2 == 0)
                    //      {
                    //          for (int i = 0; i < test_pnlCount; i++)
                    //          {
                    //              Console.WriteLine("Pnl1 " + Lst_Panelpointsystem[i]);
                    //
                    //          }
                    //      }
                    //      else
                    //      {
                    //          for (int i = a; i < test_pnlCount + a; i+=1)
                    //          {
                    //              Console.WriteLine("Pnl2 " + Lst_Panelpointsystem[i + 1]);
                    //
                    //          }
                    //      }
                    //    
                    //      // total += sum;
                    //  }
                    //

                    //Test


                    for (int ii = 0; ii < Lst_PanelRectangle.Count; ii++)
                    {

                        Rectangle rect = Lst_PanelRectangle[ii];
                        // Console.WriteLine(" " + Lst_Panelpointsystem[ii] );


                        if (rect.Contains(e.Location))
                        {

                            //  Console.WriteLine(lastSelectedY + " " + lastSelectedX);

                            if (selectedPanelRectangles.Contains(rect))
                            {
                               if (e.Button == MouseButtons.Left)
                                {
                                //Remove Rectangle if de-select
                                selectedPanelRectangles.Remove(rect);
                                //  Lst_PanelLineY.Remove(rect.Y);
                                Lst_Paneltotal.Remove(Lst_Panelpointsystem[ii]);

                                // Console.WriteLine("Count: " + selectedPanelRectangles.Count());
                            }


                            if (e.Button == MouseButtons.Right)
                                {
                                    _topViewdesign.GetcmenuTopView().Show(_topViewdesign.GetPbox(),e.Location);
                                }

                            }
                            else
                            {
                                  if (e.Button == MouseButtons.Left)
                                {
                                 //If Rectangle not selected, Rectangle is selected
                                selectedPanelRectangles.Add(rect); // Panel Selected
                                                                   // Lst_PanelLineY.Add(rect.Y);
                                Lst_Paneltotal.Add(Lst_Panelpointsystem[ii]); // Point inserted

                                // Console.WriteLine("Total: " + Lst_Paneltotal.Sum());
                                //Console.WriteLine("Y: " + Lst_PanelLineY[ii]);
                                //  Console.WriteLine("Points: " + selectedPanelRectangles[ii]);
                                }
                            }


                            // Redraw Paint Event
                            _topViewdesign.GetPbox().Invalidate();
                            break;

                        }

                    }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

              
        }

        private void _topViewdesign_TopViewSlidingViewButtonClickEventRaised (object sender, EventArgs e)
        {

            try
            {
                int sum = 0,
                   total = 0,
                   sum_point = 0;

                //Calculate Combination Points
             

                    for (int a = 0; a < Lst_PanelLineY.Count; a++)
                    {
                        for (int i = 0; i < selectedPanelRectangles.Count; i++)
                        {
                            if (Lst_PanelLineY[a] == selectedPanelRectangles[i].Y)
                            {
                                Console.WriteLine("Track: " + (a + 1) + " Point: " + Lst_Paneltotal[i]);
                                sum_point = Lst_Paneltotal[i] * (a + 1);
                                sum += sum_point;
                                   Console.WriteLine("2 Sum Point: " + sum_point);
                                //   Console.WriteLine("3 Sum: " + sum);

                            }

                        }

                        total = sum;
                        // Console.WriteLine("4 total: " + total);
                    }

                    MessageBox.Show("Total Points: " + total);


         

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        private void _topViewdesign_FormTimerTickEventRaised(object sender, EventArgs e)
        {
           // _topViewdesign.GetPbox().Invalidate();
        }

        private void _topViewdesign_TopViewSlidingViewMouseMoveEventRaised(object sender, MouseEventArgs e)
        {
            //Mouse Position
            CursorLocX = e.X;
            CursorLocY = e.Y;

               //   Console.WriteLine("Coordinates X: " + CursorLocX + " Y: " + CursorLocY);
        }
        private void _topViewdesign_TopViewSlidingViewLoadEventRaised(object sender, EventArgs e)
        {
            foreach (IFrameModel fr in _windoorModel.lst_frame)
            {
                foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                {
                    if (mpnl.MPanel_DividerEnabled == false)
                    {
                        topview_pnlCount = mpnl.MPanelLst_Panel.Count;
                    }

                }
            }
          //  test_pnlCount = _windoorModel.pnlCount;
            topview_track = _frameModel.Frame_SlidingRailsQty;
            int total_points = 0,
                sum_points = 0,
                sum = 0;
            for( int i = 0; i < topview_track; i ++)
            {
                point_multiplier = i + 1;
                Lst_multiplier.Add(point_multiplier);
                Console.WriteLine("Multiplier: " + point_multiplier);
                if (i == 0 || i % 2 == 0)
                {
                    for (int ii = topview_pnlCount; ii >= 1; ii--)
                    {
                        Lst_Panelpointsystem.Add(ii);
                        sum += ii;
                        
                     //   Console.WriteLine("Count Dec: " + ii);
                    }
                    sum_points = sum * point_multiplier;
                    Console.WriteLine("Sum Points: " + sum_points);
                }
                else
                {
                    sum = 0;
                    for (int ii = 0; ii < topview_pnlCount; ii++)
                    {
                        Lst_Panelpointsystem.Add(ii + 1);
                        sum += ii + 1;
                       
                        // Console.WriteLine("Count Inc: " + Lst_Panelpointsystem[ii]);
                    }
                    sum_points = sum * point_multiplier;
                    Console.WriteLine("Sum Points: " + sum_points);
                }
                total_points += sum_points;

            }

            
            Console.WriteLine("Total Points: " + total_points);

            foreach (int value in Lst_Panelpointsystem)
            {
                Console.WriteLine(value);
              
            }


            _topViewdesign.GetLabelTracks().Text = _frameModel.Frame_SlidingRailsQty.ToString();
            _topViewdesign.GetLabelPanel().Text = _windoorModel.pnlCount.ToString();
        }
        private void _topViewdesign_TopViewPaintEventRaised(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int panel_width = 600,
              panel_height = 380;

            Color tracklightgray = Color.FromArgb(163, 163, 163);
            Color panelgray = Color.FromArgb(100, 100, 100);
            Color tracmidgray = Color.Gray;

            Rectangle outer_bounds = new Rectangle(0, 0,
                                                panel_width,
                                                panel_height);
            int outerX = outer_bounds.X,
                outerY = outer_bounds.Y,
                outerWd = outer_bounds.Width,
                outerHt = outer_bounds.Height;

            int track_lineResult,
                track_lineGap = 0,
                pnl_lineResult,
                pnl_lineGap = 0,
                defaultY,
                defaultX;


        //    g.DrawRectangle(new Pen(Color.Black, 1), outer_bounds);
        //    g.FillRectangle(Brushes.White, outer_bounds);

            int addY = (panel_height - (panel_height / (topview_track + 1)) * topview_track) - (panel_height / (topview_track + 1)) / 2;
            int addX = (panel_width - (panel_width / (topview_pnlCount + 1)) * topview_pnlCount) - (panel_width / (topview_pnlCount + 1)) / 2;
         //   Console.WriteLine("addY: " + addY);

            int track_lineGaps = track_lineGap;
            int pnl_lineGaps = pnl_lineGap;

            for (int i = 0; i < topview_track; i++)
            {
          //      Console.WriteLine("Tracks");
                track_lineResult = panel_height / (topview_track + 1) + Convert.ToInt32(Math.Floor((double)track_lineGaps));
                track_lineGaps += (panel_height / (topview_track + 1));

              
                    defaultY = track_lineResult + outerY - 10;
                
                if (addtrcktoList == false)
                {
                    Lst_PanelLineY.Add(defaultY - 20);
                 //  Console.WriteLine("List Added: Y: " + Lst_PanelLineY[i] + " " + i);
                }
                if (i == topview_track - 1)
                {
                    addtrcktoList = true;
                }

                Point[] Trackline_PointsY = null;



                Trackline_PointsY = new[]
                {
                     new Point(outerX + addY, defaultY),
                     new Point((panel_width - addY) + outerY, defaultY)
                };

                //Draw Tracks
                for (int ii = 0; ii < Trackline_PointsY.Length - 1; ii += 2)
                {

                    g.DrawLine(new Pen(tracklightgray, 10), Trackline_PointsY[ii], Trackline_PointsY[ii + 1]); // Track Lines
                    g.DrawLine(new Pen(tracmidgray, 3), Trackline_PointsY[ii], Trackline_PointsY[ii + 1]); // Track Lines Middle Part
                }
                //Panel
               if (i > 0)
               {
                   pnl_lineResult = 0;
                   pnl_lineGap = 0;
                   pnl_lineGaps = pnl_lineGap;
               }
               
                for (int a = 0; a < topview_pnlCount; a++)
                {
                    pnl_lineResult = panel_width / (topview_pnlCount) + Convert.ToInt32(Math.Floor((double)pnl_lineGaps));
                    pnl_lineGaps += (panel_width / (topview_pnlCount + 1));
                                      
                    defaultX = pnl_lineResult + outerX;
                   
                  
                    if (addpnltoList == false )
                    {
                        
                    }

                    if (a == topview_pnlCount - 1  && i == topview_track - 1)
                    {
                        addpnltoList = true;
                    }

                    Point[] Panelline_PointsX = null;

                    Rectangle panel_bounds = new Rectangle((defaultX - addX) - 20, defaultY - 20,
                                                             100, 40);
                    if(topview_pnlCount == 2)
                    {
                        panel_bounds.X = (defaultX - addX) - 70;
                        panel_bounds.Width = 150;
                    }
                    Panelline_PointsX = new[]
                    {
                           new Point(defaultX - addX , defaultY),
                           new Point(defaultX , defaultY)
                    };
                    Lst_PanelRectangle.Add(panel_bounds);
                }



            }
            foreach (Rectangle rect in Lst_PanelRectangle)
            {
                if (selectedPanelRectangles.Contains(rect))
                {
                 
                    // Rectangle is selected, fill it with blue color
                    g.DrawRectangle(new Pen(Color.Blue, 1), rect);
                    g.FillRectangle(Brushes.Blue, rect);
                }
                else
                {
                    // Rectangle is not selected, fill it with gray color
                    g.DrawRectangle(new Pen(panelgray, 1), rect);
                    g.FillRectangle(Brushes.LightGray, rect);
                }
            }

        }
    

        public ITopView GetTopViewDesign()
        {
            return _topViewdesign;
        }

  //      public Dictionary<string, Binding> CreateBindingDictionary()
  //      {
  //          Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
  //          binding.Add("pboxFrame", new Binding("Image", _windoorModel, "WD_flpImage", true, DataSourceUpdateMode.OnPropertyChanged));
  //          binding.Add("WD_TopViewType", new Binding("TEXT", _windoorModel, "WD_TopViewType", true, DataSourceUpdateMode.OnPropertyChanged));
  //
  //          return binding;
  //      }

        public ITopViewPresenter GetNewInstance(IMainPresenter mainPresenter,
                                           IUnityContainer unityC,
                                           IPanelModel panelModel,
                                           IFrameModel frameModel,
                                           IWindoorModel windoorModel)
          {
            unityC
             .RegisterType<ITopView, TopView>()
             .RegisterType<ITopViewPresenter, TopViewPresenter>();
            TopViewPresenter TVPresenter = unityC.Resolve<TopViewPresenter>();
            TVPresenter._mainPresenter = mainPresenter;
            TVPresenter._unityC = unityC;
            TVPresenter._panelModel = panelModel;
            TVPresenter._frameModel = frameModel;
            TVPresenter._windoorModel = windoorModel;

            return TVPresenter;
        }
    }
    
}
