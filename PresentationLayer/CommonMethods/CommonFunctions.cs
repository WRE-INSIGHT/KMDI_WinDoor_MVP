using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.Dividers.Imagers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.Dividers;
using PresentationLayer.Views.UserControls.Dividers.Imagers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using ServiceLayer.Services.DividerServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Frame.FrameModel;
namespace PresentationLayer.CommonMethods
{
    public class CommonFunctions
    {
        public void Automatic_Div_Addition(IMainPresenter mainPresenter,
                                           IFrameModel frameModel,
                                           IDividerServices divServices,
                                           ITransomUCPresenter _transomUCP,
                                           IUnityContainer _unityC,
                                           IMullionUCPresenter _mullionUCP,
                                           IMullionImagerUCPresenter _mullionImagerUCP,
                                           ITransomImagerUCPresenter _transomImagerUCP,
                                           int divID,
                                           IMultiPanelModel multiPanelModel = null,
                                           IPanelModel panelModel = null,
                                           IMultiPanelTransomUCPresenter multiTransomUCP = null,
                                           IMultiPanelMullionUCPresenter multiMullionUCP = null,
                                           IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP = null,
                                           IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP = null)
        {
            FlowLayoutPanel parentfpnl = new FlowLayoutPanel();
            IMultiPanelModel parentModel = null;

            if (panelModel == null)
            {
                parentfpnl = (FlowLayoutPanel)multiPanelModel.MPanel_Parent;
                parentModel = multiPanelModel.MPanel_ParentModel;
            }
            else if (panelModel != null)
            {
                parentfpnl = (FlowLayoutPanel)panelModel.Panel_Parent;
                parentModel = multiPanelModel;
            }

            int divSize = 0;

            if (frameModel.Frame_Type.ToString().Contains("Window"))
            {
                divSize = 26;
            }
            else if (frameModel.Frame_Type.ToString().Contains("Door"))
            {
                divSize = 33;
            }

            Control last_ctrl = null;
            if (parentModel.MPanelLst_Objects.Count() >= 1)
            {
                last_ctrl = parentModel.MPanelLst_Objects.Last();
            }

            if (last_ctrl != null && !last_ctrl.Name.Contains("TransomUC") && !last_ctrl.Name.Contains("MullionUC"))
            {
                int divHT = 0, divWd = 0;
                DividerModel.DividerType divType = DividerModel.DividerType.Mullion;
                if (parentModel.MPanel_Type == "Transom")
                {
                    divType = DividerModel.DividerType.Transom;
                    divHT = divSize;
                    divWd = parentModel.MPanel_Width;
                }
                else if (parentModel.MPanel_Type == "Mullion")
                {
                    divType = DividerModel.DividerType.Mullion;
                    divHT = parentModel.MPanel_Height;
                    divWd = divSize;
                }

                IDividerModel divModel = divServices.AddDividerModel(divWd,
                                                                     divHT,
                                                                     parentfpnl,
                                                                     divType,
                                                                     true,
                                                                     frameModel.Frame_Zoom,
                                                                     Divider_ArticleNo._7536,
                                                                     parentModel.MPanel_DisplayWidth,
                                                                     parentModel.MPanel_DisplayHeight,
                                                                     parentModel,
                                                                     divID,
                                                                     frameModel.FrameImageRenderer_Zoom,
                                                                     frameModel.Frame_Type.ToString());

                frameModel.Lst_Divider.Add(divModel);
                parentModel.MPanelLst_Divider.Add(divModel);

                if (divType == DividerModel.DividerType.Mullion)
                {
                    IDividerPropertiesUCPresenter divPropUCP = mainPresenter.divPropertiesUCP.GetNewInstance(_unityC, divModel, mainPresenter);
                    multiMullionUCP.multiPropUCP2_given.GetMultiPanelPropertiesFLP().Controls.Add((UserControl)divPropUCP.GetDivProperties());
                }
                else if (divType == DividerModel.DividerType.Transom)
                {
                    IDividerPropertiesUCPresenter divPropUCP = mainPresenter.divPropertiesUCP.GetNewInstance(_unityC, divModel, mainPresenter);
                    multiTransomUCP.multiPropUCP2_given.GetMultiPanelPropertiesFLP().Controls.Add((UserControl)divPropUCP.GetDivProperties());
                }

                parentModel.AdjustPropertyPanelHeight("Div", "add");
                frameModel.AdjustPropertyPanelHeight("Div", "add");

                if (parentModel.MPanel_Type == "Transom")
                {
                    ITransomUCPresenter transomUCP = null;
                    ITransomImagerUCPresenter transomImagerUCP = null;

                    if (multiTransomUCP != null)
                    {
                        transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                divModel,
                                                                parentModel,
                                                                multiTransomUCP,
                                                                frameModel,
                                                                mainPresenter);
                    }
                    else if (multiMullionUCP != null)
                    {
                        transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                divModel,
                                                                parentModel,
                                                                multiMullionUCP,
                                                                frameModel,
                                                                mainPresenter);
                    }

                    ITransomUC transomUC = transomUCP.GetTransom();
                    parentfpnl.Controls.Add((UserControl)transomUC);
                    transomUCP.SetInitialLoadFalse();//SetInitialLoadFalse para magresize yung div
                    parentModel.AddControl_MPanelLstObjects((UserControl)transomUC, 
                                                            frameModel.Frame_Type.ToString(),
                                                            true);

                    transomImagerUCP = _transomImagerUCP.GetNewInstance(_unityC,
                                                                        divModel,
                                                                        parentModel,
                                                                        frameModel,
                                                                        multiTransomImagerUCP,
                                                                        transomUC);
                    ITransomImagerUC transomImagerUC = transomImagerUCP.GetTransomImager();
                    multiTransomImagerUCP.AddControl((UserControl)transomImagerUC);
                }
                else if (parentModel.MPanel_Type == "Mullion")
                {
                    IMullionUCPresenter mullionUCP = null;
                    IMullionImagerUCPresenter mullionImagerUCP = null;

                    if (multiTransomUCP != null)
                    {
                        mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                divModel,
                                                                parentModel,
                                                                multiTransomUCP,
                                                                frameModel,
                                                                mainPresenter);

                    }
                    else if (multiMullionUCP != null)
                    {
                        mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                divModel,
                                                                parentModel,
                                                                multiMullionUCP,
                                                                frameModel,
                                                                mainPresenter);
                    }

