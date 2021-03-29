using CommonComponents;
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
    public class MultiPanelMullionImagerUCPresenter : IMultiPanelMullionImagerUCPresenter, IPresenterCommon
    {
        IMultiPanelMullionImagerUC _multiPanelMullionImagerUC;

        private IUnityContainer _unityC;

        private IMultiPanelModel _multiPanelModel;
        private IFrameModel _frameModel;

        private IFrameImagerUCPresenter _frameImagerUCP;

        private MultiPanelCommon _mpnlCommons = new MultiPanelCommon();

        public MultiPanelMullionImagerUCPresenter(IMultiPanelMullionImagerUC multiPanelMullionImagerUC)
        {
            _multiPanelMullionImagerUC = multiPanelMullionImagerUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _multiPanelMullionImagerUC.flpMulltiPaintEventRaised += _multiPanelMullionImagerUC_flpMulltiPaintEventRaised;
            _multiPanelMullionImagerUC.flpMulltiVisibleChangedEventRaised += _multiPanelMullionImagerUC_flpMulltiVisibleChangedEventRaised;
        }

        private void _multiPanelMullionImagerUC_flpMulltiVisibleChangedEventRaised(object sender, EventArgs e)
        {
            if (((UserControl)sender).Visible == false)
            {
                if (_frameImagerUCP != null)
                {
                    _frameImagerUCP.DeleteControl((UserControl)_multiPanelMullionImagerUC);
                }
            }
        }

        private void _multiPanelMullionImagerUC_flpMulltiPaintEventRaised(object sender, PaintEventArgs e)
        {
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender;
            Control fpnlParent = fpnl.Parent.Parent; //Parent ng mismong usercontrol, Its either Frame or Multi-Panel
            IMultiPanelModel parent_mpnl = _multiPanelModel.MPanel_ParentModel;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int pInnerX = 10,
                pInnerY = 10,
                pInnerWd = fpnl.ClientRectangle.Width - 20,
                pInnerHt = fpnl.ClientRectangle.Height - 20;

            Point[] upperLine = new Point[2];
            Point[] botLine = new Point[2];
            Point[] leftCurve = new Point[3];
            Point[] rightCurve = new Point[3];

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

            if (_multiPanelModel.MPanel_Parent.GetType() == typeof(FrameUC))
            {
                for (int i = 0; i < corner_points.Length - 1; i += 2)
                {
                    g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                }

                bounds = new Rectangle(new Point(10, 10),
                                       new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));
            }
            else if (_multiPanelModel.MPanel_Parent.GetType() == typeof(FlowLayoutPanel)) //If MultiPanel
            {
                string parent_name = _multiPanelModel.MPanel_Parent.Name,
                       lvl2_parent_Type = "",
                       thisObj_placement = _multiPanelModel.MPanel_Placement,
                       parentObj_placement = _multiPanelModel.MPanel_ParentModel.MPanel_Placement;
                DockStyle parent_doxtyle = _multiPanelModel.MPanel_ParentModel.MPanel_Dock;
                int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1,
                    parent_mpnl_childObj_count = parent_mpnl.GetCount_MPanelLst_Object(),
                    indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;

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
                    wd_deduction = 20;
                    bounds_PointX = 10;
                    if (thisObj_placement == "First")
                    {
                        bounds_PointY = 10;
                        ht_deduction = (10 + (pixels_count + 1));
                    }
                    else if (thisObj_placement == "Last")
                    {
                        bounds_PointY = pixels_count + 2;
                        ht_deduction = (((pixels_count + 2) * 2)) - 1;
                    }
                    else if (thisObj_placement == "Somewhere in Between")
                    {
                        bounds_PointY = pixels_count + 2;
                        ht_deduction = (pixels_count + 2) * 2;
                        if (parent_doxtyle == DockStyle.None)
                        {
                            bounds_PointY = (pixels_count + 2 == 10) ? pixels_count + 2 : 10;
                            ht_deduction = 10 + (pixels_count + 1);
                        }
                    }
                }
                #endregion

                else if (parent_name.Contains("MultiMullion"))
                #region Parent is MultiPanel Mullion
                {
                    bounds_PointY = 10;
                    ht_deduction = 20;
                    if (thisObj_placement == "First")
                    {
                        bounds_PointX = 10;
                        wd_deduction = (10 + (pixels_count + 1));
                    }
                    else if (thisObj_placement == "Last")
                    {
                        bounds_PointX = pixels_count + 2;
                        wd_deduction = ((pixels_count + 2) * 2) - 1;
                    }
                    else if (thisObj_placement == "Somewhere in Between")
                    {
                        bounds_PointX = pixels_count + 2;
                        wd_deduction = (pixels_count + 2) * 2;
                    }
                }
                #endregion

                bounds = new Rectangle(new Point(bounds_PointX, bounds_PointY),
                                       new Size(fpnl.Width - wd_deduction,
                                                fpnl.Height - ht_deduction));
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


                #region MAIN GRAPHICS ALGORITHM
                if (parent_name.Contains("MultiMullion") &&
                    parent_doxtyle == DockStyle.Fill &&
                    thisObj_placement == "First")
                #region First Multi-Panel in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX, pInnerY + pInnerHt));

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Last")
                #region Last Multi-Panel in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between Multi-Panel in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "First")
                #region First Multi-Panel in a MAIN PLATFORM (MultiTransom)
                {
                    for (int i = 0; i < corner_points.Length - 5; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
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

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between Multi-Panel in a MAIN PLATFORM (MultiTransom)
                {
                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);
                }
                #endregion

                #region Pattern (M-T-M)

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0), new Point(pInnerX, pInnerY));

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Last")
                #region Last in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX, pInnerY + pInnerHt));


                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);


                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
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

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
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

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                #endregion

                #region Pattern (T-T-M)

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    for (int i = 0; i < corner_points.Length - 5; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         (thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                #region (Last or Somewhere in Between) in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         (thisObj_placement == "First" || thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                #region (First or Last or Somewhere in Between) in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         (thisObj_placement == "First" || thisObj_placement == "Somewhere in Between"))
                #region (First or Somewhere in Between) in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Last")
                #region Last in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    for (int i = 4; i < corner_points.Length - 1; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);
                }
                #endregion

                #endregion

                #region Pattern (M-M-M)

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

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         (thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                #region (Last or Somewhere in Between) in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         (thisObj_placement == "First" || thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                #region (First or Last or Somewhere in Between) in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         (thisObj_placement == "First" || thisObj_placement == "Somewhere in Between"))
                #region (First or Somewhere in Between) in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
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

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                #endregion

                #region Pattern (T-M-M)

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    thisDrawingPoints_bot[1][0].X += 20;
                    thisDrawingPoints_bot[1][1].X += 20;
                    thisDrawingPoints_bot[1][2].X += 20;
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
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

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    thisDrawingPoints_bot[3][0].X -= 20;
                    thisDrawingPoints_bot[3][1].X -= 20;
                    thisDrawingPoints_bot[3][2].X -= 20;
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    thisDrawingPoints_bot[1][0].X += 20;
                    thisDrawingPoints_bot[1][1].X += 20;
                    thisDrawingPoints_bot[1][2].X += 20;
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    thisDrawingPoints_bot[3][0].X -= 20;
                    thisDrawingPoints_bot[3][1].X -= 20;
                    thisDrawingPoints_bot[3][2].X -= 20;
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    thisDrawingPoints_bot[1][0].X += 20;
                    thisDrawingPoints_bot[1][1].X += 20;
                    thisDrawingPoints_bot[1][2].X += 20;
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    thisDrawingPoints_top[1][0].X += 20;
                    thisDrawingPoints_top[1][1].X += 20;
                    thisDrawingPoints_top[1][2].X += 20;
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    thisDrawingPoints_bot[3][0].X -= 20;
                    thisDrawingPoints_bot[3][1].X -= 20;
                    thisDrawingPoints_bot[3][2].X -= 20;
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    thisDrawingPoints_top[3][0].X -= 20;
                    thisDrawingPoints_top[3][1].X -= 20;
                    thisDrawingPoints_top[3][2].X -= 20;
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    thisDrawingPoints_bot[1][0].X += 20;
                    thisDrawingPoints_bot[1][1].X += 20;
                    thisDrawingPoints_bot[1][2].X += 20;
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    thisDrawingPoints_bot[3][0].X -= 20;
                    thisDrawingPoints_bot[3][1].X -= 20;
                    thisDrawingPoints_bot[3][2].X -= 20;
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    thisDrawingPoints_top[1][0].X += 20;
                    thisDrawingPoints_top[1][1].X += 20;
                    thisDrawingPoints_top[1][2].X += 20;
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    thisDrawingPoints_top[3][0].X -= 20;
                    thisDrawingPoints_top[3][1].X -= 20;
                    thisDrawingPoints_top[3][2].X -= 20;
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
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

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    thisDrawingPoints_top[1][0].X += 20;
                    thisDrawingPoints_top[1][1].X += 20;
                    thisDrawingPoints_top[1][2].X += 20;
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
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

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    thisDrawingPoints_top[3][0].X -= 20;
                    thisDrawingPoints_top[3][1].X -= 20;
                    thisDrawingPoints_top[3][2].X -= 20;
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    thisDrawingPoints_top[1][0].X += 20;
                    thisDrawingPoints_top[1][1].X += 20;
                    thisDrawingPoints_top[1][2].X += 20;
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    thisDrawingPoints_top[3][0].X -= 20;
                    thisDrawingPoints_top[3][1].X -= 20;
                    thisDrawingPoints_top[3][2].X -= 20;
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                }
                #endregion

                #endregion

                #endregion
            }

            g.FillRectangle(new SolidBrush(Color.MistyRose), bounds);
            g.DrawRectangle(new Pen(Color.Black, 1), bounds);

        }

        public IMultiPanelMullionImagerUC GetMultiPanelImager()
        {
            _multiPanelMullionImagerUC.ThisBinding(CreateBindingDictionary());
            return _multiPanelMullionImagerUC;
        }

        public IMultiPanelMullionImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                  IMultiPanelModel multiPanelModel,
                                                                  IFrameModel frameModel,
                                                                  IFrameImagerUCPresenter frameImagerUCP)
        {
            unityC
                .RegisterType<IMultiPanelMullionImagerUC, MultiPanelMullionImagerUC>()
                .RegisterType<IMultiPanelMullionImagerUCPresenter, MultiPanelMullionImagerUCPresenter>();
            MultiPanelMullionImagerUCPresenter multiMullionImagerUCP = unityC.Resolve<MultiPanelMullionImagerUCPresenter>();
            multiMullionImagerUCP._unityC = unityC;
            multiMullionImagerUCP._multiPanelModel = multiPanelModel;
            multiMullionImagerUCP._frameModel = frameModel;
            multiMullionImagerUCP._frameImagerUCP = frameImagerUCP;

            return multiMullionImagerUCP;
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
            multiPanelBinding.Add("MPanel_Margin", new Binding("Margin", _multiPanelModel, "MPanel_Margin", true, DataSourceUpdateMode.OnPropertyChanged));

            return multiPanelBinding;
        }

        public void AddControl(UserControl userctrlObj)
        {
            _multiPanelMullionImagerUC.AddImagerControl(userctrlObj);
        }

        public void DeleteControl(UserControl userctrlObj)
        {
            _multiPanelMullionImagerUC.DeleteImagerControl(userctrlObj);
        }
    }
}
