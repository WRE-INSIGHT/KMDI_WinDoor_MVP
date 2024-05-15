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
        private ITopViewPanelViewerPresenter _topViewPanelViewerPresenter;
        private IQuotationModel _quotationModel;


        PictureBox _pboxFrame;
        Font handle_names;

        public int TotalPoints { get; set; }

        int topview_pnlCount = 0,
            CursorLocX,
            CursorLocY,
            point_multiplier = 0,
            topview_track = 0; // for testing

        bool addpnltoList,
            addtrcktoList,
            handlesselected,
            interlockselected,
            nonstructselected,
            structselected,
            popupselected,
            dhandleselected,
            cremoneselected;

        Color pnlClickedColor = Color.Blue;
        List<int> Lst_PanelLineY = new List<int>();
        List<int> Lst_multiplier = new List<int>();
        List<int> Lst_Panelpointsystem = new List<int>();
        List<int> Lst_Paneltotal = new List<int>();
        List<string> Lst_Handles = new List<string>();
        List<string> Lst_Interlock = new List<string>();
        List<Rectangle> Lst_PanelRectangle = new List<Rectangle>();
        List<Rectangle> selectedPanelRectangles = new List<Rectangle>();
        List<Rectangle> lst_handlePanelRectangles = new List<Rectangle>();
        List<Rectangle> lst_interlockPanelRectangles = new List<Rectangle>();
      
        public TopViewPresenter(ITopView topViewdesign,
                                ITopViewPanelViewerPresenter topViewPanelViewerPresenter)
        {
            _topViewPanelViewerPresenter = topViewPanelViewerPresenter;
            _topViewdesign = topViewdesign;

            _pboxFrame = topViewdesign.GetPbox();

            SubscribeToEventSetup();
        }
        private void SubscribeToEventSetup()
        {
            _topViewdesign.TopViewSlidingViewLoadEventRaised += _topViewdesign_TopViewSlidingViewLoadEventRaised;
            _topViewdesign.TopViewPaintEventRaised += _topViewdesign_TopViewPaintEventRaised;
            _topViewdesign.TopViewSlidingViewButtonClickEventRaised += _topViewdesign_TopViewSlidingViewButtonClickEventRaised;
            _topViewdesign.TopViewSlidingViewMouseMoveEventRaised += _topViewdesign_TopViewSlidingViewMouseMoveEventRaised;
            _topViewdesign.TopViewSlidingViewMouseClickEventRaised += _topViewdesign_TopViewSlidingViewMouseClickEventRaised;
            _topViewdesign.popupToolStripClickedEventRaised += _topViewdesign_popupToolStripClickedEventRaised;
            _topViewdesign.dhandleToolStripClickedEventRaised += _topViewdesign_dhandleToolStripClickedEventRaised;
            _topViewdesign.cremoneToolStripClickedEventRaised += _topViewdesign_cremoneToolStripClickedEventRaised;
            _topViewdesign.rightmenuToolStripClickedEventRaised += _topViewdesign_rightmenuToolStripClickedEventRaised;
            _topViewdesign.leftmenuToolStripClickedEventRaised += _topViewdesign_leftmenuToolStripClickedEventRaised;
            _topViewdesign.bothmenuToolStripClickedEventRaised += _topViewdesign_bothmenuToolStripClickedEventRaised;
        }
             
        private void _topViewdesign_bothmenuToolStripClickedEventRaised(object sender, EventArgs e)
        {
            ToolStripMenuItem bothmenuitem = (ToolStripMenuItem)sender;
            ToolStripMenuItem parent = (ToolStripMenuItem)bothmenuitem.OwnerItem;

            string toolstrip = bothmenuitem.ToString();
            interlockselected = true;

            if (parent.Text == "Structural")
            {
                for (int ii = 0; ii < Lst_PanelRectangle.Count; ii++)
                {
                    Rectangle rect = Lst_PanelRectangle[ii];

                    if (rect.Contains(CursorLocX, CursorLocY))
                    {
                        if (selectedPanelRectangles.Contains(rect))
                        {

                            if (lst_interlockPanelRectangles.Contains(rect))
                            {
                                structselected = false;
                                int test_interlock = lst_interlockPanelRectangles.IndexOf(rect);

                                if (Lst_Interlock[test_interlock] == "Right Structural" ||
                                        Lst_Interlock[test_interlock] == "Left Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Right Non-Structural" ||
                                        Lst_Interlock[test_interlock] == "Left Non-Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Non-Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Left Non & Right Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Right Non & Left Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Structural";
                                }
                                else
                                {
                                    lst_interlockPanelRectangles.Remove(rect);
                                    Lst_Interlock.Remove(Lst_Interlock[test_interlock]);
                                    Console.WriteLine("Both Struct 3");
                                }
                            }
                            else
                            {
                                lst_interlockPanelRectangles.Add(rect);
                                Lst_Interlock.Add("Structural");
                            }
                        }
                        _topViewdesign.GetPbox().Refresh();
                        break;
                    }
                }
            }
            else if (parent.Text == "Non-Structural")
            {
                for (int ii = 0; ii < Lst_PanelRectangle.Count; ii++)
                {
                    Rectangle rect = Lst_PanelRectangle[ii];
                    if (rect.Contains(CursorLocX, CursorLocY))
                    {
                        if (selectedPanelRectangles.Contains(rect))
                        {
                            if (lst_interlockPanelRectangles.Contains(rect))
                            {
                                int test_interlock = lst_interlockPanelRectangles.IndexOf(rect);
                                nonstructselected = false;

                                if (Lst_Interlock[test_interlock] == "Right Structural" ||
                                        Lst_Interlock[test_interlock] == "Left Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Non-Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Right Non-Structural" ||
                                        Lst_Interlock[test_interlock] == "Left Non-Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Non-Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Non-Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Left Non & Right Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Non-Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Right Non & Left Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Non-Structural";
                                }

                                //  if (structselected == true)
                                //  {
                                //      structselected = false;
                                //      Lst_Interlock[test_interlock] = "Non-Structural";
                                //      nonstructselected = true;
                                //      Console.WriteLine("Both Non-Struct 1");
                                //  }
                                //  else
                                //  {
                                //     
                                //      if (Lst_Interlock[test_interlock] == "Right Non-Structural" ||
                                //         Lst_Interlock[test_interlock] == "Left Non-Structural")
                                //      {
                                //          Lst_Interlock[test_interlock] = "Non-Structural";
                                //          nonstructselected = true;
                                //          Console.WriteLine("Both Non-Struct 2");
                                //      }
                                //      else
                                //      {
                                //          lst_interlockPanelRectangles.Remove(rect);
                                //          Lst_Interlock.Remove(Lst_Interlock[test_interlock]);
                                //          Console.WriteLine("Both Non-Struct 3");
                                //      }
                                //      
                                //  }                           
                            }
                            else
                            {
                                lst_interlockPanelRectangles.Add(rect);
                                Lst_Interlock.Add("Non-Structural");;
                            }
                        }
                        _topViewdesign.GetPbox().Invalidate();
                        break;
                    }
                }
            }                       
        }
        private void _topViewdesign_leftmenuToolStripClickedEventRaised(object sender, EventArgs e)
        {
            ToolStripMenuItem leftmenuitem = (ToolStripMenuItem)sender;
            ToolStripMenuItem parent = (ToolStripMenuItem)leftmenuitem.OwnerItem;

            interlockselected = true;

            if (parent.Text == "Structural")
            {
                for (int ii = 0; ii < Lst_PanelRectangle.Count; ii++)
                {
                    Rectangle rect = Lst_PanelRectangle[ii];

                    if (rect.Contains(CursorLocX, CursorLocY))
                    {
                        if (selectedPanelRectangles.Contains(rect))
                        {
                            if (lst_interlockPanelRectangles.Contains(rect))
                            {
                                structselected = false;
                                int test_interlock = lst_interlockPanelRectangles.IndexOf(rect);
                                if (Lst_Interlock[test_interlock] == "Structural" ||
                                    Lst_Interlock[test_interlock] == "Right Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Left Structural";
                                    Console.WriteLine("Change Both Struct/Right STruct to Left Struct");
                                }
                                else if(Lst_Interlock[test_interlock] == "Non-Structural" ||
                                        Lst_Interlock[test_interlock] == "Left Non-Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Left Structural";
                                    Console.WriteLine("Change Non-Struct to Left Struct");
                                }
                                else if(Lst_Interlock[test_interlock] == "Right Non-Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Right Non & Left Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Right Non & Left Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Right Non-Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Left Non & Right Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Left Structural";
                                }
                                else
                                {
                                    lst_interlockPanelRectangles.Remove(rect);
                                    Lst_Interlock.Remove(Lst_Interlock[test_interlock]);
                                    Console.WriteLine("Remove Interlock from the Left Structural");
                                }

                                //   if (nonstructselected == true)
                                //   {
                                //       if(Lst_Interlock[test_interlock] == "Right Non-Structural")
                                //       {
                                //           Lst_Interlock[test_interlock] = "Right Non & Left Structural";
                                //           Console.WriteLine(" Left Struct 1");
                                //           //structselected = true;
                                //       }
                                //    //   else if (Lst_Interlock[test_interlock] == "Left&Right Structural")
                                //    //   {
                                //    //       Lst_Interlock[test_interlock] = "Right Structural";
                                //    //       Console.WriteLine("non 2");
                                //    //       structselected = true;
                                //    //   }
                                //       else
                                //       {
                                //           Lst_Interlock[test_interlock] = "Right Non-Structural";
                                //           Console.WriteLine(" Left Struct 2");
                                //       }                                  
                                //   }
                                //   else
                                //   {
                                //       if(Lst_Interlock[test_interlock] == "Structural" ||
                                //                Lst_Interlock[test_interlock] == "Right Structural")
                                //       {
                                //           Lst_Interlock[test_interlock] = "Left Structural";
                                //           Console.WriteLine(" Left Struct 3");
                                //           structselected = true;
                                //       }
                                //       else if (Lst_Interlock[test_interlock] == "Right Non & Left Structural")
                                //       {
                                //           Lst_Interlock[test_interlock] = "Right Structural";
                                //           Console.WriteLine(" Left Struct 4");
                                //           structselected = true;
                                //       }
                                //       else
                                //       {
                                //           lst_interlockPanelRectangles.Remove(rect);
                                //           Lst_Interlock.Remove(Lst_Interlock[test_interlock]);
                                //           Console.WriteLine(" Left Struct 5");
                                //       }                                 
                                //   }
                            }
                            else
                            {
                                lst_interlockPanelRectangles.Add(rect);
                                Lst_Interlock.Add("Left Structural");
                                Console.WriteLine("Left Structural Added");
                                structselected = true;
                            }
                        }
                        _topViewdesign.GetPbox().Invalidate();
                        break;
                    }
                }
            }
            else if (parent.Text == "Non-Structural")
            {
                for (int ii = 0; ii < Lst_PanelRectangle.Count; ii++)
                {
                    Rectangle rect = Lst_PanelRectangle[ii];

                    if (rect.Contains(CursorLocX, CursorLocY))
                    {
                        if (selectedPanelRectangles.Contains(rect))
                        {

                            if (lst_interlockPanelRectangles.Contains(rect))
                            {
                                nonstructselected = false;
                                int test_interlock = lst_interlockPanelRectangles.IndexOf(rect);

                                if (Lst_Interlock[test_interlock] == "Structural" ||
                                    Lst_Interlock[test_interlock] == "Left Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Left Non-Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Non-Structural" ||
                                        Lst_Interlock[test_interlock] == "Right Non-Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Left Non-Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Left Non & Right Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Right Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Right Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Left Non & Right Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Right Non & Left Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Left Non-Structural";
                                }
                                else
                                {
                                    lst_interlockPanelRectangles.Remove(rect);
                                    Lst_Interlock.Remove(Lst_Interlock[test_interlock]);
                                }
                                // if (structselected == true)
                                // {
                                //     if (Lst_Interlock[test_interlock] == "Right Structural")
                                //     {
                                //         Lst_Interlock[test_interlock] = "Left Non & Right Structural";
                                //         Console.WriteLine(" Left Non-Struct 1 (Change)");
                                //     }
                                //     else
                                //     {
                                //         Lst_Interlock[test_interlock] = "Left Non-Structural";
                                //         nonstructselected = true;
                                //         Console.WriteLine(" Left Non-Struct 2");
                                //     }
                                //     
                                // }
                                // else
                                // {
                                //     if (Lst_Interlock[test_interlock] == "Right Non-Structural")
                                //     {
                                //         
                                //         Lst_Interlock.Add("Left Non-Structural");
                                //         Console.WriteLine(" Left Non-Struct 3");
                                //         nonstructselected = true;
                                //     }
                                //
                                //     else if (Lst_Interlock[test_interlock] == "Left Non & Right Structural")
                                //     {
                                //         Lst_Interlock[test_interlock] = "--Left Non-Structural";
                                //         nonstructselected = true;
                                //         Console.WriteLine(" Left Non-Struct 4");
                                //     }
                                //     else if (Lst_Interlock[test_interlock] == "Non-Structural")
                                //     {
                                //
                                //     }
                                //     else
                                //     {
                                //         lst_interlockPanelRectangles.Remove(rect);
                                //         Lst_Interlock.Remove(Lst_Interlock[test_interlock]);
                                //         nonstructselected = false;
                                //         Console.WriteLine(" Left Non-Struct 5");
                                //     }                                  
                                // }
                            }
                            else
                            {
                                lst_interlockPanelRectangles.Add(rect);
                                Lst_Interlock.Add("Left Non-Structural");
                            }
                        }
                        _topViewdesign.GetPbox().Invalidate();
                        break;
                    }
                }
            }
        }
        private void _topViewdesign_rightmenuToolStripClickedEventRaised(object sender, EventArgs e)
        {
            ToolStripMenuItem rightmenuitem = (ToolStripMenuItem)sender;
            ToolStripMenuItem parent = (ToolStripMenuItem)rightmenuitem.OwnerItem;

            interlockselected = true;

            if (parent.Text == "Structural")
            {

                for (int ii = 0; ii < Lst_PanelRectangle.Count; ii++)
                {

                    Rectangle rect = Lst_PanelRectangle[ii];

                    if (rect.Contains(CursorLocX, CursorLocY))
                    {
                        if (selectedPanelRectangles.Contains(rect))
                        {
                            if (lst_interlockPanelRectangles.Contains(rect))
                            {
                                structselected = false;
                                int test_interlock = lst_interlockPanelRectangles.IndexOf(rect);

                                if (Lst_Interlock[test_interlock] == "Structural" ||
                                    Lst_Interlock[test_interlock] == "Left Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Right Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Non-Structural" ||
                                         Lst_Interlock[test_interlock] == "Right Non-Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Right Structural";
                                }
                                else if(Lst_Interlock[test_interlock] == "Left Non-Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Left Non & Right Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Left Non & Right Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Left Non-Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Right Non & Left Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Right Structural";
                                }
                              // if (nonstructselected == true)
                              // {
                              //     if (Lst_Interlock[test_interlock] == "Left Non-Structural")
                              //     {
                              //         Lst_Interlock[test_interlock] = "Left Non & Right Structural";
                              //         Console.WriteLine(" Right Struct 1");
                              //     }
                              //     else
                              //     {
                              //         Lst_Interlock[test_interlock] = "Right Structural";
                              //         structselected = true;
                              //         Console.WriteLine(" Right Struct 2 (Change)");
                              //     }
                              //       
                              // }
                              // else
                              // {
                              //     if (Lst_Interlock[test_interlock] == "Left Structural")
                              //     {
                              //         Lst_Interlock[test_interlock] = "Left&Right Structural";
                              //         Console.WriteLine(" Right Struct 3");
                              //         structselected = true;
                              //     }
                              //     else if (Lst_Interlock[test_interlock] == "Right Non & Left Structural")
                              //     {
                              //         Lst_Interlock[test_interlock] = "Left&Right Structural";
                              //         structselected = true;
                              //         Console.WriteLine(" Right Struct 4");
                              //     }                                
                              //     else if (Lst_Interlock[test_interlock] == "Left Non & Right Structural")
                              //     {
                              //         Lst_Interlock[test_interlock] = "Left Non-Structural";
                              //         Console.WriteLine(" Right Struct 5");
                              //
                              //         nonstructselected = true;
                              //         structselected = false;
                              //
                              //     }
                              //     else if (Lst_Interlock[test_interlock] == "Structural")
                              //     {
                              //         Lst_Interlock[test_interlock] = "Right Structural";
                              //         structselected = true;
                              //         Console.WriteLine(" Right Struct 6");
                              //     }
                              //     else
                              //     {
                              //         lst_interlockPanelRectangles.Remove(rect);
                              //         Lst_Interlock.Remove(Lst_Interlock[test_interlock]);
                              //         structselected = false;
                              //         Console.WriteLine(" Right Struct 7");
                              //     }
                              //     
                              // }

                            }
                            else
                            {
                                lst_interlockPanelRectangles.Add(rect);
                                Lst_Interlock.Add("Right Structural");
                            }
                        }
                        _topViewdesign.GetPbox().Invalidate();
                        break;
                    }
                }
            }
            else if (parent.Text == "Non-Structural")
            {
                for (int ii = 0; ii < Lst_PanelRectangle.Count; ii++)
                {
                    Rectangle rect = Lst_PanelRectangle[ii];

                    if (rect.Contains(CursorLocX, CursorLocY))
                    {
                        if (selectedPanelRectangles.Contains(rect))
                        {
                            if (lst_interlockPanelRectangles.Contains(rect))
                            {
                                nonstructselected = false;
                                int test_interlock = lst_interlockPanelRectangles.IndexOf(rect);

                                if (Lst_Interlock[test_interlock] == "Non-Structural" ||
                                    Lst_Interlock[test_interlock] == "Left Non-Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Right Non-Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Left Non & Right Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Right Non-Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Left Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Right Non & Left Structural";
                                }
                                else if (Lst_Interlock[test_interlock] == "Right Structural")
                                {
                                    Lst_Interlock[test_interlock] = "Right Non-Structural";
                                }
                               //if (structselected == true)
                               //{                                 
                               //    if (Lst_Interlock[test_interlock] == "Left Structural")
                               //    {
                               //        Lst_Interlock[test_interlock] = "Right Non & Left Structural";
                               //        Console.WriteLine(" Right Non-Struct 1");
                               //    }
                               //    else if(Lst_Interlock[test_interlock] == "Right Non & Left Structural")
                               //    {
                               //        Lst_Interlock[test_interlock] = "Left Structural";
                               //        Console.WriteLine(" Right Non-Struct 2");
                               //    }
                               //    else
                               //    {
                               //        Lst_Interlock[test_interlock] = "Right Non-Structural";
                               //        nonstructselected = true;
                               //    }
                               //    
                               //}
                               //else
                               //{
                               //   
                               //    if (Lst_Interlock[test_interlock] == "Left Non-Structural")
                               //    {                                   
                               //        Lst_Interlock.Add("Right Non-Structural");
                               //        nonstructselected = true;
                               //        Console.WriteLine(" Right Non-Struct 3");
                               //    }
                               //    else if (Lst_Interlock[test_interlock] == "Non-Structural")
                               //    {
                               //        Lst_Interlock[test_interlock] = "Right Non-Structural";
                               //        nonstructselected = true;
                               //        Console.WriteLine(" Right Non-Struct 4");
                               //    }
                               //    else
                               //    {
                               //        lst_interlockPanelRectangles.Remove(rect);
                               //        Lst_Interlock.Remove(Lst_Interlock[test_interlock]);
                               //        nonstructselected = false;
                               //        Console.WriteLine(" Right Non-Struct 5");
                               //    }
                               //    
                               //}                            
                            }
                            else
                            {
                                lst_interlockPanelRectangles.Add(rect);
                                Lst_Interlock.Add("Right Non-Structural");
                                nonstructselected = true;
                                Console.WriteLine(" Right Non-Struct 6");
                            }
                        }
                        _topViewdesign.GetPbox().Invalidate();
                        break;
                    }
                }
            }
        }

        private void _topViewdesign_cremoneToolStripClickedEventRaised(object sender, EventArgs e)
        {
            ToolStripItem cremonemenuitem = (ToolStripItem)sender;

            string toolstrip = cremonemenuitem.ToString();

            for (int ii = 0; ii < Lst_PanelRectangle.Count; ii++)
            {

                Rectangle rect = Lst_PanelRectangle[ii];

                if (rect.Contains(CursorLocX, CursorLocY))
                {
                    if (selectedPanelRectangles.Contains(rect))
                    {
                        if (lst_handlePanelRectangles.Contains(rect))
                        {
                            int test_handle = lst_handlePanelRectangles.IndexOf(rect);

                            if (popupselected == true)
                            {
                                popupselected = false;
                                Lst_Handles[test_handle] = toolstrip;
                                cremoneselected = true;
                            }   
                            else if(dhandleselected == true)
                            {
                                dhandleselected = false;
                                Lst_Handles[test_handle] = toolstrip;
                                cremoneselected = true;
                            }
                            else
                            {
                                cremoneselected = false;
                                lst_handlePanelRectangles.Remove(rect);
                                Lst_Handles.Remove(Lst_Handles[test_handle]);
                            }                                              
                        }
                        else
                        {
                            int test_handle = lst_handlePanelRectangles.IndexOf(rect);

                            lst_handlePanelRectangles.Add(rect);
                            Lst_Handles.Add(toolstrip);
                            cremoneselected = true;                    
                        }
                    }
                    _topViewdesign.GetPbox().Invalidate();
                    break;
                }
            }
        }

        private void _topViewdesign_dhandleToolStripClickedEventRaised(object sender, EventArgs e)
        {
            ToolStripItem dhandlemenuitem = (ToolStripItem)sender;

            string toolstrip = dhandlemenuitem.ToString();

            for (int ii = 0; ii < Lst_PanelRectangle.Count; ii++)
            {

                Rectangle rect = Lst_PanelRectangle[ii];

                if (rect.Contains(CursorLocX, CursorLocY))
                {
                    if (selectedPanelRectangles.Contains(rect))
                    {                     
                        if (lst_handlePanelRectangles.Contains(rect))
                        {                          
                            int test_handle = lst_handlePanelRectangles.IndexOf(rect);

                            if (popupselected == true)
                            {
                                popupselected = false;
                                Lst_Handles[test_handle] = toolstrip;
                                dhandleselected = true;
                            }
                            else if(cremoneselected == true)
                            {
                                cremoneselected = false;
                                Lst_Handles[test_handle] = toolstrip;
                                dhandleselected = true;
                            }
                            else
                            {
                                dhandleselected = false;
                                lst_handlePanelRectangles.Remove(rect);
                                Lst_Handles.Remove(Lst_Handles[test_handle]);
                            }                         
                        }
                        else
                        {
                            int test_handle = lst_handlePanelRectangles.IndexOf(rect);

                            lst_handlePanelRectangles.Add(rect);
                            Lst_Handles.Add(toolstrip);
                            dhandleselected = true;
                        }
                    }
                    _topViewdesign.GetPbox().Invalidate();
                    break;
                }
            }
        }

        private void _topViewdesign_popupToolStripClickedEventRaised(object sender, EventArgs e)
        {
            ToolStripItem popupmenuitem = (ToolStripItem)sender;

            string toolstrip = popupmenuitem.ToString();

            for (int ii = 0; ii < Lst_PanelRectangle.Count; ii++)
            {

                Rectangle rect = Lst_PanelRectangle[ii];

                if (rect.Contains(CursorLocX, CursorLocY))
                {
                    if (selectedPanelRectangles.Contains(rect))
                    {                   
                        if (lst_handlePanelRectangles.Contains(rect))
                        {
                            int test_handle = lst_handlePanelRectangles.IndexOf(rect);

                            if (dhandleselected == true)
                            {
                                dhandleselected = false;
                                Lst_Handles[test_handle] = toolstrip;
                                popupselected = true;
                            }
                            else if(cremoneselected == true)
                            {
                                cremoneselected = false;
                                Lst_Handles[test_handle] = toolstrip;
                                popupselected = true;
                            }
                           else
                            {
                                popupselected = false;
                                lst_handlePanelRectangles.Remove(rect);
                                Lst_Handles.Remove(Lst_Handles[test_handle]);
                            }
                           
                        }
                        else
                        {
                            int test_handle = lst_handlePanelRectangles.IndexOf(rect);

                            lst_handlePanelRectangles.Add(rect);
                            Lst_Handles.Add(toolstrip);
                            popupselected = true;                     
                        }
                    }
                    _topViewdesign.GetPbox().Invalidate();
                    break;
                }
            }
        }
        private void _topViewdesign_TopViewSlidingViewMouseClickEventRaised(object sender, MouseEventArgs e)
        {
            try
            {       
                    for (int ii = 0; ii < Lst_PanelRectangle.Count; ii++)
                    {

                        Rectangle rect = Lst_PanelRectangle[ii];
                        if (rect.Contains(e.Location))
                        {
                            if (selectedPanelRectangles.Contains(rect))
                            {
                               if (e.Button == MouseButtons.Left)
                                {
                                  int test_interlock = selectedPanelRectangles.IndexOf(rect);
                                 
                                  //Remove Rectangle if de-select
                                  selectedPanelRectangles.Remove(rect);
                                  lst_interlockPanelRectangles.Remove(rect);
                                  lst_handlePanelRectangles.Remove(rect);
                                 
                                  if(selectedPanelRectangles.Remove(rect))
                                  {
                                      Lst_Handles[test_interlock] = "";
                                  }
                                  if (lst_handlePanelRectangles.Count == 0)
                                  {
                                      Lst_Handles.Clear();
                                      handlesselected = false;
                                  }
                                  if (lst_interlockPanelRectangles.Count == 0)
                                  {
                                      Lst_Interlock.Clear();
                                  }
                                 
                                  Lst_Paneltotal.Remove(Lst_Panelpointsystem[ii]);
                                  _topViewdesign.GetPbox().Invalidate();
                                  break;
                                }
                                if (e.Button == MouseButtons.Right)
                                {
                                    //Mouse Position
                                    CursorLocX = e.X;
                                    CursorLocY = e.Y;
                                    _topViewdesign.GetcmenuTopView().Show(_topViewdesign.GetPbox(), e.Location);
                                }

                             }
                            else
                            {
                                if (e.Button == MouseButtons.Left)
                                {
                                 //If Rectangle not selected, Rectangle is selected
                                selectedPanelRectangles.Add(rect); // Panel Selected
                                Lst_Paneltotal.Add(Lst_Panelpointsystem[ii]); // Point inserted
                                _topViewdesign.GetPbox().Invalidate();
                                break;
                                }
                            }                       
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
                    sum_interlock = 0,
                    sum_handle = 0,
                    interlock_point = 0,
                    interlock_total= 0,
                    handle_point = 0,
                    handle_total = 0,
                    point_total,

                   total = 0,
                   sum_point = 0;

                //<--Calculate Combination Points of SELECTED PANELS        
                for (int a = 0; a < Lst_PanelLineY.Count; a++)
                {
                    for (int i = 0; i < selectedPanelRectangles.Count; i++)
                    {
                        if (Lst_PanelLineY[a] == selectedPanelRectangles[i].Y)
                        {                             
                            sum_point = Lst_Paneltotal[i] * (a + 1);
                            sum += sum_point;                              
                        }
                    }
                    total = sum;
                }
                Console.WriteLine(" Total Points: " + total);
                //Calculate Combination Points of SELECTED PANELS -->

                //<-- Calculate Points of Interlock
                for (int a = 0; a < Lst_PanelLineY.Count; a++)
                {
                    for (int i = 0; i < lst_interlockPanelRectangles.Count; i++)
                    {
                        if (Lst_PanelLineY[a] == lst_interlockPanelRectangles[i].Y)
                        {
                                                 
                            if(Lst_Interlock[i] =="Structural")
                            {
                                interlock_point = 4 * (a + 1);
                                sum_interlock += interlock_point;
                            }
                            else if (Lst_Interlock[i] == "Right Structural")
                            {
                                interlock_point = 5 * (a + 1);
                                sum_interlock += interlock_point;
                            }
                            else if (Lst_Interlock[i] == "Left Structural")
                            {
                                interlock_point = 6 * (a + 1);
                                sum_interlock += interlock_point;
                            }                                               
                            else if (Lst_Interlock[i] == "Non-Structural")
                            {
                                interlock_point = 1 * (a + 1);
                                sum_interlock += interlock_point;
                            }
                            else if (Lst_Interlock[i] == "Right Non-Structural")
                            {
                                interlock_point = 2 * (a + 1);
                                sum_interlock += interlock_point;
                            }
                            else if (Lst_Interlock[i] == "Left Non-Structural")
                            {
                                interlock_point = 3 * (a + 1);
                                sum_interlock += interlock_point;
                            }
                            else if (Lst_Interlock[i] == "Right Non & Left Structural")
                            {
                                interlock_point = (2 + 3) * (a + 1);
                                sum_interlock += interlock_point;
                            }
                            else if (Lst_Interlock[i] == "Left Non & Right Structural")
                            {
                                interlock_point = (2 + 1) * (a + 1);
                                sum_interlock += interlock_point;
                            }
                        }
                    }
                    interlock_total = sum_interlock;
                    
                }
                Console.WriteLine("Total Interlock: " + interlock_total);
                //Calculate Points of InterLock -->

                //<--Calculate Points of Handles
                for (int a = 0; a < Lst_PanelLineY.Count; a++)
                {
                    for (int i = 0; i < lst_handlePanelRectangles.Count; i++)
                    {
                        if (Lst_PanelLineY[a] == lst_handlePanelRectangles[i].Y)
                        {

                          //  if (Lst_Handles[i] == "Pop up")
                          //  {
                          //      handlesselected = true;
                          //      handle_point = 1 * (a + 1);
                          //      sum_handle += handle_point;
                          //  }
                          //  else if (Lst_Handles[i] == "D-Handle")
                          //  {
                          //      handlesselected = true;
                          //      handle_point = 2 * (a + 1);
                          //      sum_handle += handle_point;
                          //  }
                          //  else if (Lst_Handles[i] == "Cremone")
                          //  {
                          //      handlesselected = true;
                          //      handle_point = 3 * (a + 1);
                          //      sum_handle += handle_point;
                          //  }
                              if(a > 0)
                              {
                                  handlesselected = true;
                                  Console.WriteLine("Checking 1");
                                  if (Lst_Handles[i] == "Pop up")
                                  {
                                      
                                      handle_point = 1 * (a + 1);
                                      sum_handle += handle_point;
                                  }
                                  else if (Lst_Handles[i] == "D-Handle")
                                  {
                                      handle_point = 2 * (a + 1);
                                      sum_handle += handle_point;
                                  }
                                  else if (Lst_Handles[i] == "Cremone")
                                  {
                                      handle_point = 3 * (a + 1);
                                      sum_handle += handle_point;
                                  }
                              }
                              else
                              {
                                  handlesselected = false;
                                  Console.WriteLine("Checking 2");
                                  if (Lst_Handles[i] == "Pop up")
                                  {
                                      
                                      handle_point = 1;
                                      sum_handle += handle_point;
                                  }
                                  else if (Lst_Handles[i] == "D-Handle")
                                  {
                                      
                                      handle_point = 2;
                                      sum_handle += handle_point;
                                  }
                                  else if (Lst_Handles[i] == "Cremone")
                                  {
                                      
                                      handle_point = 3;
                                      sum_handle += handle_point;
                                  }
                              }

                        }
                    }
                    handle_total = sum_handle;
                  
                }
                Console.WriteLine("Total Handle: " + handle_total);
                // Calculate Points of Handles -->

                // _topviewpanelviewer.showTopViewPanelViewer();
                if(handlesselected)
                {
                    TotalPoints = (total + interlock_total) * handle_total;
                }
                else
                {
                    TotalPoints = (total + interlock_total) + handle_total;
                }
               
             //   _windoorModel.WD_topviewpoints = TotalPoints;
             //   _windoorModel.WD_TopViewSaved = true;
               MessageBox.Show("Total Points: " + TotalPoints);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         //   _mainPresenter.Get_TopViewPanelViewer();
         //   _topViewdesign.CloseTopView();



        }
        public void Get_TopViewPanelViewer()
        {
           
        }
        private void _topViewdesign_TopViewSlidingViewMouseMoveEventRaised(object sender, MouseEventArgs e)
        {      
               //   Console.WriteLine("Coordinates X: " + CursorLocX + " Y: " + CursorLocY);
        }
        private void _topViewdesign_TopViewSlidingViewLoadEventRaised(object sender, EventArgs e)
        {
            _frameModel.Frame_SlidingRailsQty = _frameModel.Frame_SlidingRailsQty;

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
            
            foreach (IWindoorModel wndr in _quotationModel.Lst_Windoor)
            {
                if(_windoorModel.WD_Selected == true)
                {
                    topview_track = _frameModel.Frame_SlidingRailsQty;
                }
            }
                //  test_pnlCount = _windoorModel.pnlCount;
               
            string test_name = _windoorModel.WD_name;
            int total_points = 0,
                sum_points = 0,
                sum = 0;
            for( int i = 0; i < topview_track; i ++)
            {
                point_multiplier = i + 1;
                Lst_multiplier.Add(point_multiplier);
                if (i == 0 || i % 2 == 0)
                {
                    for (int ii = topview_pnlCount; ii >= 1; ii--)
                    {
                        Lst_Panelpointsystem.Add(ii);
                        sum += ii;                     
                    }
                    sum_points = sum * point_multiplier;
                }
                else
                {
                    sum = 0;
                    for (int ii = 0; ii < topview_pnlCount; ii++)
                    {
                        Lst_Panelpointsystem.Add(ii + 1);
                        sum += ii + 1;                      
                    }
                    sum_points = sum * point_multiplier;
                }
                total_points += sum_points;

            }       
            Console.WriteLine("Total Points: " + total_points);

            //  foreach (int value in Lst_Panelpointsystem)
            //  {
            //      Console.WriteLine(value);
            //    
            //  }

            _topViewdesign.ThisBinding(CreateBindingDictionary());
            _topViewdesign.GetThis().Invalidate();
            _topViewdesign.GetLabelTracks().Text = _frameModel.Frame_SlidingRailsQty.ToString();
            _topViewdesign.GetLabelPanel().Text = topview_pnlCount.ToString();
        }
        private void _topViewdesign_TopViewPaintEventRaised(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int panel_width = _topViewdesign.GetPbox().Width,
              panel_height = _topViewdesign.GetPbox().Height;

            Color tracklightgray = Color.FromArgb(163, 163, 163);
            Color panelgray = Color.FromArgb(100, 100, 100);
            Color tracmidgray = Color.Gray;

            handle_names = new Font("Segoe UI", 10, FontStyle.Bold);


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
                     new Point(outerX, defaultY),
                     new Point((panel_width) + outerY, defaultY)
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
                    if (topview_pnlCount > 4)
                    {
                        panel_bounds.X = (defaultX - addX) -10;
                        panel_bounds.Width = 90;
                    }
                    if (topview_pnlCount > 5)
                    {
                        panel_bounds.X = (defaultX - addX) - 5;
                        panel_bounds.Width = 80;
                    }
                    if (topview_pnlCount > 6)
                    {
                        panel_bounds.X = (defaultX - addX) -5;
                        panel_bounds.Width = 65;
                    }
                    Panelline_PointsX = new[]
                    {
                           new Point(defaultX - addX , defaultY),
                           new Point(defaultX , defaultY)
                    };
                    Lst_PanelRectangle.Add(panel_bounds);
                }



            }
            //<-- Panel is Selected
            
            foreach (Rectangle rect in Lst_PanelRectangle)
            {
                if (selectedPanelRectangles.Contains(rect))
                {
                    Rectangle new_rect = rect;
                    // Rectangle is selected, fill it with blue color
                    g.DrawRectangle(new Pen(Color.FromArgb(115,115,255), 1), rect);
                    g.FillRectangle(Brushes.LightBlue, rect);
                   if(interlockselected)
                   {
                      
                        if (lst_interlockPanelRectangles.Contains(rect))
                        {
                            int test_interlock = lst_interlockPanelRectangles.IndexOf(rect);
                            if (Lst_Interlock[test_interlock] == "Non-Structural") //Both Non-structural
                            {
                                g.DrawRectangle(new Pen(Color.Green, 1), rect);
                                g.FillRectangle(Brushes.Green, rect);

                                new_rect.X = (rect.X + (rect.Width / 2)) - 22;
                                new_rect.Width = (rect.Width / 2) - 4;
                                g.FillRectangle(Brushes.LightBlue, new_rect);

                            }
                            else if (Lst_Interlock[test_interlock] == "Left Structural")
                            {                             
                                new_rect.Width = (rect.Width / 2) - 10;

                                g.FillRectangle(Brushes.Crimson, new_rect);
                            }
                            else if (Lst_Interlock[test_interlock] == "Right Non & Left Structural")
                            {
                                g.DrawRectangle(new Pen(Color.Crimson, 1), rect);
                                g.FillRectangle(Brushes.Crimson, rect);

                                new_rect.X = (rect.X + (rect.Width / 2)) + 10;
                                new_rect.Width = (rect.Width / 2) - 10;
                                g.FillRectangle(Brushes.Green, new_rect);

                                new_rect.X = (rect.X + (rect.Width / 2)) - 30;
                                new_rect.Width = (rect.Width / 2) - 15;
                                g.FillRectangle(Brushes.LightBlue, new_rect);
                            }
                            else if (Lst_Interlock[test_interlock] == "Left Non & Right Structural")
                            {
                                g.DrawRectangle(new Pen(Color.Crimson, 1), rect);
                                g.FillRectangle(Brushes.Crimson, rect);
                             
                                new_rect.Width = (rect.Width / 2) - 10;
                                g.FillRectangle(Brushes.Green, new_rect);

                                new_rect.X = (rect.X + (rect.Width / 2)) - 30;
                                new_rect.Width = (rect.Width / 2) - 15;
                                g.FillRectangle(Brushes.LightBlue, new_rect);
                            }
                            else if (Lst_Interlock[test_interlock] == "Left Non-Structural")
                            {
                                new_rect.Width = (rect.Width / 2) - 10;
                                g.FillRectangle(Brushes.Green, new_rect);
                            }
                            else if (Lst_Interlock[test_interlock] == "Right Structural")
                            {
                                new_rect.X = (rect.X + (rect.Width / 2)) + 10;
                                new_rect.Width = (rect.Width / 2) - 10;
                                g.FillRectangle(Brushes.Crimson, new_rect);
                            }
                            else if (Lst_Interlock[test_interlock] == "Right Non-Structural")
                            {
                                new_rect.X = (rect.X + (rect.Width / 2)) + 10;
                                new_rect.Width = (rect.Width / 2) - 10;
                                g.FillRectangle(Brushes.Green, new_rect);
                            }
                            else
                            {
                                g.DrawRectangle(new Pen(Color.Crimson, 1), rect);
                                g.FillRectangle(Brushes.Crimson, rect);

                                new_rect.X = (rect.X + (rect.Width / 2)) - 22;
                                new_rect.Width = (rect.Width / 2) - 4;
                                g.FillRectangle(Brushes.LightBlue, new_rect);
                            }
                           
                        }
                  
                 
                   //   if (structPanelRectangles.Contains(rect))
                   //   {
                   //       g.DrawRectangle(new Pen(Color.Red, 1), rect);
                   //       g.FillRectangle(Brushes.Red, rect);
                   //   }
                            
                   }
                   if(lst_handlePanelRectangles.Contains(rect))
                    {
                        int test_handle = lst_handlePanelRectangles.IndexOf(rect);

                       // g.FillRectangle(Brushes.White, rect);
                        g.DrawString(Lst_Handles[test_handle], handle_names, Brushes.Black, rect.X + 12, (rect.Y + 10));

                    }                  
                }
                else
                {
                    // Rectangle is not selected, fill it with gray color
                    g.DrawRectangle(new Pen(panelgray, 1), rect);
                    g.FillRectangle(Brushes.LightGray, rect);
                }
            }

       //    if(interlockselected)
       //    {
       //        for (int a = 0; a < Lst_PanelLineY.Count; a++)
       //        {
       //            for (int i = 0; i < selectedPanelRectangles.Count; i++)
       //            {
       //                Rectangle rect = selectedPanelRectangles[i];
       // 
       //                if (rect.Contains(CursorLocX, CursorLocY))
       //                {
       //                    if (Lst_PanelLineY[a] == selectedPanelRectangles[i].Y)
       //                    {
       //                       // if(nonstructselect)
       //                        if(Lst_Interlock[i] == "Non-Structural")
       //                        {
       //                            g.DrawRectangle(new Pen(Color.Green, 1), rect);
       //                            g.FillRectangle(Brushes.Green, rect);
       //                        }
       //                        //  if(structuralselect)
       //                        if (Lst_Interlock[i] == "Structural")
       //                        {
       //                            g.DrawRectangle(new Pen(Color.Red, 1), rect);
       //                            g.FillRectangle(Brushes.Red, rect);
       //                        }
       //                      
       //                    }
       //                  
       //                 
       //                }
       //            }
       // 
       //        }
       // 
       //    }

            // Panel is Selected -->

            //<-- Menu Strip Selected (InterLock)



            // Menu Strip selected (InterLock) -->

        }


        public ITopView GetTopViewDesign()
        {
            return _topViewdesign;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
           // binding.Add("Frame_SlidingRailsQty", new Binding("Value", _frameModel, "Frame_SlidingRailsQty", true, DataSourceUpdateMode.OnPropertyChanged));
            //       binding.Add("WD_TopViewType", new Binding("TEXT", _windoorModel, "WD_TopViewType", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

        public ITopViewPresenter GetNewInstance(IMainPresenter mainPresenter,
                                           IUnityContainer unityC,
                                           IPanelModel panelModel,
                                           IFrameModel frameModel,
                                           IWindoorModel windoorModel,
                                           IQuotationModel quotationModel)
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
            TVPresenter._quotationModel = quotationModel;

            return TVPresenter;
        }
    }
    
}
