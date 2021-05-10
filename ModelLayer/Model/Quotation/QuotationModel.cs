using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ModelLayer.Model.Quotation
{
    public class QuotationModel : IQuotationModel
    {
        public enum FrameProfile_ArticleNo
        {
            _7502 = 0
        }

        public enum FrameReinf_ArticleNo
        {
            _R676 = 0
        }

        public enum Divider_ArticleNo
        {
            None = 0,
            _7536 = 1,
            _7538 = 2//,
            //_6052 = 2,
        }

        public enum DividerReinf_ArticleNo
        {
            _R677 = 0,
            _R686 = 1
        }

        public enum GlazingBead_ArticleNo
        {
            _2452 = 0,
            _2451 = 1,
            _2453 = 2,
            _2436 = 3,
            _2438 = 4,
            _2437 = 5,
            _2434 = 6,
            _2435 = 7
        }

        public enum InstMats_ArticleNo
        {
            PU_FOAMING = 0,
            SEALANT_WH = 1
        }

        public List<IWindoorModel> Lst_Windoor { get; set; }

        [Required(ErrorMessage = "Quotation reference number is Required")]
        public string Quotation_ref_no { get; set; }

        private DataColumn CreateColumn(string columname, string caption, string type)
        {
            DataColumn col = new DataColumn();
            col.DataType = Type.GetType(type);
            col.ColumnName = columname;
            col.Caption = caption;
            return col;
        }

        public DataTable GetListOfMaterials()
        {
            DataTable Material_List = new DataTable();
            Material_List.Columns.Add(CreateColumn("Description", "Description", "System.String"));
            Material_List.Columns.Add(CreateColumn("Qty", "Qty", "System.Int32"));
            Material_List.Columns.Add(CreateColumn("Unit", "Unit", "System.String"));
            Material_List.Columns.Add(CreateColumn("Size", "Size", "System.String"));

            foreach (IWindoorModel item in Lst_Windoor.Where(wndr => wndr.WD_visibility == true))
            {
                foreach (IFrameModel frame in item.GetAllVisibleFrames())
                {
                    Material_List.Rows.Add("Frame Width " + frame.Frame_ArtNo.ToString(),
                                           2, "pc(s)",
                                           frame.Frame_ExplosionHeight.ToString());

                    Material_List.Rows.Add("Frame Height " + frame.Frame_ArtNo.ToString(),
                                           2, "pc(s)",
                                           frame.Frame_ExplosionWidth);

                    Material_List.Rows.Add("Frame Reinf Width " + frame.Frame_ReinfArtNo.ToString(),
                                           2, "pc(s)",
                                           frame.Frame_ReinfWidth.ToString());

                    Material_List.Rows.Add("Frame Reinf Height " + frame.Frame_ReinfArtNo.ToString(),
                                           2, "pc(s)",
                                           frame.Frame_ReinfHeight.ToString());

                    if (frame.GetVisibleMultiPanels().Count() == 1 && frame.GetVisiblePanels().Count() == 0)
                    {
                        foreach (IMultiPanelModel mpnl in frame.GetVisibleMultiPanels())
                        {
                            List<IPanelModel> panels = mpnl.GetVisiblePanels().ToList();
                            List<IDividerModel> divs = mpnl.GetVisibleDividers().ToList();

                            if (mpnl.MPanel_Type == "Mullion")
                            {
                                int obj_count = mpnl.GetVisibleObjects().Count();
                                for (int i = 0; i < obj_count; i+=2)
                                {
                                    Control cur_ctrl = mpnl.GetVisibleObjects().ToList()[i];
                                    IPanelModel pnl_curCtrl = panels.Find(pnl => pnl.Panel_Name == cur_ctrl.Name);

                                    if (i+1 < obj_count)
                                    {
                                        Control nxt_ctrl = mpnl.GetVisibleObjects().ToList()[i+1];
                                        IDividerModel div_nxtCtrl = divs.Find(div => div.Div_Name == nxt_ctrl.Name);

                                        Material_List.Rows.Add(div_nxtCtrl.Div_Type.ToString() + " " + mpnl.MPanel_Type + " " + div_nxtCtrl.Div_ArtNo.ToString(),
                                                               1, "pc(s)",
                                                               div_nxtCtrl.Div_ExplosionHeight.ToString());
                                        Material_List.Rows.Add(div_nxtCtrl.Div_Type.ToString() + " " + mpnl.MPanel_Type + " " + div_nxtCtrl.Div_ReinfArtNo.ToString(),
                                                               1, "pc(s)",
                                                               div_nxtCtrl.Div_ReinfHeight.ToString());

                                        pnl_curCtrl.SetPanelExplosionValues_Panel(div_nxtCtrl.Div_ArtNo);
                                    }
                                    else if (i+1 == obj_count)
                                    {
                                        Control nxt_ctrl = mpnl.GetVisibleObjects().ToList()[i-1];
                                        IDividerModel div_nxtCtrl = divs.Find(div => div.Div_Name == nxt_ctrl.Name);
                                        pnl_curCtrl.SetPanelExplosionValues_Panel(div_nxtCtrl.Div_ArtNo);
                                    }

                                    Material_List.Rows.Add("Glazing Bead Width (P" + i + ")" + pnl_curCtrl.PanelGlazingBead_ArtNo.ToString(),
                                                               2, "pc(s)",
                                                               pnl_curCtrl.Panel_GlazingBeadWidth.ToString());

                                    Material_List.Rows.Add("Glazing Bead Height " + pnl_curCtrl.PanelGlazingBead_ArtNo.ToString(),
                                                           2, "pc(s)",
                                                           pnl_curCtrl.Panel_GlazingBeadHeight.ToString());

                                    Material_List.Rows.Add("Glass Width (" + pnl_curCtrl.Panel_GlassThickness + "-P " + i +")",
                                                           1, "pc(s)",
                                                           pnl_curCtrl.Panel_GlassWidth.ToString());

                                    Material_List.Rows.Add("Glass Height (" + pnl_curCtrl.Panel_GlassThickness + ")",
                                                           1, "pc(s)",
                                                           pnl_curCtrl.Panel_GlassHeight.ToString());

                                    Material_List.Rows.Add("Glazing Spacer (KBC70)",
                                                           1, "pc(s)", "");

                                    Material_List.Rows.Add("Sealant-WH",
                                                           pnl_curCtrl.Panel_SealantWHQty,
                                                           "pc(s)",
                                                           "");
                                }
                            }
                        }

                    }
                    else if (frame.GetVisiblePanels().Count() == 1 && frame.GetVisibleMultiPanels().Count() == 0)
                    {
                        IPanelModel pnl = frame.GetVisiblePanels().ToList()[0];
                        pnl.SetPanelExplosionValues_Panel(Divider_ArticleNo.None);

                        Material_List.Rows.Add("Glazing Bead Width " + pnl.PanelGlazingBead_ArtNo.ToString(),
                                                   2, "pc(s)",
                                                   pnl.Panel_GlazingBeadWidth.ToString());

                        Material_List.Rows.Add("Glazing Bead Height " + pnl.PanelGlazingBead_ArtNo.ToString(),
                                               2, "pc(s)",
                                               pnl.Panel_GlazingBeadHeight.ToString());

                        Material_List.Rows.Add("Glass Width (" + pnl.Panel_GlassThickness + ")",
                                               1, "pc(s)",
                                               pnl.Panel_GlassWidth.ToString());

                        Material_List.Rows.Add("Glass Height (" + pnl.Panel_GlassThickness + ")",
                                               1, "pc(s)",
                                               pnl.Panel_GlassHeight.ToString());

                        Material_List.Rows.Add("Glazing Spacer (KBC70)",
                                               1, "pc(s)", "");

                        Material_List.Rows.Add("Sealant-WH",
                                               pnl.Panel_SealantWHQty,
                                               "pc(s)",
                                               "");
                    }

                    Material_List.Rows.Add("PU Foaming",
                                           frame.Frame_PUFoamingQty, "can", "");
                    Material_List.Rows.Add("Sealant-WH",
                                           frame.Frame_SealantWHQty, "pc(s)", "");
                }
            }

            return Material_List;
        }

        public QuotationModel(string quotation_ref_no,
                              List<IWindoorModel> lst_Windoor)
        {
            Quotation_ref_no = quotation_ref_no;
            Lst_Windoor = lst_Windoor;
        }
    }
}
