﻿using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers
{
    public class MultiPanelTransomImagerUCPresenter : IMultiPanelTransomImagerUCPresenter, IPresenterCommon
    {
        IMultiPanelTransomImagerUC _multiTransomImagerUC;

        private IUnityContainer _unityC;

        private IMultiPanelModel _multiPanelModel;
        private IFrameModel _frameModel;

        private IFrameImagerUCPresenter _frameImagerUCP;
        private IMultiPanelMullionImagerUCPresenter _multiPanelMullionImagerUCP;
        private IMultiPanelTransomImagerUCPresenter _multiPanelTransomImagerUCP;

        private MultiPanelCommon _mpnlCommons = new MultiPanelCommon();

        public MultiPanelTransomImagerUCPresenter(IMultiPanelTransomImagerUC multiTransomImagerUC)
        {
            _multiTransomImagerUC = multiTransomImagerUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _multiTransomImagerUC.flpMulltiPaintEventRaised += _multiTransomImagerUC_flpMulltiPaintEventRaised;
            _multiTransomImagerUC.flpMultiVisibleChangedEventRaised += _multiTransomImagerUC_flpMultiVisibleChangedEventRaised;
        }

        private void _multiTransomImagerUC_flpMultiVisibleChangedEventRaised(object sender, EventArgs e)
        {
            if (((UserControl)sender).Visible == false)
            {
                if (_frameImagerUCP != null)
                {
                    _frameImagerUCP.DeleteControl((UserControl)_multiTransomImagerUC);
                }
                else if (_multiPanelMullionImagerUCP != null)
                {
                    _multiPanelMullionImagerUCP.DeleteControl((UserControl)_multiTransomImagerUC);
                }
                else if (_multiPanelTransomImagerUCP != null)
                {
                    _multiPanelTransomImagerUCP.DeleteControl((UserControl)_multiTransomImagerUC);
                }
            }
        }

        private void _multiTransomImagerUC_flpMulltiPaintEventRaised(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender;

            float zoom = _multiPanelModel.MPanel_Zoom;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            int pInnerX = (int)(10 * zoom),
                pInnerY = (int)(10 * zoom),
                pInnerWd = fpnl.ClientRectangle.Width - (int)(20 * zoom),
                pInnerHt = fpnl.ClientRectangle.Height - (int)(20 * zoom);

            if (zoom == 0.26f || zoom == 0.17f ||
                zoom == 0.13f || zoom == 0.10f)
            {
                pInnerX = 15;
                pInnerY = 15;
                pInnerWd = fpnl.ClientRectangle.Width - 30;
                pInnerHt = fpnl.ClientRectangle.Height - 30;
            }

            int ht_ToBind = _multiPanelModel.MPanelImageRenderer_Height,
                wd_ToBind = _multiPanelModel.MPanelImageRenderer_Width;

            Point[] corner_points = new[]
            {
                new Point(0,0),
                new Point(pInnerX, pInnerY),
                new Point(fpnl.ClientRectangle.Width, 0),
                new Point(pInnerX + pInnerWd, pInnerY),
                new Point(0, fpnl.ClientRectangle.Height),
                new Point(pInnerX, pInnerY + pInnerHt),
                new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                new Point(pInnerX + pInnerWd, pInnerY + pInnerHt)
            };

            GraphicsPath gpath = new GraphicsPath();
            GraphicsPath gpath2 = new GraphicsPath();
            Rectangle bounds = new Rectangle();
            Pen pen = new Pen(Color.Black, 2);

            List<Point[]> thisDrawingPoints_bot = null, //botTransom
                          thisDrawingPoints_top = null, //topTransom
                          thisDrawingPoints_forMullion_RightSide = null,
                          thisDrawingPoints_forMullion_LeftSide = null;

            int pixels_count = 0;
            if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
            {
                pixels_count = 8;
            }
            else if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
            {
                pixels_count = 10;
            }

            Rectangle[] divs_bounds_values = { new Rectangle(new Point(0, ht_ToBind - (int)(pixels_count * zoom)), new Size(wd_ToBind - 1, (int)(pixels_count * zoom))) , //bot
                                               new Rectangle(new Point(0, -1), new Size(wd_ToBind - 1, (int)(pixels_count * zoom))), //top
                                               new Rectangle(new Point(wd_ToBind - (int)(pixels_count * zoom), 0), new Size((int)(pixels_count * zoom), ht_ToBind - 1)), //right
                                               new Rectangle(new Point(-1, 0), new Size((int)(pixels_count * zoom), ht_ToBind - 1)) //left
                                             };

            if (zoom == 0.26f || zoom == 0.17f ||
                zoom == 0.13f || zoom == 0.10f)
            {
                divs_bounds_values[0] = new Rectangle(new Point(0, ht_ToBind - (int)(pixels_count * zoom)), new Size(wd_ToBind - 1, (int)(pixels_count * zoom))); //bot
                divs_bounds_values[1] = new Rectangle(new Point(0, -1), new Size(wd_ToBind - 1, (int)(pixels_count * zoom))); //top
                divs_bounds_values[2] = new Rectangle(new Point(wd_ToBind - 2, 0), new Size(2, ht_ToBind - 1)); //right
                divs_bounds_values[3] = new Rectangle(new Point(-1, 0), new Size(2, ht_ToBind - 1)); //left
            }

            Rectangle divider_bounds_Bot = new Rectangle();
            Rectangle divider_bounds_Top = new Rectangle();
            Rectangle divider_bounds_Right = new Rectangle();
            Rectangle divider_bounds_Left = new Rectangle();

            Font drawFont = new Font("Segoe UI", 12); //* zoom);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Near;

            IMultiPanelModel parent_mpnl = _multiPanelModel.MPanel_ParentModel;

            string parent_name = _multiPanelModel.MPanel_Parent.Name,
                       lvl2_parent_Type = "",
                       thisObj_placement = _multiPanelModel.MPanel_Placement;
            DockStyle parent_doxtyle = DockStyle.None;

            if (_multiPanelModel.MPanel_Parent.GetType() == typeof(FrameUC)) //if inside Frame
            {
                for (int i = 0; i < corner_points.Length - 1; i += 2)
                {
                    g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                }

                int bPoints = (int)(10 * _frameModel.FrameImageRenderer_Zoom),
                    bSizeDeduction = (int)(20 * _frameModel.FrameImageRenderer_Zoom);

                if (zoom == 0.26f || zoom == 0.17f ||
                    zoom == 0.13f || zoom == 0.10f)
                {
                    bounds = new Rectangle(new Point(5, 5),
                                           new Size(fpnl.ClientRectangle.Width - 10, fpnl.ClientRectangle.Height - 10));
                }
                else
                {
                    bounds = new Rectangle(new Point(bPoints, bPoints),
                                           new Size(fpnl.ClientRectangle.Width - bSizeDeduction, fpnl.ClientRectangle.Height - bSizeDeduction));
                }
            }
            else if (_multiPanelModel.MPanel_Parent.GetType() == typeof(FlowLayoutPanel)) //If MultiPanel
            {
                string parentObj_placement = _multiPanelModel.MPanel_ParentModel.MPanel_Placement;
                int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1,
                    parent_mpnl_childObj_count = parent_mpnl.GetCount_MPanelLst_Object(),
                    indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;

                parent_doxtyle = _multiPanelModel.MPanel_ParentModel.MPanel_Dock;

                GraphicsPath gpath_forMullion_RightSide = new GraphicsPath();
                GraphicsPath gpath_forMullion_LeftSide = new GraphicsPath();

                #region Variable Declaration

                #region MAIN PLATFORM Parent_Type
                if (parent_doxtyle == DockStyle.None)
                {
                    lvl2_parent_Type = _multiPanelModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Type;
                }
                #endregion

                #region thisDrawingPoints_bot and thisDrawingPoints_top
                thisDrawingPoints_bot = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                        fpnl.Height,
                                                                                        "TransomUC",
                                                                                        "First",
                                                                                        _frameModel.Frame_Type.ToString());

                thisDrawingPoints_top = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                    fpnl.Height,
                                                                                    "TransomUC",
                                                                                    "Last",
                                                                                    _frameModel.Frame_Type.ToString());
                #endregion

                #region bounds declaration
                int wd_deduction = 0,
                    ht_deduction = 0,
                    bounds_PointX = 0,
                    bounds_PointY = 0;

                if (parent_name.Contains("MultiTransom"))
                #region Parent is MultiPanel Transom
                {
                    wd_deduction = (int)(20 * zoom);
                    bounds_PointX = (int)(10 * zoom);

                    if (thisObj_placement == "First")
                    {
                        bounds_PointY = (int)(10 * zoom);
                        ht_deduction = (int)((10 + (pixels_count + 1)) * zoom);
                    }
                    else if (thisObj_placement == "Last")
                    {
                        bounds_PointY = (int)(pixels_count * zoom);
                        ht_deduction = (int)(((((pixels_count + 2) * 2)) - 1) * zoom);
                    }
                    else if (thisObj_placement == "Somewhere in Between")
                    {
                        bounds_PointY = (int)(pixels_count * zoom);
                        ht_deduction = (int)((pixels_count * 2) * zoom);
                    }
                }
                #endregion

                else if (parent_name.Contains("MultiMullion"))
                #region Parent is MultiPanel Mullion
                {
                    if (zoom == 0.26f)
                    {
                        bounds_PointY = 5;
                        ht_deduction = 10;
                    }
                    else if (zoom == 1.0f)
                    {
                        bounds_PointY = (int)(10 * zoom);
                        ht_deduction = (int)(20 * zoom);
                    }
                    else if (zoom == 0.50f)
                    {
                        bounds_PointY = 5;
                        ht_deduction = 11;
                    }
                    else if (zoom <= 0.17f)
                    {
                        bounds_PointY = 5;
                        ht_deduction = 10;
                        if (thisObj_placement == "Last")
                        {
                            if (parentObj_placement == "First")
                            {
                                bounds_PointY += 3;
                                ht_deduction += 3;
                            }
                            else if (parentObj_placement == "Last")
                            {
                                ht_deduction += 3;
                            }
                        }
                    }

                    if (thisObj_placement == "First")
                    {
                        if (zoom <= 0.26f)
                        {
                            bounds_PointX = 5;
                            if (lvl2_parent_Type != "")
                            {
                                wd_deduction = 8 + 3;
                            }
                            else if (lvl2_parent_Type == "")
                            {
                                wd_deduction = 8 + 4;
                            }
                        }
                        else if (zoom == 0.50f)
                        {
                            bounds_PointX = (int)(10 * zoom);
                            if (lvl2_parent_Type != "")
                            {
                                wd_deduction = (int)((10 + (pixels_count + 1)) * zoom) + 2;
                            }
                            else if (lvl2_parent_Type == "")
                            {
                                wd_deduction = (int)((10 + (pixels_count + 1)) * zoom) + 2;
                            }
                        }
                        else if (zoom == 1.0f)
                        {
                            bounds_PointX = (int)(10 * zoom);
                            wd_deduction = (int)((10 + (pixels_count + 1)) * zoom);
                        }
                    }
                    else if (thisObj_placement == "Last")
                    {
                        if (zoom <= 0.26f)
                        {
                            if (lvl2_parent_Type != "")
                            {
                                bounds_PointX = 2 + 3;
                                wd_deduction = 8 + 6;
                            }
                            else if (lvl2_parent_Type == "")
                            {
                                bounds_PointX = 6;
                                wd_deduction = 8 + 4;
                            }
                        }
                        else if (zoom == 0.50f)
                        {
                            bounds_PointX = (int)(pixels_count * zoom);
                            wd_deduction = (int)((((pixels_count + 2) * 2) - 1) * zoom) + 1;
                        }
                        else if (zoom == 1.0f)
                        {
                            bounds_PointX = (int)(pixels_count * zoom);
                            wd_deduction = (int)((((pixels_count + 2) * 2) - 1) * zoom);
                        }
                    }
                    else if (thisObj_placement == "Somewhere in Between")
                    {
                        if (zoom <= 0.26f)
                        {
                            if (lvl2_parent_Type != "")
                            {
                                bounds_PointX = 2 + 3;
                                wd_deduction = 5 + 6;
                            }
                            else if (lvl2_parent_Type == "")
                            {
                                bounds_PointX = 4;
                                wd_deduction = 5 + 4;
                            }
                        }
                        else if (zoom == 0.50f)
                        {
                            bounds_PointX = (int)(pixels_count * zoom);
                            if (lvl2_parent_Type != "")
                            {
                                wd_deduction = (int)((10 + (pixels_count + 1)) * zoom);
                            }
                            else if (lvl2_parent_Type == "")
                            {
                                wd_deduction = (int)((10 + (pixels_count + 1)) * zoom) + 2;
                            }
                        }
                        else if (zoom == 1.0f)
                        {
                            bounds_PointX = (int)(pixels_count * zoom);
                            wd_deduction = (int)((pixels_count * 2) * zoom);
                        }
                    }
                }
                #endregion

                bounds = new Rectangle(new Point(bounds_PointX, bounds_PointY),
                                       new Size(wd_ToBind - wd_deduction,
                                                ht_ToBind - ht_deduction));
                #endregion

                #region 'thisDrawingPoints_for..' of this obj when the Parent obj has doxtyle.None

                thisDrawingPoints_forMullion_RightSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                     fpnl.Height,
                                                                                                     "Mullion",
                                                                                                     "First",
                                                                                                     _frameModel.Frame_Type.ToString()); //4th parameter must be the placement of the parent control

                thisDrawingPoints_forMullion_LeftSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                    fpnl.Height,
                                                                                                    "Mullion",
                                                                                                    "Last",
                                                                                                    _frameModel.Frame_Type.ToString()); //4th parameter must be the placement of the parent control
                #endregion

                #endregion

                #region MAIN GRAPHICS ALGORITHM with curve (Commented)

                //if (parent_name.Contains("MultiTransom") &&
                //    parent_doxtyle == DockStyle.Fill &&
                //    thisObj_placement == "First")
                //#region First Multi-Panel in a MAIN PLATFORM (MultiTransom)
                //{
                //    for (int i = 0; i < corner_points.Length - 5; i += 2)
                //    {
                //        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                //    }

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "Last")
                //#region Last Multi-Panel in a MAIN PLATFORM (MultiTransom)
                //{
                //    for (int i = 4; i < corner_points.Length - 1; i += 2)
                //    {
                //        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                //    }

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "First")
                //#region First Multi-Panel in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, 0),
                //                           new Point(pInnerX, pInnerY));
                //    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX, pInnerY + pInnerHt));

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "Last")
                //#region Last Multi-Panel in MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                //                           new Point(pInnerX + pInnerWd, pInnerY));
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between Multi-Panel in MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);


                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //#region Pattern (M-T-T)

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "First")
                //#region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, 0), new Point(pInnerX, pInnerY));

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0],
                //                                       new Point(thisDrawingPoints_forMullion_RightSide[0][1].X,
                //                                                thisDrawingPoints_forMullion_RightSide[0][1].Y + 20));
                //    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "Last")
                //#region Last in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height), new Point(pInnerX, pInnerY + pInnerHt));

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "First")
                //#region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0],
                //                                      new Point(thisDrawingPoints_forMullion_LeftSide[0][1].X,
                //                                                thisDrawingPoints_forMullion_LeftSide[0][1].Y + 20));
                //    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);


                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0],
                //                                       new Point(thisDrawingPoints_forMullion_RightSide[0][1].X,
                //                                                 thisDrawingPoints_forMullion_RightSide[0][1].Y + 20));
                //    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "Last")
                //#region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "First")
                //#region First in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion) 
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0), 
                //                           new Point(pInnerX + pInnerWd, pInnerY));

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0],
                //                                      new Point(thisDrawingPoints_forMullion_LeftSide[0][1].X,
                //                                                thisDrawingPoints_forMullion_LeftSide[0][1].Y + 20));
                //    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Last")
                //#region Last in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0],
                //                                      new Point(thisDrawingPoints_forMullion_LeftSide[0][1].X,
                //                                                thisDrawingPoints_forMullion_LeftSide[0][1].Y + 20));
                //    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //#endregion

                //#region Pattern (T-T-T)

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "First")
                //#region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, 0),
                //                           new Point(pInnerX, pInnerY));

                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                //                           new Point(pInnerX + pInnerWd, pInnerY));

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         (thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                //#region (Last or Somewhere in Between) in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         (thisObj_placement == "First" || thisObj_placement == "Somewhere in Between" || thisObj_placement == "Last"))
                //#region (First or Somewhere in Between or Last) in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in MAIN PLATFORM (MultiMullion)
                //{
                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         (thisObj_placement == "First" || thisObj_placement == "Somewhere in Between"))
                //#region (First or Somewhere in Between) in a LAST SUB-PLATFORM (MultiTransom) in MAIN PLATFORM (MultiMullion)
                //{
                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Last")
                //#region Last in a LAST SUB-PLATFORM (MultiTransom) in MAIN PLATFORM (MultiMullion)
                //{
                //    for (int i = 4; i < corner_points.Length - 1; i += 2)
                //    {
                //        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                //    }

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //}
                //#endregion

                //#endregion

                //#region Pattern (M-M-T)

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "First")
                //#region First in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, 0),
                //                           new Point(pInnerX, pInnerY));
                //    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX, pInnerY + pInnerHt));

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         (thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                //#region (Somewhere in Between && Last) in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "First")
                //#region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         (thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                //#region (Last or Somewhere in Between) in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         (thisObj_placement == "First" || thisObj_placement == "Somewhere in Between"))
                //#region First in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Last")
                //#region Last in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                //                           new Point(pInnerX + pInnerWd, pInnerY));
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //#endregion

                //#region Pattern (T-M-T)
                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "First")
                //#region First in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, 0),
                //                           new Point(pInnerX, pInnerY));

                //    thisDrawingPoints_bot[1][0].X += 20;
                //    thisDrawingPoints_bot[1][1].X += 20;
                //    thisDrawingPoints_bot[1][2].X += 20;

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0],thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "Last")
                //#region Last in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                //                           new Point(pInnerX + pInnerWd, pInnerY));

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    thisDrawingPoints_bot[3][0].X -= 20; //deduct 20 units
                //    thisDrawingPoints_bot[3][1].X -= 20;
                //    thisDrawingPoints_bot[3][2].X -= 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                //                           new Point(pInnerX + pInnerWd, pInnerY));

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    thisDrawingPoints_bot[1][0].X += 20; //Add 20 units
                //    thisDrawingPoints_bot[1][1].X += 20;
                //    thisDrawingPoints_bot[1][2].X += 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    thisDrawingPoints_bot[3][0].X -= 20; //deduct 20 units
                //    thisDrawingPoints_bot[3][1].X -= 20;
                //    thisDrawingPoints_bot[3][2].X -= 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "First")
                //#region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    thisDrawingPoints_bot[1][0].X += 20;
                //    thisDrawingPoints_bot[1][1].X += 20;
                //    thisDrawingPoints_bot[1][2].X += 20;

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    thisDrawingPoints_top[1][0].X += 20;
                //    thisDrawingPoints_top[1][1].X += 20;
                //    thisDrawingPoints_top[1][2].X += 20;

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);


                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "Last")
                //#region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    thisDrawingPoints_top[3][0].X -= 20; //deduct 20 units
                //    thisDrawingPoints_top[3][1].X -= 20;
                //    thisDrawingPoints_top[3][2].X -= 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    thisDrawingPoints_bot[3][0].X -= 20; //deduct 20 units
                //    thisDrawingPoints_bot[3][1].X -= 20;
                //    thisDrawingPoints_bot[3][2].X -= 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);


                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    thisDrawingPoints_top[1][0].X += 20; //add 20 units
                //    thisDrawingPoints_top[1][1].X += 20;
                //    thisDrawingPoints_top[1][2].X += 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    thisDrawingPoints_top[3][0].X -= 20; //deduct 20 units
                //    thisDrawingPoints_top[3][1].X -= 20;
                //    thisDrawingPoints_top[3][2].X -= 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    thisDrawingPoints_bot[1][0].X += 20;
                //    thisDrawingPoints_bot[1][1].X += 20;
                //    thisDrawingPoints_bot[1][2].X += 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    thisDrawingPoints_bot[3][0].X -= 20; //deduct 20 units
                //    thisDrawingPoints_bot[3][1].X -= 20;
                //    thisDrawingPoints_bot[3][2].X -= 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "First")
                //#region First in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX, pInnerY + pInnerHt));

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    thisDrawingPoints_top[1][0].X += 20; //add 20 units
                //    thisDrawingPoints_top[1][1].X += 20;
                //    thisDrawingPoints_top[1][2].X += 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Last")
                //#region Last in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    thisDrawingPoints_top[3][0].X -= 20; //deduct 20 units
                //    thisDrawingPoints_top[3][1].X -= 20;
                //    thisDrawingPoints_top[3][2].X -= 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    thisDrawingPoints_top[1][0].X += 20; //add 20 units
                //    thisDrawingPoints_top[1][1].X += 20;
                //    thisDrawingPoints_top[1][2].X += 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    thisDrawingPoints_top[3][0].X -= 20; //deduct 20 units
                //    thisDrawingPoints_top[3][1].X -= 20;
                //    thisDrawingPoints_top[3][2].X -= 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //}
                //#endregion

                //#endregion

                #endregion

                #region MAIN GRAPHICS ALGORITHM (without curve)

                if (parent_name.Contains("MultiTransom") &&
                    parent_doxtyle == DockStyle.Fill &&
                    thisObj_placement == "First")
                #region First Multi-Panel in a MAIN PLATFORM (MultiTransom)
                {
                    for (int i = 0; i < corner_points.Length - 5; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    divider_bounds_Bot = divs_bounds_values[0];

                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Last")
                #region Last Multi-Panel in a MAIN PLATFORM (MultiTransom)
                {
                    for (int i = 4; i < corner_points.Length - 1; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a MAIN PLATFORM (MultiTransom)
                {
                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "First")
                #region First Multi-Panel in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX, pInnerY + pInnerHt));

                    if (zoom == 0.50f)
                    {
                        divs_bounds_values[2].X -= 2;
                        divs_bounds_values[2].Width += 2;
                    }
                    else if (zoom <= 0.26f)
                    {
                        divs_bounds_values[2].X -= 4;
                        divs_bounds_values[2].Width += 4;
                    }

                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Last")
                #region Last Multi-Panel in MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                    if (zoom <= 0.26f)
                    {
                        divs_bounds_values[3].Width += 4;
                    }

                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between Multi-Panel in MAIN PLATFORM (MultiMullion)
                {
                    if (zoom == 1.0f)
                    {
                        divs_bounds_values[3].Width += 1;
                    }
                    else if (zoom == 0.50f)
                    {
                        divs_bounds_values[2].X -= 2;
                        divs_bounds_values[2].Width += 2;
                    }
                    else if (zoom <= 0.26f)
                    {
                        divs_bounds_values[3].Width += 3;

                        divs_bounds_values[2].X -= 3;
                        divs_bounds_values[2].Width += 3;
                    }

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                #region Pattern (M-T-T)

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0), new Point(pInnerX, pInnerY));

                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Last")
                #region Last in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height), new Point(pInnerX, pInnerY + pInnerHt));

                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;
                    divs_bounds_values[3].Width += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;
                    divs_bounds_values[3].Width += 2;

                    divider_bounds_Bot = divs_bounds_values[1];
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;
                    divs_bounds_values[3].Width += 2;

                    divider_bounds_Top = divs_bounds_values[0];
                    divider_bounds_Bot = divs_bounds_values[1];
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "First")
                #region First in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion) 
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));

                    divs_bounds_values[3].Width += 2;

                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Top = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Last")
                #region Last in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                    divs_bounds_values[3].Width += 2;

                    divider_bounds_Bot = divs_bounds_values[1];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0],
                                                      new Point(thisDrawingPoints_forMullion_LeftSide[0][1].X,
                                                                thisDrawingPoints_forMullion_LeftSide[0][1].Y + 20));

                    divs_bounds_values[3].Width += 2;

                    divider_bounds_Top = divs_bounds_values[0];
                    divider_bounds_Bot = divs_bounds_values[1];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                #endregion

                #region Pattern (T-T-T)

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));

                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));

                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Last")
                #region Last in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in MAIN PLATFORM (MultiMullion)
                {
                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "First")
                #region First in a LAST SUB-PLATFORM (MultiTransom) in MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Last")
                #region Last in a LAST SUB-PLATFORM (MultiTransom) in MAIN PLATFORM (MultiMullion)
                {
                    for (int i = 4; i < corner_points.Length - 1; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between) in a LAST SUB-PLATFORM (MultiTransom) in MAIN PLATFORM (MultiMullion)
                {
                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                #endregion

                #region Pattern (M-M-T)

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX, pInnerY + pInnerHt));

                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Last")
                #region Last in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[3].Width += 2;
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "First")
                #region First in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[3].Width += 2;
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Last")
                #region Last in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                #endregion

                #region Pattern (T-M-T)

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    if (zoom == 0.17f || zoom == 0.13f)
                    {
                        divs_bounds_values[0].Y -= 2;
                        divs_bounds_values[0].Height += 2;
                    }
                    else if (zoom == 0.10f)
                    {
                        divs_bounds_values[0].Y -= 3;
                        divs_bounds_values[0].Height += 3;
                    }

                    if (zoom == 0.50f)
                    {
                        divs_bounds_values[2].X -= 2;
                        divs_bounds_values[2].Width += 2;
                    }
                    else if (zoom <= 0.26f)
                    {
                        divs_bounds_values[2].X -= 3;
                        divs_bounds_values[2].Width += 3;
                    }

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Last")
                #region Last in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    if (zoom == 0.17f || zoom == 0.13f)
                    {
                        divs_bounds_values[0].Y -= 2;
                        divs_bounds_values[0].Height += 2;
                    }
                    else if (zoom == 0.10f)
                    {
                        divs_bounds_values[0].Y -= 3;
                        divs_bounds_values[0].Height += 3;
                    }

                    if (zoom <= 0.26f)
                    {
                        divs_bounds_values[3].Width += 3;
                    }
                    //else if (zoom == 0.17f)
                    //{
                    //    divs_bounds_values[3].Width += 3;
                    //}

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    if (zoom == 0.17f || zoom == 0.13f)
                    {
                        divs_bounds_values[0].Y -= 2;
                        divs_bounds_values[0].Height += 2;
                    }
                    else if (zoom == 0.10f)
                    {
                        divs_bounds_values[0].Y -= 3;
                        divs_bounds_values[0].Height += 3;
                    }

                    if (zoom <= 0.26f)
                    {
                        divs_bounds_values[2].X -= 3;
                        divs_bounds_values[2].Width += 3;

                        divs_bounds_values[3].Width += 3;
                    }

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;
                    divs_bounds_values[1].Height += 2;

                    if (zoom == 0.26f)
                    {
                        divs_bounds_values[1].Height += 1;
                    }
                    else if (zoom == 0.17f || zoom == 0.13f)
                    {
                        divs_bounds_values[1].Height += 3;
                    }
                    else if (zoom == 0.10f)
                    {
                        divs_bounds_values[1].Height += 4;
                    }

                    if (zoom == 0.17f || zoom == 0.13f)
                    {
                        divs_bounds_values[0].Y -= 2;
                        divs_bounds_values[0].Height += 2;
                    }
                    else if (zoom == 0.10f)
                    {
                        divs_bounds_values[0].Y -= 3;
                        divs_bounds_values[0].Height += 3;
                    }

                    if (zoom == 0.50f)
                    {
                        divs_bounds_values[2].X -= 2;
                        divs_bounds_values[2].Width += 2;
                    }
                    else if (zoom <= 0.26f)
                    {
                        divs_bounds_values[2].X -= 3;
                        divs_bounds_values[2].Width += 3;
                    }

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;
                    divs_bounds_values[1].Height += 2;

                    if (zoom == 0.26f)
                    {
                        divs_bounds_values[1].Height += 1;
                    }
                    else if (zoom == 0.17f || zoom == 0.13f)
                    {
                        divs_bounds_values[1].Height += 3;
                    }
                    else if (zoom == 0.10f)
                    {
                        divs_bounds_values[1].Height += 4;
                    }

                    if (zoom == 0.17f || zoom == 0.13f)
                    {
                        divs_bounds_values[0].Y -= 2;
                        divs_bounds_values[0].Height += 2;
                    }
                    else if (zoom == 0.10f)
                    {
                        divs_bounds_values[0].Y -= 3;
                        divs_bounds_values[0].Height += 3;
                    }

                    if (zoom <= 0.26f)
                    {
                        divs_bounds_values[3].Width += 3;
                    }
                    //else if (zoom == 0.17f)
                    //{
                    //    divs_bounds_values[3].Width += 3;
                    //}

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;
                    divs_bounds_values[1].Height += 2;

                    if (zoom == 0.26f)
                    {
                        divs_bounds_values[1].Height += 1;
                    }
                    else if (zoom == 0.17f || zoom == 0.13f)
                    {
                        divs_bounds_values[1].Height += 3;
                    }
                    else if (zoom == 0.10f)
                    {
                        divs_bounds_values[1].Height += 4;
                    }

                    if (zoom == 0.17f || zoom == 0.13f)
                    {
                        divs_bounds_values[0].Y -= 2;
                        divs_bounds_values[0].Height += 2;
                    }
                    else if (zoom == 0.10f)
                    {
                        divs_bounds_values[0].Y -= 3;
                        divs_bounds_values[0].Height += 3;
                    }

                    if (zoom <= 0.26f)
                    {
                        divs_bounds_values[2].X -= 3;
                        divs_bounds_values[2].Width += 3;

                        divs_bounds_values[3].Width += 3;
                    }


                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "First")
                #region First in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX, pInnerY + pInnerHt));

                    divs_bounds_values[1].Height += 2;

                    if (zoom == 0.26f)
                    {
                        divs_bounds_values[1].Height += 1;
                    }
                    else if (zoom == 0.17f || zoom == 0.13f)
                    {
                        divs_bounds_values[1].Height += 3;
                    }
                    else if (zoom == 0.10f)
                    {
                        divs_bounds_values[1].Height += 4;
                    }

                    if (zoom == 0.50f)
                    {
                        divs_bounds_values[2].X -= 2;
                        divs_bounds_values[2].Width += 2;
                    }
                    else if (zoom <= 0.26f)
                    {
                        divs_bounds_values[2].X -= 3;
                        divs_bounds_values[2].Width += 3;
                    }

                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Last")
                #region Last in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                    divs_bounds_values[1].Height += 2;

                    if (zoom == 0.26f)
                    {
                        divs_bounds_values[1].Height += 1;
                    }
                    else if (zoom == 0.17f || zoom == 0.13f)
                    {
                        divs_bounds_values[1].Height += 3;
                    }
                    else if (zoom == 0.10f)
                    {
                        divs_bounds_values[1].Height += 4;
                    }

                    if (zoom <= 0.26f)
                    {
                        divs_bounds_values[3].Width += 3;
                    }
                    //else if (zoom == 0.17f)
                    //{
                    //    divs_bounds_values[3].Width += 3;
                    //}

                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[1].Height += 2;

                    if (zoom == 0.26f)
                    {
                        divs_bounds_values[1].Height += 1;
                    }
                    else if (zoom == 0.17f || zoom == 0.13f)
                    {
                        divs_bounds_values[1].Height += 3;
                    }
                    else if (zoom == 0.10f)
                    {
                        divs_bounds_values[1].Height += 4;
                    }

                    if (zoom <= 0.26f)
                    {
                        divs_bounds_values[2].X -= 3;
                        divs_bounds_values[2].Width += 3;

                        divs_bounds_values[3].Width += 3;
                    }

                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                #endregion

                #endregion
            }

            if (parent_name.Contains("MultiMullion") &&
                parent_doxtyle == DockStyle.None &&
                lvl2_parent_Type == "Transom")
            {
                g.FillRectangle(Brushes.PowderBlue, divider_bounds_Top);
                g.DrawRectangle(Pens.Black, divider_bounds_Top);

                g.FillRectangle(Brushes.PowderBlue, divider_bounds_Bot);
                g.DrawRectangle(Pens.Black, divider_bounds_Bot);

                g.FillRectangle(Brushes.RosyBrown, divider_bounds_Left);
                g.DrawRectangle(Pens.Black, divider_bounds_Left);

                g.FillRectangle(Brushes.RosyBrown, divider_bounds_Right);
                g.DrawRectangle(Pens.Black, divider_bounds_Right);
            }
            else
            {
                g.FillRectangle(Brushes.RosyBrown, divider_bounds_Left);
                g.DrawRectangle(Pens.Black, divider_bounds_Left);

                g.FillRectangle(Brushes.RosyBrown, divider_bounds_Right);
                g.DrawRectangle(Pens.Black, divider_bounds_Right);

                g.FillRectangle(Brushes.PowderBlue, divider_bounds_Top);
                g.DrawRectangle(Pens.Black, divider_bounds_Top);

                g.FillRectangle(Brushes.PowderBlue, divider_bounds_Bot);
                g.DrawRectangle(Pens.Black, divider_bounds_Bot);
            }

            g.FillRectangle(new SolidBrush(SystemColors.ActiveCaption), bounds);
            g.DrawRectangle(new Pen(Color.Black, 1), bounds);
        }

        public IMultiPanelTransomImagerUC GetMultiPanelImager()
        {
            _multiTransomImagerUC.ThisBinding(CreateBindingDictionary());
            return _multiTransomImagerUC;
        }

        public IMultiPanelTransomImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                  IMultiPanelModel multiPanelModel,
                                                                  IFrameModel frameModel,
                                                                  IFrameImagerUCPresenter frameImagerUCP)
        {
            unityC
                .RegisterType<IMultiPanelTransomImagerUC, MultiPanelTransomImagerUC>()
                .RegisterType<IMultiPanelTransomImagerUCPresenter, MultiPanelTransomImagerUCPresenter>();
            MultiPanelTransomImagerUCPresenter multiTransomImagerUCP = unityC.Resolve<MultiPanelTransomImagerUCPresenter>();
            multiTransomImagerUCP._unityC = unityC;
            multiTransomImagerUCP._multiPanelModel = multiPanelModel;
            multiTransomImagerUCP._frameModel = frameModel;
            multiTransomImagerUCP._frameImagerUCP = frameImagerUCP;

            return multiTransomImagerUCP;
        }

        public IMultiPanelTransomImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                   IMultiPanelModel multiPanelModel,
                                                                   IFrameModel frameModel,
                                                                   IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP)
        {
            unityC
                .RegisterType<IMultiPanelTransomImagerUC, MultiPanelTransomImagerUC>()
                .RegisterType<IMultiPanelTransomImagerUCPresenter, MultiPanelTransomImagerUCPresenter>();
            MultiPanelTransomImagerUCPresenter multiTransomImagerUCP = unityC.Resolve<MultiPanelTransomImagerUCPresenter>();
            multiTransomImagerUCP._unityC = unityC;
            multiTransomImagerUCP._multiPanelModel = multiPanelModel;
            multiTransomImagerUCP._frameModel = frameModel;
            multiTransomImagerUCP._multiPanelMullionImagerUCP = multiPanelMullionImagerUCP;

            return multiTransomImagerUCP;
        }

        public IMultiPanelTransomImagerUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                                  IMultiPanelModel multiPanelModel, 
                                                                  IFrameModel frameModel, 
                                                                  IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP)
        {
            unityC
                .RegisterType<IMultiPanelTransomImagerUC, MultiPanelTransomImagerUC>()
                .RegisterType<IMultiPanelTransomImagerUCPresenter, MultiPanelTransomImagerUCPresenter>();
            MultiPanelTransomImagerUCPresenter multiTransomImagerUCP = unityC.Resolve<MultiPanelTransomImagerUCPresenter>();
            multiTransomImagerUCP._unityC = unityC;
            multiTransomImagerUCP._multiPanelModel = multiPanelModel;
            multiTransomImagerUCP._frameModel = frameModel;
            multiTransomImagerUCP._multiPanelTransomImagerUCP = multiPanelTransomImagerUCP;

            return multiTransomImagerUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> multiPanelBinding = new Dictionary<string, Binding>();
            multiPanelBinding.Add("MPanel_ID", new Binding("MPanel_ID", _multiPanelModel, "MPanel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Name", new Binding("Name", _multiPanelModel, "MPanel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Dock", new Binding("Dock", _multiPanelModel, "MPanel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanelImageRenderer_Width", new Binding("Width", _multiPanelModel, "MPanelImageRenderer_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanelImageRenderer_Height", new Binding("Height", _multiPanelModel, "MPanelImageRenderer_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Visibility", new Binding("Visible", _multiPanelModel, "MPanel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Margin", new Binding("Margin", _multiPanelModel, "MPanelImageRenderer_Margin", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Placement", new Binding("MPanel_Placement", _multiPanelModel, "MPanel_Placement", true, DataSourceUpdateMode.OnPropertyChanged));

            return multiPanelBinding;
        }

        public void AddControl(UserControl userctrlObj)
        {
            _multiTransomImagerUC.AddImagerControl(userctrlObj);
        }

        public void DeleteControl(UserControl userctrlObj)
        {
            _multiTransomImagerUC.DeleteImagerControl(userctrlObj);
        }
    }
}
