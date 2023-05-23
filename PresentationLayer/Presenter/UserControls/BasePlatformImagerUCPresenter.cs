using CommonComponents;
using ModelLayer.Model.Quotation.Concrete;
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
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls
{
    public class BasePlatformImagerUCPresenter : IBasePlatformImagerUCPresenter, IPresenterCommon
    {
        IBasePlatformImagerUC _basePlatformImagerUC;
        FlowLayoutPanel _flpMain;

        IWindoorModel _windoorModel;
        IMainPresenter _mainPresenter;
        Font dmnsion_font_wd;
        Font dmnsion_font_ht;

        CommonFunctions _commonfunc = new CommonFunctions();
        int deductBotPadding;

        bool topViewCheck;
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
            _basePlatformImagerUC.BasePlatformImagerUCLoadEventRaised += _basePlatformImagerUC_BasePlatformImagerUCLoadEventRaised;
        }

        private void _basePlatformImagerUC_BasePlatformImagerUCLoadEventRaised(object sender, EventArgs e)
        {
            _basePlatformImagerUC.ThisBinding(CreateBindingDictionary());
        }

        private void _basePlatformImagerUC_basePlatformSizeChangedEventRaised(object sender, EventArgs e)
        {
            _basePlatformImagerUC.InvalidateThis();
        }

        public List<Point> OuterFrame_DrawPoints(List<Size> frameImager_sizes, int basePlatformImage_Width_minus70)
        {
            List<Point> object_points = new List<Point>();
            List<int> curr_LocY = new List<int>();

            //DeductionForBottomFramePaddingImager();

            int flocX = 0, controlndex = 0, flocY = 0, prev_wd_covered = 0, prev_ht_covered = 0, total_wd_covered = 0, total_ht_covered = 0, frame_row = 0;

            #region oldAlgo

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

            #endregion

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
                            int FrameImageRendererHeight = 0;
                            if (topViewCheck == true)
                            {
                                FrameImageRendererHeight = (int)Math.Round(NewimagerHeightDecuted70(frm.Frame_Height));
                            }
                            else if (topViewCheck == false)
                            {
                                FrameImageRendererHeight = frm.FrameImageRenderer_Height;
                            }
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
                                            MaxHeightImgager = FrameImageRendererHeight;//frm.FrameImageRenderer_Height;
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
                                        MaxHeightImgager = FrameImageRendererHeight;//(int)Math.Round(NewimagerHeightDecuted70(frm.Frame_Height)); //frm.FrameImageRenderer_Height; 
                                    }
                                    startingObject = null;
                                    MaxHeightImgager = FrameImageRendererHeight;// (int)Math.Round(NewimagerHeightDecuted70(frm.Frame_Height)); //frm.FrameImageRenderer_Height;
                                }
                                else
                                {
                                    occupiedHeight += Maxheight;
                                    occupiedWidth = 0;
                                    availableWidth = _windoorModel.WD_width;
                                    availableHeight -= Maxheight;
                                    MaxHeightImgager = FrameImageRendererHeight;//(int)Math.Round(NewimagerHeightDecuted70(frm.Frame_Height)); //frm.FrameImageRenderer_Height;
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

            #region oldAlgo

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
            #endregion

            return object_points;
        }

        public int DeductionForBottomFramePaddingImager(int FH) // for frame 
        {
            int totalWdOfFrame = 0;

            float frameHTOverItemHT = (float)FH / (float)_windoorModel.WD_height;

            foreach (IFrameModel frm in _windoorModel.lst_frame)
            {
                totalWdOfFrame += frm.FrameImageRenderer_Width;
            }
            if (totalWdOfFrame < _windoorModel.WD_width)
            {
                deductBotPadding = (int)(70.0f * frameHTOverItemHT);
            }
            else if (totalWdOfFrame != 0)
            {
                deductBotPadding = (int)(70.0f * frameHTOverItemHT) / (totalWdOfFrame / _windoorModel.WD_width);
            }

            return deductBotPadding;
        }

        public int DeductionForBottomFramePaddingImagerRendering()
        {
            int BotPad = 0;
            if (_windoorModel.GetZoom_forRendering() == 1.0f)
            {
                BotPad = 70 * 1;
            }
            else if (_windoorModel.GetZoom_forRendering() == 0.5f)
            {
                BotPad = 70 * 2;
            }
            else if (_windoorModel.GetZoom_forRendering() == 0.26f)
            {
                BotPad = 70 * 4;
            }
            else if (_windoorModel.GetZoom_forRendering() == 0.17f)
            {
                BotPad = 70 * 6;
            }
            else if (_windoorModel.GetZoom_forRendering() == 0.13f)
            {
                BotPad = 70 * 8;
            }
            else if (_windoorModel.GetZoom_forRendering() == 0.10f)
            {
                BotPad = 70 * 10;
            }
            else if (_windoorModel.GetZoom_forRendering() == 0.08f)
            {
                BotPad = 70 * 12;
            }
            else if (_windoorModel.GetZoom_forRendering() == 0.06f)
            {
                BotPad = 70 * 16;
            }
            else if (_windoorModel.GetZoom_forRendering() == 0.05f)
            {
                BotPad = 70 * 20;
            }
            else if (_windoorModel.GetZoom_forRendering() == 0.02f)
            {
                BotPad = 70 * 20;
            }
            else if (_windoorModel.GetZoom_forRendering() == 0.01f)
            {
                BotPad = 70 * 22;
            }
            return BotPad;
        }


        public float NewimagerHeightDecuted70(int FH)
        {
            float frameHTOverItemHT = (float)FH / (float)_windoorModel.WD_height;
            float frameImagerRendering = (_windoorModel.WD_height - DeductionForBottomFramePaddingImagerRendering()) * frameHTOverItemHT; // frame
            float NewImagerHeight = frameImagerRendering * _windoorModel.GetZoom_forRendering(); // imager

            return NewImagerHeight;
        }

        int BotPaddingBaseOnItemSize;
        public void BotPadBaseOnItemHT(int FH)
        {
            float frameHTOverItemHT = ((float)FH / _windoorModel.WD_height);
            float NewBotPad = (70 * frameHTOverItemHT);
            BotPaddingBaseOnItemSize = (int)NewBotPad;
        }
        public Point Panel_MPanel_DrawPoints_ParentIsFrame(Point framePoint, int frame_topPad, int frame_leftPad)
        {
            return new Point(framePoint.X + frame_leftPad, framePoint.Y + frame_topPad);
        }
        private void _basePlatformImagerUC_flpFrameDragDropPaintEventRaised(object sender, PaintEventArgs e)
        {
            //try
            //{
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender;
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.HighQuality;

            float zoom = _windoorModel.WD_zoom_forImageRenderer;

            List<Size> windoor_objects_sizes = new List<Size>();
            //int flocX = 0, flocY = 0, total_wd_covered = 0, total_ht_covered = 0, frame_row = 0;

            foreach (var objects in _windoorModel.lst_objects)
            {
                if (objects.Name.Contains("Frame"))
                {
                    foreach (IFrameModel frame in _windoorModel.lst_frame)
                    {
                        int FrameImageRendererHeight = 0;
                        if (topViewCheck == true)
                        {
                            FrameImageRendererHeight = (int)Math.Round(NewimagerHeightDecuted70(frame.Frame_Height));
                        }
                        else if (topViewCheck == false)
                        {
                            FrameImageRendererHeight = frame.FrameImageRenderer_Height;
                        }

                        if (objects.Name == frame.Frame_Name)
                        {
                            windoor_objects_sizes.Add(new Size(frame.FrameImageRenderer_Width, frame.FrameImageRenderer_Height)); //(int)Math.Round(NewimagerHeightDecuted70(frame.Frame_Height))));//frame.FrameImageRenderer_Height));
                            break;
                        }
                    }
                }
                else if (objects.Name.Contains("Concrete"))
                {
                    foreach (IConcreteModel concrete in _windoorModel.lst_concrete)
                    {
                        if (objects.Name == concrete.Concrete_Name)
                        {
                            windoor_objects_sizes.Add(new Size(concrete.Concrete_ImagerWidthToBind, concrete.Concrete_ImagerHeightToBind));
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
                    Draw_Frame(e, object_points[i], windoor_objects_sizes[i], frameModel);

                    BotPadBaseOnItemHT(frameModel.Frame_Height);

                    //Draw panel per frame
                    if (frameModel.Lst_Panel.Count() == 1)
                    {
                        Point pPoint = Panel_MPanel_DrawPoints_ParentIsFrame(object_points[i], frameModel.FrameImageRenderer_Padding_int.Top, frameModel.FrameImageRenderer_Padding_int.Left);
                        Draw_Panel(e, frameModel.Lst_Panel[0], pPoint);
                    }
                    else if (frameModel.Lst_MultiPanel.Count() > 0)
                    {
                        int mParentLoc_X = 0,
                               mParentLoc_Y = 0;
                        int mParentLoc_X1 = 0,
                               mParentLoc_Y1 = 0;
                        IMultiPanelModel mpnls = null;
                        for (int ii = 0; ii < frameModel.Lst_MultiPanel.Count; ii++)
                        {

                            IMultiPanelModel mpnl = frameModel.Lst_MultiPanel[ii];

                            if (mpnl.MPanel_Parent.Name.Contains("Frame"))
                            {
                                int BotPadding = 0;
                                if (topViewCheck == true)
                                {
                                    BotPadding = BotPaddingBaseOnItemSize;
                                }
                                else if (topViewCheck == false)
                                {
                                    BotPadding = 0;
                                }

                                Point MPoint = Panel_MPanel_DrawPoints_ParentIsFrame(object_points[i], frameModel.FrameImageRenderer_Padding_int.Top, frameModel.FrameImageRenderer_Padding_int.Left);
                                Draw_MultiPanel(e, mpnl, MPoint, BotPadding);
                                Draw_MultiPanelParent(mpnl, MPoint, zoom, e);
                            }
                            else if (mpnl.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                            {
                                Point MPoint = Panel_MPanel_DrawPoints_ParentIsFrame(object_points[i], frameModel.FrameImageRenderer_Padding_int.Top + mParentLoc_Y, frameModel.FrameImageRenderer_Padding_int.Left + mParentLoc_X);

                                mParentLoc_X = 0;
                                mParentLoc_Y = 0;

                                bool isMultiPanelName = false;
                                foreach (Control parentMpnl_obj in mpnl.MPanel_Parent.Controls)
                                {
                                    if (mpnl.MPanel_Type == "Mullion")
                                    {
                                        if (parentMpnl_obj.Name.Contains("PanelUC_"))
                                        {
                                            IPanelModel panelModel = mpnl.MPanel_ParentModel.MPanelLst_Panel.Find(panel => panel.Panel_Name == parentMpnl_obj.Name);
                                            mParentLoc_Y += panelModel.PanelImageRenderer_Height;
                                        }
                                        else if (parentMpnl_obj.Name.Contains("TransomUC_"))
                                        {
                                            int BotPadding = 0;
                                            IDividerModel divModel = mpnl.MPanel_ParentModel.MPanelLst_Divider.Find(div => div.Div_Name == parentMpnl_obj.Name);

                                            if (topViewCheck == true)
                                            {
                                                BotPadding = (BotPaddingBaseOnItemSize / (divModel.Div_MPanelParent.MPanel_Divisions + 1));
                                            }
                                            else if (topViewCheck == false)
                                            {
                                                BotPadding = 0;
                                            }

                                            mParentLoc_Y += divModel.DivImageRenderer_Height - BotPadding;
                                        }
                                        else if (parentMpnl_obj.Name.Contains("MultiMullion_"))
                                        {
                                            IMultiPanelModel multiPanelModel = mpnl.MPanel_ParentModel.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == parentMpnl_obj.Name);
                                            MPoint = Panel_MPanel_DrawPoints_ParentIsFrame(object_points[i], frameModel.FrameImageRenderer_Padding_int.Top + mParentLoc_Y, frameModel.FrameImageRenderer_Padding_int.Left + mParentLoc_X);
                                            if (multiPanelModel.MPanel_Name == mpnl.MPanel_Name)
                                            {
                                                Draw_MultiPanelParent(multiPanelModel, MPoint, zoom, e);
                                            }
                                            mParentLoc_Y += multiPanelModel.MPanelImageRenderer_Height;
                                        }
                                    }
                                    else if (mpnl.MPanel_Type == "Transom")
                                    {
                                        if (parentMpnl_obj.Name.Contains("PanelUC_"))
                                        {
                                            IPanelModel panelModel = mpnl.MPanel_ParentModel.MPanelLst_Panel.Find(panel => panel.Panel_Name == parentMpnl_obj.Name);
                                            mParentLoc_X += panelModel.PanelImageRenderer_Width;
                                        }
                                        else if (parentMpnl_obj.Name.Contains("MullionUC_"))
                                        {
                                            IDividerModel divModel = mpnl.MPanel_ParentModel.MPanelLst_Divider.Find(div => div.Div_Name == parentMpnl_obj.Name);
                                            mParentLoc_X += divModel.DivImageRenderer_Width;
                                        }
                                        else if (parentMpnl_obj.Name.Contains("MultiTransom_"))
                                        {
                                            IMultiPanelModel multiPanelModel = mpnl.MPanel_ParentModel.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == parentMpnl_obj.Name);
                                            MPoint = Panel_MPanel_DrawPoints_ParentIsFrame(object_points[i], frameModel.FrameImageRenderer_Padding_int.Top + mParentLoc_Y, frameModel.FrameImageRenderer_Padding_int.Left + mParentLoc_X);
                                            if (multiPanelModel.MPanel_Name == mpnl.MPanel_Name)
                                            {
                                                Draw_MultiPanelParent(multiPanelModel, MPoint, zoom, e);
                                            }
                                            mParentLoc_X += multiPanelModel.MPanelImageRenderer_Width;
                                        }
                                    }
                                    if (isMultiPanelName)
                                        break;
                                    int lastObject = mpnl.MPanel_Parent.Controls.IndexOf(parentMpnl_obj);
                                    if (mpnl.MPanel_Name == parentMpnl_obj.Name)
                                    {
                                        isMultiPanelName = true;
                                    }
                                }
                            }
                            else if (mpnl.MPanel_ParentModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                            {
                                if (mpnl.MPanel_ParentModel != mpnls && mpnls != null)
                                {

                                    mParentLoc_Y1 = 0;
                                    mParentLoc_X1 = 0;
                                    foreach (Control parentMpnl_obj in mpnl.MPanel_ParentModel.MPanel_Parent.Controls)
                                    {
                                        if (mpnl.MPanel_ParentModel.MPanel_Name != parentMpnl_obj.Name)
                                        {
                                            if (mpnl.MPanel_ParentModel.MPanel_Type == "Mullion")
                                            {
                                                if (parentMpnl_obj.Name.Contains("PanelUC_"))
                                                {
                                                    IPanelModel panelModel = mpnl.MPanel_ParentModel.MPanel_ParentModel.MPanelLst_Panel.Find(panel => panel.Panel_Name == parentMpnl_obj.Name);
                                                    mParentLoc_Y1 += panelModel.PanelImageRenderer_Height;
                                                }
                                                else if (parentMpnl_obj.Name.Contains("TransomUC_"))
                                                {
                                                    IDividerModel divModel = mpnl.MPanel_ParentModel.MPanel_ParentModel.MPanelLst_Divider.Find(div => div.Div_Name == parentMpnl_obj.Name);
                                                    mParentLoc_Y1 += divModel.DivImageRenderer_Height;
                                                }
                                                else if (parentMpnl_obj.Name.Contains("MultiMullion_"))
                                                {
                                                    IMultiPanelModel multiPanelModel = mpnl.MPanel_ParentModel.MPanel_ParentModel.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == parentMpnl_obj.Name);

                                                    mParentLoc_Y1 += multiPanelModel.MPanelImageRenderer_Height;
                                                }
                                            }
                                            else if (mpnl.MPanel_ParentModel.MPanel_Type == "Transom")
                                            {
                                                if (parentMpnl_obj.Name.Contains("PanelUC_"))
                                                {
                                                    IPanelModel panelModel = mpnl.MPanel_ParentModel.MPanel_ParentModel.MPanelLst_Panel.Find(panel => panel.Panel_Name == parentMpnl_obj.Name);
                                                    mParentLoc_X1 += panelModel.PanelImageRenderer_Width;
                                                }
                                                else if (parentMpnl_obj.Name.Contains("MullionUC_"))
                                                {
                                                    IDividerModel divModel = mpnl.MPanel_ParentModel.MPanel_ParentModel.MPanelLst_Divider.Find(div => div.Div_Name == parentMpnl_obj.Name);
                                                    mParentLoc_X1 += divModel.DivImageRenderer_Width;
                                                }
                                                else if (parentMpnl_obj.Name.Contains("MultiTransom_"))
                                                {
                                                    IMultiPanelModel multiPanelModel = mpnl.MPanel_ParentModel.MPanel_ParentModel.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == parentMpnl_obj.Name);
                                                    mParentLoc_X1 += multiPanelModel.MPanelImageRenderer_Width;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }

                                    }

                                }

                                mpnls = mpnl.MPanel_ParentModel;
                                if (mpnls.MPanel_Type == "Mullion")
                                {
                                    mParentLoc_Y1 = 0;

                                }
                                else if (mpnls.MPanel_Type == "Transom")
                                {
                                    mParentLoc_X1 = 0;

                                }
                                int indX = 0, indY = 0;
                                foreach (Control mpnlParent in mpnls.MPanel_ParentModel.MPanelLst_Objects)
                                {

                                    if (mpnl.MPanel_ParentModel.MPanel_Type == "Mullion")
                                    {
                                        if (mpnlParent.Name.Contains("PanelUC_"))
                                        {
                                            IPanelModel panelModel = mpnls.MPanel_ParentModel.MPanelLst_Panel.Find(panel => panel.Panel_Name == mpnlParent.Name);
                                            indY += panelModel.PanelImageRenderer_Height;
                                        }
                                        else if (mpnlParent.Name.Contains("TransomUC_"))
                                        {
                                            int BotPadding = 0;
                                            IDividerModel divModel = mpnls.MPanel_ParentModel.MPanelLst_Divider.Find(div => div.Div_Name == mpnlParent.Name);

                                            if (topViewCheck == true)
                                            {
                                                BotPadding = (BotPaddingBaseOnItemSize / (mpnl.MPanel_ParentModel.MPanel_Divisions + 1));
                                            }
                                            else if (topViewCheck == false)
                                            {
                                                BotPadding = 0;
                                            }

                                            indY += divModel.DivImageRenderer_Height - BotPadding;// 3rd
                                        }
                                        else if (mpnlParent.Name.Contains("MultiMullion_"))
                                        {
                                            IMultiPanelModel multiPanelModel = mpnls.MPanel_ParentModel.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == mpnlParent.Name);
                                            if (multiPanelModel.MPanel_Placement != "Last" && mpnlParent.Name != mpnls.MPanel_Name)
                                            {
                                                indY += multiPanelModel.MPanelImageRenderer_Height;
                                            }
                                            if (mpnlParent.Name == mpnls.MPanel_Name)
                                            {
                                                break;

                                            }
                                        }
                                    }
                                    else if (mpnl.MPanel_ParentModel.MPanel_Type == "Transom")
                                    {
                                        if (mpnlParent.Name.Contains("PanelUC_"))
                                        {
                                            IPanelModel panelModel = mpnls.MPanel_ParentModel.MPanelLst_Panel.Find(panel => panel.Panel_Name == mpnlParent.Name);
                                            indX += panelModel.PanelImageRenderer_Width;
                                        }
                                        else if (mpnlParent.Name.Contains("MullionUC_"))
                                        {
                                            IDividerModel divModel = mpnls.MPanel_ParentModel.MPanelLst_Divider.Find(div => div.Div_Name == mpnlParent.Name);
                                            indX += divModel.DivImageRenderer_Width;
                                        }
                                        else if (mpnlParent.Name.Contains("MultiTransom_"))
                                        {
                                            IMultiPanelModel multiPanelModel = mpnls.MPanel_ParentModel.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == mpnlParent.Name);

                                            if (multiPanelModel.MPanel_Placement != "Last" && mpnlParent.Name != mpnls.MPanel_Name)
                                            {
                                                indX += multiPanelModel.MPanelImageRenderer_Width;
                                            }
                                            if (mpnlParent.Name == mpnls.MPanel_Name)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (mpnl.MPanel_Type == "Mullion")
                                {
                                    mParentLoc_Y1 = 0;
                                    if (mpnls.MPanel_Placement != "First")
                                    {
                                        mParentLoc_X1 += indX;
                                    }

                                }
                                else if (mpnl.MPanel_Type == "Transom")
                                {
                                    mParentLoc_X1 = 0;

                                    if (mpnls.MPanel_Placement != "First")
                                    {
                                        mParentLoc_Y1 += indY;
                                    }

                                }
                                foreach (Control parentMpnl_obj in mpnl.MPanel_Parent.Controls)
                                {
                                    if (mpnl.MPanel_Name != parentMpnl_obj.Name)
                                    {
                                        if (mpnl.MPanel_Type == "Mullion")
                                        {
                                            if (parentMpnl_obj.Name.Contains("MultiMullion_"))
                                            {
                                                IMultiPanelModel multiPanelModel = mpnl.MPanel_ParentModel.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == parentMpnl_obj.Name);

                                                mParentLoc_Y1 += multiPanelModel.MPanelImageRenderer_Height;
                                            }
                                            else if (parentMpnl_obj.Name.Contains("TransomUC_"))
                                            {
                                                int BotPadding = 0;
                                                IDividerModel divModel = mpnl.MPanel_ParentModel.MPanelLst_Divider.Find(div => div.Div_Name == parentMpnl_obj.Name);
                                                if (topViewCheck == true)
                                                {
                                                    BotPadding = (BotPaddingBaseOnItemSize / (mpnl.MPanel_ParentModel.MPanel_Divisions + 1));
                                                }
                                                else if (topViewCheck == false)
                                                {
                                                    BotPadding = 0;
                                                }

                                                mParentLoc_Y1 += divModel.DivImageRenderer_Height - BotPadding;//3rd
                                            }
                                        }
                                        else if (mpnl.MPanel_Type == "Transom")
                                        {
                                            if (parentMpnl_obj.Name.Contains("MultiTransom_"))
                                            {
                                                IMultiPanelModel multiPanelModel = mpnl.MPanel_ParentModel.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == parentMpnl_obj.Name);

                                                mParentLoc_X1 += multiPanelModel.MPanelImageRenderer_Width;
                                            }
                                            else if (parentMpnl_obj.Name.Contains("MullionUC_"))
                                            {
                                                IDividerModel divModel = mpnl.MPanel_ParentModel.MPanelLst_Divider.Find(div => div.Div_Name == parentMpnl_obj.Name);
                                                mParentLoc_X1 += divModel.DivImageRenderer_Width;
                                            }
                                        }
                                        if (parentMpnl_obj.Name.Contains("Panel"))
                                        {
                                            if (mpnl.MPanel_Type == "Mullion")
                                            {
                                                IPanelModel panelModel = mpnl.MPanel_ParentModel.MPanelLst_Panel.Find(panel => panel.Panel_Name == parentMpnl_obj.Name);
                                                mParentLoc_Y1 += panelModel.PanelImageRenderer_Height;
                                            }
                                            else if (mpnl.MPanel_Type == "Transom")
                                            {
                                                IPanelModel panelModel = mpnl.MPanel_ParentModel.MPanelLst_Panel.Find(panel => panel.Panel_Name == parentMpnl_obj.Name);
                                                mParentLoc_X1 += panelModel.PanelImageRenderer_Width;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                Point MPoint = Panel_MPanel_DrawPoints_ParentIsFrame(object_points[i], frameModel.FrameImageRenderer_Padding_int.Top + mParentLoc_Y1, frameModel.FrameImageRenderer_Padding_int.Left + mParentLoc_X1);

                                Draw_MultiPanelParent(mpnl, MPoint, zoom, e);

                            }
                        }
                    }
                }
                else if (objects.Name.Contains("Concrete"))
                {
                    IConcreteModel concreteModel = _windoorModel.lst_concrete.Find(concrete => concrete.Concrete_Name == _windoorModel.lst_objects[i].Name);
                    Draw_Concrete(e, object_points[i], windoor_objects_sizes[i], concreteModel);
                }
            }
            Color col = Color.Black;
            int w = 2;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                           0,
                                                           fpnl.ClientRectangle.Width - w,
                                                           fpnl.ClientRectangle.Height - w));
            //}
            //catch (Exception ex)l
            //{
            //    Logger log = new Logger(ex.Message, ex.StackTrace);
            //    MessageBox.Show("Error Message: " + ex.Message);
            //}
        }
        private void Draw_Concrete(PaintEventArgs e, Point cPoint, Size cSize, IConcreteModel concreteModel)
        {
            Color color = Color.Black;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int cond = cSize.Width + cSize.Height;
            int w = 1;

            for (int i = 10; i < cond; i += 10)
            {
                Point upperPoint = new Point(0, 0);
                if (i > cSize.Width)
                {
                    upperPoint = new Point(cPoint.X + cSize.Width - w, cPoint.Y + i - cSize.Width);
                }
                else
                {
                    upperPoint = new Point(cPoint.X + i, cPoint.Y);
                }


                Point lowerPoint = new Point(0, 0);
                if (i > cSize.Height)
                {
                    lowerPoint = new Point(cPoint.X + i - cSize.Height, cPoint.Y + cSize.Height - w);
                }
                else
                {
                    lowerPoint = new Point(cPoint.X, cPoint.Y + i);
                }


                g.DrawLine(Pens.Black, lowerPoint, upperPoint);




            }
            g.DrawRectangle(new Pen(color, w), new Rectangle(cPoint.X - w,
                                                  cPoint.Y - w + 2,
                                                  cSize.Width,
                                                  cSize.Height));
        }

        private void Draw_MultiPanelParent(IMultiPanelModel mpnl, Point MPoint, float zoom, PaintEventArgs e)
        {
            int mlocX = MPoint.X,
                mlocY = MPoint.Y,
                objLocX = 0,
                objLocY = 0;

            if (mpnl.MPanel_Type == "Mullion")
            {
                foreach (Control ctrl in mpnl.MPanelLst_Objects)
                {
                    if (ctrl.Name.Contains("PanelUC_"))
                    {
                        IPanelModel panelModel = mpnl.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name);
                        objLocY = mlocY;

                        if (panelModel.Panel_Placement == "First")
                        {
                            objLocX += mlocX; //addition of frame_pads and div wd   
                        }
                        else if (panelModel.Panel_Placement != "First")
                        {
                        }

                        Draw_Panel(e, panelModel, new Point(objLocX + 1, objLocY));

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
                        else if (zoom <= 0.50f)
                        {
                            locY_deduct = 5;
                        }

                        int botPadDeduct = 0;
                        if (topViewCheck == true)
                        {
                            if (mpnl.MPanel_ParentModel != null) // 2nd lvl div ht
                            {
                                if (mpnl.MPanel_ParentModel.MPanel_Name.Contains("MultiTransom_"))
                                {
                                    botPadDeduct = BotPaddingBaseOnItemSize / (mpnl.MPanel_ParentModel.MPanel_Divisions + 1);
                                }
                                else if (mpnl.MPanel_ParentModel.MPanel_Name.Contains("MultiMullion_"))
                                {
                                    botPadDeduct = BotPaddingBaseOnItemSize;
                                }
                            }
                            else
                            {
                                botPadDeduct = BotPaddingBaseOnItemSize;
                            }

                        }
                        else if (topViewCheck == false)
                        {
                            botPadDeduct = 0;
                        }

                        Draw_Divider(e, divModel, new Point(objLocX, objLocY - locY_deduct), botPadDeduct);

                        objLocX += divModel.DivImageRenderer_Width;

                    }
                    else if (ctrl.Name.Contains("MultiTransom_")) //2nd level Mpanel
                    {
                        IMultiPanelModel mpnlModel = mpnl.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == ctrl.Name);
                        objLocY = mlocY;

                        if (mpnlModel.MPanel_Placement == "First")
                        {
                            objLocX += mlocX; //addition of frame_pads and div wd
                        }
                        else if (mpnlModel.MPanel_Placement != "First")
                        {

                        }

                        int botPadDeduct = 0;
                        if (topViewCheck == true)
                        {
                            if (mpnlModel.MPanel_ParentModel.MPanel_ParentModel != null)
                            {
                                if (mpnlModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Name.Contains("MultiTransom_"))
                                {
                                    botPadDeduct = BotPaddingBaseOnItemSize / (mpnlModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Divisions + 1);
                                }
                            }
                            else
                            {
                                botPadDeduct = BotPaddingBaseOnItemSize;
                            }
                        }
                        else if (topViewCheck == false)
                        {
                            botPadDeduct = 0;
                        }

                        Draw_MultiPanel(e, mpnlModel, new Point(objLocX, objLocY), botPadDeduct);

                        objLocX += mpnlModel.MPanelImageRenderer_Width;
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
                        objLocX = mlocX;

                        if (panelModel.Panel_Placement == "First")
                        {
                            objLocY += mlocY; //addition of frame_pads and div wd
                        }
                        else if (panelModel.Panel_Placement != "First")
                        {

                        }
                        Draw_Panel(e, panelModel, new Point(objLocX, objLocY));

                        int lastLevelDivisor = 0, botPadDeduction = 0;
                        if (topViewCheck == true)
                        {
                            if (mpnl.MPanel_ParentModel != null &&
                               mpnl.MPanel_ParentModel.MPanel_ParentModel != null)
                            {
                                if (mpnl.MPanel_ParentModel.MPanel_ParentModel.MPanel_Name.Contains("MultiTransom_"))
                                {
                                    lastLevelDivisor = mpnl.MPanel_ParentModel.MPanel_ParentModel.MPanel_Divisions + 1;
                                }
                            }

                            botPadDeduction = (BotPaddingBaseOnItemSize / ((mpnl.MPanel_Divisions + 1) + lastLevelDivisor));
                        }
                        else if (topViewCheck == false)
                        {
                            botPadDeduction = 0;
                        }

                        objLocY += panelModel.PanelImageRenderer_Height - botPadDeduction;
                    }
                    else if (ctrl.Name.Contains("TransomUC_"))
                    {
                        IDividerModel divModel = mpnl.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name);
                        int locX_deduct = 0;

                        if (zoom == 1.0f)
                        {
                            locX_deduct = 10;
                        }
                        else if (zoom <= 0.50f)
                        {
                            locX_deduct = 5;
                        }

                        Draw_Divider(e, divModel, new Point(objLocX - locX_deduct, objLocY), 0);

                        objLocY += divModel.DivImageRenderer_Height;


                    }
                    else if (ctrl.Name.Contains("MultiMullion_"))//2nd level Mpanel
                    {
                        IMultiPanelModel mpnlModel = mpnl.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == ctrl.Name);
                        objLocX = mlocX;

                        if (mpnlModel.MPanel_Placement == "First")
                        {
                            objLocY += mlocY; //addition of frame_pads and div wd
                        }
                        else if (mpnlModel.MPanel_Placement != "First")
                        {

                        }

                        int botPadDeduction = 0;
                        if (topViewCheck == true)
                        {
                            botPadDeduction = (BotPaddingBaseOnItemSize / (mpnl.MPanel_Divisions + 1));
                        }
                        else if (topViewCheck == false)
                        {
                            botPadDeduction = 0;
                        }
                        Draw_MultiPanel(e, mpnlModel, new Point(objLocX, objLocY), botPadDeduction);
                        objLocY += mpnlModel.MPanelImageRenderer_Height - botPadDeduction;
                    }
                }
            }
            //Mpnl_point = new Point()
            //Draw_MultiPanel(e, mpnlModel, MPoint);

        }

        int
            line_X_Distance,
            pnlCount;
        private void _basePlatformImagerUC_basePlatformPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl basePL = (UserControl)sender;
            FlowLayoutPanel _flpMain = (FlowLayoutPanel)basePL.Controls[0];
            //dito ilagay ang drawing ng red-arrowlines
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            int ctrl_Y = 35;
            float zoom = _windoorModel.WD_zoom_forImageRenderer;
            Pen redP = new Pen(Color.Red);
            Pen greenP = new Pen(Color.Green);
            Pen blueP = new Pen(Color.Blue);
            Pen BlackP = new Pen(Color.Black, 3.5f);

            redP.Width = 3.5f;

            if (_windoorModel.WD_width >= 10000)
            {
                dmnsion_font_wd = new Font("Segoe UI", 12, FontStyle.Bold);
                dmnsion_font_ht = new Font("Segoe UI", 12, FontStyle.Bold);
            }
            else
            {
                dmnsion_font_wd = new Font("Segoe UI", 22, FontStyle.Bold);
                dmnsion_font_ht = new Font("Segoe UI", 22, FontStyle.Bold);
            }


            int total_frame = _windoorModel.lst_frame.Count();
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
                float locX = 0;
                foreach (KeyValuePair<int, decimal> wd in _windoorModel.Dictionary_wd_redArrowLines)
                {
                    locX = Draw_Arrow_Width(wd.Value, e, locX, dmnsion_font_wd, ctrl_Y);
                }

                float locY = 0;
                foreach (KeyValuePair<int, decimal> ht in _windoorModel.Dictionary_ht_redArrowLines)
                {
                    locY = Draw_Arrow_Height(ht.Value, e, locY, dmnsion_font_ht, ctrl_Y);
                }

                int InitialDistance = _flpMain.Location.X,
                        endOfLine = _flpMain.Width - 10,
                        pnlLeftCounter = _mainPresenter.frameModel_MainPresenter.Frame_FoldAndSlideTopViewLeftCount,
                       pnlRightCounter = _mainPresenter.frameModel_MainPresenter.Frame_FoldAndSlideTopViewRightCount,
                       line_LtR_Y = _flpMain.Location.Y + (_flpMain.Height - 3) + 70; // 70 bot pad

                Point dmnsion_w_startP_topview = new Point(_flpMain.Location.X, _flpMain.Location.Y + (_flpMain.Height - 3) + 70);
                Point dmnsion_w_endP_topview = new Point(_flpMain.Location.X + _flpMain.Width - 3, _flpMain.Location.Y + (_flpMain.Height - 3) + 70);

                if (_windoorModel.WD_TopViewType == "Fold and Slide")
                {
                    //fold and slide top view 

                    if (pnlLeftCounter != 0 || pnlRightCounter != 0)
                    {
                        topViewCheck = true;
                        if (_basePlatformImagerUC.GetBasePlatformImagerUC().Padding.Bottom == 0)
                        {
                            _basePlatformImagerUC.GetBasePlatformImagerUC().Padding = new Padding(70, 35, 0, 70);
                        }

                        if (total_panel != 0)
                        {
                            line_X_Distance = Math.Abs(_flpMain.Width / total_panel);
                        }


                        g.DrawLine(BlackP, dmnsion_w_startP_topview, dmnsion_w_endP_topview); // line


                        for (int a = 0; a < pnlLeftCounter; a++)
                        {
                            int x1 = InitialDistance,
                                x2 = InitialDistance + (line_X_Distance / 2);

                            if (a % 2 == 0)
                            {
                                g.DrawLine(new Pen(Color.Black, 5), new Point(x1, line_LtR_Y - 10), new Point(x2, line_LtR_Y - 60));
                            }
                            else
                            {
                                g.DrawLine(new Pen(Color.Black, 5), new Point(x2, line_LtR_Y - 10), new Point(x1, line_LtR_Y - 60));
                            }

                            InitialDistance = x2;
                        }

                        InitialDistance = _flpMain.Location.X + _flpMain.Width - 3;
                        for (int a = 0; a < pnlRightCounter; a++)
                        {
                            int x1 = InitialDistance,
                                x2 = InitialDistance - (line_X_Distance / 2);

                            if (a % 2 == 0)
                            {
                                g.DrawLine(new Pen(Color.Black, 5), new Point(x1, line_LtR_Y - 10), new Point(x2, line_LtR_Y - 60));
                            }
                            else
                            {
                                g.DrawLine(new Pen(Color.Black, 5), new Point(x2, line_LtR_Y - 10), new Point(x1, line_LtR_Y - 60));
                            }

                            InitialDistance = x2;
                        }
                    }
                }
                else if (_windoorModel.WD_TopViewType == "Sliding Pivot")
                {
                    if (pnlLeftCounter != 0 || pnlRightCounter != 0)
                    {
                        topViewCheck = true;
                        if (_basePlatformImagerUC.GetBasePlatformImagerUC().Padding.Bottom == 0)
                        {
                            _basePlatformImagerUC.GetBasePlatformImagerUC().Padding = new Padding(70, 35, 0, 70);
                        }
                        g.DrawLine(BlackP, dmnsion_w_startP_topview, dmnsion_w_endP_topview); // line


                        for (int a = 0; a < pnlLeftCounter; a++)
                        {
                            int x1 = InitialDistance;

                            g.DrawLine(new Pen(Color.Black, 5), new Point(x1, line_LtR_Y), new Point(x1, line_LtR_Y - 60));

                            InitialDistance += 10;
                        }
                        for (int a = 0; a < pnlRightCounter; a++)
                        {
                            int x1 = endOfLine + 75;

                            g.DrawLine(new Pen(Color.Black, 5), new Point(x1, line_LtR_Y), new Point(x1, line_LtR_Y - 60));

                            endOfLine -= 10;
                        }
                    }


                }
                else
                {
                    topViewCheck = false;
                    _basePlatformImagerUC.GetBasePlatformImagerUC().Padding = new Padding(70, 35, 0, 0);
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

                g.DrawLines(redP, arrwhd_pnts_H1);
                g.DrawLine(redP, dmnsion_h_startP, dmnsion_h_endP);
                g.DrawLines(redP, arrwhd_pnts_H2);
                TextRenderer.DrawText(g,
                                      dmnsion_h,
                                      dmnsion_font_ht,
                                      new Rectangle(new Point((70 - s2.Width + 5) / 2, (int)(mid2 - (s2.Height / 2))),
                                                    new Size(s2.Width, s2.Height)),
                                      Color.Black,
                                      Color.White,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                //arrow for HEIGHT


            }

            Bitmap bm = new Bitmap(basePL.Size.Width, basePL.Size.Height);
            basePL.DrawToBitmap(bm, new Rectangle(0, 0, bm.Width, bm.Height));

            _windoorModel.WD_image = bm;
        }

        private float Draw_Arrow_Width(decimal wd, PaintEventArgs e, float locX, Font dmnsion_font_wd, int ctrl_Y)
        {
            Graphics g = e.Graphics;

            string dmnsion_w = wd.ToString();

            if (dmnsion_w.Contains(".0"))
            {
                dmnsion_w = dmnsion_w.Replace(".0", "");
            }

            float DispWd_float = float.Parse(dmnsion_w);

            PointF dmnsion_w_startP = new PointF(_flpMain.Location.X + (locX * _windoorModel.GetZoom_forRendering()),
                                                 (ctrl_Y - 17));// * _windoorModel.WD_zoom;)
            PointF dmnsion_w_endP = new PointF((_flpMain.Location.X - 3) + ((locX + DispWd_float) * _windoorModel.GetZoom_forRendering()),
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

            if (_windoorModel.lst_frame.Count() > 0)
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
                                      Color.White,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            //arrow for WIDTH
            locX += DispWd_float;

            return locX;
        }
        int botPaddingMultiplier;
        private float Draw_Arrow_Height(decimal ht, PaintEventArgs e, float locY, Font dmnsion_font_ht, int ctrl_Y)
        {
            //arrow for HEIGHT
            Graphics g = e.Graphics;

            string dmnsion_h = ht.ToString();
            float DispHt_float = float.Parse(dmnsion_h);
            if (topViewCheck == true)
            {
                DispHt_float -= (float)DeductionForBottomFramePaddingImagerRendering() / _windoorModel.Dictionary_ht_redArrowLines.Count;
            }
            else if (topViewCheck == false)
            {

            }
            PointF dmnsion_h_startP = new PointF(70 - 17, _flpMain.Location.Y + (locY * _windoorModel.GetZoom_forRendering()));
            PointF dmnsion_h_endP = new PointF(70 - 17, (_flpMain.Location.Y - 3) + ((locY + DispHt_float) * _windoorModel.GetZoom_forRendering()));



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

            if (_windoorModel.lst_frame.Count() > 0)
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
                                      Color.White,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            //arrow for HEIGHT
            locY += DispHt_float;

            return locY;
        }

        private void Draw_Frame(PaintEventArgs e, Point fPoint, Size fSize, IFrameModel frameModel)
        {
            Pen blkPen = new Pen(Color.Black);
            blkPen.Width = 2;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (topViewCheck == true)
            {
                DeductionForBottomFramePaddingImager(frameModel.Frame_Height);
            }
            else if (topViewCheck == false)
            {
                deductBotPadding = 0;
            }

            int fr_pads = frameModel.FrameImageRenderer_Padding_int.All;

            int top_pads = frameModel.FrameImageRenderer_Padding_int.Top,
                right_pads = frameModel.FrameImageRenderer_Padding_int.Right,
                left_pads = frameModel.FrameImageRenderer_Padding_int.Left,
                bot_pads = frameModel.FrameImageRenderer_Padding_int.Bottom;

            Rectangle pnl_inner = new Rectangle(new Point(fPoint.X + left_pads, fPoint.Y + top_pads),
                                                new Size(frameModel.FrameImageRenderer_Width - (right_pads + left_pads),
                                                         frameModel.FrameImageRenderer_Height - deductBotPadding - (top_pads + bot_pads)));


            int pInnerX = pnl_inner.Location.X,
            pInnerY = pnl_inner.Location.Y,
            pInnerWd = pnl_inner.Width,
            pInnerHt = pnl_inner.Height;

            Point[] corner_points = new[]
            {
                new Point(fPoint.X, fPoint.Y),
                new Point(pInnerX, pInnerY),
                new Point(fPoint.X + frameModel.FrameImageRenderer_Width, fPoint.Y),
                new Point(pInnerX + pInnerWd, pInnerY),
                new Point(fPoint.X, frameModel.FrameImageRenderer_Height + fPoint.Y - deductBotPadding),
                new Point(pInnerX, pInnerY + pInnerHt),
                new Point(fPoint.X + frameModel.FrameImageRenderer_Width, frameModel.FrameImageRenderer_Height + fPoint.Y - deductBotPadding),
                new Point(pInnerX + pInnerWd, pInnerY + pInnerHt)
            };

            for (int i = 0; i < corner_points.Length - 1; i += 2)
            {
                g.DrawLine(blkPen, corner_points[i], corner_points[i + 1]);
            }

            g.DrawRectangle(blkPen, pnl_inner);

            int w = 2;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(blkPen, new Rectangle(fPoint.X,
                                                  fPoint.Y,
                                                  fSize.Width - w,
                                                          fSize.Height + 3 - w));
        }
        float first = 0;
        private void Draw_Panel(PaintEventArgs e, IPanelModel panelModel, Point Ppoint)
        {
            Graphics g = e.Graphics;
            int w = 2;
            int outerLineDeduction = 18;
            int innerLineDeduction = 13;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            float ArrowExpectedWidth = 0
                        , ArrowExpectedHeight = 0
                        , arrowStartingX = 0
                        , arrowStartingY = 0;
            int client_wd = 0, client_ht = 0;




            int BotPadDeduct = 0;
            if (panelModel.Panel_ParentMultiPanelModel != null)
            {
                if (panelModel.Panel_ParentMultiPanelModel.MPanel_Type == "Mullion")
                {
                    if (topViewCheck == true)
                    {
                        if (panelModel.Panel_ParentMultiPanelModel.MPanel_ParentModel != null)
                        {
                            if (panelModel.Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Name.Contains("MultiTransom_"))
                            {
                                BotPadDeduct = BotPaddingBaseOnItemSize / (panelModel.Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Divisions + 1);
                            }
                            else
                            {
                                BotPadDeduct = BotPaddingBaseOnItemSize;
                            }
                        }
                        else
                        {
                            BotPadDeduct = BotPaddingBaseOnItemSize;
                        }
                    }
                    else if (topViewCheck == false)
                    {
                        BotPadDeduct = 0;
                    }



                    client_wd = panelModel.PanelImageRenderer_Width;
                    client_ht = panelModel.Panel_ParentMultiPanelModel.MPanelImageRenderer_Height - BotPadDeduct;
                }
                else if (panelModel.Panel_ParentMultiPanelModel.MPanel_Type == "Transom")
                {
                    int lastLevelDivisor = 0;
                    if (topViewCheck == true)
                    {
                        if (panelModel.Panel_ParentMultiPanelModel.MPanel_ParentModel != null &&
                                               panelModel.Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_ParentModel != null)
                        {
                            if (panelModel.Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Name.Contains("MultiTransom_"))
                            {
                                lastLevelDivisor = panelModel.Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Divisions + 1;
                            }
                        }

                        BotPadDeduct = (BotPaddingBaseOnItemSize / ((panelModel.Panel_ParentMultiPanelModel.MPanel_Divisions + 1) + lastLevelDivisor));
                    }
                    else if (topViewCheck == false)
                    {
                        BotPadDeduct = 0;
                    }



                    client_wd = panelModel.Panel_ParentMultiPanelModel.MPanelImageRenderer_Width;
                    client_ht = panelModel.PanelImageRenderer_Height - BotPadDeduct;
                }
            }
            else
            {
                if (topViewCheck == true)
                {
                    BotPadDeduct = deductBotPadding;
                }
                else if (topViewCheck == false)
                {
                    BotPadDeduct = 0;
                }
                client_wd = panelModel.PanelImageRenderer_Width;
                client_ht = panelModel.PanelImageRenderer_Height - BotPadDeduct;
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
                sashD = inner_line;
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
            Pen pInnerLine = new Pen(Color.FromArgb(245, 245, 220), penThickness);
            Pen pOuterLine = new Pen(Color.Black, 1);





            int addY = ((client_ht - (((int)(client_ht - sashDeduction + pGbarInnerY) / (horizontalQty + 1)) * horizontalQty)) - ((client_ht + pGbarInnerY) / (horizontalQty + 1))) / 2;

            //Horizontal
            int GeorgianBar_GapYs = GeorgianBar_GapY;
            for (int ii = 0; ii < horizontalQty; ii++)
            {
                GBpointResultY = ((pGbarInnerY + client_ht - sashDeduction) / (horizontalQty + 1) + Convert.ToInt32(Math.Floor((double)GeorgianBar_GapY)));
                GeorgianBar_GapY += (client_ht - sashDeduction + (pGbarInnerY)) / (horizontalQty + 1);

                Point[] GeorgianBarTop_PointsY = null;
                Point[] GeorgianBarBottom_PointsY = null;
                if (panelModel.Panel_Overlap_Sash == OverlapSash._Right)
                {
                    GeorgianBarTop_PointsY = new[]
                    {
                        new Point(pGbarInnerY+1 + Ppoint.X + sashD, GBpointResultY + Ppoint.Y-leftdeduction + addY),
                        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD + inner_line - 2, GBpointResultY + Ppoint.Y-leftdeduction + addY),
                    };
                    GeorgianBarBottom_PointsY = new[]
                    {
                        new Point(pGbarInnerY+1 + Ppoint.X + sashD, GBpointResultY + Ppoint.Y + rightAddition + addY),
                        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD + inner_line, GBpointResultY + Ppoint.Y + rightAddition + addY),
                    };
                }
                else if (panelModel.Panel_Overlap_Sash == OverlapSash._Left)
                {
                    GeorgianBarTop_PointsY = new[]
                    {
                        new Point(pGbarInnerY+1 + Ppoint.X + sashD - inner_line, GBpointResultY + Ppoint.Y-leftdeduction + addY),
                        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD, GBpointResultY + Ppoint.Y-leftdeduction + addY),
                    };
                    GeorgianBarBottom_PointsY = new[]
                    {
                        new Point(pGbarInnerY+1 + Ppoint.X + sashD - inner_line, GBpointResultY + Ppoint.Y + rightAddition + addY),
                        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD, GBpointResultY + Ppoint.Y + rightAddition + addY),
                    };
                }
                else if (panelModel.Panel_Overlap_Sash == OverlapSash._Both)
                {
                    GeorgianBarTop_PointsY = new[]
                    {
                        new Point(pGbarInnerY+1 + Ppoint.X + sashD - inner_line, GBpointResultY + Ppoint.Y-leftdeduction + addY),
                        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD + inner_line - 2, GBpointResultY + Ppoint.Y-leftdeduction + addY),
                    };
                    GeorgianBarBottom_PointsY = new[]
                    {
                        new Point(pGbarInnerY+1 + Ppoint.X + sashD - inner_line, GBpointResultY + Ppoint.Y + rightAddition + addY),
                        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD + inner_line, GBpointResultY + Ppoint.Y + rightAddition + addY),
                    };
                }
                else if (panelModel.Panel_Overlap_Sash == OverlapSash._None)
                {
                    GeorgianBarTop_PointsY = new[]
                    {
                        new Point(pGbarInnerY+1 + Ppoint.X + sashD,GBpointResultY + Ppoint.Y-leftdeduction + addY),
                        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD,GBpointResultY + Ppoint.Y-leftdeduction + addY),
                    };
                    GeorgianBarBottom_PointsY = new[]
                    {
                        new Point(pGbarInnerY+1 + Ppoint.X + sashD,GBpointResultY + Ppoint.Y + rightAddition + addY),
                        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD,GBpointResultY + Ppoint.Y + rightAddition + addY),
                    };
                }
                for (int i = 0; i < GeorgianBarTop_PointsY.Length - 1; i += 2)
                {
                    g.DrawLine(pOuterLine, GeorgianBarTop_PointsY[i], GeorgianBarTop_PointsY[i + 1]);
                }
                for (int i = 0; i < GeorgianBarBottom_PointsY.Length - 1; i += 2)
                {
                    g.DrawLine(pOuterLine, GeorgianBarBottom_PointsY[i], GeorgianBarBottom_PointsY[i + 1]);
                }
            }



            int addX = ((client_wd - (((int)(client_wd - sashDeduction + pGbarInnerX) / (verticalQty + 1)) * verticalQty)) - ((client_wd + pGbarInnerX) / (verticalQty + 1))) / 2;

            //vertical
            for (int ii = 0; ii < verticalQty; ii++)
            {
                GBpointResultX = ((pGbarInnerX + client_wd - sashDeduction) / (verticalQty + 1) + Convert.ToInt32(Math.Floor((double)GeorgianBar_GapX)));
                GeorgianBar_GapX += (client_wd - sashDeduction + (pGbarInnerX)) / (verticalQty + 1);
                Point[] GeorgianBar_PointsX = new[]
                {
                  new Point(GBpointResultX + Ppoint.X + addX,pGbarInnerX+1 + Ppoint.Y + sashD),
                  new Point(GBpointResultX + Ppoint.X + addX,pGbarInnerX + client_ht-1 + Ppoint.Y - sashD),
                };
                for (int i = 0; i < GeorgianBar_PointsX.Length - 1; i += 2)
                {
                    g.DrawLine(pInnerLine, GeorgianBar_PointsX[i], GeorgianBar_PointsX[i + 1]);
                }
                Point[] GeorgianBarBoderLeft_PointsX = new[]
                {

                     new Point(GBpointResultX + Ppoint.X-leftdeduction + addX,pGbarInnerX+1 + Ppoint.Y + sashD),
                     new Point(GBpointResultX + Ppoint.X-leftdeduction + addX,pGbarInnerX + client_ht-1 + Ppoint.Y - sashD),
                };
                for (int i = 0; i < GeorgianBarBoderLeft_PointsX.Length - 1; i += 2)
                {
                    g.DrawLine(pOuterLine, GeorgianBarBoderLeft_PointsX[i], GeorgianBarBoderLeft_PointsX[i + 1]);

                }
                Point[] GeorgianBarBoderRight_PointsX = new[]
                {

                     new Point(GBpointResultX + Ppoint.X + rightAddition + addX,pGbarInnerX+1 + Ppoint.Y + sashD),
                     new Point(GBpointResultX + Ppoint.X + rightAddition + addX,pGbarInnerX + client_ht-1 + Ppoint.Y - sashD),
                };
                for (int i = 0; i < GeorgianBarBoderRight_PointsX.Length - 1; i += 2)
                {
                    g.DrawLine(pOuterLine, GeorgianBarBoderRight_PointsX[i], GeorgianBarBoderRight_PointsX[i + 1]);
                }

            }
            //Horizontal

            for (int ii = 0; ii < horizontalQty; ii++)
            {
                GBpointResultY = ((pGbarInnerY + client_ht - sashDeduction) / (horizontalQty + 1) + Convert.ToInt32(Math.Floor((double)GeorgianBar_GapYs)));
                GeorgianBar_GapYs += (client_ht - sashDeduction + (pGbarInnerY)) / (horizontalQty + 1);
                Point[] GeorgianBar_PointsY = null;
                if (panelModel.Panel_Overlap_Sash == OverlapSash._Right)
                {
                    GeorgianBar_PointsY = new[]
                    {
                        new Point(pGbarInnerY+1 + Ppoint.X + sashD,GBpointResultY + Ppoint.Y + addY),
                        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD + inner_line - 2, GBpointResultY + Ppoint.Y + addY),
                    };
                }
                else if (panelModel.Panel_Overlap_Sash == OverlapSash._Left)
                {
                    GeorgianBar_PointsY = new[]
                     {
                        new Point(pGbarInnerY+1 + Ppoint.X + sashD - inner_line, GBpointResultY + Ppoint.Y + addY),
                        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD, GBpointResultY + Ppoint.Y + addY),
                    };
                }
                else if (panelModel.Panel_Overlap_Sash == OverlapSash._Both)
                {
                    GeorgianBar_PointsY = new[]
                    {
                        new Point(pGbarInnerY+1 + Ppoint.X + sashD - inner_line, GBpointResultY + Ppoint.Y + addY),
                        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD + inner_line  - 2, GBpointResultY + Ppoint.Y + addY),
                    };
                }
                else if (panelModel.Panel_Overlap_Sash == OverlapSash._None)
                {
                    GeorgianBar_PointsY = new[]
                    {
                        new Point(pGbarInnerY+1 + Ppoint.X + sashD,GBpointResultY + Ppoint.Y + addY),
                        new Point(pGbarInnerY-1 + client_wd + Ppoint.X - sashD,GBpointResultY + Ppoint.Y + addY),
                    };
                }
                for (int i = 0; i < GeorgianBar_PointsY.Length - 1; i += 2)
                {
                    g.DrawLine(pInnerLine, GeorgianBar_PointsY[i], GeorgianBar_PointsY[i + 1]);
                }
            }
            #endregion
            if (panelModel.Panel_Type != "Louver Panel")
            {
                //g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(Ppoint.X + outer_line,
                //                                                   Ppoint.Y + outer_line,
                //                                                   (client_wd - (outer_line * 2)) - w,
                //                                                   (client_ht - (outer_line * 2)) - w));
                if (panelModel.Panel_Overlap_Sash == OverlapSash._Right)
                {
                    tenPercentAdditional += 1;
                    //outer Line
                    PointF outerLine1 = new PointF(Ppoint.X + outer_line, Ppoint.Y + outer_line);
                    PointF outerLine2 = new PointF(Ppoint.X + client_wd - w, Ppoint.Y + outer_line);
                    PointF outerLine3 = new PointF(Ppoint.X + outer_line, Ppoint.Y + outer_line);
                    PointF outerLine4 = new PointF(Ppoint.X + outer_line, Ppoint.Y + outer_line + (client_ht - (outer_line * 2)) - w);
                    PointF outerLine5 = new PointF(Ppoint.X + outer_line, Ppoint.Y + outer_line + (client_ht - (outer_line * 2)) - w);
                    PointF outerLine6 = new PointF(Ppoint.X + client_wd - w, Ppoint.Y + outer_line + (client_ht - (outer_line * 2)) - w);
                    e.Graphics.DrawLine(new Pen(outerColor, 1), outerLine1, outerLine2);
                    e.Graphics.DrawLine(new Pen(outerColor, 1), outerLine3, outerLine4);
                    e.Graphics.DrawLine(new Pen(outerColor, 1), outerLine5, outerLine6);

                    if (panelModel.Panel_Type != "Fixed Panel" || (panelModel.Panel_Type == "Fixed Panel" && panelModel.Panel_Orient == true))
                    {
                        //inner Line 
                        PointF innerLine1 = new PointF(Ppoint.X + inner_line, Ppoint.Y + inner_line);
                        PointF innerLine2 = new PointF(Ppoint.X + client_wd - w, Ppoint.Y + inner_line);
                        PointF innerLine3 = new PointF(Ppoint.X + inner_line, Ppoint.Y + inner_line);
                        PointF innerLine4 = new PointF(Ppoint.X + inner_line, Ppoint.Y + inner_line + (client_ht - (inner_line * 2)) - w);
                        PointF innerLine5 = new PointF(Ppoint.X + inner_line, Ppoint.Y + inner_line + (client_ht - (inner_line * 2)) - w);
                        PointF innerLine6 = new PointF(Ppoint.X + client_wd - w, Ppoint.Y + inner_line + (client_ht - (inner_line * 2)) - w);
                        e.Graphics.DrawLine(new Pen(Color.Black, 3), innerLine1, innerLine2);
                        e.Graphics.DrawLine(new Pen(Color.Black, 3), innerLine3, innerLine4);
                        e.Graphics.DrawLine(new Pen(Color.Black, 3), innerLine5, innerLine6);
                    }
                    sashOverlapValue += inner_line;
                }

                else if (panelModel.Panel_Overlap_Sash == OverlapSash._Left)
                {
                    //outer Line
                    //PointF outerLine1 = new PointF(Ppoint.X + outer_line - innerLineDeduction + w + tenPercentAdditional, Ppoint.Y + outer_line);
                    PointF outerLine1 = new PointF(Ppoint.X, Ppoint.Y + outer_line);
                    PointF outerLine2 = new PointF(Ppoint.X + outer_line - innerLineDeduction + (client_wd - (outer_line * 2)) - w + innerLineDeduction, Ppoint.Y + outer_line);
                    PointF outerLine3 = new PointF(Ppoint.X + outer_line - innerLineDeduction + (client_wd - (outer_line * 2)) - w + innerLineDeduction, Ppoint.Y + outer_line);
                    PointF outerLine4 = new PointF(Ppoint.X + outer_line - innerLineDeduction + (client_wd - (outer_line * 2)) - w + innerLineDeduction, Ppoint.Y + outer_line + (client_ht - (outer_line * 2)) - w);
                    //PointF outerLine5 = new PointF(Ppoint.X + outer_line - innerLineDeduction + w + tenPercentAdditional, Ppoint.Y + outer_line + (client_ht - (outer_line * 2)) - w);
                    PointF outerLine5 = new PointF(Ppoint.X, Ppoint.Y + outer_line + (client_ht - (outer_line * 2)) - w);
                    PointF outerLine6 = new PointF(Ppoint.X + outer_line - innerLineDeduction + (client_wd - (outer_line * 2)) - w + innerLineDeduction, Ppoint.Y + outer_line + (client_ht - (outer_line * 2)) - w);
                    e.Graphics.DrawLine(new Pen(outerColor, 1), outerLine1, outerLine2);
                    e.Graphics.DrawLine(new Pen(outerColor, 1), outerLine3, outerLine4);
                    e.Graphics.DrawLine(new Pen(outerColor, 1), outerLine5, outerLine6);
                    if (panelModel.Panel_Type != "Fixed Panel" || (panelModel.Panel_Type == "Fixed Panel" && panelModel.Panel_Orient == true))
                    {
                        //inner Line 
                        //PointF innerLine1 = new PointF(Ppoint.X + inner_line - outerLineDeduction + w + tenPercentAdditional, Ppoint.Y + inner_line);
                        PointF innerLine1 = new PointF(Ppoint.X, Ppoint.Y + inner_line);
                        PointF innerLine2 = new PointF(Ppoint.X + inner_line - outerLineDeduction + (client_wd - (inner_line * 2)) - w + outerLineDeduction, Ppoint.Y + inner_line);
                        PointF innerLine3 = new PointF(Ppoint.X + inner_line - outerLineDeduction + (client_wd - (inner_line * 2)) - w + outerLineDeduction, Ppoint.Y + inner_line);
                        PointF innerLine4 = new PointF(Ppoint.X + inner_line - outerLineDeduction + (client_wd - (inner_line * 2)) - w + outerLineDeduction, Ppoint.Y + inner_line + (client_ht - (inner_line * 2)) - w);
                        //PointF innerLine5 = new PointF(Ppoint.X + inner_line - outerLineDeduction + w + tenPercentAdditional, Ppoint.Y + inner_line + (client_ht - (inner_line * 2)) - w);
                        PointF innerLine5 = new PointF(Ppoint.X, Ppoint.Y + inner_line + (client_ht - (inner_line * 2)) - w);
                        PointF innerLine6 = new PointF(Ppoint.X + inner_line - outerLineDeduction + (client_wd - (inner_line * 2)) - w + outerLineDeduction, Ppoint.Y + inner_line + (client_ht - (inner_line * 2)) - w);
                        e.Graphics.DrawLine(new Pen(Color.Black, 3), innerLine1, innerLine2);
                        e.Graphics.DrawLine(new Pen(Color.Black, 3), innerLine3, innerLine4);
                        e.Graphics.DrawLine(new Pen(Color.Black, 3), innerLine5, innerLine6);
                    }
                    arrowStartingX -= inner_line;
                    sashOverlapValue += inner_line;
                }
                else if (panelModel.Panel_Overlap_Sash == OverlapSash._Both)
                {
                    //outer Line
                    //PointF outerLine1 = new PointF(Ppoint.X + outer_line - innerLineDeduction + w + tenPercentAdditional, Ppoint.Y + outer_line);
                    PointF outerLine1 = new PointF(Ppoint.X, Ppoint.Y + outer_line);
                    PointF outerLine2 = new PointF(Ppoint.X + client_wd - w, Ppoint.Y + outer_line);
                    PointF outerLine3 = new PointF(Ppoint.X, Ppoint.Y + outer_line + (client_ht - (outer_line * 2)) - w);
                    PointF outerLine4 = new PointF(Ppoint.X + client_wd - w, Ppoint.Y + outer_line + (client_ht - (outer_line * 2)) - w);
                    e.Graphics.DrawLine(new Pen(outerColor, 1), outerLine1, outerLine2);
                    e.Graphics.DrawLine(new Pen(outerColor, 1), outerLine3, outerLine4);

                    if (panelModel.Panel_Type != "Fixed Panel" || (panelModel.Panel_Type == "Fixed Panel" && panelModel.Panel_Orient == true))
                    {
                        //inner Line
                        //PointF innerLine1 = new PointF(Ppoint.X + inner_line - outerLineDeduction + w + tenPercentAdditional, Ppoint.Y + inner_line);
                        PointF innerLine1 = new PointF(Ppoint.X, Ppoint.Y + inner_line);
                        PointF innerLine2 = new PointF(Ppoint.X + client_wd - w, Ppoint.Y + inner_line);
                        PointF innerLine4 = new PointF(Ppoint.X, Ppoint.Y + inner_line + (client_ht - (inner_line * 2)) - w);
                        PointF innerLine5 = new PointF(Ppoint.X + client_wd - w, Ppoint.Y + inner_line + (client_ht - (inner_line * 2)) - w);
                        e.Graphics.DrawLine(new Pen(Color.Black, 3), innerLine1, innerLine2);
                        e.Graphics.DrawLine(new Pen(Color.Black, 3), innerLine4, innerLine5);
                    }
                    arrowStartingX -= inner_line;
                    sashOverlapValue += inner_line + (inner_line / 2);
                }
                else if (panelModel.Panel_Overlap_Sash == OverlapSash._None)
                {
                    //outer Line
                    g.DrawRectangle(new Pen(outerColor, 1), new Rectangle(Ppoint.X + outer_line,
                                                                      Ppoint.Y + outer_line,
                                                                      (client_wd - (outer_line * 2)) - w,
                                                                      (client_ht - (outer_line * 2)) - w));

                    if (panelModel.Panel_Type != "Fixed Panel" || (panelModel.Panel_Type == "Fixed Panel" && panelModel.Panel_Orient == true))
                    {
                        //inner Line
                        g.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(Ppoint.X + inner_line,
                                                                      Ppoint.Y + inner_line,
                                                                      (client_wd - (inner_line * 2)) - w,
                                                                      (client_ht - (inner_line * 2)) - w));
                    }
                }
            }


            StringFormat drawFormat = new StringFormat();
            int pnl_ID = 0;
            string pnl_ThicknessDesc = "";
            IDictionary<int, string> lst_glassThickness = new Dictionary<int, string>();
            foreach (IFrameModel frm in _windoorModel.lst_frame)
            {
                foreach (IMultiPanelModel mpnl in frm.Lst_MultiPanel)
                {
                    foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                    {
                        if (panelModel.Panel_GlassThicknessDesc != null)
                        {
                            if (pnl.Panel_GlassFilm.ToString() != "None")
                            {
                                string glassDesc = pnl.Panel_GlassThicknessDesc + " with " + pnl.Panel_GlassFilm.ToString();
                                lst_glassThickness.Add(pnl.Panel_ID, glassDesc);
                                if (pnl == panelModel)
                                {
                                    pnl_ID = pnl.Panel_ID;
                                    pnl_ThicknessDesc = glassDesc;
                                }
                            }
                            else
                            {
                                string glassDesc = pnl.Panel_GlassThicknessDesc;
                                lst_glassThickness.Add(pnl.Panel_ID, glassDesc);
                                if (pnl == panelModel)
                                {
                                    pnl_ID = pnl.Panel_ID;
                                    pnl_ThicknessDesc = glassDesc;
                                }
                            }
                        }
                    }
                }
                foreach (IPanelModel pnl in frm.Lst_Panel)
                {
                    if (panelModel.Panel_GlassThicknessDesc != null)
                    {
                        if (pnl.Panel_GlassFilm.ToString() != "None")
                        {
                            string glassDesc = pnl.Panel_GlassThicknessDesc + " with " + pnl.Panel_GlassFilm.ToString();
                            lst_glassThickness.Add(pnl.Panel_ID, glassDesc);
                            if (pnl == panelModel)
                            {
                                pnl_ID = pnl.Panel_ID;
                                pnl_ThicknessDesc = glassDesc;
                            }
                        }
                        else
                        {
                            string glassDesc = pnl.Panel_GlassThicknessDesc;
                            lst_glassThickness.Add(pnl.Panel_ID, glassDesc);
                            if (pnl == panelModel)
                            {
                                pnl_ID = pnl.Panel_ID;
                                pnl_ThicknessDesc = glassDesc;
                            }
                        }
                    }
                }
            }
            List<string> lst_glassThicknessDistinct = new List<string>();
            foreach (var value in lst_glassThickness.Values)
            {
                lst_glassThicknessDistinct.Add(value);
            }
            IDictionary<string, string> GlassNumberList = new Dictionary<string, string>();
            lst_glassThicknessDistinct = lst_glassThicknessDistinct.Distinct().ToList();
            if (lst_glassThicknessDistinct.Count > 1)
            {
                for (int i = 0; i < lst_glassThicknessDistinct.Count; i++)
                {
                    GlassNumberList.Add("G" + (i + 1).ToString(), lst_glassThicknessDistinct[i]);
                }

                //lst_glassThicknessPerItem.Add(glassThick);
            }

            foreach (KeyValuePair<string, string> entry in GlassNumberList)
            {
                if (pnl_ThicknessDesc == entry.Value)
                {
                    Brush the_brush = new SolidBrush(Color.FromArgb(219, 80, 80));
                    int LocY = Ppoint.Y;
                    if (font_size + 10 < client_ht)
                    {
                        if (panelModel.Panel_Type == "Awning Panel" || panelModel.Panel_Type == "Casement Panel")
                        {
                            LocY = Ppoint.Y + (client_ht / 2) - font_size + 10;
                        }
                        else
                        {
                            LocY = Ppoint.Y + (client_ht / 2) + (int)(client_ht * 0.1) - 15;

                        }
                    }
                    Font gdrawFont = new Font("Times New Roman", font_size);
                    RectangleF glassrect = new RectangleF(Ppoint.X + (client_wd / 2) - font_size,
                                                         LocY,
                                                         client_wd + 100,
                                                         font_size + 10);
                    g.DrawString(entry.Key,
                                 gdrawFont,
                                 the_brush,
                                 glassrect,
                                 drawFormat);
                    break;

                }
            }
            if (panelModel.Panel_Type == "Fixed Panel")
            {


                Font drawFont = new Font("Times New Roman", font_size);// * zoom);

                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString("F", drawFont, new SolidBrush(Color.Black), panel_bounds, drawFormat);



            }
            else if (panelModel.Panel_Type == "Casement Panel")
            {


                Point sashPoint = new Point(Ppoint.X, Ppoint.Y);

                //Pen dgrayPen = new Pen(Color.DimGray);
                Pen dgrayPen = new Pen(Color.FromArgb(219, 80, 80));
                dgrayPen.DashStyle = DashStyle.Dash;
                dgrayPen.Width = 3;

                int sashW = client_wd,
                    sashH = client_ht;

                if (panelModel.Panel_Orient == true)//Left
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW + sashOverlapValue), sashPoint.Y),
                                             new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))),
                                         new Point(sashPoint.X + (sashW + sashOverlapValue), sashPoint.Y + sashH));
                }
                else if (panelModel.Panel_Orient == false)//Right
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                         new Point(sashPoint.X + (sashW + sashOverlapValue), (sashPoint.Y + (sashH / 2))));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW + sashOverlapValue), (sashPoint.Y + (sashH / 2))),
                                         new Point(sashPoint.X, sashH + sashPoint.Y));
                }
            }
            else if (panelModel.Panel_Type == "Awning Panel")
            {


                Point sashPoint = new Point(Ppoint.X, Ppoint.Y);

                //Pen dgrayPen = new Pen(Color.DimGray);
                Pen dgrayPen = new Pen(Color.FromArgb(219, 80, 80));
                dgrayPen.DashStyle = DashStyle.Dash;
                dgrayPen.Width = 3;

                int sashW = client_wd,
                    sashH = client_ht;

                if (panelModel.Panel_Orient == true)
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                         new Point(sashPoint.X + ((sashW + sashOverlapValue) / 2), sashPoint.Y + sashH));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + ((sashW + sashOverlapValue) / 2), sashPoint.Y + sashH),
                                         new Point(sashPoint.X + (sashW + sashOverlapValue), sashPoint.Y));
                }
                else if (panelModel.Panel_Orient == false)
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y + sashH),
                                     new Point(sashPoint.X + ((sashW + sashOverlapValue) / 2), sashPoint.Y));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + ((sashW + sashOverlapValue) / 2), sashPoint.Y),
                                         new Point(sashPoint.X + (sashW + sashOverlapValue), sashH + sashPoint.Y));
                }
            }
            else if (panelModel.Panel_Type == "Sliding Panel")
            {
                Point sashPoint = new Point(Ppoint.X + 25, Ppoint.Y);
                int sashW = client_wd,
                    sashH = client_ht;
                if (panelModel.Panel_Orient == false)
                {

                    if (panelModel.Panel_SlidingTypes == SlidingTypes._Premiline ||
                  panelModel.Panel_SlidingTypes == SlidingTypes._FoldAndSlide ||
                  panelModel.Panel_SlidingTypes == SlidingTypes._Pivot ||
                  panelModel.Panel_SlidingTypes == SlidingTypes._TopHung)
                    {
                        //sliding
                        if ((sashW + sashOverlapValue) >= sashH)
                        {

                            ArrowExpectedWidth = (float)(sashH * 0.2);
                            ArrowExpectedHeight = (float)(sashH * 0.3);
                            //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX + Ppoint.X, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                        }
                        else if ((sashW + sashOverlapValue) < sashH)
                        {
                            ArrowExpectedWidth = (float)((sashW + sashOverlapValue) * 0.2);
                            ArrowExpectedHeight = (float)((sashW + sashOverlapValue) * 0.3);

                            //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX + Ppoint.X, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                        }
                        arrowStartingX += ((sashW + sashOverlapValue) / 2) - (ArrowExpectedWidth / 2);
                        arrowStartingY = (sashH / 2) - (ArrowExpectedHeight / 2);
                        PointF sliding1 = new PointF(arrowStartingX + Ppoint.X, Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                        PointF sliding2 = new PointF(arrowStartingX + Ppoint.X, Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                        PointF sliding3 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.7), Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                        PointF sliding4 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.7), Ppoint.Y + ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.2));
                        PointF sliding5 = new PointF(arrowStartingX + Ppoint.X + ArrowExpectedWidth, Ppoint.Y + (ArrowExpectedHeight / 2) + arrowStartingY);
                        PointF sliding6 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.7), Ppoint.Y + arrowStartingY + (float)(ArrowExpectedHeight * 0.2));
                        PointF sliding7 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.7), Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                        PointF[] slidingCurvePoints = { sliding1, sliding2, sliding3, sliding4, sliding5, sliding6, sliding7 };

                        g.FillPolygon(new SolidBrush(Color.Black), slidingCurvePoints);
                    }
                    else if (panelModel.Panel_SlidingTypes == SlidingTypes._Paraslide)
                    {
                        //paraslide
                        if ((sashW + sashOverlapValue) >= sashH)
                        {

                            ArrowExpectedWidth = (float)(sashH * 0.3);
                            ArrowExpectedHeight = (float)(sashH * 0.3);
                            //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX + Ppoint.X, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                        }
                        else if ((sashW + sashOverlapValue) < sashH)
                        {
                            ArrowExpectedWidth = (float)((sashW + sashOverlapValue) * 0.3);
                            ArrowExpectedHeight = (float)((sashW + sashOverlapValue) * 0.3);
                            //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX + Ppoint.X, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                        }
                        arrowStartingX += ((sashW + sashOverlapValue) / 2) - (ArrowExpectedWidth / 2);
                        arrowStartingY = (sashH / 2) - (ArrowExpectedHeight / 2);
                        PointF paraslide1 = new PointF(arrowStartingX + Ppoint.X, Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.3));
                        PointF paraslide2 = new PointF(arrowStartingX + Ppoint.X, Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                        PointF paraslide3 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.8), Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                        PointF paraslide4 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.8), Ppoint.Y + ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.2));
                        PointF paraslide5 = new PointF(arrowStartingX + Ppoint.X + ArrowExpectedWidth, Ppoint.Y + (ArrowExpectedHeight / 2) + arrowStartingY);
                        PointF paraslide6 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.8), Ppoint.Y + arrowStartingY + (float)(ArrowExpectedHeight * 0.2));
                        PointF paraslide7 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.8), Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                        PointF paraslide8 = new PointF(paraslide1.X + (paraslide3.Y - paraslide7.Y), paraslide7.Y);
                        PointF paraslide9 = new PointF(paraslide1.X + (paraslide3.Y - paraslide7.Y), paraslide1.Y);
                        PointF[] paraslideCurvePoints = { paraslide1, paraslide2, paraslide3, paraslide4, paraslide5, paraslide6, paraslide7, paraslide8, paraslide9 };
                        g.FillPolygon(new SolidBrush(Color.Black), paraslideCurvePoints);

                    }
                    else if (panelModel.Panel_SlidingTypes == SlidingTypes._LiftAndSlide)
                    {
                        //LiftAndSlide
                        if ((sashW + sashOverlapValue) >= sashH)
                        {

                            ArrowExpectedWidth = (float)(sashH * 0.3);
                            ArrowExpectedHeight = (float)(sashH * 0.3);
                            //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX + Ppoint.X, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                        }
                        else if ((sashW + sashOverlapValue) < sashH)
                        {
                            ArrowExpectedWidth = (float)((sashW + sashOverlapValue) * 0.3);
                            ArrowExpectedHeight = (float)((sashW + sashOverlapValue) * 0.3);
                            //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX + Ppoint.X, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                        }
                        arrowStartingX += ((sashW + sashOverlapValue) / 2) - (ArrowExpectedWidth / 2);
                        arrowStartingY = (sashH / 2) - (ArrowExpectedHeight / 2);
                        PointF liftandslide1 = new PointF(arrowStartingX + Ppoint.X, Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                        PointF liftandslide2 = new PointF(arrowStartingX + Ppoint.X, Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.3));
                        PointF liftandslide3 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.8), Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                        PointF liftandslide4 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.8), Ppoint.Y + ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.2));
                        PointF liftandslide5 = new PointF(arrowStartingX + Ppoint.X + ArrowExpectedWidth, Ppoint.Y + (ArrowExpectedHeight / 2) + arrowStartingY);
                        PointF liftandslide6 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.8), Ppoint.Y + arrowStartingY + (float)(ArrowExpectedHeight * 0.2));
                        PointF liftandslide7 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.8), Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                        PointF liftandslide8 = new PointF(liftandslide1.X + (liftandslide3.Y - liftandslide7.Y), liftandslide3.Y);
                        PointF liftandslide9 = new PointF(liftandslide1.X + (liftandslide3.Y - liftandslide7.Y), liftandslide2.Y);
                        PointF[] paraslideCurvePoints = { liftandslide1, liftandslide2, liftandslide9, liftandslide8, liftandslide3, liftandslide4, liftandslide5, liftandslide6, liftandslide7 };
                        g.FillPolygon(new SolidBrush(Color.Black), paraslideCurvePoints);
                    }
                }
                else if (panelModel.Panel_Orient == true)
                {


                    if (panelModel.Panel_SlidingTypes == SlidingTypes._Premiline ||
                        panelModel.Panel_SlidingTypes == SlidingTypes._FoldAndSlide ||
                        panelModel.Panel_SlidingTypes == SlidingTypes._Pivot ||
                        panelModel.Panel_SlidingTypes == SlidingTypes._TopHung)
                    {
                        //sliding
                        if ((sashW + sashOverlapValue) >= sashH)
                        {

                            ArrowExpectedWidth = (float)(sashH * 0.2);
                            ArrowExpectedHeight = (float)(sashH * 0.3);
                            //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX + Ppoint.X, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                        }
                        else if ((sashW + sashOverlapValue) < sashH)
                        {
                            ArrowExpectedWidth = (float)((sashW + sashOverlapValue) * 0.2);
                            ArrowExpectedHeight = (float)((sashW + sashOverlapValue) * 0.3);
                            //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX + Ppoint.X, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                        }

                        arrowStartingX += ((sashW + sashOverlapValue) / 2) - (ArrowExpectedWidth / 2);
                        arrowStartingY = (sashH / 2) - (ArrowExpectedHeight / 2);
                        PointF sliding1 = new PointF(arrowStartingX + Ppoint.X + ArrowExpectedWidth, Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                        PointF sliding2 = new PointF(arrowStartingX + Ppoint.X + ArrowExpectedWidth, Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                        PointF sliding3 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.3), Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                        PointF sliding4 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.3), Ppoint.Y + ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.2));
                        PointF sliding5 = new PointF(arrowStartingX + Ppoint.X, Ppoint.Y + (ArrowExpectedHeight / 2) + arrowStartingY);
                        PointF sliding6 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.3), Ppoint.Y + arrowStartingY + (float)(ArrowExpectedHeight * 0.2));
                        PointF sliding7 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.3), Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                        PointF[] slidingCurvePoints = { sliding1, sliding2, sliding3, sliding4, sliding5, sliding6, sliding7 };

                        g.FillPolygon(new SolidBrush(Color.Black), slidingCurvePoints);
                    }
                    else if (panelModel.Panel_SlidingTypes == SlidingTypes._Paraslide)
                    {
                        //paraslide
                        if ((sashW + sashOverlapValue) >= sashH)
                        {

                            ArrowExpectedWidth = (float)(sashH * 0.3);
                            ArrowExpectedHeight = (float)(sashH * 0.3);
                            //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX + Ppoint.X, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                        }
                        else if ((sashW + sashOverlapValue) < sashH)
                        {
                            ArrowExpectedWidth = (float)((sashW + sashOverlapValue) * 0.3);
                            ArrowExpectedHeight = (float)((sashW + sashOverlapValue) * 0.3);
                            //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX + Ppoint.X, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                        }
                        arrowStartingX += ((sashW + sashOverlapValue) / 2) - (ArrowExpectedWidth / 2);
                        arrowStartingY = (sashH / 2) - (ArrowExpectedHeight / 2);
                        PointF paraslide1 = new PointF(arrowStartingX + Ppoint.X + ArrowExpectedWidth, Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.3));
                        PointF paraslide2 = new PointF(arrowStartingX + Ppoint.X + ArrowExpectedWidth, Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                        PointF paraslide3 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.2), Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                        PointF paraslide4 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.2), Ppoint.Y + ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.2));
                        PointF paraslide5 = new PointF(arrowStartingX + Ppoint.X, Ppoint.Y + (ArrowExpectedHeight / 2) + arrowStartingY);
                        PointF paraslide6 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.2), Ppoint.Y + arrowStartingY + (float)(ArrowExpectedHeight * 0.2));
                        PointF paraslide7 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.2), Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                        PointF paraslide8 = new PointF(paraslide1.X - (paraslide3.Y - paraslide7.Y), paraslide7.Y);
                        PointF paraslide9 = new PointF(paraslide1.X - (paraslide3.Y - paraslide7.Y), paraslide1.Y);
                        PointF[] paraslideCurvePoints = { paraslide1, paraslide2, paraslide3, paraslide4, paraslide5, paraslide6, paraslide7, paraslide8, paraslide9 };
                        g.FillPolygon(new SolidBrush(Color.Black), paraslideCurvePoints);

                    }
                    else if (panelModel.Panel_SlidingTypes == SlidingTypes._LiftAndSlide)
                    {
                        //LiftAndSlide
                        if ((sashW + sashOverlapValue) >= sashH)
                        {

                            ArrowExpectedWidth = (float)(sashH * 0.3);
                            ArrowExpectedHeight = (float)(sashH * 0.3);
                            //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX + Ppoint.X, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                        }
                        else if ((sashW + sashOverlapValue) < sashH)
                        {
                            ArrowExpectedWidth = (float)((sashW + sashOverlapValue) * 0.3);
                            ArrowExpectedHeight = (float)((sashW + sashOverlapValue) * 0.3);
                            //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX + Ppoint.X, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                        }
                        arrowStartingX += ((sashW + sashOverlapValue) / 2) - (ArrowExpectedWidth / 2);
                        arrowStartingY = (sashH / 2) - (ArrowExpectedHeight / 2);
                        PointF liftandslide1 = new PointF(arrowStartingX + Ppoint.X + ArrowExpectedWidth, Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                        PointF liftandslide2 = new PointF(arrowStartingX + Ppoint.X + ArrowExpectedWidth, Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.3));
                        PointF liftandslide3 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.2), Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                        PointF liftandslide4 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.2), Ppoint.Y + ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.2));
                        PointF liftandslide5 = new PointF(arrowStartingX + Ppoint.X, Ppoint.Y + (ArrowExpectedHeight / 2) + arrowStartingY);
                        PointF liftandslide6 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.2), Ppoint.Y + arrowStartingY + (float)(ArrowExpectedHeight * 0.2));
                        PointF liftandslide7 = new PointF(arrowStartingX + Ppoint.X + (float)(ArrowExpectedWidth * 0.2), Ppoint.Y + arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                        PointF liftandslide8 = new PointF(liftandslide1.X - (liftandslide3.Y - liftandslide7.Y), liftandslide3.Y);
                        PointF liftandslide9 = new PointF(liftandslide1.X - (liftandslide3.Y - liftandslide7.Y), liftandslide2.Y);
                        PointF[] paraslideCurvePoints = { liftandslide1, liftandslide2, liftandslide9, liftandslide8, liftandslide3, liftandslide4, liftandslide5, liftandslide6, liftandslide7 };
                        g.FillPolygon(new SolidBrush(Color.Black), paraslideCurvePoints);
                    }

                }


            }


            else if (panelModel.Panel_Type == "TiltNTurn Panel")
            {
                g.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(Ppoint.X + inner_line,
                                                                       Ppoint.Y + inner_line,
                                                                       (client_wd - (inner_line * 2)) - w,
                                                                       (client_ht - (inner_line * 2)) - w));

                Point sashPoint = new Point(Ppoint.X, Ppoint.Y);

                //Pen dgrayPen = new Pen(Color.DimGray);
                Pen dgrayPen = new Pen(Color.FromArgb(219, 80, 80));
                dgrayPen.DashStyle = DashStyle.Dash;
                dgrayPen.Width = 3;

                int sashW = client_wd,
                    sashH = client_ht;

                g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                     new Point(sashPoint.X + ((sashW + sashOverlapValue) / 2), sashPoint.Y + sashH));
                g.DrawLine(dgrayPen, new Point(sashPoint.X + ((sashW + sashOverlapValue) / 2), sashPoint.Y + sashH),
                                     new Point(sashPoint.X + (sashW + sashOverlapValue), sashPoint.Y));

                if (panelModel.Panel_Orient == true)//Left
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW + sashOverlapValue), sashPoint.Y),
                                             new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))),
                                         new Point(sashPoint.X + (sashW + sashOverlapValue), sashPoint.Y + sashH));
                }
                else if (panelModel.Panel_Orient == false)//Right
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                         new Point(sashPoint.X + (sashW + sashOverlapValue), (sashPoint.Y + (sashH / 2))));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW + sashOverlapValue), (sashPoint.Y + (sashH / 2))),
                                         new Point(sashPoint.X, sashH + sashPoint.Y));
                }
            }
            else if (panelModel.Panel_Type == "Louver Panel")
            {
                //Pen p = new Pen(Color.Black);
                //Pen LvrPen = new Pen(Color.Black, 7);
                //Pen LvrPen2 = new Pen(Color.White, 5);
                //// jelusi

                //int Lvr_NewLocation = 0,
                //    Lvr_Gap = 0,
                //    pInnerY = Ppoint.Y,
                //    pInnerX = Ppoint.X,
                //    pInnerHt = client_ht,
                //    pInnerWd = client_wd,
                //    NoOfBlades = panelModel.Panel_LouverBladesCount;
                //double Lvr_GlassHt = 0;

                //float Ht_Allowance = 20 * _windoorModel.WD_zoom_forImageRenderer;

                ////side blade
                //for (int ii = 0; ii < panelModel.Panel_LouverBladesCount; ii++)
                //{
                //    Lvr_GlassHt = (((pInnerHt - (((int)NoOfBlades))) / (int)NoOfBlades) / 2) + (int)NoOfBlades;//33 + (33 * 0.75);
                //    Lvr_NewLocation = ((pInnerY + (int)Ht_Allowance) + Lvr_Gap) + (int)Lvr_GlassHt;
                //    Lvr_Gap += (pInnerHt - (int)Lvr_GlassHt) / ((int)NoOfBlades);

                //    Point[] LvrSideBlade =
                //     {
                //        new Point((pInnerX - 7) + pInnerWd - 2, Lvr_NewLocation-(int)Lvr_GlassHt),
                //        new Point((pInnerX - 7) + pInnerWd + 4, Lvr_NewLocation+(int)Lvr_GlassHt),

                //        new Point(pInnerX-2, Lvr_NewLocation-(int)Lvr_GlassHt),
                //        new Point(pInnerX+4, Lvr_NewLocation+(int)Lvr_GlassHt),

                //        new Point(pInnerX-4, Lvr_NewLocation-(int)Lvr_GlassHt-1),
                //        new Point(pInnerX-4, Lvr_NewLocation+(int)Lvr_GlassHt+1)
                //     };

                //    for (int i = 0; i < LvrSideBlade.Length; i += 2)
                //    {
                //        if (i == 4)
                //        {
                //            g.DrawLine(LvrPen2, LvrSideBlade[i], LvrSideBlade[i + 1]);
                //        }
                //        else
                //        {
                //            g.DrawLine(LvrPen, LvrSideBlade[i], LvrSideBlade[i + 1]);
                //        }
                //    }

                //    //blade
                //    Point[] blade =
                //    {
                //        new Point(pInnerX, Lvr_NewLocation - (int)Lvr_GlassHt),
                //        new Point((int)client_wd + pInnerX - 7, Lvr_NewLocation - (int)Lvr_GlassHt),
                //        new Point((int)client_wd + pInnerX, Lvr_NewLocation + (int)Lvr_GlassHt), // - 26 para mag slant yung blade
                //        new Point(pInnerX , Lvr_NewLocation + (int)Lvr_GlassHt)
                //    };
                //    for (int i = 0; i < blade.Length; i += 2)
                //    {
                //        g.DrawLine(p, blade[i], blade[i + 1]);
                //    }
                //}
                Pen p = new Pen(Color.Black);
                Pen LvrPen = new Pen(Color.Black, 7);
                Pen LvrPen2 = new Pen(Color.White, 5);
                // jelusi

                int Lvr_NewLocation = 0,
                    Lvr_Gap = 0,
                    pInnerY = Ppoint.Y,
                    pInnerX = Ppoint.X,
                    pInnerHt = client_ht,
                    pInnerWd = client_wd,
                    NoOfBlades = panelModel.Panel_LouverBladesCount;

                float Ht_Allowance = 20 * _windoorModel.WD_zoom_forImageRenderer;
                double Lvr_GlassHt = 0, Total_Lvr_GlassHt = (int)(Ht_Allowance / 2);
                pInnerHt -= (int)Ht_Allowance;
                double ht_allowance_deci = 0.0, Lvr_GlassHt_deci = 0.0;
                //side blade
                IDictionary<Point[], Point[]> lvrBlade = new Dictionary<Point[], Point[]>();
                for (int ii = 0; ii < panelModel.Panel_LouverBladesCount; ii++)
                {
                    Lvr_GlassHt = (double)pInnerHt / NoOfBlades;
                    Total_Lvr_GlassHt += Lvr_GlassHt;
                    Lvr_NewLocation = ((pInnerY + (int)Ht_Allowance) + Lvr_Gap) + (int)Total_Lvr_GlassHt;
                    //Lvr_Gap += (pInnerHt - (int)Lvr_GlassHt) / ((int)NoOfBlades);
                    int New_Lvr_GlassHt_Location = (int)Lvr_GlassHt;
                    ht_allowance_deci += (double)(Ht_Allowance - Math.Truncate(Ht_Allowance));
                    Lvr_GlassHt_deci += (Lvr_GlassHt - Math.Truncate(Lvr_GlassHt));
                    if ((Lvr_GlassHt + (int)(Ht_Allowance / 2)) != Total_Lvr_GlassHt)
                    {
                        New_Lvr_GlassHt_Location = (int)Total_Lvr_GlassHt - ((int)Lvr_GlassHt * ii) - (int)(Ht_Allowance / 2);
                    }
                    Point[] LvrSideBlade =
                     {
                        new Point((pInnerX - 7) + pInnerWd - 2, Lvr_NewLocation-(int)New_Lvr_GlassHt_Location),
                        new Point((pInnerX - 7) + pInnerWd + 4, (int)Total_Lvr_GlassHt + pInnerY),

                        new Point(pInnerX-2, Lvr_NewLocation-(int)Lvr_GlassHt),
                        new Point(pInnerX+4, (int)Total_Lvr_GlassHt + pInnerY),

                        new Point(pInnerX-4, Lvr_NewLocation-(int)New_Lvr_GlassHt_Location-1),
                        new Point(pInnerX-4, Lvr_NewLocation+(int)Lvr_GlassHt+1 + pInnerY )
                     };
                    Point[] blade =
                    {
                        new Point(pInnerX, Lvr_NewLocation - (int)Lvr_GlassHt),
                        new Point((int)client_wd + pInnerX - 7, Lvr_NewLocation - (int)Lvr_GlassHt),
                        new Point((int)client_wd + pInnerX, (int)Total_Lvr_GlassHt+ pInnerY), // - 26 para mag slant yung blade
                        new Point(pInnerX , (int)Total_Lvr_GlassHt + pInnerY)
                    };
                    lvrBlade.Add(LvrSideBlade, blade);
                }



                for (int ii = 0; ii < panelModel.Panel_LouverBladesCount; ii++)
                {
                    IList<Point> lstPtsSide = new List<Point>();
                    foreach (Point pnts in lvrBlade.ElementAt(ii).Key)
                    {
                        lstPtsSide.Add(new Point(pnts.X, pnts.Y + (int)(Lvr_GlassHt_deci / 2) + (int)((ht_allowance_deci * _windoorModel.WD_zoom_forImageRenderer) / 2)));
                    }

                    IList<Point> lstPtsblade = new List<Point>();
                    foreach (Point pnts in lvrBlade.ElementAt(ii).Value)
                    {
                        lstPtsblade.Add(new Point(pnts.X, pnts.Y + (int)(Lvr_GlassHt_deci / 2) + (int)((ht_allowance_deci * _windoorModel.WD_zoom_forImageRenderer) / 2)));
                    }
                    for (int i = 0; i < lvrBlade.ElementAt(ii).Key.Length; i += 2)
                    {
                        if (i == 4)
                        {
                            g.DrawLine(LvrPen2, lstPtsSide[i], lstPtsSide[i + 1]);
                        }
                        else
                        {
                            g.DrawLine(LvrPen, lstPtsSide[i], lstPtsSide[i + 1]);
                        }
                    }

                    for (int i = 0; i < lvrBlade.ElementAt(ii).Value.Length; i += 2)
                    {
                        g.DrawLine(p, lstPtsblade[i], lstPtsblade[i + 1]);
                    }

                }
            }
        }
        private void Draw_MultiPanel(PaintEventArgs e, IMultiPanelModel mpanelModel, Point Mpoint, int botPadHeightDeduct)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float zoom = mpanelModel.MPanelImageRenderer_Zoom;

            int client_wd = mpanelModel.MPanelImageRenderer_Width,
                client_ht = mpanelModel.MPanelImageRenderer_Height - botPadHeightDeduct;

            Rectangle mpnl_bounds = new Rectangle(Mpoint, new Size(client_wd, client_ht));
            //SolidBrush mpnl_sBrush = new SolidBrush(Color.MistyRose);
            SolidBrush mpnl_sBrush = new SolidBrush(Color.White);
            if (mpanelModel.MPanel_Type == "Mullion")
            {
                //mpnl_sBrush = new SolidBrush(Color.White);
                mpnl_sBrush = new SolidBrush(Color.MistyRose);
            }
            else if (mpanelModel.MPanel_Type == "Transom")
            {
                // mpnl_sBrush = new SolidBrush(Color.White);
                mpnl_sBrush = new SolidBrush(Color.LightSteelBlue);
            }

            g.FillRectangle(mpnl_sBrush, mpnl_bounds);
            g.DrawRectangle(new Pen(Color.Black, 1), mpnl_bounds);
        }
        private void Draw_Divider(PaintEventArgs e, IDividerModel divModel, Point Dpoint, int botPadDivDeduct)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.HighQuality;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            IMultiPanelModel parent_mpnl = divModel.Div_MPanelParent;

            int client_wd = divModel.DivImageRenderer_Width,
                client_ht = divModel.DivImageRenderer_Height - botPadDivDeduct;

            Rectangle div_rect = new Rectangle(Dpoint.X,
                                               Dpoint.Y,
                                               client_wd - w,
                                               client_ht - w);

            //SolidBrush div_sBrush = new SolidBrush(Color.RosyBrown);
            SolidBrush div_sBrush = new SolidBrush(Color.White);
            if (divModel.Div_Type == DividerModel.DividerType.Mullion)
            {
                //div_sBrush = new SolidBrush(Color.RosyBrown);
                div_sBrush = new SolidBrush(Color.White);
            }
            else if (divModel.Div_Type == DividerModel.DividerType.Transom)
            {
                //div_sBrush = new SolidBrush(Color.PowderBlue);
                div_sBrush = new SolidBrush(Color.White);
            }
            g.FillRectangle(div_sBrush, div_rect);
            g.DrawRectangle(new Pen(Color.Black, w), div_rect);
        }
        public IBasePlatformImagerUC GetBasePlatformImagerUC()
        {
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
        public void SetWdFlpImage()
        {
            Bitmap bbm = new Bitmap(_flpMain.Size.Width, _flpMain.Size.Height);
            _flpMain.DrawToBitmap(bbm, new Rectangle(0, 0, _flpMain.Size.Width, _flpMain.Size.Height));

            _windoorModel.WD_flpImage = bbm;
        }
    }
}
