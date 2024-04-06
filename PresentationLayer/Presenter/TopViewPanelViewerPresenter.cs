using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.Panel;
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
    

        PictureBox _pboxFrame,
                    _pboxPanel;
        Panel _pnlPanelling;


        Image topview_toppart, 
            topview_bottompart;

        bool isImgBinded;

        public TopViewPanelViewerPresenter(ITopViewPanelViewer topViewPanelViewer)
        {
            _topViewPanelViewer = topViewPanelViewer;

            _pboxFrame = _topViewPanelViewer.GetTopViewPictureBox();
            _pnlPanelling = _topViewPanelViewer.GetPnlTopViewer();
            _pboxPanel = _topViewPanelViewer.GetPnlPanelViewer();

            SubscribeToEventSetUp();
        }
        private void SubscribeToEventSetUp()
        {
            _topViewPanelViewer.TopViewPanelViewLoadEventRaised += _topViewPanelViewer_TopViewPanelViewLoadEventRaised;
            _topViewPanelViewer.TopViewPanelViewButtonClickEventRaised += _topViewPanelViewer_TopViewPanelViewButtonClickEventRaised;
            _topViewPanelViewer.pnlSlidingArrowPaintEventRaised += _topViewPanelViewer_pnlSlidingArrowPaintEventRaised;
            _topViewPanelViewer.TopViewSlidingViewMouseUpEventRaised += _topViewPanelViewer_TopViewSlidingViewMouseUpEventRaised;
        }
        private void _topViewPanelViewer_TopViewPanelViewButtonClickEventRaised(object sender, EventArgs e)
        {
            if(_windoorModel.WD_Selected == true)
            {
                if(_windoorModel.WD_TopViewSaved == true)
                {
                    _windoorModel.WD_TopViewSaved = false;
                    _topViewPanelViewer.CloseTopViewPanelViewer();
                    _mainPresenter.Get_TopViewSelectPanel();
                }
            }
            
      //     ITopViewPresenter topViewDesign = _topviewPresenter.GetNewInstance(this, _unityC, _panelModel, _frameModel, _windoorModel);
      //     topViewDesign.GetTopViewDesign().ShowTopView();
        }
        private void _topViewPanelViewer_TopViewSlidingViewMouseUpEventRaised(object sender, MouseEventArgs e)
        {
           // Console.WriteLine("X: " + e.X + " Y: " + e.Y);
        }
        private void _topViewPanelViewer_pnlSlidingArrowPaintEventRaised(object sender, PaintEventArgs e)
        {
            Panel basePL = (Panel)sender;
            PictureBox pbox = (PictureBox)basePL.Controls[0];
            Font dmnsion_font_wd = new Font("Segoe UI", 22, FontStyle.Bold);
            Font panel_font_wd = new Font("Segoe UI", 22, FontStyle.Bold);
            PictureBox pbox_Panel = (PictureBox)_topViewPanelViewer.GetPnlPanelViewer();

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            int pnl_width = pbox.Width,
                pnl_height = pbox.Height,

                locX = 20,
                width_reduce = 140;
            Rectangle pnl_rectangle = new Rectangle(locX, 0,
                                              pnl_width - width_reduce, pnl_height - 2);

            //   g.DrawRectangle(new Pen(Color.Black, 1), pnl_rectangle);

            int total_frame = _windoorModel.lst_frame.Count;
            int total_panel = 0, total_mpanel = 0;

            
            if (!isImgBinded)
            {
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
                    int TotalArrowWidthBounds = pnl_width,
                        TotalArrowHeightBounds = basePL.Height - 35;

                    float pnllocX = 0;
                    foreach (KeyValuePair<int, decimal> KV_WD in _windoorModel.Dictionary_wd_redArrowLines)
                    {
                        decimal wd_count = _windoorModel.WD_width / _windoorModel.Dictionary_wd_redArrowLines.Count;
                        //pnl_rectangle.Width = (pnl_width - width_reduce) / 2;
                        //g.DrawRectangle(new Pen(Color.Red, 1), pnl_rectangle);
                        //
                        //pnl_rectangle.X += (pnl_width - width_reduce) / 2;
                        //  Console.WriteLine(" Width :" + wd_count);
                        decimal WidthPercentage = wd_count / _windoorModel.WD_width,
                                FinalWidth = WidthPercentage * TotalArrowWidthBounds;

                        pnllocX = Draw_Panel_Arrow(KV_WD.Key, KV_WD.Value, FinalWidth, e, pnllocX, dmnsion_font_wd, locX);
                        // Console.WriteLine(" Value :" + KV_WD.Value);
                        // Console.WriteLine(" Width :" + TotalArrowWidthBounds);
                        // Console.WriteLine(" WidthPercentage :" + WidthPercentage);
                        // Console.WriteLine(" FinalWidth = Actual_Width" + FinalWidth);
                        //  decimal WidthPercentage = KV_WD.Value / _windoorModel.WD_width,
                        //          FinalWidth = WidthPercentage * TotalArrowWidthBounds;
                        //  locX = Draw_Arrow_Width(KV_WD.Value, FinalWidth, e, locX, dmnsion_font_wd, ctrl_Y);
                    }
                }



                Bitmap bm = new Bitmap(basePL.Size.Width, basePL.Size.Height);
                basePL.DrawToBitmap(bm, new Rectangle(0, 0, basePL.Size.Width, basePL.Size.Height));
                topview_bottompart = bm;

                isImgBinded = true;
                g.Dispose();
               // _topViewPanelViewer.GetPnlTopViewer().Invalidate();
                _topViewPanelViewer.GetTopViewPanelViewer().Invalidate();
            }

          
               
               
            
           
        }
       
        private float Draw_Panel_Arrow(int txt_panelwidth, decimal txt_width, decimal actual_width, PaintEventArgs e, float pnllocX, Font dmnsion_font_wd, int ctrl_Y)
        {
            Graphics g = e.Graphics;
            int panels = 1;
            string dmnsion_w = txt_width.ToString(),
                    panel_coutns = txt_panelwidth.ToString();
            if(dmnsion_w.Contains(".0"))
            {
                dmnsion_w = dmnsion_w.Replace(".0", "");
            }

            Font panel_font_wd = new Font("Segoe UI", 35, FontStyle.Bold);

            float DispWd_float = (float)actual_width;
            float pnl_Y = (float)ctrl_Y;
       

            PointF dmnsion_startP = new PointF((_pboxPanel.Location.X + pnllocX),
                                                _pnlPanelling.Height - pnl_Y);

            PointF dmnsion_endP = new PointF(((_pboxPanel.Location.X - 3) + (pnllocX + DispWd_float)),
                                             _pnlPanelling.Height - pnl_Y);

            Size s2 = TextRenderer.MeasureText(dmnsion_w, dmnsion_font_wd);
            Size s3 = TextRenderer.MeasureText(panel_coutns, panel_font_wd);
            double mid = (dmnsion_startP.X + dmnsion_endP.X) / 2;

            //arrow for WIDTH
            PointF[] arrwhd_pnts_W1 =
            {
                    new PointF(dmnsion_startP.X,dmnsion_startP.Y - 10),
                    dmnsion_startP,
                    new PointF(dmnsion_startP.X,dmnsion_startP.Y + 10),
            };

            PointF[] arrwhd_pnts_W2 =
            {
                new PointF(dmnsion_endP.X, dmnsion_endP.Y - 10),
                dmnsion_endP,
                new PointF(dmnsion_endP.X, dmnsion_endP.Y + 10)
            };

            Rectangle panel_squares = new Rectangle((int)dmnsion_startP.X , _pboxPanel.Location.Y + 3,
                                                    (int)DispWd_float, _pboxPanel.Height - 3);

            PointF[] arr_bg_colorT =
          {
                             new PointF(dmnsion_startP.X -3.8f , dmnsion_startP.Y - 11),
                             new PointF(dmnsion_startP.X -3.8f  , dmnsion_startP.Y - 1.9f)
                        };

            PointF[] arr_bg_colorB =
           {
                             new PointF(dmnsion_startP.X -3.7f , dmnsion_startP.Y + 11),
                             new PointF(dmnsion_startP.X -3.7f  , dmnsion_startP.Y + 1.6f)
                        };
            if (_windoorModel.lst_frame.Count > 0)
            {
                g.DrawRectangle(new Pen(Color.Black, 3.5f), panel_squares);

                //PANELS 
                g.DrawLines(new Pen(Color.Red, 3.5f), arrwhd_pnts_W1);
                TextRenderer.DrawText(g,
                                      panel_coutns,
                                      panel_font_wd,
                                      new Rectangle(new Point(((int)mid - (s3.Width / 2)), (panel_squares.Height / 2)- (s3.Width / 2)),
                                                    new Size(s3.Width, s3.Height)),
                                      Color.Black,
                                      SystemColors.ControlLightLight,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                //RED ARROW LINES
                g.DrawLine(new Pen(Color.Red, 3.5f), dmnsion_startP, dmnsion_endP);
                g.DrawLines(new Pen(Color.Red, 3.5f), arrwhd_pnts_W2);
                g.DrawLines(new Pen(Color.White, 3.5f), arr_bg_colorT);
                g.DrawLines(new Pen(Color.White, 3.5f), arr_bg_colorB);
                TextRenderer.DrawText(g,
                                      dmnsion_w,
                                      dmnsion_font_wd,
                                      new Rectangle(new Point((int)(mid - (s2.Width / 2)), _pnlPanelling.Height - 42),
                                                    new Size(s2.Width, s2.Height)),
                                      Color.Black,
                                      SystemColors.ControlLightLight,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);


            }


            panels += panels;
            pnllocX += DispWd_float;
            return pnllocX;
        }
        
        private void _topViewPanelViewer_TopViewPanelViewLoadEventRaised(object sender, EventArgs e)
        {
           
            PictureBox pbox_Topview = (PictureBox)_topViewPanelViewer.GetTopViewPictureBox();
            PictureBox pbox_Panel = (PictureBox)_topViewPanelViewer.GetPnlPanelViewer();
            int points_for_topview = _windoorModel.WD_topviewpoints;



            string itemname = _windoorModel.WD_name;
            _topViewPanelViewer.topviewpanel_title = "Top View Panel Viewer (" + itemname + ")";

            Console.WriteLine("List: " + itemname +" Viewer Points: " + _windoorModel.WD_topviewpoints);

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
            if(total_panel == 4)
            {
                pbox_Panel.Location = new Point(55, 0);
                _pboxPanel.Size = new Size(700, 228);
            }



            if (points_for_topview == 12)
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
            else if (points_for_topview == 18)
            {
                pbox_Topview.Image = Properties.Resources.Combination5;
            }

           
            pbox_Topview.SizeMode = PictureBoxSizeMode.StretchImage;

            topview_bottompart = pbox_Topview.Image;

   
            LoadTopViewPanel(pbox_Topview);

            //  _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();

            //    SetImagerHeight();
            //    _mainPresenter.basePlatformWillRenderImg_MainPresenter.SetWdFlpImage();
            //    _topViewPanelViewer.ThisBinding(CreateBindingDictionary());
        }
        private void LoadTopViewPanel(PictureBox bottom_topview)
        {
            if (isImgBinded)
            {
                bottom_topview.Image = Properties.Resources.duplicate;
                bottom_topview.Invalidate();
            }

        }
        public ITopViewPanelViewer GetSetTopViewSlidingPanellingView()
        {
            return _topViewPanelViewer;
        }
        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("pnlTopViewer", new Binding("Image", _windoorModel, "WD_TopViewImage", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

        public ITopViewPanelViewerPresenter CreateNewInstance(IUnityContainer unityC,
                                                        IMainPresenter mainPresenter,
                                                        IWindoorModel windoorModel)
        {
            unityC
                .RegisterType<ITopViewPanelViewer, TopViewPanelViewer>()
                .RegisterType<ITopViewPanelViewerPresenter, TopViewPanelViewerPresenter>();
            TopViewPanelViewerPresenter TopView = unityC.Resolve<TopViewPanelViewerPresenter>();
            TopView._unityC = unityC;
            TopView._mainPresenter = mainPresenter;
            TopView._windoorModel = windoorModel;

            return TopView; 
        }
    }
}
