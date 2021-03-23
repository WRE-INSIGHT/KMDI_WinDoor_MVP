using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.Dividers;
using ServiceLayer.Services.DividerServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.CommonMethods
{
    public class CommonFunctions
    {
        public void Automatic_Div_Addition(IMainPresenter mainPresenter,
                                           IFrameModel frameModel,
                                           IDividerServices divServices,
                                           //IFrameUCPresenter frameUCP,
                                           ITransomUCPresenter _transomUCP,
                                           IUnityContainer _unityC,
                                           IMullionUCPresenter _mullionUCP,
                                           int divID,
                                           IMultiPanelModel multiPanelModel = null,
                                           IPanelModel panelModel = null,
                                           IMultiPanelTransomUCPresenter multiTransomUCP = null,
                                           IMultiPanelMullionUCPresenter multiMullionUCP = null)
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
                    divWd = parentfpnl.Width;
                }
                else if (parentModel.MPanel_Type == "Mullion")
                {
                    divType = DividerModel.DividerType.Mullion;
                    divHT = parentfpnl.Height;
                    divWd = divSize;
                }

                IDividerModel divModel = divServices.AddDividerModel(divWd,
                                                                     divHT,
                                                                     parentfpnl,
                                                                     //(UserControl)frameUCP.GetFrameUC(),
                                                                     divType,
                                                                     true,
                                                                     divID,
                                                                     frameModel.Frame_Type.ToString());

                frameModel.Lst_Divider.Add(divModel);
                parentModel.MPanelLst_Divider.Add(divModel);

                if (parentModel.MPanel_Type == "Transom")
                {
                    ITransomUCPresenter transomUCP = null;
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
                }
                else if (parentModel.MPanel_Type == "Mullion")
                {
                    IMullionUCPresenter mullionUCP = null;

                    if (multiTransomUCP != null)
                    {
                        mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                divModel,
                                                                parentModel,
                                                                multiTransomUCP,
                                                                frameModel);
                    }
                    else if (multiMullionUCP != null)
                    {
                        mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                divModel,
                                                                parentModel,
                                                                multiMullionUCP,
                                                                frameModel);
                    }

                    IMullionUC mullionUC = mullionUCP.GetMullion();
                    parentfpnl.Controls.Add((UserControl)mullionUC);
                    mullionUCP.SetInitialLoadFalse();//SetInitialLoadFalse para magresize yung div
                    parentModel.AddControl_MPanelLstObjects((UserControl)mullionUC, 
                                                             frameModel.Frame_Type.ToString(),
                                                             true);
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
            string dmnsion_h = multiPanelModel.MPanel_Height.ToString();
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
            string dmnsion_h = panelModel.Panel_Height.ToString();
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
            string dmnsion_w = multiPanelModel.MPanel_Width.ToString();
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
            string dmnsion_w = panelModel.Panel_Width.ToString();
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
    }
}