                    IMullionUC mullionUC = mullionUCP.GetMullion();
                    parentfpnl.Controls.Add((UserControl)mullionUC);
                    mullionUCP.SetInitialLoadFalse();//SetInitialLoadFalse para magresize yung div
                    parentModel.AddControl_MPanelLstObjects((UserControl)mullionUC, 
                                                             frameModel.Frame_Type.ToString(),
                                                             true);

                    mullionImagerUCP = _mullionImagerUCP.GetNewInstance(_unityC,
                                                                        divModel,
                                                                        parentModel,
                                                                        frameModel,
                                                                        multiMullionImagerUCP,
                                                                        mullionUC);

                    IMullionImagerUC mullionImagerUC = mullionImagerUCP.GetMullionImager();
                    multiMullionImagerUCP.AddControl((UserControl)mullionImagerUC);
                }
            }
        }
        
        public void Red_Arrow_Lines_forHeight(Graphics g,
                                              IMultiPanelModel multiPanelModel)
        {
            Pen redP = new Pen(Color.Red);
            redP.Width = 1.0f;
            Font dmnsion_font = new Font("Segoe UI", 11, FontStyle.Bold);

            //arrow for HEIGHT
            string dmnsion_h = multiPanelModel.MPanel_DisplayHeight.ToString();
            Point dmnsion_h_startP = new Point(multiPanelModel.MPanel_Width - 20, 10);
            Point dmnsion_h_endP = new Point(multiPanelModel.MPanel_Width - 20, multiPanelModel.MPanel_Height - 10);

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

            g.DrawLines(redP, arrwhd_pnts_H1);
            g.DrawLine(redP, dmnsion_h_startP, dmnsion_h_endP);
            g.DrawLines(redP, arrwhd_pnts_H2);
            TextRenderer.DrawText(g,
                                  dmnsion_h,
                                  dmnsion_font,
                                  new Rectangle(new Point(((multiPanelModel.MPanel_Width - 20) - s2.Width), (int)(mid2 - (s2.Height / 2))),
                                                new Size(s2.Width, s2.Height)),
                                  Color.Black,
                                  Color.Transparent,
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            //arrow for HEIGHT


        }
        public void Red_Arrow_Lines_forHeight(Graphics g,
                                              IPanelModel panelModel)
        {
            Pen redP = new Pen(Color.Red);
            redP.Width = 1.0f;
            Font dmnsion_font = new Font("Segoe UI", 11, FontStyle.Bold);

            //arrow for HEIGHT
            string dmnsion_h = panelModel.Panel_DisplayHeight.ToString();
            Point dmnsion_h_startP = new Point(panelModel.Panel_Width - 20, 1);
            Point dmnsion_h_endP = new Point(panelModel.Panel_Width - 20, panelModel.Panel_Height - 1);

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

            g.DrawLines(redP, arrwhd_pnts_H1);
            g.DrawLine(redP, dmnsion_h_startP, dmnsion_h_endP);
            g.DrawLines(redP, arrwhd_pnts_H2);
            TextRenderer.DrawText(g,
                                  dmnsion_h,
                                  dmnsion_font,
                                  new Rectangle(new Point(((panelModel.Panel_Width - 20) - s2.Width), (int)(mid2 - (s2.Height / 2))),
                                                new Size(s2.Width, s2.Height)),
                                  Color.Black,
                                  Color.Transparent,
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            //arrow for HEIGHT


        }

        public void Red_Arrow_Lines_forWidth(Graphics g,
                                             IMultiPanelModel multiPanelModel)
        {
            Pen redP = new Pen(Color.Red);
            redP.Width = 1.0f;
            Font dmnsion_font = new Font("Segoe UI", 11, FontStyle.Bold);

            //arrow for WIDTH
            string dmnsion_w = multiPanelModel.MPanel_DisplayWidth.ToString();
            Point dmnsion_w_startP = new Point(10, multiPanelModel.MPanel_Height - 20);
            Point dmnsion_w_endP = new Point(multiPanelModel.MPanel_Width - 10, multiPanelModel.MPanel_Height - 20);

            Size s = TextRenderer.MeasureText(dmnsion_w, dmnsion_font);
            double mid = (dmnsion_w_startP.X + dmnsion_w_endP.X) / 2;

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
            ;
            g.DrawLines(redP, arrwhd_pnts_W1);
            g.DrawLine(redP, dmnsion_w_startP, dmnsion_w_endP);
            g.DrawLines(redP, arrwhd_pnts_W2);
            TextRenderer.DrawText(g,
                                  dmnsion_w,
                                  dmnsion_font,
                                  new Rectangle(new Point((int)(mid - (s.Width / 2)), ((multiPanelModel.MPanel_Height - 20) - s.Height)),
                                                new Size(s.Width, s.Height)),
                                  Color.Black,
                                  Color.Transparent,
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            //arrow for WIDTH
        }

        public void Red_Arrow_Lines_forWidth(Graphics g,
                                             IPanelModel panelModel)
        {
            Pen redP = new Pen(Color.Red);
            redP.Width = 1.0f;
            Font dmnsion_font = new Font("Segoe UI", 11, FontStyle.Bold);

            //arrow for WIDTH
            string dmnsion_w = panelModel.Panel_DisplayWidth.ToString();
            Point dmnsion_w_startP = new Point(1, panelModel.Panel_Height - 20);
            Point dmnsion_w_endP = new Point(panelModel.Panel_Width - 1, panelModel.Panel_Height - 20);

            Size s = TextRenderer.MeasureText(dmnsion_w, dmnsion_font);
            double mid = (dmnsion_w_startP.X + dmnsion_w_endP.X) / 2;

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
            ;
            g.DrawLines(redP, arrwhd_pnts_W1);
            g.DrawLine(redP, dmnsion_w_startP, dmnsion_w_endP);
            g.DrawLines(redP, arrwhd_pnts_W2);
            TextRenderer.DrawText(g,
                                  dmnsion_w,
                                  dmnsion_font,
                                  new Rectangle(new Point((int)(mid - (s.Width / 2)), ((panelModel.Panel_Height - 20) - s.Height)),
                                                new Size(s.Width, s.Height)),
                                  Color.Black,
                                  Color.Transparent,
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            //arrow for WIDTH
        }


        public List<Point[]> GetMullionDrawingPoints(int width,
                                                     int height,
                                                     string prev_obj,
                                                     string nxt_obj,
                                                     IFrameModel frameModel,
                                                     float zoom)
        {
            List<Point[]> Mullion_Points = new List<Point[]>();

            int accessible_Wd = width - 2,
                accessible_Ht = height - 2,
                Ht_beforeCurve = height - 5;

            Point[] leftLine = new Point[2];
            Point[] botCurve = new Point[3];
            Point[] rightLine = new Point[2];
            Point[] upperCurve = new Point[3];

            int pointX_Mid = ((int)(frameModel.Frame_Type) - 2) / 2;

            int pixels_count = 0,
                wd_formula = (int)(width / zoom); //(int)(width + (width * frameModel.FrameImageRenderer_Zoom));

            if (wd_formula == 18)
            {
                pixels_count = 26;
            }
            else if (wd_formula == 23)
            {
                pixels_count = 33;
            }
            else if (wd_formula == 10)
            {
                pixels_count = 18;
            }
            else if (wd_formula == 13)
            {
                pixels_count = 23;
            }

            if (wd_formula == 26 || wd_formula == 33)
            {
                leftLine[0] = new Point(1, 5);
                leftLine[1] = new Point(1, Ht_beforeCurve);

                botCurve[0] = new Point(1, Ht_beforeCurve);
                botCurve[1] = new Point(accessible_Wd / 2, accessible_Ht);
                botCurve[2] = new Point(accessible_Wd, Ht_beforeCurve);

                rightLine[0] = new Point(accessible_Wd, Ht_beforeCurve);
                rightLine[1] = new Point(accessible_Wd, 5);

                upperCurve[0] = new Point(accessible_Wd, 5);
                upperCurve[1] = new Point(accessible_Wd / 2, 1);
                upperCurve[2] = new Point(1, 5);
            }
            else if (wd_formula == 18 || wd_formula == 23)
            {
                if (((prev_obj.Contains("MultiTransom") || prev_obj.Contains("MultiMullion")) && nxt_obj.Contains("PanelUC")) ||
                    (((prev_obj.Contains("MultiTransom") || prev_obj.Contains("MultiMullion")) && nxt_obj == "")))
                {
                    leftLine[0] = new Point((width - pixels_count) + 1, 5);
                    leftLine[1] = new Point((width - pixels_count) + 1, Ht_beforeCurve);

                    botCurve[0] = new Point((width - pixels_count) + 1, Ht_beforeCurve);
                    botCurve[1] = new Point((width - pixels_count) + pointX_Mid, accessible_Ht);
                    botCurve[2] = new Point(accessible_Wd, Ht_beforeCurve);

                    rightLine[0] = new Point(accessible_Wd, Ht_beforeCurve);
                    rightLine[1] = new Point(accessible_Wd, 5);

                    upperCurve[0] = new Point(accessible_Wd, 5);
                    upperCurve[1] = new Point((width - pixels_count) + pointX_Mid, 1);
                    upperCurve[2] = new Point((width - pixels_count) + 1, 5);
                }
                else if (prev_obj.Contains("PanelUC") && (nxt_obj.Contains("MultiTransom") || nxt_obj.Contains("MultiMullion")))
                {
                    leftLine[0] = new Point(1, 5);
                    leftLine[1] = new Point(1, Ht_beforeCurve);

                    botCurve[0] = new Point(1, Ht_beforeCurve);
                    botCurve[1] = new Point(pointX_Mid, accessible_Ht);
                    botCurve[2] = new Point(accessible_Wd + (pixels_count - width), Ht_beforeCurve);

                    rightLine[0] = new Point(accessible_Wd + (pixels_count - width), Ht_beforeCurve);
                    rightLine[1] = new Point(accessible_Wd + (pixels_count - width), 5);

                    upperCurve[0] = new Point(accessible_Wd + (pixels_count - width), 5);
                    upperCurve[1] = new Point(pointX_Mid + 1, 1);
                    upperCurve[2] = new Point(1, 5);
                }
                else
                {
                    leftLine[0] = new Point(1, 5);
                    leftLine[1] = new Point(1, Ht_beforeCurve);

                    botCurve[0] = new Point(1, Ht_beforeCurve);
                    botCurve[1] = new Point(accessible_Wd / 2, accessible_Ht);
                    botCurve[2] = new Point(accessible_Wd, Ht_beforeCurve);

                    rightLine[0] = new Point(accessible_Wd, Ht_beforeCurve);
                    rightLine[1] = new Point(accessible_Wd, 5);

                    upperCurve[0] = new Point(accessible_Wd, 5);
                    upperCurve[1] = new Point(accessible_Wd / 2, 1);
                    upperCurve[2] = new Point(1, 5);
                }
            }
            else if (wd_formula == 10 || wd_formula == 13)
            {

                leftLine[0] = new Point((width - pixels_count) + 1, 4);
                leftLine[1] = new Point((width - pixels_count) + 1, Ht_beforeCurve);

                botCurve[0] = new Point((width - pixels_count) + 1, Ht_beforeCurve);
                botCurve[1] = new Point((width - pixels_count) + pointX_Mid, accessible_Ht);
                botCurve[2] = new Point(accessible_Wd + 8, Ht_beforeCurve);

                rightLine[0] = new Point(accessible_Wd + 8, Ht_beforeCurve);
                rightLine[1] = new Point(accessible_Wd + 8, 4);

                upperCurve[0] = new Point(accessible_Wd + 8, 4);
                upperCurve[1] = new Point((width - pixels_count) + pointX_Mid, 1);
                upperCurve[2] = new Point((width - pixels_count) + 1, 4);
            }

            Mullion_Points.Add(leftLine);
            Mullion_Points.Add(botCurve);
            Mullion_Points.Add(rightLine);
            Mullion_Points.Add(upperCurve);

            return Mullion_Points;
        }

        public List<Point[]> GetMullionDrawingPoints2(int width,
                                                      int height,
                                                      UserControl prev_obj,
                                                      UserControl nxt_obj,
                                                      Frame_Padding frame_type,
                                                      float zoom)
        {
            List<Point[]> Mullion_Points = new List<Point[]>();
            int accessible_Wd = width - 2,
                accessible_Ht = height - 2,
                Ht_beforeCurve = height - 5;

            int start_wd = 1,
                end_wd = width - 1,
                start_ht = 1,
                end_ht = height - 1;

            Point[] leftLine = new Point[2];
            Point[] botCurve = new Point[3];
            Point[] rightLine = new Point[2];
            Point[] upperCurve = new Point[3];

            if (prev_obj is IPanelUC)
            {
                leftLine[0] = new Point((int)(1 * zoom), (int)(5 * zoom));
                leftLine[1] = new Point((int)(1 * zoom), (int)(Ht_beforeCurve * zoom));

                botCurve[0] = new Point((int)(1 * zoom), Ht_beforeCurve);
                botCurve[1] = new Point((int)((accessible_Wd / 2) * zoom), accessible_Ht);
                botCurve[2] = new Point((int)(accessible_Wd * zoom), Ht_beforeCurve);
            }

            if (nxt_obj is IPanelUC || nxt_obj == null)
            {
                rightLine[0] = new Point((int)(accessible_Wd * zoom), Ht_beforeCurve);
                rightLine[1] = new Point((int)(accessible_Wd * zoom), 5);

                upperCurve[0] = new Point((int)(accessible_Wd * zoom), 5);
                upperCurve[1] = new Point(accessible_Wd / 2, 1);
                upperCurve[2] = new Point(1, 5);
            }

            Mullion_Points.Add(leftLine);
            Mullion_Points.Add(botCurve);
            Mullion_Points.Add(rightLine);
            Mullion_Points.Add(upperCurve);

            for (int i = 0; i < Mullion_Points.Count() ; i++)
            {
                for (int j = 0; j < Mullion_Points[i].Count() ; j++)
                {
                    Mullion_Points[i][j] = new Point((int)(Mullion_Points[i][j].X * zoom), (int)(Mullion_Points[i][j].Y * zoom));
                }
            }

            return Mullion_Points;
        }

        public List<Point[]> GetTransomDrawingPoints(int width,
                                                     int height,
                                                     string prev_obj,
                                                     string nxt_obj,
                                                     IFrameModel frameModel)
        {
            List<Point[]> Transom_Points = new List<Point[]>();

            int accessible_Wd = width - 2,
                accessible_Ht = height - 2,
                Wd_beforeCurve = width - 5;

            Point[] upperLine = new Point[2];
            Point[] botLine = new Point[2];
            Point[] leftCurve = new Point[3];
            Point[] rightCurve = new Point[3];

            int pointY_Mid = ((int)(frameModel.Frame_Type) - 2) / 2;

            int pixels_count = 0;
            if (height == 18)
            {
                pixels_count = 26;
            }
            else if (height == 23)
            {
                pixels_count = 33;
            }
            else if (height == 10)
            {
                pixels_count = 18;
            }
            else if (height == 13)
            {
                pixels_count = 23;
            }

            if (height == 26 || height == 33)
            {
                upperLine[0] = new Point(5, 1);
                upperLine[1] = new Point(Wd_beforeCurve, 1);

                rightCurve[0] = new Point(Wd_beforeCurve, 1);
                rightCurve[1] = new Point(accessible_Wd, accessible_Ht / 2);
                rightCurve[2] = new Point(Wd_beforeCurve, accessible_Ht);

                botLine[0] = new Point(Wd_beforeCurve, accessible_Ht);
                botLine[1] = new Point(5, accessible_Ht);

                leftCurve[0] = new Point(5, accessible_Ht);
                leftCurve[1] = new Point(1, accessible_Ht / 2);
                leftCurve[2] = new Point(5, 1);
            }
            else if (height == 18 || height == 23)
            {
                if (((prev_obj.Contains("MultiTransom") || prev_obj.Contains("MultiMullion")) && nxt_obj.Contains("PanelUC")) ||
                    (((prev_obj.Contains("MultiTransom") || prev_obj.Contains("MultiMullion")) && nxt_obj == "")))
                {
                    upperLine[0] = new Point(5, (height - pixels_count) + 1);
                    upperLine[1] = new Point(Wd_beforeCurve, (height - pixels_count) + 1);

                    rightCurve[0] = new Point(Wd_beforeCurve, (height - pixels_count) + 1);
                    rightCurve[1] = new Point(accessible_Wd, (height - pixels_count) + pointY_Mid);
                    rightCurve[2] = new Point(Wd_beforeCurve, accessible_Ht);

                    botLine[0] = new Point(Wd_beforeCurve, accessible_Ht);
                    botLine[1] = new Point(5, accessible_Ht);

                    leftCurve[0] = new Point(5, accessible_Ht);
                    leftCurve[1] = new Point(1, (height - pixels_count) + pointY_Mid);
                    leftCurve[2] = new Point(5, (height - pixels_count) + 1);
                }
                else if (prev_obj.Contains("PanelUC") && (nxt_obj.Contains("MultiTransom") || nxt_obj.Contains("MultiMullion")))
                {
                    upperLine[0] = new Point(5, 1);
                    upperLine[1] = new Point(Wd_beforeCurve, 1);

                    rightCurve[0] = new Point(Wd_beforeCurve, 1);
                    rightCurve[1] = new Point(accessible_Wd, pointY_Mid);
                    rightCurve[2] = new Point(Wd_beforeCurve, accessible_Ht + (pixels_count - height));

                    botLine[0] = new Point(Wd_beforeCurve, accessible_Ht + (pixels_count - height));
                    botLine[1] = new Point(5, accessible_Ht + (pixels_count - height));

                    leftCurve[0] = new Point(5, accessible_Ht + (pixels_count - height));
                    leftCurve[1] = new Point(1, pointY_Mid + 1);
                    leftCurve[2] = new Point(5, 1);
                }
                else
                {
                    upperLine[0] = new Point(5, 1);
                    upperLine[1] = new Point(Wd_beforeCurve, 1);

                    rightCurve[0] = new Point(Wd_beforeCurve, 1);
                    rightCurve[1] = new Point(accessible_Wd, accessible_Ht / 2);
                    rightCurve[2] = new Point(Wd_beforeCurve, accessible_Ht);

                    botLine[0] = new Point(Wd_beforeCurve, accessible_Ht);
                    botLine[1] = new Point(5, accessible_Ht);

                    leftCurve[0] = new Point(5, accessible_Ht);
                    leftCurve[1] = new Point(1, accessible_Ht / 2);
                    leftCurve[2] = new Point(5, 1);
                }
            }
            else if (height == 10 || height == 13)
            {
                upperLine[0] = new Point(4, (height - pixels_count) + 1);
                upperLine[1] = new Point(Wd_beforeCurve, (height - pixels_count) + 1);

                rightCurve[0] = new Point(Wd_beforeCurve, (height - pixels_count) + 1);
                rightCurve[1] = new Point(accessible_Wd, (height - pixels_count) + pointY_Mid);
                rightCurve[2] = new Point(Wd_beforeCurve, accessible_Ht + 8);

                botLine[0] = new Point(Wd_beforeCurve, accessible_Ht + 8);
                botLine[1] = new Point(4, accessible_Ht + 8);

                leftCurve[0] = new Point(4, accessible_Ht + 8);
                leftCurve[1] = new Point(1, (height - pixels_count) + pointY_Mid);
                leftCurve[2] = new Point(4, (height - pixels_count) + 1);
            }

            Transom_Points.Add(upperLine);
            Transom_Points.Add(rightCurve);
            Transom_Points.Add(botLine);
            Transom_Points.Add(leftCurve);

            return Transom_Points;
        }

        public IEnumerable<Control> GetAll(Control control, string name)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, name))
                                      .Concat(controls)
                                      .Where(c => c.Visible == true)
                                      .Where(c => c.Name.Contains(name));
        }
    }
}
