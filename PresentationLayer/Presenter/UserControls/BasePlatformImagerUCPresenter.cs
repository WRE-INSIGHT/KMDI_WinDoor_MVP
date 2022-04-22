using CommonComponents;
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
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class BasePlatformImagerUCPresenter : IBasePlatformImagerUCPresenter, IPresenterCommon
    {
        IBasePlatformImagerUC _basePlatformImagerUC;
        FlowLayoutPanel _flpMain;

        IWindoorModel _windoorModel;
        IMainPresenter _mainPresenter;

        CommonFunctions _commonfunc = new CommonFunctions();

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
            List<Point> frame_points = new List<Point>();
            List<int> curr_LocY = new List<int>();

            int flocX = 0, flocY = 0, total_wd_covered = 0, total_ht_covered = 0, frame_row = 0;

            foreach (Size frame_size in frameImager_sizes)
            {
                frame_points.Add(new Point(flocX, flocY));
                total_wd_covered += frame_size.Width;

                if (curr_LocY.Count() == 0)
                {
                    curr_LocY.Add(0);
                }

                if (total_wd_covered < basePlatformImage_Width_minus70)
                {
                    flocX += frame_size.Width;
                    flocY = curr_LocY[frame_row];
                }
                else if (total_wd_covered >= basePlatformImage_Width_minus70)
                {
                    total_ht_covered += frame_size.Height;
                    curr_LocY.Add(total_ht_covered);
                    frame_row++;

                    flocX = 0;
                    flocY = curr_LocY[frame_row];
                    total_wd_covered = 0;
                }
            }

            return frame_points;
        }

        public Point Panel_MPanel_DrawPoints_ParentIsFrame(Point framePoint, int frame_topPad, int frame_leftPad)
        {
            return new Point(framePoint.X + frame_leftPad, framePoint.Y + frame_topPad);
        }

        private void _basePlatformImagerUC_flpFrameDragDropPaintEventRaised(object sender, PaintEventArgs e)
        {
            try
            {
                FlowLayoutPanel fpnl = (FlowLayoutPanel)sender;
                Graphics g = e.Graphics;

                g.SmoothingMode = SmoothingMode.HighQuality;

                float zoom = _windoorModel.WD_zoom_forImageRenderer;

                List<Size> frame_sizes = new List<Size>();
                //int flocX = 0, flocY = 0, total_wd_covered = 0, total_ht_covered = 0, frame_row = 0;

                foreach (IFrameModel frame in _windoorModel.lst_frame)
                {
                    frame_sizes.Add(new Size(frame.FrameImageRenderer_Width, frame.FrameImageRenderer_Height));

                    //int frame_pads_all = frame.FrameImageRenderer_Padding_int.All,
                    //    frame_pads_top = frame.FrameImageRenderer_Padding_int.Top,
                    //    frame_pads_left = frame.FrameImageRenderer_Padding_int.Left,
                    //    added_loc_based_on_ParentMpnl_ndx = 0;

                    //Draw_Frame(e, new Point(flocX, flocY), new Size(frame.FrameImageRenderer_Width, frame.FrameImageRenderer_Height), frame);

                    #region Old_Algorithm

                    //if (frame.Lst_Panel.Count == 1)
                    //{
                    //    int plocX = 0, plocY = 0;

                    //    Draw_Panel(e, frame.Lst_Panel[0], new Point(plocX + flocX + frame_pads_left, plocY + flocY + frame_pads_top));
                    //}
                    //else if (frame.Lst_MultiPanel.Count >= 1)
                    //{
                    //    foreach (IMultiPanelModel mpnl in frame.Lst_MultiPanel)
                    //    {
                    //        int mlocX = 0, mlocY = 0,
                    //            objLocX = 0, objLocY = 0;
                    //        IPanelModel panelModel;
                    //        IDividerModel divModel;
                    //        IMultiPanelModel mpnlModel;

                    //        if (mpnl.MPanel_Parent.Name.Contains("Frame")) //drawing of 1st and 2nd level multipanel objs
                    //        {
                    //            #region Frame_Parent
                    //            mlocX += frame_pads_left;
                    //            mlocY += frame_pads_top;

                    //            Draw_MultiPanel(e, mpnl, new Point(mlocX, mlocY)); //drawing of 1st level MPanel

                    //            if (mpnl.MPanel_Type == "Mullion")
                    //            {
                    //                foreach (Control ctrl in mpnl.MPanelLst_Objects)
                    //                {
                    //                    if (ctrl.Name.Contains("PanelUC_"))
                    //                    {
                    //                        panelModel = mpnl.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name);
                    //                        objLocY = mlocY;

                    //                        if (panelModel.Panel_Placement == "First")
                    //                        {
                    //                            objLocX += mlocX; //addition of frame_pads and div wd
                    //                        }
                    //                        else if (panelModel.Panel_Placement != "First")
                    //                        {
                    //                            if (zoom == 1.0f || zoom == 0.50f)
                    //                            {
                    //                                objLocX += mlocX; //addition of frame_pads and div wd
                    //                            }
                    //                            else if (zoom <= 0.26f)
                    //                            {
                    //                                objLocX += 13;
                    //                            }
                    //                        }

                    //                        Draw_Panel(e, panelModel, new Point(objLocX, objLocY));

                    //                        objLocX += panelModel.PanelImageRenderer_Width;
                    //                    }
                    //                    else if (ctrl.Name.Contains("MullionUC_"))
                    //                    {
                    //                        divModel = mpnl.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name);
                    //                        int locY_deduct = 0;

                    //                        if (zoom == 1.0f)
                    //                        {
                    //                            locY_deduct = 10;
                    //                        }
                    //                        else if (zoom <= 0.50f)
                    //                        {
                    //                            locY_deduct = 5;
                    //                        }

                    //                        Draw_Divider(e, divModel, new Point(objLocX, objLocY - locY_deduct));
                    //                    }
                    //                    else if (ctrl.Name.Contains("MultiTransom_")) //2nd level Mpanel
                    //                    {
                    //                        mpnlModel = mpnl.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == ctrl.Name);
                    //                        objLocY = mlocY;

                    //                        if (mpnlModel.MPanel_Placement == "First")
                    //                        {
                    //                            objLocX += mlocX; //addition of frame_pads and div wd
                    //                        }
                    //                        else if (mpnlModel.MPanel_Placement != "First")
                    //                        {
                    //                            if (zoom == 1.0f || zoom == 0.50f)
                    //                            {
                    //                                objLocX += mlocX; //addition of frame_pads and div wd
                    //                            }
                    //                            else if (zoom <= 0.26f)
                    //                            {
                    //                                objLocX += 13;
                    //                            }
                    //                        }

                    //                        Draw_MultiPanel(e, mpnlModel, new Point(objLocX, objLocY));

                    //                        objLocX += mpnlModel.MPanelImageRenderer_Width;
                    //                    }
                    //                }
                    //            }
                    //            else if (mpnl.MPanel_Type == "Transom")
                    //            {
                    //                foreach (Control ctrl in mpnl.MPanelLst_Objects)
                    //                {
                    //                    if (ctrl.Name.Contains("PanelUC_"))
                    //                    {
                    //                        panelModel = mpnl.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name);
                    //                        objLocX = mlocX;

                    //                        if (panelModel.Panel_Placement == "First")
                    //                        {
                    //                            objLocY += mlocY; //addition of frame_pads and div wd
                    //                        }
                    //                        else if (panelModel.Panel_Placement != "First")
                    //                        {
                    //                            if (zoom == 1.0f || zoom == 0.50f)
                    //                            {
                    //                                objLocY += mlocY; //addition of frame_pads and div wd
                    //                            }
                    //                            else if (zoom <= 0.26f)
                    //                            {
                    //                                objLocY += 13;
                    //                            }
                    //                        }

                    //                        Draw_Panel(e, panelModel, new Point(objLocX, objLocY));

                    //                        objLocY += panelModel.PanelImageRenderer_Height;
                    //                    }
                    //                    else if (ctrl.Name.Contains("TransomUC_"))
                    //                    {
                    //                        divModel = mpnl.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name);
                    //                        int locX_deduct = 0;

                    //                        if (zoom == 1.0f)
                    //                        {
                    //                            locX_deduct = 10;
                    //                        }
                    //                        else if (zoom <= 0.50f)
                    //                        {
                    //                            locX_deduct = 5;
                    //                        }

                    //                        Draw_Divider(e, divModel, new Point(objLocX - locX_deduct, objLocY));
                    //                    }
                    //                    else if (ctrl.Name.Contains("MultiMullion_"))//2nd level Mpanel
                    //                    {
                    //                        mpnlModel = mpnl.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == ctrl.Name);
                    //                        objLocX = mlocX;

                    //                        if (mpnlModel.MPanel_Placement == "First")
                    //                        {
                    //                            objLocY += mlocY; //addition of frame_pads and div wd
                    //                        }
                    //                        else if (mpnlModel.MPanel_Placement != "First")
                    //                        {
                    //                            if (zoom == 1.0f || zoom == 0.50f)
                    //                            {
                    //                                objLocY += mlocY; //addition of frame_pads and div wd
                    //                            }
                    //                            else if (zoom <= 0.26f)
                    //                            {
                    //                                objLocY += 13;
                    //                            }
                    //                        }
                    //                        Draw_MultiPanel(e, mpnlModel, new Point(objLocX, objLocY));

                    //                        objLocY += mpnlModel.MPanelImageRenderer_Height;
                    //                    }
                    //                }
                    //            }
                    //            #endregion
                    //        }
                    //        else if (mpnl.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                    //        {
                    //            #region Multipanel_Parent

                    //            int mpnl_ndx = mpnl.MPanel_Index_Inside_MPanel;

                    //            mlocX += frame_pads_left;
                    //            mlocY += frame_pads_top;

                    //            if (mpnl_ndx == 0)
                    //            {
                    //                if (zoom == 1.0f || zoom == 0.50f)
                    //                {
                    //                    added_loc_based_on_ParentMpnl_ndx += frame_pads_top;
                    //                }
                    //                else if (zoom <= 0.26f)
                    //                {
                    //                    added_loc_based_on_ParentMpnl_ndx += 15;
                    //                }
                    //            }

                    //            if (mpnl.MPanel_Type == "Mullion")
                    //            {
                    //                foreach (Control ctrl in mpnl.MPanelLst_Objects)
                    //                {
                    //                    if (ctrl.Name.Contains("PanelUC_"))
                    //                    {
                    //                        panelModel = mpnl.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name);

                    //                        objLocY = added_loc_based_on_ParentMpnl_ndx;

                    //                        if (panelModel.Panel_Placement == "First")
                    //                        {
                    //                            objLocX += mlocX; //addition of frame_pads and div wd
                    //                        }
                    //                        else if (panelModel.Panel_Placement != "First")
                    //                        {
                    //                            if (zoom == 1.0f || zoom == 0.50f)
                    //                            {
                    //                                objLocX += mlocX; //addition of frame_pads and div wd
                    //                            }
                    //                            else if (zoom <= 0.26f)
                    //                            {
                    //                                objLocX += 13;
                    //                            }
                    //                        }

                    //                        Draw_Panel(e, panelModel, new Point(objLocX, objLocY));

                    //                        objLocX += panelModel.PanelImageRenderer_Width;
                    //                    }
                    //                    else if (ctrl.Name.Contains("MullionUC_"))
                    //                    {
                    //                        divModel = mpnl.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name);
                    //                        int locY_deduct = 0;

                    //                        if (zoom == 1.0f)
                    //                        {
                    //                            locY_deduct = 10;
                    //                        }
                    //                        else if (zoom <= 0.50f)
                    //                        {
                    //                            locY_deduct = 5;
                    //                        }

                    //                        Draw_Divider(e, divModel, new Point(objLocX, objLocY - locY_deduct));
                    //                    }
                    //                    else if (ctrl.Name.Contains("MultiTransom_"))
                    //                    {
                    //                        mpnlModel = mpnl.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == ctrl.Name);
                    //                        objLocY = added_loc_based_on_ParentMpnl_ndx;

                    //                        if (mpnlModel.MPanel_Placement == "First")
                    //                        {
                    //                            objLocX += mlocX; //addition of frame_pads and div wd
                    //                        }
                    //                        else if (mpnlModel.MPanel_Placement != "First")
                    //                        {
                    //                            if (zoom == 1.0f || zoom == 0.50f)
                    //                            {
                    //                                objLocX += mlocX; //addition of frame_pads and div wd
                    //                            }
                    //                            else if (zoom <= 0.26f)
                    //                            {
                    //                                objLocX += 13;
                    //                            }
                    //                        }

                    //                        Draw_MultiPanel(e, mpnlModel, new Point(objLocX, objLocY));

                    //                        objLocX += mpnlModel.MPanelImageRenderer_Width;
                    //                    }
                    //                }
                    //                added_loc_based_on_ParentMpnl_ndx += mpnl.MPanelImageRenderer_Height;
                    //            }
                    //            else if (mpnl.MPanel_Type == "Transom")
                    //            {
                    //                foreach (Control ctrl in mpnl.MPanelLst_Objects)
                    //                {
                    //                    if (ctrl.Name.Contains("PanelUC_"))
                    //                    {
                    //                        panelModel = mpnl.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name);

                    //                        objLocX = added_loc_based_on_ParentMpnl_ndx;

                    //                        if (panelModel.Panel_Placement == "First")
                    //                        {
                    //                            objLocY += mlocY; //addition of frame_pads and div wd
                    //                        }
                    //                        else if (panelModel.Panel_Placement != "First")
                    //                        {
                    //                            if (zoom == 1.0f || zoom == 0.50f)
                    //                            {
                    //                                objLocY += mlocY; //addition of frame_pads and div wd
                    //                            }
                    //                            else if (zoom <= 0.26f)
                    //                            {
                    //                                objLocY += 13;
                    //                            }
                    //                        }

                    //                        Draw_Panel(e, panelModel, new Point(objLocX, objLocY));

                    //                        objLocY += panelModel.PanelImageRenderer_Height;
                    //                    }
                    //                    else if (ctrl.Name.Contains("TransomUC_"))
                    //                    {
                    //                        divModel = mpnl.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name);
                    //                        int locX_deduct = 0;

                    //                        if (zoom == 1.0f)
                    //                        {
                    //                            locX_deduct = 10;
                    //                        }
                    //                        else if (zoom <= 0.50f)
                    //                        {
                    //                            locX_deduct = 5;
                    //                        }

                    //                        Draw_Divider(e, divModel, new Point(objLocX - locX_deduct, objLocY));
                    //                    }
                    //                    else if (ctrl.Name.Contains("MultiMullion_"))
                    //                    {
                    //                        mpnlModel = mpnl.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == ctrl.Name);
                    //                        objLocX = added_loc_based_on_ParentMpnl_ndx;

                    //                        if (mpnlModel.MPanel_Placement == "First")
                    //                        {
                    //                            objLocY += mlocY; //addition of frame_pads and div wd
                    //                        }
                    //                        else if (mpnlModel.MPanel_Placement != "First")
                    //                        {
                    //                            if (zoom == 1.0f || zoom == 0.50f)
                    //                            {
                    //                                objLocY += mlocY; //addition of frame_pads and div wd
                    //                            }
                    //                            else if (zoom <= 0.26f)
                    //                            {
                    //                                objLocY += 13;
                    //                            }
                    //                        }

                    //                        Draw_MultiPanel(e, mpnlModel, new Point(objLocX, objLocY));

                    //                        objLocY += mpnlModel.MPanelImageRenderer_Height;
                    //                    }
                    //                }

                    //                added_loc_based_on_ParentMpnl_ndx += mpnl.MPanelImageRenderer_Width;
                    //            }

                    //            if (zoom == 1.0f || zoom == 0.50f)
                    //            {
                    //                added_loc_based_on_ParentMpnl_ndx += frame_pads_top;
                    //            }
                    //            else if (zoom <= 0.26f)
                    //            {
                    //                added_loc_based_on_ParentMpnl_ndx += 13;
                    //            }
                    //            #endregion
                    //        }
                    //        else if (mpnl.MPanel_ParentModel.MPanel_Parent.Name.Contains("Multi")) //drawing of 4th level panel and div objs
                    //        {
                    //            int mpnl_ndx = mpnl.MPanel_Index_Inside_MPanel,
                    //                mpnlParent_ndx = mpnl.MPanel_ParentModel.MPanel_Index_Inside_MPanel,
                    //                ht_of_previous_objs = 0, wd_previous_objs = 0;

                    //            if (mpnl.MPanelLst_Objects.Count >= 1)
                    //            {
                    //                if (mpnl.MPanel_Type == "Mullion")
                    //                {
                    //                    wd_previous_objs = Find_LocX_Inside_MpanelParent(mpnlParent_ndx, mpnl);
                    //                    ht_of_previous_objs = Find_LocY_Inside_MpanelParent(mpnl_ndx, mpnl);

                    //                    mlocX = frame_pads_left + wd_previous_objs;
                    //                    mlocY = frame_pads_top + ht_of_previous_objs;

                    //                    foreach (Control ctrl in mpnl.MPanelLst_Objects)
                    //                    {
                    //                        if (ctrl.Name.Contains("PanelUC_"))
                    //                        {
                    //                            panelModel = mpnl.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name);
                    //                            objLocY = mlocY;

                    //                            if (panelModel.Panel_Placement == "First")
                    //                            {
                    //                                objLocX = mlocX;
                    //                            }

                    //                            Draw_Panel(e, panelModel, new Point(objLocX, objLocY));

                    //                            objLocX += panelModel.PanelImageRenderer_Width;
                    //                        }
                    //                        else if (ctrl.Name.Contains("MullionUC_"))
                    //                        {
                    //                            divModel = mpnl.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name);
                    //                            int locY_deduct = 0;

                    //                            if (zoom == 1.0f)
                    //                            {
                    //                                locY_deduct = 10;
                    //                            }
                    //                            else if (zoom <= 0.50f)
                    //                            {
                    //                                locY_deduct = 5;
                    //                            }

                    //                            Draw_Divider(e, divModel, new Point(objLocX, objLocY - locY_deduct));

                    //                            objLocX += divModel.DivImageRenderer_Width;
                    //                        }
                    //                    }
                    //                }

                    //                else if (mpnl.MPanel_Type == "Transom")
                    //                {
                    //                    wd_previous_objs = Find_LocX_Inside_MpanelParent(mpnl_ndx, mpnl);
                    //                    ht_of_previous_objs = Find_LocY_Inside_MpanelParent(mpnlParent_ndx, mpnl);

                    //                    mlocX = frame_pads_left + wd_previous_objs;
                    //                    mlocY = frame_pads_top + ht_of_previous_objs;

                    //                    foreach (Control ctrl in mpnl.MPanelLst_Objects)
                    //                    {
                    //                        if (ctrl.Name.Contains("PanelUC_"))
                    //                        {
                    //                            panelModel = mpnl.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name);
                    //                            objLocX = mlocX;

                    //                            if (panelModel.Panel_Placement == "First")
                    //                            {
                    //                                objLocY = mlocY;
                    //                            }

                    //                            Draw_Panel(e, panelModel, new Point(objLocX, objLocY));

                    //                            objLocY += panelModel.PanelImageRenderer_Height;
                    //                        }
                    //                        else if (ctrl.Name.Contains("TransomUC_"))
                    //                        {
                    //                            divModel = mpnl.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name);
                    //                            int locX_deduct = 0;

                    //                            if (zoom == 1.0f)
                    //                            {
                    //                                locX_deduct = 10;
                    //                            }
                    //                            else if (zoom <= 0.50f)
                    //                            {
                    //                                locX_deduct = 5;
                    //                            }

                    //                            Draw_Divider(e, divModel, new Point(objLocX - locX_deduct, objLocY));

                    //                            objLocY += divModel.DivImageRenderer_Height;
                    //                        }
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //}

                    #endregion

                }

                int basePlatformImage_Width_minus70 = _windoorModel.WD_width_4basePlatform_forImageRenderer - 70;

                List<Point> frame_points = OuterFrame_DrawPoints(frame_sizes, basePlatformImage_Width_minus70);

                for (int i = 0; i < frame_points.Count; i++)
                {
                    IFrameModel frameModel = _windoorModel.lst_frame[i];
                    Draw_Frame(e, frame_points[i], frame_sizes[i], frameModel);

                    //Draw panel per frame
                    if (frameModel.Lst_Panel.Count() == 1)
                    {
                        Point pPoint = Panel_MPanel_DrawPoints_ParentIsFrame(frame_points[i], frameModel.FrameImageRenderer_Padding_int.Top, frameModel.FrameImageRenderer_Padding_int.Left);
                        Draw_Panel(e, frameModel.Lst_Panel[0], pPoint);
                    }
                    else if (frameModel.Lst_MultiPanel.Count() > 0)
                    {
                        //Draw_MultiPanel
                        IMultiPanelModel mpnl = frameModel.Lst_MultiPanel[0];

                        if (mpnl.MPanel_Parent.Name.Contains("Frame"))
                        {
                            Point MPoint = Panel_MPanel_DrawPoints_ParentIsFrame(frame_points[i], frameModel.FrameImageRenderer_Padding_int.Top, frameModel.FrameImageRenderer_Padding_int.Left);

                            int mlocX = MPoint.X, 
                                mlocY = MPoint.Y,
                                objLocX = 0, 
                                objLocY = 0;

                            Draw_MultiPanel(e, mpnl, MPoint);

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
                                            //if (zoom == 1.0f || zoom == 0.50f)
                                            //{
                                            //    objLocX += mlocX; //addition of frame_pads and div wd
                                            //}
                                            //else 
                                            if (zoom <= 0.26f)
                                            {
                                                objLocX += 13;
                                            }
                                        }

                                        Draw_Panel(e, panelModel, new Point(objLocX, objLocY));

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

                                        Draw_Divider(e, divModel, new Point(objLocX, objLocY - locY_deduct));

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
                                            //if (zoom == 1.0f || zoom == 0.50f)
                                            //{
                                            //    objLocX += mlocX; //addition of frame_pads and div wd
                                            //}
                                            //else 
                                            if (zoom <= 0.26f)
                                            {
                                                objLocX += 13;
                                            }
                                        }

                                        Draw_MultiPanel(e, mpnlModel, new Point(objLocX, objLocY));

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
                                            //if (zoom == 1.0f || zoom == 0.50f)
                                            //{
                                            //    objLocY += mlocY; //addition of frame_pads and div wd
                                            //}
                                            //else 
                                            if (zoom <= 0.26f)
                                            {
                                                objLocY += 13;
                                            }
                                        }

                                        Draw_Panel(e, panelModel, new Point(objLocX, objLocY));

                                        objLocY += panelModel.PanelImageRenderer_Height;
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

                                        Draw_Divider(e, divModel, new Point(objLocX - locX_deduct, objLocY));

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
                                            //if (zoom == 1.0f || zoom == 0.50f)
                                            //{
                                            //    objLocY += mlocY; //addition of frame_pads and div wd
                                            //}
                                            //else 
                                            if (zoom <= 0.26f)
                                            {
                                                objLocY += 13;
                                            }
                                        }
                                        Draw_MultiPanel(e, mpnlModel, new Point(objLocX, objLocY));

                                        objLocY += mpnlModel.MPanelImageRenderer_Height;
                                    }
                                }
                            }
                        }
                    }
                }

                Color col = Color.Black;

                int w = 2;
                int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
                g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                               0,
                                                               fpnl.ClientRectangle.Width - w,
                                                               fpnl.ClientRectangle.Height - w));
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private int Find_LocY_Inside_MpanelParent(int mpnl_ndx, IMultiPanelModel mpnl)
        {
            int locY = 0;

            if (mpnl.MPanel_Type == "Mullion")
            {
                for (int i = 0; i < mpnl_ndx; i++)
                {
                    IMultiPanelModel lvl2_parent = mpnl.MPanel_ParentModel;
                    Control ctrl = lvl2_parent.MPanelLst_Objects[i];
                    int imgr_ht = 0;
                    if (ctrl.Name.Contains("PanelUC_"))
                    {
                        imgr_ht = lvl2_parent.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name).PanelImageRenderer_Height;
                        locY += imgr_ht;
                    }
                    else if (ctrl.Name.Contains("TransomUC_"))
                    {
                        imgr_ht = lvl2_parent.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name).DivImageRenderer_Height;
                        locY += imgr_ht;
                    }
                    else if (ctrl.Name.Contains("MultiMullion_"))
                    {
                        imgr_ht = lvl2_parent.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == ctrl.Name).MPanelImageRenderer_Height;
                        locY += imgr_ht;
                    }
                }
            }
            else if (mpnl.MPanel_Type == "Transom")
            {
                for (int i = 0; i < mpnl_ndx; i++)
                {
                    IMultiPanelModel lvl1_parent = mpnl.MPanel_ParentModel.MPanel_ParentModel;
                    Control ctrl = lvl1_parent.MPanelLst_Objects[i];
                    int imgr_ht = 0;
                    if (ctrl.Name.Contains("PanelUC_"))
                    {
                        imgr_ht = lvl1_parent.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name).PanelImageRenderer_Height;
                        locY += imgr_ht;
                    }
                    else if (ctrl.Name.Contains("TransomUC_"))
                    {
                        imgr_ht = lvl1_parent.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name).DivImageRenderer_Height;
                        locY += imgr_ht;
                    }
                    else if (ctrl.Name.Contains("MultiMullion_"))
                    {
                        imgr_ht = lvl1_parent.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == ctrl.Name).MPanelImageRenderer_Height;
                        locY += imgr_ht;
                    }
                }
            }

            return locY;
        }

        private int Find_LocX_Inside_MpanelParent(int mpnl_ndx, IMultiPanelModel mpnl)
        {
            int locX = 0;

            if (mpnl.MPanel_Type == "Mullion")
            {
                for (int i = 0; i < mpnl_ndx; i++)
                {
                    IMultiPanelModel lvl1_parent = mpnl.MPanel_ParentModel.MPanel_ParentModel; //matik mpanel mullion
                    Control ctrl = lvl1_parent.MPanelLst_Objects[i];
                    int imgr_wd = 0;

                    if (ctrl.Name.Contains("PanelUC_"))
                    {
                        imgr_wd = lvl1_parent.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name).PanelImageRenderer_Width;
                        locX += imgr_wd;
                    }
                    else if (ctrl.Name.Contains("MullionUC_"))
                    {
                        imgr_wd = lvl1_parent.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name).DivImageRenderer_Width;
                        locX += imgr_wd;
                    }
                    else if (ctrl.Name.Contains("MultiTransom_"))
                    {
                        imgr_wd = lvl1_parent.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == ctrl.Name).MPanelImageRenderer_Width;
                        locX += imgr_wd;
                    }
                }
            }
            else if (mpnl.MPanel_Type == "Transom")
            {
                for (int i = 0; i < mpnl_ndx; i++)
                {
                    IMultiPanelModel lvl2_parent = mpnl.MPanel_ParentModel;
                    Control ctrl = lvl2_parent.MPanelLst_Objects[i];
                    int imgr_wd = 0;

                    if (ctrl.Name.Contains("PanelUC_"))
                    {
                        imgr_wd = lvl2_parent.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name).PanelImageRenderer_Width;
                        locX += imgr_wd;
                    }
                    else if (ctrl.Name.Contains("MullionUC_"))
                    {
                        imgr_wd = lvl2_parent.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name).DivImageRenderer_Width;
                        locX += imgr_wd;
                    }
                    else if (ctrl.Name.Contains("MultiTransom_"))
                    {
                        imgr_wd = lvl2_parent.MPanelLst_MultiPanel.Find(mpanel => mpanel.MPanel_Name == ctrl.Name).MPanelImageRenderer_Width;
                        locX += imgr_wd;
                    }
                }
            }

            return locX;
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
            redP.Width = 3.5f;

            Font dmnsion_font_wd = new Font("Segoe UI", 22, FontStyle.Bold);
            Font dmnsion_font_ht = new Font("Segoe UI", 17, FontStyle.Bold);

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
                foreach (decimal wd in _windoorModel.lst_wd_redArrowLines)
                {
                    locX = Draw_Arrow_Width(wd, e, locX, dmnsion_font_wd, ctrl_Y);
                }

                float locY = 0;
                foreach (decimal ht in _windoorModel.lst_ht_redArrowLines)
                {
                    locY = Draw_Arrow_Height(ht, e, locY, dmnsion_font_ht, ctrl_Y);
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
                                          new Rectangle(new Point((70 - s2.Width) / 2, (int)(mid2 - (s2.Height / 2))),
                                                        new Size(s2.Width, s2.Height)),
                                          Color.Black,
                                          Color.White,
                                          TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                //arrow for HEIGHT
            }

            Bitmap bm = new Bitmap(basePL.Size.Width, basePL.Size.Height);
            basePL.DrawToBitmap(bm, new Rectangle(0, 0, basePL.Size.Width, basePL.Size.Height));
            //bm.Save(@"C:\Users\Minrivel\Pictures\Saved Pictures\2.png", ImageFormat.Png);

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
                                      SystemColors.Control,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            //arrow for WIDTH
            locX += DispWd_float;

            return locX;
        }

        private float Draw_Arrow_Height(decimal ht, PaintEventArgs e, float locY, Font dmnsion_font_ht, int ctrl_Y)
        {
            //arrow for HEIGHT
            Graphics g = e.Graphics;

            string dmnsion_h = ht.ToString();
            float DispHt_float = float.Parse(dmnsion_h);

            PointF dmnsion_h_startP = new PointF(70 - 17, _flpMain.Location.Y + (locY * _windoorModel.WD_zoom));
            PointF dmnsion_h_endP = new PointF(70 - 17, (_flpMain.Location.Y - 3) + ((locY + DispHt_float) * _windoorModel.WD_zoom));

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
                                      SystemColors.Control,
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

            int fr_pads = frameModel.FrameImageRenderer_Padding_int.All;

            int top_pads = frameModel.FrameImageRenderer_Padding_int.Top,
                right_pads = frameModel.FrameImageRenderer_Padding_int.Right,
                left_pads = frameModel.FrameImageRenderer_Padding_int.Left,
                bot_pads = frameModel.FrameImageRenderer_Padding_int.Bottom;

            Rectangle pnl_inner = new Rectangle(new Point(fPoint.X + left_pads, fPoint.Y + top_pads),
                                                new Size(frameModel.FrameImageRenderer_Width - (right_pads + left_pads),
                                                         frameModel.FrameImageRenderer_Height - (top_pads + bot_pads)));


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
                new Point(fPoint.X, frameModel.FrameImageRenderer_Height + fPoint.Y),
                new Point(pInnerX, pInnerY + pInnerHt),
                new Point(fPoint.X + frameModel.FrameImageRenderer_Width, frameModel.FrameImageRenderer_Height + fPoint.Y),
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
                                                  fSize.Height - w));
        }

        private void Draw_Panel(PaintEventArgs e, IPanelModel panelModel, Point Ppoint)
        {
            Graphics g = e.Graphics;
            int w = 2;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            int client_wd = 0, client_ht = 0;

            client_wd = panelModel.PanelImageRenderer_Width;
            client_ht = panelModel.PanelImageRenderer_Height;

            Rectangle panel_bounds = new Rectangle(Ppoint, new Size(client_wd, client_ht));

            g.SmoothingMode = SmoothingMode.HighQuality;

            int font_size = 30,
                outer_line = 10,
                inner_line = 15;

            if (panelModel.PanelImageRenderer_Zoom == 0.28f)
            {
                font_size = 25;
            }
            else if (panelModel.PanelImageRenderer_Zoom == 0.19f)
            {
                font_size = 15;
                outer_line = 5;
                inner_line = 8;
            }
            else if (panelModel.PanelImageRenderer_Zoom == 0.14f)
            {
                font_size = 13;
                outer_line = 3;
                inner_line = 7;
            }
            else if (panelModel.PanelImageRenderer_Zoom == 0.10f)
            {
                font_size = 8;
                outer_line = 3;
                inner_line = 7;
            }

            Rectangle outer_bounds = new Rectangle(Ppoint.X,
                                                   Ppoint.Y,
                                                   client_wd - w,
                                                   client_ht - w);

            g.DrawRectangle(new Pen(Color.Black, w), outer_bounds);
            g.FillRectangle(Brushes.DarkGray, outer_bounds);

            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(Ppoint.X + outer_line,
                                                                   Ppoint.Y + outer_line,
                                                                   (client_wd - (outer_line * 2)) - w,
                                                                   (client_ht - (outer_line * 2)) - w));

            

            if (panelModel.Panel_Type == "Fixed Panel")
            {
                if (panelModel.Panel_Orient == true)
                {
                    g.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(Ppoint.X + inner_line,
                                                                           Ppoint.Y + inner_line,
                                                                           (client_wd - (inner_line * 2)) - w,
                                                                           (client_ht - (inner_line * 2)) - w));

                }

                Font drawFont = new Font("Times New Roman", font_size);// * zoom);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString("F", drawFont, new SolidBrush(Color.Black), panel_bounds, drawFormat);
            }
            else if (panelModel.Panel_Type == "Casement Panel")
            {
                g.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(Ppoint.X + inner_line,
                                                                       Ppoint.Y + inner_line,
                                                                       (client_wd - (inner_line * 2)) - w,
                                                                       (client_ht - (inner_line * 2)) - w));

                Point sashPoint = new Point(Ppoint.X, Ppoint.Y);

                Pen dgrayPen = new Pen(Color.DimGray);
                dgrayPen.DashStyle = DashStyle.Dash;
                dgrayPen.Width = 3;

                int sashW = client_wd,
                    sashH = client_ht;

                if (panelModel.Panel_Orient == true)//Left
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + sashW, sashPoint.Y),
                                             new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))),
                                         new Point(sashPoint.X + sashW, sashPoint.Y + sashH));
                }
                else if (panelModel.Panel_Orient == false)//Right
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                         new Point(sashPoint.X + sashW, (sashPoint.Y + (sashH / 2))));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + sashW, (sashPoint.Y + (sashH / 2))),
                                         new Point(sashPoint.X, sashH + sashPoint.Y));
                }
            }
            else if (panelModel.Panel_Type == "Awning Panel")
            {
                g.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(Ppoint.X + inner_line,
                                                                       Ppoint.Y + inner_line,
                                                                       (client_wd - (inner_line * 2)) - w,
                                                                       (client_ht - (inner_line * 2)) - w));

                Point sashPoint = new Point(Ppoint.X, Ppoint.Y);

                Pen dgrayPen = new Pen(Color.DimGray);
                dgrayPen.DashStyle = DashStyle.Dash;
                dgrayPen.Width = 3;

                int sashW = client_wd,
                    sashH = client_ht;

                if (panelModel.Panel_Orient == true)
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                         new Point(sashPoint.X + (sashW / 2), sashPoint.Y + sashH));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW / 2), sashPoint.Y + sashH),
                                         new Point(sashPoint.X + sashW, sashPoint.Y));
                }
                else if (panelModel.Panel_Orient == false)
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y + sashH),
                                     new Point(sashPoint.X + (sashW / 2), sashPoint.Y));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW / 2), sashPoint.Y),
                                         new Point(sashPoint.X + sashW, sashH + sashPoint.Y));
                }
            }
            else if (panelModel.Panel_Type == "Sliding Panel")
            {
                g.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(Ppoint.X + inner_line,
                                                                       Ppoint.Y + inner_line,
                                                                       (client_wd - (inner_line * 2)) - w,
                                                                       (client_ht - (inner_line * 2)) - w));
                Point sashPoint = new Point(Ppoint.X + 25, Ppoint.Y);

                int sashW = client_wd,
                    sashH = client_ht;

                float arwStart_x1 = sashPoint.X + (sashW / 20),
                      center_y1 = sashPoint.Y + (sashH / 2),
                      arwEnd_x2 = ((sashPoint.X + sashW) - arwStart_x1) + (sashW / 20),
                      arwHeadUp_x3,
                      arwHeadUp_y3 = center_y1 - (center_y1 / 4),
                      arwHeadUp_x4,
                      arwHeadUp_y4 = center_y1 + (center_y1 / 4);


                if (panelModel.Panel_Orient == true)
                {
                    arwHeadUp_x3 = sashPoint.X + arwStart_x1 + (sashW / 10);
                    arwHeadUp_x4 = sashPoint.X + arwStart_x1 + (sashW / 10);

                    g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x3, arwHeadUp_y3),
                                                     new PointF(arwStart_x1, center_y1));
                    g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x4, arwHeadUp_y4),
                                                     new PointF(arwStart_x1, center_y1));
                }
                else if (panelModel.Panel_Orient == false)
                {
                    arwHeadUp_x3 = ((sashPoint.X + sashW) - arwStart_x1) - (sashW / 10);
                    arwHeadUp_x4 = ((sashPoint.X + sashW) - arwStart_x1) - (sashW / 10);

                    g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x3, arwHeadUp_y3),
                                                     new PointF(arwEnd_x2, center_y1));
                    g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x4, arwHeadUp_y4),
                                                     new PointF(arwEnd_x2, center_y1));
                }

                g.DrawLine(new Pen(Color.Black), new PointF(arwStart_x1, center_y1),
                                                 new PointF(arwEnd_x2, center_y1));
            }
            else if (panelModel.Panel_Type == "TiltNTurn Panel")
            {
                g.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(Ppoint.X + inner_line,
                                                                       Ppoint.Y + inner_line,
                                                                       (client_wd - (inner_line * 2)) - w,
                                                                       (client_ht - (inner_line * 2)) - w));

                Point sashPoint = new Point(Ppoint.X, Ppoint.Y);

                Pen dgrayPen = new Pen(Color.DimGray);
                dgrayPen.DashStyle = DashStyle.Dash;
                dgrayPen.Width = 3;

                int sashW = client_wd,
                    sashH = client_ht;

                g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                     new Point(sashPoint.X + (sashW / 2), sashPoint.Y + sashH));
                g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW / 2), sashPoint.Y + sashH),
                                     new Point(sashPoint.X + sashW, sashPoint.Y));

                if (panelModel.Panel_Orient == true)//Left
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + sashW, sashPoint.Y),
                                             new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))),
                                         new Point(sashPoint.X + sashW, sashPoint.Y + sashH));
                }
                else if (panelModel.Panel_Orient == false)//Right
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                         new Point(sashPoint.X + sashW, (sashPoint.Y + (sashH / 2))));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + sashW, (sashPoint.Y + (sashH / 2))),
                                         new Point(sashPoint.X, sashH + sashPoint.Y));
                }
            }
        }

        private void Draw_MultiPanel(PaintEventArgs e, IMultiPanelModel mpanelModel, Point Mpoint)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float zoom = mpanelModel.MPanelImageRenderer_Zoom;

            int client_wd = mpanelModel.MPanelImageRenderer_Width,
                client_ht = mpanelModel.MPanelImageRenderer_Height;

            Rectangle mpnl_bounds = new Rectangle(Mpoint, new Size(client_wd, client_ht));
            SolidBrush mpnl_sBrush = new SolidBrush(Color.MistyRose);

            if (mpanelModel.MPanel_Type == "Mullion")
            {
                mpnl_sBrush = new SolidBrush(Color.MistyRose);
            }
            else if (mpanelModel.MPanel_Type == "Transom")
            {
                mpnl_sBrush = new SolidBrush(SystemColors.ActiveCaption);
            }

            g.FillRectangle(mpnl_sBrush, mpnl_bounds);
            g.DrawRectangle(new Pen(Color.Black, 1), mpnl_bounds);
        }

        private void Draw_lvl4_PanelDiv_obj(PaintEventArgs e, IMultiPanelModel lvl3_parent, int locX, int locY, int mlocX, int mlocY)
        {
            int objLocX = 0, objLocY = 0;

            float zoom = lvl3_parent.MPanelImageRenderer_Zoom;

            IPanelModel panelModel;
            IDividerModel divModel;

            if (lvl3_parent.MPanel_Type == "Mullion")
            {
                objLocX = locX;

                foreach (Control ctrl in lvl3_parent.MPanelLst_Objects)
                {
                    if (ctrl.Name.Contains("PanelUC_"))
                    {
                        panelModel = lvl3_parent.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name);

                        if (panelModel.Panel_Placement == "First")
                        {
                            objLocY += mlocY; //addition of frame_pads and div wd
                        }
                        else if (panelModel.Panel_Placement != "First")
                        {
                            if (zoom == 1.0f || zoom == 0.50f)
                            {
                                objLocY += mlocY; //addition of frame_pads and div wd
                            }
                            else if (zoom <= 0.26f)
                            {
                                objLocY += 13;
                            }
                        }

                        Draw_Panel(e, panelModel, new Point(objLocX, objLocY));

                        objLocX += panelModel.PanelImageRenderer_Width;
                    }
                    else if (ctrl.Name.Contains("MullionUC_"))
                    {
                        divModel = lvl3_parent.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name);
                        int locY_deduct = 0;

                        if (zoom == 1.0f)
                        {
                            locY_deduct = 10;
                        }
                        else if (zoom <= 0.50f)
                        {
                            locY_deduct = 5;
                        }

                        Draw_Divider(e, divModel, new Point(objLocX, objLocY - locY_deduct));
                    }
                }
            }
            else if (lvl3_parent.MPanel_Type == "Transom")
            {
                objLocX = locX;

                foreach (Control ctrl in lvl3_parent.MPanelLst_Objects)
                {
                    if (ctrl.Name.Contains("PanelUC_"))
                    {
                        panelModel = lvl3_parent.MPanelLst_Panel.Find(panel => panel.Panel_Name == ctrl.Name);

                        if (panelModel.Panel_Placement == "First")
                        {
                            objLocY += mlocY; //addition of frame_pads and div wd
                        }
                        else if (panelModel.Panel_Placement != "First")
                        {
                            if (zoom == 1.0f || zoom == 0.50f)
                            {
                                objLocY += mlocY; //addition of frame_pads and div wd
                            }
                            else if (zoom <= 0.26f)
                            {
                                objLocY += 13;
                            }
                        }

                        Draw_Panel(e, panelModel, new Point(objLocX, objLocY));

                        objLocY += panelModel.PanelImageRenderer_Height;
                    }
                    else if (ctrl.Name.Contains("TransomUC_"))
                    {
                        divModel = lvl3_parent.MPanelLst_Divider.Find(div => div.Div_Name == ctrl.Name);
                        int locX_deduct = 0;

                        if (zoom == 1.0f)
                        {
                            locX_deduct = 10;
                        }
                        else if (zoom <= 0.50f)
                        {
                            locX_deduct = 5;
                        }

                        Draw_Divider(e, divModel, new Point(objLocX - locX_deduct, objLocY));
                    }
                }
            }
        }

        private void Draw_Divider(PaintEventArgs e, IDividerModel divModel, Point Dpoint)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.HighQuality;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            IMultiPanelModel parent_mpnl = divModel.Div_MPanelParent;

            int client_wd = divModel.DivImageRenderer_Width,
                client_ht = divModel.DivImageRenderer_Height;

            Rectangle div_rect = new Rectangle(Dpoint.X,
                                               Dpoint.Y,
                                               client_wd - w,
                                               client_ht - w);

            SolidBrush div_sBrush = new SolidBrush(Color.RosyBrown);

            if (divModel.Div_Type == DividerModel.DividerType.Mullion)
            {
                div_sBrush = new SolidBrush(Color.RosyBrown);
            }
            else if (divModel.Div_Type == DividerModel.DividerType.Transom)
            {
                div_sBrush = new SolidBrush(Color.PowderBlue);
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
    }
}
