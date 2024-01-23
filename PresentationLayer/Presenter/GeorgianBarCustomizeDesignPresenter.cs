using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter
{
    public class GeorgianBarCustomizeDesignPresenter : IGeorgianBarCustomizeDesignPresenter
    {

        IGeorgianBarCustomizeDesignView _georgianBarCustomizeDesignView;

        private IMainPresenter _mainPresenter;
        private IUnityContainer _unityC;
        private IPanelModel _panelModel;
        private IWindoorModel _windoorModel;


        Color pInnerLinePrevColor;
        Color pInnerLineColor = Color.Black;//Color.FromArgb(245, 245, 220);
        Color pInnerLineColorHighlight = Color.LimeGreen;
        Color pInnerLineColorDefault = Color.Black; //Color.FromArgb(245, 245, 220);
        Point verticalP1 = new Point(500, 0),
              verticalP2 = new Point(500, 1000);//= position testing 
        List<int> Lst_GeorgianBarX = new List<int>();
        List<int> Lst_GeorgianBarY = new List<int>();


        int CursurLocX,
            CursurLocY,
            positionX,
            positionY,
            verticalSelectedCount,
            horizontalSelectedCount,
            defaultX,
            defaultY;

        bool draggingX,
            draggingY,
            addXtoList,
            addYtoList;


        public GeorgianBarCustomizeDesignPresenter(IGeorgianBarCustomizeDesignView georgianBarCustomizeDesignView)
        {
            _georgianBarCustomizeDesignView = georgianBarCustomizeDesignView;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _georgianBarCustomizeDesignView.GeorgianBarCustomizeDesignViewLoadEventRaised += _georgianBarCustomizeDesignView_GeorgianBarCustomizeDesignViewLoadEventRaised;

            _georgianBarCustomizeDesignView.GeorgianBarCustomizeDesignViewPaintEventRaised += _georgianBarCustomizeDesignView_GeorgianBarCustomizeDesignViewPaintEventRaised;
            _georgianBarCustomizeDesignView.FormTimerTickEventRaised += _georgianBarCustomizeDesignView_FormTimerTickEventRaised;
            _georgianBarCustomizeDesignView.GeorgianBarCustomizeDesignViewMouseMoveEventRaised += _georgianBarCustomizeDesignView_GeorgianBarCustomizeDesignViewMouseMoveEventRaised;
            _georgianBarCustomizeDesignView.GeorgianBarCustomizeDesignViewMouseDownEventRaised += _georgianBarCustomizeDesignView_GeorgianBarCustomizeDesignViewMouseDownEventRaised;
            _georgianBarCustomizeDesignView.GeorgianBarCustomizeDesignViewMouseUpEventRaised += _georgianBarCustomizeDesignView_GeorgianBarCustomizeDesignViewMouseUpEventRaised;
            _georgianBarCustomizeDesignView.GeorgianBarCustomizeDesignViewMouseClickEventRaised += _georgianBarCustomizeDesignView_GeorgianBarCustomizeDesignViewMouseClickEventRaised;

        }

        private void _georgianBarCustomizeDesignView_GeorgianBarCustomizeDesignViewMouseClickEventRaised(object sender, MouseEventArgs e)
        {
            Point mousePosition = new Point(e.X, e.Y);
            getLineCount(mousePosition);
        }

        private void _georgianBarCustomizeDesignView_GeorgianBarCustomizeDesignViewMouseUpEventRaised(object sender, MouseEventArgs e)
        {
            if (draggingX)
            {
                draggingX = false;
                Lst_GeorgianBarX[verticalSelectedCount] = e.X;
                Console.WriteLine("dropX");

                ////test
                //dragging = false;
                //verticalP1.X = e.X;
                //verticalP2.X = e.X;

                //Console.WriteLine("drop");
            }

            if (draggingY)
            {
                draggingY = false;
                Lst_GeorgianBarY[horizontalSelectedCount] = e.Y;
                Console.WriteLine("dropY");
            }
        }

        private void _georgianBarCustomizeDesignView_GeorgianBarCustomizeDesignViewMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            int inner_line = 15;
            if (_windoorModel.WD_zoom_forImageRenderer == 0.17f)
            {
                inner_line = 8;
            }
            else if (_windoorModel.WD_zoom_forImageRenderer == 0.13f || _windoorModel.WD_zoom_forImageRenderer == 0.10f)
            {
                inner_line = 7;
            }

            if (e.X <= (Lst_GeorgianBarX[verticalSelectedCount] + (inner_line / 2) - 2) &&
                e.X >= (Lst_GeorgianBarX[verticalSelectedCount] - (inner_line / 2)) + 2)
            {

                draggingX = true;
                Console.WriteLine("draggingX");
            }

            if (e.Y <= (Lst_GeorgianBarY[horizontalSelectedCount] + (inner_line / 2) - 2) &&
                e.Y >= (Lst_GeorgianBarY[horizontalSelectedCount] - (inner_line / 2)) + 2)
            {
                draggingY = true;
                Console.WriteLine("draggingY");
            }
            ////test
            //if (e.X <= (verticalP1.X + (inner_line / 2) - 2) &&
            //    e.X >= (verticalP1.X - (inner_line / 2)) + 2)
            //{
            //   dragging = true;
            //   Console.WriteLine("dragging");
            //}
        }

        private void _georgianBarCustomizeDesignView_GeorgianBarCustomizeDesignViewMouseMoveEventRaised(object sender, MouseEventArgs e)
        {
            CursurLocX = e.X;
            CursurLocY = e.Y;

            ////test
            if (draggingX)
            {
                positionX = e.X;
            }

            if (draggingY)
            {
                positionY = e.Y;
            }

        }

        private void _georgianBarCustomizeDesignView_FormTimerTickEventRaised(object sender, EventArgs e)
        {
            if (positionX != 0)
            {
                Lst_GeorgianBarX[verticalSelectedCount] = positionX;
            }


            if (positionY != 0)
            {
                Lst_GeorgianBarY[horizontalSelectedCount] = positionY;
            }


            ////test
            //if (position !=0)
            //{
            //    verticalP1.X = position;
            //    verticalP2.X = position;
            //}

            _georgianBarCustomizeDesignView.GetFormView().Invalidate();
        }

        private void getLineCount(Point CurLoc)
        {
            int inner_line = 15;
            if (_windoorModel.WD_zoom_forImageRenderer == 0.17f)
            {
                inner_line = 8;
            }
            else if (_windoorModel.WD_zoom_forImageRenderer == 0.13f || _windoorModel.WD_zoom_forImageRenderer == 0.10f)
            {
                inner_line = 7;
            }

            for (int i = 0; i < Lst_GeorgianBarX.Count; i++)
            {
                if (CurLoc.X <= (Lst_GeorgianBarX[i] + (inner_line / 2) - 2) &&
                    CurLoc.X >= (Lst_GeorgianBarX[i] - (inner_line / 2)) + 2)
                {
                    verticalSelectedCount = i;
                    positionX = CurLoc.X;
                    Console.WriteLine("Vertical line count" + i);
                }
            }


            for (int i = 0; i < Lst_GeorgianBarY.Count; i++)
            {
                if (CurLoc.Y <= (Lst_GeorgianBarY[i] + (inner_line / 2) - 2) &&
                    CurLoc.Y >= (Lst_GeorgianBarY[i] - (inner_line / 2)) + 2)
                {
                    horizontalSelectedCount = i;
                    positionY = CurLoc.Y;
                    Console.WriteLine("Horizontal line count" + i);
                }
            }
        }

        private void _georgianBarCustomizeDesignView_GeorgianBarCustomizeDesignViewPaintEventRaised(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Color PC;

            ////test
            //Color PC;
            //if (dragging)
            //{
            //    PC = Color.Yellow;
            //}
            //else
            //{
            //    PC = Color.Violet;
            //}
            //g.DrawLine(new Pen(PC, 8), verticalP1, verticalP2);


            #region gbdraw

            List<Size> windoor_objects_sizes = new List<Size>();


            foreach (var objects in _windoorModel.lst_objects)
            {
                if (objects.Name.Contains("Frame"))
                {
                    foreach (IFrameModel frame in _windoorModel.lst_frame)
                    {
                        if (objects.Name == frame.Frame_Name)
                        {
                            windoor_objects_sizes.Add(new Size(frame.FrameImageRenderer_Width, frame.FrameImageRenderer_Height));
                            break;
                        }
                    }
                }
            }
            int basePlatformImage_Width_minus70 = _windoorModel.WD_width_4basePlatform_forImageRenderer - 70;

            List<Point> object_points = OuterFrame_DrawPoints(windoor_objects_sizes, basePlatformImage_Width_minus70);


            for (int i = 0; i < object_points.Count; i++)
            {
                var objects = _windoorModel.lst_objects[i];
                if (objects.Name.Contains("Frame"))
                {
                    IFrameModel frameModel = _windoorModel.lst_frame.Find(frame => frame.Frame_Name == _windoorModel.lst_objects[i].Name);


                    //Draw panel per frame
                    if (frameModel.Lst_Panel.Count == 1)
                    {
                        Point pPoint = Panel_MPanel_DrawPoints_ParentIsFrame(object_points[i], frameModel.FrameImageRenderer_Padding_int.Top, frameModel.FrameImageRenderer_Padding_int.Left);
                        Draw_Panel(e, frameModel.Lst_Panel[0], pPoint);
                    }
                }
            }
            #endregion
        }

        public List<Point> OuterFrame_DrawPoints(List<Size> frameImager_sizes, int basePlatformImage_Width_minus70)
        {
            List<Point> object_points = new List<Point>();
            List<int> curr_LocY = new List<int>();

            int flocX = 0, controlndex = 0, flocY = 0, prev_wd_covered = 0, prev_ht_covered = 0, total_wd_covered = 0, total_ht_covered = 0, frame_row = 0;

            //int occupiedWidth = 0,
            //    occupiedHeight = 0,
            //    Maxheight = 0,
            //    availableWidth = _windoorModel.WD_width,
            //    availableHeight = _windoorModel.WD_height;
            //bool isDimentionFit = true;

            //foreach (var wndrObject in _windoorModel.lst_objects)
            //{
            //    if (wndrObject.Name.Contains("Frame"))
            //    {
            //        foreach (IFrameModel frm in _windoorModel.lst_frame)
            //        {
            //            if (wndrObject.Name == frm.Frame_Name)
            //            {
            //                if (flocX == 0 && flocY == 0)
            //                {
            //                    object_points.Add(new Point(flocX, flocY));
            //                    flocX += frm.FrameImageRenderer_Width;
            //                    controlndex = frm.FrameImageRenderer_Height;
            //                    availableWidth = frm.Frame_Width;
            //                    occupiedWidth += frm.Frame_Width;
            //                }
            //                else
            //                {
            //                    if (availableWidth >= frm.Frame_Width)
            //                    {

            //                        if (availableHeight >= frm.Frame_Height)
            //                        {
            //                            occupiedWidth += frm.Frame_Width;

            //                            if (Maxheight < frm.Frame_Height)
            //                            {
            //                                Maxheight = frm.Frame_Height;
            //                            }
            //                        }
            //                        else
            //                        {
            //                            isDimentionFit = false;
            //                        }
            //                        if (availableWidth == frm.Frame_Width)
            //                        {
            //                            flocY += controlndex;
            //                        }

            //                    }
            //                    if (occupiedWidth >= _windoorModel.WD_width)
            //                    {
            //                        occupiedHeight += Maxheight;
            //                        occupiedWidth = 0;
            //                        availableWidth = _windoorModel.WD_width;
            //                        availableHeight -= Maxheight;
            //                        Maxheight = 0;
            //                        flocX = 0;
            //                        controlndex = frm.FrameImageRenderer_Height;
            //                        object_points.Add(new Point(flocX, flocY));

            //                    }
            //                    else
            //                    {
            //                        if (availableHeight > frm.Frame_Height && (_windoorModel.WD_width - occupiedWidth) < frm.Frame_Width)
            //                        {
            //                            availableWidth = _windoorModel.WD_width;
            //                            occupiedHeight += frm.Frame_Height;
            //                            availableHeight -= frm.Frame_Height;
            //                            Maxheight = 0;
            //                            flocY += frm.FrameImageRenderer_Height;
            //                            flocX = 0;
            //                        }
            //                        else
            //                        {
            //                            availableWidth -= frm.Frame_Width;

            //                        }
            //                        object_points.Add(new Point(flocX, flocY));

            //                    }
            //                }
            //                break;
            //            }

            //        }
            //    }
            //    if (wndrObject.Name.Contains("Concrete"))
            //    {

            //        foreach (IConcreteModel crtm in _windoorModel.lst_concrete)
            //        {
            //            if (wndrObject.Name == crtm.Concrete_Name)
            //            { 
            //                if (flocX == 0 && flocY == 0)
            //                {
            //                    object_points.Add(new Point(flocX, flocY));
            //                    flocX += crtm.Concrete_ImagerWidthToBind;
            //                    controlndex = crtm.Concrete_ImagerHeightToBind;
            //                    availableWidth = crtm.Concrete_Width;
            //                    occupiedWidth += crtm.Concrete_Width;
            //                }
            //                else
            //                {


            //                    if (availableWidth >= crtm.Concrete_Width)
            //                    {

            //                        if (availableHeight >= crtm.Concrete_Height)
            //                        {
            //                            occupiedWidth += crtm.Concrete_Width;

            //                            if (Maxheight < crtm.Concrete_Height)
            //                            {
            //                                Maxheight = crtm.Concrete_Height;
            //                            }
            //                        }
            //                        else
            //                        {
            //                            isDimentionFit = false;
            //                        }
            //                        if (availableWidth == crtm.Concrete_Width)
            //                        {
            //                            flocY += controlndex;
            //                        }

            //                    }
            //                    if (occupiedWidth >= _windoorModel.WD_width)
            //                    {
            //                        occupiedHeight += Maxheight;
            //                        occupiedWidth = 0;
            //                        availableWidth = _windoorModel.WD_width;
            //                        availableHeight -= Maxheight;
            //                        Maxheight = 0;
            //                        flocX = 0;
            //                        controlndex = crtm.Concrete_ImagerHeightToBind;
            //                        object_points.Add(new Point(flocX, flocY));

            //                    }
            //                    else
            //                    {
            //                        if (availableHeight > crtm.Concrete_Height && (_windoorModel.WD_width - occupiedWidth) < crtm.Concrete_Width)
            //                        {
            //                            availableWidth = _windoorModel.WD_width;
            //                            occupiedHeight += crtm.Concrete_Height;
            //                            availableHeight -= crtm.Concrete_Height;
            //                            Maxheight = 0;
            //                            flocY += controlndex;
            //                            flocX = 0;
            //                            controlndex = crtm.Concrete_ImagerHeightToBind;


            //                        }
            //                        else
            //                        {
            //                            availableWidth -= crtm.Concrete_Width;

            //                        }
            //                        object_points.Add(new Point(flocX, flocY));

            //                    }

            //                }
            //                break;
            //            }

            //        }
            //    }
            //}

            int occupiedWidth = 0,
              occupiedHeight = 0,
              Maxheight = 0,
              MaxHeightImgager = 0,
              currentY = 0,
              availableWidth = _windoorModel.WD_width,
              availableHeight = _windoorModel.WD_height;
            if (_windoorModel.lst_objects.Count > 0)
            {
                var startingObject = _windoorModel.lst_objects[0];
                startingObject = null;
                foreach (var wndrObject in _windoorModel.lst_objects)
                {
                    if (wndrObject.Name.Contains("Frame"))
                    {


                        foreach (IFrameModel frm in _windoorModel.lst_frame)
                        {
                            if (wndrObject.Name == frm.Frame_Name)
                            {

                                if (currentY != wndrObject.Location.Y)
                                {
                                    flocY += MaxHeightImgager;
                                    flocX = 0;
                                    currentY = wndrObject.Location.Y;
                                }
                                if (availableWidth > frm.Frame_Width)
                                {
                                    if (startingObject == null)
                                    {
                                        startingObject = wndrObject;
                                    }
                                    if (availableHeight >= frm.Frame_Height)
                                    {
                                        occupiedWidth += frm.Frame_Width;
                                        if (Maxheight < frm.Frame_Height)
                                        {
                                            Maxheight = frm.Frame_Height;
                                            MaxHeightImgager = frm.FrameImageRenderer_Height;
                                        }
                                    }
                                    else
                                    {
                                    }
                                }
                                else if (availableWidth == frm.Frame_Width)
                                {

                                    ////Fit_MyObject_ToBindDimensions(startingObject, wndrObject);
                                    occupiedWidth += frm.Frame_Width;
                                    if (Maxheight < frm.Frame_Height)
                                    {
                                        Maxheight = frm.Frame_Height;
                                        MaxHeightImgager = frm.FrameImageRenderer_Height;
                                    }
                                    startingObject = null;
                                    MaxHeightImgager = frm.FrameImageRenderer_Height;
                                }
                                else
                                {
                                    occupiedHeight += Maxheight;
                                    occupiedWidth = 0;
                                    availableWidth = _windoorModel.WD_width;
                                    availableHeight -= Maxheight;
                                    MaxHeightImgager = frm.FrameImageRenderer_Height;
                                }
                                if (occupiedWidth >= _windoorModel.WD_width)
                                {
                                    occupiedHeight += Maxheight;
                                    occupiedWidth = 0;
                                    availableWidth = _windoorModel.WD_width;
                                    availableHeight -= Maxheight;
                                    object_points.Add(new Point(flocX, flocY));
                                }
                                else
                                {

                                    object_points.Add(new Point(flocX, flocY));
                                    availableWidth -= frm.Frame_Width;
                                    flocX += frm.FrameImageRenderer_Width;
                                }
                                break;
                            }
                        }
                    }
                    if (wndrObject.Name.Contains("Concrete"))
                    {
                        foreach (IConcreteModel crtm in _windoorModel.lst_concrete)
                        {
                            if (wndrObject.Name == crtm.Concrete_Name)
                            {
                                if (currentY != wndrObject.Location.Y)
                                {
                                    flocY += MaxHeightImgager;
                                    flocX = 0;
                                    currentY = wndrObject.Location.Y;
                                }
                                if (availableWidth > crtm.Concrete_Width)
                                {
                                    if (startingObject == null)
                                    {
                                        startingObject = wndrObject;
                                    }
                                    if (availableHeight >= crtm.Concrete_Height)
                                    {
                                        occupiedWidth += crtm.Concrete_Width;
                                        if (Maxheight < crtm.Concrete_Height)
                                        {
                                            Maxheight = crtm.Concrete_Height;
                                            MaxHeightImgager = crtm.Concrete_ImagerHeightToBind;
                                        }
                                    }
                                    else
                                    {
                                    }
                                }
                                else if (availableWidth == crtm.Concrete_Width)
                                {


                                    if (startingObject == null)
                                    {
                                        startingObject = wndrObject;
                                    }
                                    //Fit_MyObject_ToBindDimensions(startingObject, wndrObject);
                                    occupiedWidth += crtm.Concrete_Width;
                                    if (Maxheight < crtm.Concrete_Height)
                                    {
                                        Maxheight = crtm.Concrete_Height;

                                    }
                                    MaxHeightImgager = crtm.Concrete_ImagerHeightToBind;

                                    startingObject = null;
                                }
                                else
                                {
                                    occupiedHeight += Maxheight;
                                    occupiedWidth = 0;
                                    availableWidth = _windoorModel.WD_width;
                                    availableHeight -= Maxheight;
                                    MaxHeightImgager = crtm.Concrete_ImagerHeightToBind;
                                }
                                if (occupiedWidth >= _windoorModel.WD_width)
                                {
                                    occupiedHeight += Maxheight;
                                    occupiedWidth = 0;
                                    availableWidth = _windoorModel.WD_width;
                                    availableHeight -= Maxheight;
                                    object_points.Add(new Point(flocX, flocY));
                                    MaxHeightImgager = crtm.Concrete_ImagerHeightToBind;
                                }
                                else
                                {
                                    object_points.Add(new Point(flocX, flocY));
                                    availableWidth -= crtm.Concrete_Width;
                                    flocX += crtm.Concrete_ImagerWidthToBind;
                                }
                                break;
                            }

                        }
                    }
                }
            }

            //foreach (Size frame_size in frameImager_sizes)
            //{
            //    prev_wd_covered = total_wd_covered;
            //    total_wd_covered += frame_size.Width;

            //    if (curr_LocY.Count() == 0)
            //    {
            //        curr_LocY.Add(0);
            //    }
            //    if (total_wd_covered < basePlatformImage_Width_minus70)
            //    {
            //        flocX = 0 + prev_wd_covered;
            //        flocY = curr_LocY[frame_row];
            //        controlndex++;
            //        object_points.Add(new Point(flocX, flocY));
            //    }
            //    else if (total_wd_covered >= basePlatformImage_Width_minus70)
            //    {

            //        total_ht_covered += frameImager_sizes[frame_row].Height;
            //        if (total_wd_covered > basePlatformImage_Width_minus70)
            //        {
            //            curr_LocY.Add(total_ht_covered);
            //            frame_row++;
            //        }
            //        controlndex++;
            //        if (total_wd_covered == basePlatformImage_Width_minus70)
            //        {
            //            flocX = 0 + prev_wd_covered;
            //            flocY = curr_LocY[frame_row];
            //        }
            //        else
            //        {
            //            flocX = 0;
            //            flocY = curr_LocY[frame_row];
            //            prev_ht_covered += curr_LocY[frame_row];
            //        }
            //        if (controlndex == 1)
            //        {
            //            flocY = 0;
            //        }
            //        object_points.Add(new Point(flocX, flocY));
            //        if (total_wd_covered > basePlatformImage_Width_minus70)
            //        {
            //            flocY += frame_size.Height;
            //        }
            //        total_wd_covered = 0;
            //    }  
            //} 

            return object_points;
        }

        public Point Panel_MPanel_DrawPoints_ParentIsFrame(Point framePoint, int frame_topPad, int frame_leftPad)
        {
            return new Point(framePoint.X + frame_leftPad, framePoint.Y + frame_topPad);
        }

        private void Draw_Panel(PaintEventArgs e, IPanelModel panelModel, Point Ppoint)
        {
            Graphics g = e.Graphics;
            int w = 2;
            int outerLineDeduction = 18;
            int innerLineDeduction = 13;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            float ArrowExpectedWidth = 0,
                  ArrowExpectedHeight = 0,
                  arrowStartingX = 0,
                  arrowStartingY = 0;
            int client_wd = 0, client_ht = 0;




            if (panelModel.Panel_ParentMultiPanelModel != null)
            {
                if (panelModel.Panel_ParentMultiPanelModel.MPanel_Type == "Mullion")
                {

                    client_wd = panelModel.PanelImageRenderer_Width;
                    client_ht = panelModel.Panel_ParentMultiPanelModel.MPanelImageRenderer_Height;
                }
                else if (panelModel.Panel_ParentMultiPanelModel.MPanel_Type == "Transom")
                {
                    client_wd = panelModel.Panel_ParentMultiPanelModel.MPanelImageRenderer_Width;
                    client_ht = panelModel.PanelImageRenderer_Height;
                }
            }
            else
            {
                client_wd = panelModel.PanelImageRenderer_Width;
                client_ht = panelModel.PanelImageRenderer_Height;
            }



            Rectangle panel_bounds = new Rectangle(Ppoint, new Size(client_wd, client_ht));

            g.SmoothingMode = SmoothingMode.HighQuality;

            int font_size = 30,
                gfont_size = 40,
                outer_line = 10,
                inner_line = 15,
                tenPercentAdditional = 0,
                sashOverlapValue = 0;

            if (_windoorModel.WD_zoom_forImageRenderer == 0.50f)
            {
                font_size = 37;

                gfont_size = 47;
            }
            else if (_windoorModel.WD_zoom_forImageRenderer == 0.26f)
            {
                font_size = 37;
                gfont_size = 47;
            }
            else if (_windoorModel.WD_zoom_forImageRenderer == 0.17f)
            {
                font_size = 35;
                outer_line = 5;
                inner_line = 8;
                gfont_size = 45;
            }
            else if (_windoorModel.WD_zoom_forImageRenderer == 0.13f)
            {
                font_size = 34;
                outer_line = 3;
                inner_line = 7;
                gfont_size = 44;
            }
            else if (_windoorModel.WD_zoom_forImageRenderer == 0.10f)
            {
                font_size = 33;
                outer_line = 3;
                inner_line = 7;
                tenPercentAdditional = 8;
                gfont_size = 43;
            }

            Rectangle outer_bounds = new Rectangle(Ppoint.X,
                                                   Ppoint.Y,
                                                   client_wd - w,
                                                   client_ht - w);

            g.DrawRectangle(new Pen(Color.Black, w), outer_bounds);
            //g.FillRectangle(Brushes.DarkGray, outer_bounds);
            g.FillRectangle(Brushes.White, outer_bounds);


            Color outerColor = Color.Black;
            if (panelModel.Panel_ChkText != "dSash" && panelModel.Panel_Type == "Fixed Panel")
            {
                outerColor = Color.Transparent;
            }

            #region Georgian Bar

            int GBpointResultX, GBpointResultY,
                penThickness = 0, penThicknessResult = 0,

                verticalQty = panelModel.Panel_GeorgianBar_VerticalQty,
                horizontalQty = panelModel.Panel_GeorgianBar_HorizontalQty,
                GeorgianBar_GapX = 0,
                GeorgianBar_GapY = 0,
                pGbarInnerX = 0,
                pGbarInnerY = 0,
                leftdeduction = 4,
                rightAddition = 4,
                sashDeduction = 0,
                sashD = 0;


            bool verticalSelected = false;

            if (panelModel.Panel_Type == "Fixed Panel" && panelModel.Panel_Orient == false)
            {
                sashDeduction = -sashD;
                sashD = 0;
            }
            else
            {
                sashDeduction = sashD;
            }
            if (panelModel.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
            {
                penThickness = 8;
            }
            else if (panelModel.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0726)
            {
                penThickness = 8;
            }

            //Pen pInnerLine = new Pen(Color.Red, penThickness);

            Pen pInnerLine = new Pen(pInnerLineColor, penThickness);
            Pen pOuterLine = new Pen(Color.Black, 1);





            int addY = ((client_ht - (((int)(client_ht - sashDeduction + pGbarInnerY) / (horizontalQty + 1)) * horizontalQty)) - ((client_ht + pGbarInnerY) / (horizontalQty + 1))) / 2;

            //Horizontal
            int GeorgianBar_GapYs = GeorgianBar_GapY;
            //for (int ii = 0; ii < horizontalQty; ii++)
            //{
            //    GBpointResultY = ((pGbarInnerY + client_ht - sashDeduction) / (horizontalQty + 1) + Convert.ToInt32(Math.Floor((double)GeorgianBar_GapY)));
            //    GeorgianBar_GapY += (client_ht - sashDeduction + (pGbarInnerY)) / (horizontalQty + 1);

            //    Point[] GeorgianBarTop_PointsY = null;
            //    Point[] GeorgianBarBottom_PointsY = null;
            //    if (panelModel.Panel_Overlap_Sash == OverlapSash._Right)
            //    {
            //        GeorgianBarTop_PointsY = new[]
            //        {
            //            new Point(pGbarInnerY+1 + Ppoint.X + sashD, GBpointResultY + Ppoint.Y-leftdeduction + addY),
            //            new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD + inner_line - 2, GBpointResultY + Ppoint.Y-leftdeduction + addY),
            //        };
            //        GeorgianBarBottom_PointsY = new[]
            //        {
            //            new Point(pGbarInnerY+1 + Ppoint.X + sashD, GBpointResultY + Ppoint.Y + rightAddition + addY),
            //            new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD + inner_line, GBpointResultY + Ppoint.Y + rightAddition + addY),
            //        };

            //    }
            //    else if (panelModel.Panel_Overlap_Sash == OverlapSash._Left)
            //    {
            //        GeorgianBarTop_PointsY = new[]
            //        {
            //            new Point(pGbarInnerY+1 + Ppoint.X + sashD - inner_line, GBpointResultY + Ppoint.Y-leftdeduction + addY),
            //            new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD, GBpointResultY + Ppoint.Y-leftdeduction + addY),
            //        };
            //        GeorgianBarBottom_PointsY = new[]
            //        {
            //            new Point(pGbarInnerY+1 + Ppoint.X + sashD - inner_line, GBpointResultY + Ppoint.Y + rightAddition + addY),
            //            new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD, GBpointResultY + Ppoint.Y + rightAddition + addY),
            //        };
            //    }
            //    else if (panelModel.Panel_Overlap_Sash == OverlapSash._Both)
            //    {
            //        GeorgianBarTop_PointsY = new[]
            //        {
            //            new Point(pGbarInnerY+1 + Ppoint.X + sashD - inner_line, GBpointResultY + Ppoint.Y-leftdeduction + addY),
            //            new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD + inner_line - 2, GBpointResultY + Ppoint.Y-leftdeduction + addY),
            //        };
            //        GeorgianBarBottom_PointsY = new[]
            //        {
            //            new Point(pGbarInnerY+1 + Ppoint.X + sashD - inner_line, GBpointResultY + Ppoint.Y + rightAddition + addY),
            //            new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD + inner_line, GBpointResultY + Ppoint.Y + rightAddition + addY),
            //        };
            //    }
            //    else if (panelModel.Panel_Overlap_Sash == OverlapSash._None)
            //    {
            //        GeorgianBarTop_PointsY = new[]
            //        {
            //            new Point(pGbarInnerY+1 + Ppoint.X + sashD,GBpointResultY + Ppoint.Y-leftdeduction + addY),
            //            new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD,GBpointResultY + Ppoint.Y-leftdeduction + addY),
            //        };
            //        GeorgianBarBottom_PointsY = new[]
            //        {
            //            new Point(pGbarInnerY+1 + Ppoint.X + sashD,GBpointResultY + Ppoint.Y + rightAddition + addY),
            //            new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD,GBpointResultY + Ppoint.Y + rightAddition + addY),
            //        };
            //    }
            //    for (int i = 0; i < GeorgianBarTop_PointsY.Length - 1; i += 2)
            //    {
            //        g.DrawLine(pOuterLine, GeorgianBarTop_PointsY[i], GeorgianBarTop_PointsY[i + 1]);
            //    }
            //    for (int i = 0; i < GeorgianBarBottom_PointsY.Length - 1; i += 2)
            //    {
            //        g.DrawLine(pOuterLine, GeorgianBarBottom_PointsY[i], GeorgianBarBottom_PointsY[i + 1]);
            //    }
            //}



            int addX = ((client_wd - (((int)(client_wd - sashDeduction + pGbarInnerX) / (verticalQty + 1)) * verticalQty)) - ((client_wd + pGbarInnerX) / (verticalQty + 1))) / 2;
            //vertical

            for (int ii = 0; ii < verticalQty; ii++)
            {

                GBpointResultX = ((pGbarInnerX + client_wd - sashDeduction) / (verticalQty + 1) + Convert.ToInt32(Math.Floor((double)GeorgianBar_GapX)));
                GeorgianBar_GapX += (client_wd - sashDeduction + (pGbarInnerX)) / (verticalQty + 1);

                if (Lst_GeorgianBarX.Count == verticalQty)
                {
                    defaultX = Lst_GeorgianBarX[ii];
                }
                else
                {
                    defaultX = GBpointResultX + Ppoint.X + addX;
                }
                Point[] GeorgianBar_PointsX = new[]
                {
                  new Point(defaultX, pGbarInnerX+1 + Ppoint.Y + sashD),
                  new Point(defaultX, pGbarInnerX + client_ht-1 + Ppoint.Y - sashD),
                };

                if (addXtoList == false)
                {
                    Lst_GeorgianBarX.Add(GBpointResultX + Ppoint.X + addX);
                }
                if (ii == verticalQty - 1)
                {
                    addXtoList = true;
                }
                for (int i = 0; i < GeorgianBar_PointsX.Length - 1; i += 2)
                {

                    if (CursurLocX <= (GeorgianBar_PointsX[i].X + (inner_line / 2) - 2) &&
                        CursurLocX >= (GeorgianBar_PointsX[i].X - (inner_line / 2)) + 2)
                    {
                        pInnerLineColor = pInnerLineColorHighlight;
                        pInnerLinePrevColor = pInnerLineColorHighlight;
                        verticalSelected = true;
                        GeorgianBar_PointsX[i].X = defaultX;
                        GeorgianBar_PointsX[i + 1].X = defaultX;
                        verticalP1 = GeorgianBar_PointsX[i];
                        verticalP2 = GeorgianBar_PointsX[i + 1];
                    }
                    else
                    {
                        pInnerLineColor = pInnerLineColorDefault;
                        pInnerLinePrevColor = pInnerLineColorDefault;
                    }

                    g.DrawLine(new Pen(pInnerLineColor, penThickness), GeorgianBar_PointsX[i], GeorgianBar_PointsX[i + 1]);
                }
                //Point[] GeorgianBarBoderLeft_PointsX = new[]
                //{

                //     new Point(GBpointResultX + Ppoint.X-leftdeduction + addX,pGbarInnerX+1 + Ppoint.Y + sashD),
                //     new Point(GBpointResultX + Ppoint.X-leftdeduction + addX,pGbarInnerX + client_ht-1 + Ppoint.Y - sashD),
                //};
                //for (int i = 0; i < GeorgianBarBoderLeft_PointsX.Length - 1; i += 2)
                //{ 
                //    g.DrawLine(pOuterLine, GeorgianBarBoderLeft_PointsX[i], GeorgianBarBoderLeft_PointsX[i + 1]);

                //}
                //Point[] GeorgianBarBoderRight_PointsX = new[]
                //{

                //     new Point(GBpointResultX + Ppoint.X + rightAddition + addX,pGbarInnerX+1 + Ppoint.Y + sashD),
                //     new Point(GBpointResultX + Ppoint.X + rightAddition + addX,pGbarInnerX + client_ht-1 + Ppoint.Y - sashD),
                //};
                //for (int i = 0; i < GeorgianBarBoderRight_PointsX.Length - 1; i += 2)
                //{
                //    g.DrawLine(pOuterLine, GeorgianBarBoderRight_PointsX[i], GeorgianBarBoderRight_PointsX[i + 1]);
                //}

            }
            //Horizontal

            for (int ii = 0; ii < horizontalQty; ii++)
            {
                GBpointResultY = ((pGbarInnerY + client_ht - sashDeduction) / (horizontalQty + 1) + Convert.ToInt32(Math.Floor((double)GeorgianBar_GapYs)));
                GeorgianBar_GapYs += (client_ht - sashDeduction + (pGbarInnerY)) / (horizontalQty + 1);

                if (Lst_GeorgianBarY.Count == horizontalQty)
                {
                    defaultY = Lst_GeorgianBarY[ii];
                }
                else
                {
                    defaultY = GBpointResultY + Ppoint.Y + addY;
                }

                Point[] GeorgianBar_PointsY = null;
                //if (panelModel.Panel_Overlap_Sash == OverlapSash._Right)
                //{
                //    GeorgianBar_PointsY = new[]
                //    {
                //        new Point(pGbarInnerY+1 + Ppoint.X + sashD,GBpointResultY + Ppoint.Y + addY),
                //        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD + inner_line - 2, GBpointResultY + Ppoint.Y + addY),
                //    };
                //}
                //else if (panelModel.Panel_Overlap_Sash == OverlapSash._Left)
                //{
                //    GeorgianBar_PointsY = new[]
                //     {
                //        new Point(pGbarInnerY+1 + Ppoint.X + sashD - inner_line, GBpointResultY + Ppoint.Y + addY),
                //        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD, GBpointResultY + Ppoint.Y + addY),
                //    };
                //}
                //else if (panelModel.Panel_Overlap_Sash == OverlapSash._Both)
                //{
                //    GeorgianBar_PointsY = new[]
                //    {
                //        new Point(pGbarInnerY+1 + Ppoint.X + sashD - inner_line, GBpointResultY + Ppoint.Y + addY),
                //        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD + inner_line  - 2, GBpointResultY + Ppoint.Y + addY),
                //    };
                //}
                //else if (panelModel.Panel_Overlap_Sash == OverlapSash._None)
                //{
                GeorgianBar_PointsY = new[]
                {
                        new Point(pGbarInnerY+1 + Ppoint.X + sashD,defaultY),
                        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD,defaultY),
                    };
                //}


                if (addYtoList == false)
                {
                    Lst_GeorgianBarY.Add(GBpointResultY + Ppoint.Y + addY);
                }
                if (ii == horizontalQty - 1)
                {
                    addYtoList = true;
                }


                for (int i = 0; i < GeorgianBar_PointsY.Length - 1; i += 2)
                {
                    if (CursurLocY <= (GeorgianBar_PointsY[i].Y + (inner_line / 2) - 2) &&
                        CursurLocY >= (GeorgianBar_PointsY[i].Y - (inner_line / 2)) + 2)
                    {
                        pInnerLineColor = pInnerLineColorHighlight;
                        pInnerLinePrevColor = pInnerLineColorHighlight;
                        GeorgianBar_PointsY[i].Y = defaultY;
                        GeorgianBar_PointsY[i + 1].Y = defaultY;
                    }
                    else
                    {
                        pInnerLineColor = pInnerLineColorDefault;
                        pInnerLinePrevColor = pInnerLineColorDefault;
                    }

                    g.DrawLine(new Pen(pInnerLineColor, penThickness), GeorgianBar_PointsY[i], GeorgianBar_PointsY[i + 1]);
                }
            }


            if (verticalSelected == true)
            {
                g.DrawLine(new Pen(Color.LimeGreen, penThickness), verticalP1, verticalP2);
            }
            verticalSelected = false;


            #endregion

        }


        private void _georgianBarCustomizeDesignView_GeorgianBarCustomizeDesignViewLoadEventRaised(object sender, EventArgs e)
        {

        }

        public IGeorgianBarCustomizeDesignView GetGeorgianBarCustomizeDesignView()
        {
            return _georgianBarCustomizeDesignView;
        }


        public IGeorgianBarCustomizeDesignPresenter GetNewInstance(IMainPresenter mainPresenter,
                                                              IUnityContainer unityC,
                                                              IPanelModel panelModel,
                                                              IWindoorModel windoorModel)
        {
            unityC
                 .RegisterType<IGeorgianBarCustomizeDesignView, GeorgianBarCustomizeDesignView>()
                 .RegisterType<IGeorgianBarCustomizeDesignPresenter, GeorgianBarCustomizeDesignPresenter>();
            GeorgianBarCustomizeDesignPresenter GBCDPresenter = unityC.Resolve<GeorgianBarCustomizeDesignPresenter>();
            GBCDPresenter._mainPresenter = mainPresenter;
            GBCDPresenter._unityC = unityC;
            GBCDPresenter._panelModel = panelModel;
            GBCDPresenter._windoorModel = windoorModel;

            return GBCDPresenter;
        }

    }
}
