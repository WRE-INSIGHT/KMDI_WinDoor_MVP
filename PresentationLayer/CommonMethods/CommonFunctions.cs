using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.User;
using PresentationLayer.Presenter;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.Dividers.Imagers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.Dividers;
using PresentationLayer.Views.UserControls.Dividers.Imagers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
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
                                           IUserModel userModel,
                                           IDividerServices divServices,
                                           ITransomUCPresenter _transomUCP,
                                           IUnityContainer _unityC,
                                           IMullionUCPresenter _mullionUCP,
                                           //IMullionImagerUCPresenter _mullionImagerUCP,
                                           //ITransomImagerUCPresenter _transomImagerUCP,
                                           int divID,
                                           IMultiPanelModel multiPanelModel = null,
                                           IPanelModel panelModel = null,
                                           IMultiPanelTransomUCPresenter multiTransomUCP = null,
                                           IMultiPanelMullionUCPresenter multiMullionUCP = null)
        //IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP = null,
        //IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP = null)
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
            bool divchkdm = false;

            if (frameModel.Frame_Type.ToString().Contains("Window"))
            {
                divSize = (int)Frame_Padding.Window;
            }
            else if (frameModel.Frame_Type.ToString().Contains("Door"))
            {
                divSize = (int)Frame_Padding.Door;
                if (frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                   frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                {
                    divchkdm = true;
                }
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
                                                                     frameModel,
                                                                     userModel,
                                                                     divID,
                                                                     frameModel.FrameImageRenderer_Zoom,
                                                                     frameModel.Frame_Type.ToString(),
                                                                     "",
                                                                     null,
                                                                     divchkdm);
                divModel.SetDimensionsToBind_using_DivZoom();
                divModel.SetDimensionsToBind_using_DivZoom_Imager();

                frameModel.Lst_Divider.Add(divModel);
                parentModel.MPanelLst_Divider.Add(divModel);

                if (divType == DividerModel.DividerType.Mullion)
                {
                    IDividerPropertiesUCPresenter divPropUCP = mainPresenter.divPropertiesUCP.GetNewInstance(_unityC, divModel, mainPresenter);
                    divPropUCP.GetDivProperties().ProfileType_FromMainPresenter = frameModel.Frame_WindoorModel.WD_profile;
                    UserControl divPropUC = (UserControl)divPropUCP.GetDivProperties();
                    divPropUC.Dock = DockStyle.Top;
                    multiMullionUCP.multiPropUCP2_given.GetMultiPanelPropertiesPNL().Controls.Add(divPropUC);
                    divPropUC.BringToFront();
                }
                else if (divType == DividerModel.DividerType.Transom)
                {
                    IDividerPropertiesUCPresenter divPropUCP = mainPresenter.divPropertiesUCP.GetNewInstance(_unityC, divModel, mainPresenter);
                    UserControl divPropUC = (UserControl)divPropUCP.GetDivProperties();
                    divPropUC.Dock = DockStyle.Top;
                    multiTransomUCP.multiPropUCP2_given.GetMultiPanelPropertiesPNL().Controls.Add(divPropUC);
                    divPropUC.BringToFront();
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
                    parentModel.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)transomUC,
                                                                          frameModel.Frame_Type.ToString(),
                                                                          true);

                    //transomImagerUCP = _transomImagerUCP.GetNewInstance(_unityC,
                    //                                                    divModel,
                    //                                                    parentModel,
                    //                                                    frameModel,
                    //                                                    multiTransomImagerUCP,
                    //                                                    transomUC);
                    //ITransomImagerUC transomImagerUC = transomImagerUCP.GetTransomImager();
                    //multiTransomImagerUCP.AddControl((UserControl)transomImagerUC);
                    //parentModel.MPanelLst_Imagers.Add((UserControl)transomImagerUC);

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
                    parentModel.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)mullionUC,
                                                                          frameModel.Frame_Type.ToString(),
                                                                          true);

                    //mullionImagerUCP = _mullionImagerUCP.GetNewInstance(_unityC,
                    //                                                    divModel,
                    //                                                    parentModel,
                    //                                                    frameModel,
                    //                                                    multiMullionImagerUCP,
                    //                                                    mullionUC);

                    //IMullionImagerUC mullionImagerUC = mullionImagerUCP.GetMullionImager();
                    //multiMullionImagerUCP.AddControl((UserControl)mullionImagerUC);
                    //parentModel.MPanelLst_Imagers.Add((UserControl)mullionImagerUC);

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
            string dmnsion_h = multiPanelModel.MPanel_DisplayHeight.ToString() + "." + multiPanelModel.MPanel_DisplayHeightDecimal.ToString();

            Point dmnsion_h_startP = new Point(),
                  dmnsion_h_endP = new Point();

            if (multiPanelModel.MPanel_Zoom > 0.26f)
            {
                dmnsion_h_startP = new Point(multiPanelModel.MPanel_WidthToBind - 20,
                                             Convert.ToInt32(10 * multiPanelModel.MPanel_Zoom));

                dmnsion_h_endP = new Point(multiPanelModel.MPanel_WidthToBind - 20, 
                                           multiPanelModel.MPanel_HeightToBind - Convert.ToInt32(10 * multiPanelModel.MPanel_Zoom));
            }
            else if (multiPanelModel.MPanel_Zoom <= 0.26f)
            {
                dmnsion_h_startP = new Point(multiPanelModel.MPanel_WidthToBind - 20,
                                             5);
                dmnsion_h_endP = new Point(multiPanelModel.MPanel_WidthToBind - 20,
                                           multiPanelModel.MPanel_HeightToBind - 5);
            }

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
                                  new Rectangle(new Point(((multiPanelModel.MPanel_WidthToBind - 20) - s2.Width), (int)(mid2 - (s2.Height / 2))),
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
            string dmnsion_h = panelModel.Panel_DisplayHeight.ToString() + "." + panelModel.Panel_DisplayHeightDecimal.ToString();
            Point dmnsion_h_startP = new Point();
            Point dmnsion_h_endP = new Point();

            if (panelModel.Panel_Zoom > 0.26f)
            {
                dmnsion_h_startP = new Point(panelModel.Panel_WidthToBind - 20,
                                             Convert.ToInt32(10 * panelModel.Panel_Zoom));

                dmnsion_h_endP = new Point(panelModel.Panel_WidthToBind - 20,
                                           panelModel.Panel_HeightToBind - Convert.ToInt32(10 * panelModel.Panel_Zoom));
            }
            else if (panelModel.Panel_Zoom <= 0.26f)
            {
                dmnsion_h_startP = new Point(panelModel.Panel_WidthToBind - 20,
                                             5);
                dmnsion_h_endP = new Point(panelModel.Panel_WidthToBind - 20,
                                           panelModel.Panel_HeightToBind - 5);
            }

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
                                  new Rectangle(new Point(((panelModel.Panel_WidthToBind - 20) - s2.Width), (int)(mid2 - (s2.Height / 2))),
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
            string dmnsion_w = multiPanelModel.MPanel_DisplayWidth.ToString() + "." + multiPanelModel.MPanel_DisplayWidthDecimal.ToString();
            Point dmnsion_w_startP = new Point(), 
                  dmnsion_w_endP = new Point();

            if (multiPanelModel.MPanel_Zoom > 0.26f)
            {
                dmnsion_w_startP = new Point(Convert.ToInt32(10 * multiPanelModel.MPanel_Zoom), 
                                             multiPanelModel.MPanel_HeightToBind - 20);
                dmnsion_w_endP = new Point(multiPanelModel.MPanel_WidthToBind - Convert.ToInt32(10 * multiPanelModel.MPanel_Zoom),
                                           multiPanelModel.MPanel_HeightToBind - 20);
            }
            else if (multiPanelModel.MPanel_Zoom <= 0.26f)
            {
                dmnsion_w_startP = new Point(5,
                                             multiPanelModel.MPanel_HeightToBind - 20);
                dmnsion_w_endP = new Point(multiPanelModel.MPanel_WidthToBind - 5,
                                           multiPanelModel.MPanel_HeightToBind - 20);
            }

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

            g.DrawLines(redP, arrwhd_pnts_W1);
            g.DrawLine(redP, dmnsion_w_startP, dmnsion_w_endP);
            g.DrawLines(redP, arrwhd_pnts_W2);
            TextRenderer.DrawText(g,
                                  dmnsion_w,
                                  dmnsion_font,
                                  new Rectangle(new Point((int)(mid - (s.Width / 2)), ((multiPanelModel.MPanel_HeightToBind - 20) - s.Height)),
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
            string dmnsion_w = panelModel.Panel_DisplayWidth.ToString() + "." + panelModel.Panel_DisplayWidthDecimal.ToString();
            Point dmnsion_w_startP = new Point();
            Point dmnsion_w_endP = new Point();
            //Point dmnsion_w_startP = new Point(1, panelModel.Panel_Height - 20);
            //Point dmnsion_w_endP = new Point(panelModel.Panel_Width - 1, panelModel.Panel_Height - 20);

            if (panelModel.Panel_Zoom > 0.26f)
            {
                dmnsion_w_startP = new Point(Convert.ToInt32(10 * panelModel.Panel_Zoom),
                                             panelModel.Panel_HeightToBind - 20);
                dmnsion_w_endP = new Point(panelModel.Panel_WidthToBind - Convert.ToInt32(10 * panelModel.Panel_Zoom),
                                           panelModel.Panel_HeightToBind - 20);
            }
            else if (panelModel.Panel_Zoom <= 0.26f)
            {
                dmnsion_w_startP = new Point(5,
                                             panelModel.Panel_HeightToBind - 20);
                dmnsion_w_endP = new Point(panelModel.Panel_WidthToBind - 5,
                                           panelModel.Panel_HeightToBind - 20);
            }

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

            g.DrawLines(redP, arrwhd_pnts_W1);
            g.DrawLine(redP, dmnsion_w_startP, dmnsion_w_endP);
            g.DrawLines(redP, arrwhd_pnts_W2);
            TextRenderer.DrawText(g,
                                  dmnsion_w,
                                  dmnsion_font,
                                  new Rectangle(new Point((int)(mid - (s.Width / 2)), ((panelModel.Panel_HeightToBind - 20) - s.Height)),
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
            else if (wd_formula == 22)
            {
                pixels_count = 32;
            }
            else if (wd_formula == 10)
            {
                pixels_count = 18;
            }
            else if (wd_formula == 12)
            {
                pixels_count = 22;
            }

            if (wd_formula == 26 || wd_formula == 32)
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
            else if (wd_formula == 18 || wd_formula == 22)
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
            else if (wd_formula == 10 || wd_formula == 12)
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

        //public List<Point[]> GetMullionDrawingPoints2(int width,
        //                                              int height,
        //                                              UserControl prev_obj,
        //                                              UserControl nxt_obj,
        //                                              Frame_Padding frame_type,
        //                                              float zoom)
        //{
        //    List<Point[]> Mullion_Points = new List<Point[]>();
        //    int accessible_Wd = width - 2,
        //        accessible_Ht = height - 2,
        //        Ht_beforeCurve = height - 5;

        //    int start_wd = 1,
        //        end_wd = width - 1,
        //        start_ht = 1,
        //        end_ht = height - 1;

        //    Point[] leftLine = new Point[2];
        //    Point[] botCurve = new Point[3];
        //    Point[] rightLine = new Point[2];
        //    Point[] upperCurve = new Point[3];

        //    if (prev_obj is IPanelUC)
        //    {
        //        leftLine[0] = new Point((int)(1 * zoom), (int)(5 * zoom));
        //        leftLine[1] = new Point((int)(1 * zoom), (int)(Ht_beforeCurve * zoom));

        //        botCurve[0] = new Point((int)(1 * zoom), Ht_beforeCurve);
        //        botCurve[1] = new Point((int)((accessible_Wd / 2) * zoom), accessible_Ht);
        //        botCurve[2] = new Point((int)(accessible_Wd * zoom), Ht_beforeCurve);
        //    }

        //    if (nxt_obj is IPanelUC || nxt_obj == null)
        //    {
        //        rightLine[0] = new Point((int)(accessible_Wd * zoom), Ht_beforeCurve);
        //        rightLine[1] = new Point((int)(accessible_Wd * zoom), 5);

        //        upperCurve[0] = new Point((int)(accessible_Wd * zoom), 5);
        //        upperCurve[1] = new Point(accessible_Wd / 2, 1);
        //        upperCurve[2] = new Point(1, 5);
        //    }

        //    Mullion_Points.Add(leftLine);
        //    Mullion_Points.Add(botCurve);
        //    Mullion_Points.Add(rightLine);
        //    Mullion_Points.Add(upperCurve);

        //    for (int i = 0; i < Mullion_Points.Count() ; i++)
        //    {
        //        for (int j = 0; j < Mullion_Points[i].Count() ; j++)
        //        {
        //            Mullion_Points[i][j] = new Point((int)(Mullion_Points[i][j].X * zoom), (int)(Mullion_Points[i][j].Y * zoom));
        //        }
        //    }

        //    return Mullion_Points;
        //}

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
            else if (height == 22)
            {
                pixels_count = 32;
            }
            else if (height == 10)
            {
                pixels_count = 18;
            }
            else if (height == 12)
            {
                pixels_count = 22;
            }

            if (height == 26 || height == 32)
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
            else if (height == 18 || height == 22)
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
            else if (height == 10 || height == 12)
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

        public IEnumerable<IMultiPanelModel> GetAll_MPanel(IMultiPanelModel mpanel)
        {
            IEnumerable<IMultiPanelModel> lst_mpnl = mpanel.MPanelLst_MultiPanel;

            return lst_mpnl.SelectMany(ctrl => GetAll_MPanel(ctrl)).Concat(lst_mpnl);
        }

        public void rowpostpaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            e.PaintHeader(DataGridViewPaintParts.Background);
            string rowIdx = (e.RowIndex + 1).ToString();
            Font rowFont = new Font("Segoe UI", 9.0f,
                                    FontStyle.Regular,
                                    GraphicsUnit.Point);
            StringFormat centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Far;
            centerFormat.LineAlignment = StringAlignment.Near;

            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, rowFont, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
         
        public void rowpostpaintForJB(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            e.PaintHeader(DataGridViewPaintParts.Background);
            e.Graphics.FillRectangle(Brushes.Red, e.ClipBounds);
            string rowIdx = (e.RowIndex + 1).ToString();
            Font rowFont = new Font("Segoe UI", 9.0f,
                                    FontStyle.Regular,
                                    GraphicsUnit.Point);
            StringFormat centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Far;
            centerFormat.LineAlignment = StringAlignment.Near;

            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, rowFont, SystemBrushes.ControlText, headerBounds, centerFormat);
        }


        public Control FindImagerControl(int id, string type, IMultiPanelModel mpanelParent)
        {
            Control imgr = new Control();

            foreach (Control item in mpanelParent.MPanelLst_Imagers)
            {
                int imgr_id = 0;

                if (type == "Panel" && item is IPanelImagerUC)
                {
                    imgr_id = ((IPanelImagerUC)item).Panel_ID;
                    if (id == imgr_id)
                    {
                        imgr = item;
                    }
                }
                else if (type == "MPanel" && item is IMultiPanelImagerUC)
                {
                    imgr_id = ((IMultiPanelImagerUC)item).MPanel_ID;
                    if (id == imgr_id)
                    {
                        imgr = item;
                    }
                }
                else if (type == "MullionImager" && item is IMullionImagerUC)
                {
                    imgr_id = ((IMullionImagerUC)item).Div_ID;
                    if (id == imgr_id)
                    {
                        imgr = item;
                    }
                }
                else if (type == "TransomImager" && item is ITransomImagerUC)
                {
                    imgr_id = ((ITransomImagerUC)item).Div_ID;
                    if (id == imgr_id)
                    {
                        imgr = item;
                    }
                }
            }

            return imgr;
        }

    }
}
