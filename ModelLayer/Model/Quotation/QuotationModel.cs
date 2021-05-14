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

        public enum Divider_MechJointArticleNo
        {
            _9U18 = 0,
            _AV585 = 1
        }

        public enum Glass_Thickness
        {
            _6mm = 0,
            _7mm = 1,
            _8mm = 2,
            _10mm = 3,
            _11mm = 4,
            _12mm = 5,
            _13mm = 6,
            _14mm = 7,
            _16mm = 8,
            _18mm = 9,
            _20mm = 10,
            _22mm = 11,
            _24mm = 12,
            _25mm = 13
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
                                           frame.Frame_ExplosionWidth.ToString());

                    Material_List.Rows.Add("Frame Height " + frame.Frame_ArtNo.ToString(),
                                           2, "pc(s)",
                                           frame.Frame_ExplosionHeight);

                    Material_List.Rows.Add("Frame Reinf Width " + frame.Frame_ReinfArtNo.ToString(),
                                           2, "pc(s)",
                                           frame.Frame_ReinfWidth.ToString());

                    Material_List.Rows.Add("Frame Reinf Height " + frame.Frame_ReinfArtNo.ToString(),
                                           2, "pc(s)",
                                           frame.Frame_ReinfHeight.ToString());

                    int glazing_seal = 0;

                    if (frame.GetVisibleMultiPanels().Count() >= 1 && frame.GetVisiblePanels().Count() == 0)
                    {
                        int loop_counter = 1;
                        foreach (IMultiPanelModel mpnl in frame.GetVisibleMultiPanels())
                        {
                            List<IPanelModel> panels = mpnl.GetVisiblePanels().ToList();
                            List<IDividerModel> divs = mpnl.GetVisibleDividers().ToList();
                            List<IMultiPanelModel> mpanels = mpnl.GetVisibleMultiPanels().ToList();

                            int obj_count = mpnl.GetVisibleObjects().Count();
                            for (int i = 0; i < obj_count; i += 2)
                            {
                                Control cur_ctrl = mpnl.GetVisibleObjects().ToList()[i];
                                IPanelModel pnl_curCtrl = panels.Find(pnl => pnl.Panel_Name == cur_ctrl.Name);
                                IMultiPanelModel mpnl_curCtrl = mpanels.Find(mpanel => mpanel.MPanel_Name == cur_ctrl.Name);

                                if (i + 1 < obj_count)
                                {
                                    Control nxt_ctrl = mpnl.GetVisibleObjects().ToList()[i + 1];
                                    IDividerModel div_nxtCtrl = divs.Find(div => div.Div_Name == nxt_ctrl.Name);
                                    div_nxtCtrl.SetPanelExplosionValues_Div();

                                    if (mpnl.MPanel_Type == "Mullion")
                                    {
                                        Material_List.Rows.Add(mpnl.MPanel_Type + " Height " + div_nxtCtrl.Div_ArtNo.ToString(),
                                                           1, "pc(s)",
                                                           div_nxtCtrl.Div_ExplosionHeight.ToString());
                                        Material_List.Rows.Add(mpnl.MPanel_Type + " Reinforcement Height" + div_nxtCtrl.Div_ReinfArtNo.ToString(),
                                                               1, "pc(s)",
                                                               div_nxtCtrl.Div_ReinfHeight.ToString());
                                    }
                                    else if (mpnl.MPanel_Type == "Transom")
                                    {
                                        Material_List.Rows.Add(mpnl.MPanel_Type + " Width " + div_nxtCtrl.Div_ArtNo.ToString(),
                                                           1, "pc(s)",
                                                           div_nxtCtrl.Div_ExplosionWidth.ToString());
                                        Material_List.Rows.Add(mpnl.MPanel_Type + " Reinforcement Width" + div_nxtCtrl.Div_ReinfArtNo.ToString(),
                                                               1, "pc(s)",
                                                               div_nxtCtrl.Div_ReinfWidth.ToString());
                                    }
                                    Material_List.Rows.Add(mpnl.MPanel_Type + " Mechanical Joint " + div_nxtCtrl.Div_MechJoinArtNo.ToString(),
                                                           2, "pc(s)", "");

                                    if (pnl_curCtrl != null)
                                    {
                                        pnl_curCtrl.SetPanelExplosionValues_Panel(div_nxtCtrl.Div_ArtNo, div_nxtCtrl.Div_Type);
                                    }
                                }
                                else if (i + 1 == obj_count)
                                {
                                    Control nxt_ctrl = mpnl.GetVisibleObjects().ToList()[i - 1];
                                    IDividerModel div_nxtCtrl = divs.Find(div => div.Div_Name == nxt_ctrl.Name);
                                    if (pnl_curCtrl != null)
                                    {
                                        pnl_curCtrl.SetPanelExplosionValues_Panel(div_nxtCtrl.Div_ArtNo, div_nxtCtrl.Div_Type);
                                    }
                                }

                                if (pnl_curCtrl != null)
                                {
                                    if (pnl_curCtrl.Panel_GlassThickness == Glass_Thickness._13mm ||
                                        pnl_curCtrl.Panel_GlassThickness == Glass_Thickness._14mm ||
                                        pnl_curCtrl.Panel_GlassThickness == Glass_Thickness._24mm)
                                    {
                                        glazing_seal += pnl_curCtrl.Panel_GlazingBeadWidth + pnl_curCtrl.Panel_GlazingBeadHeight;
                                    }

                                    Material_List.Rows.Add("Glazing Bead Width (P" + loop_counter + ") " + pnl_curCtrl.PanelGlazingBead_ArtNo.ToString(),
                                                               2, "pc(s)",
                                                               pnl_curCtrl.Panel_GlazingBeadWidth.ToString());

                                    Material_List.Rows.Add("Glazing Bead Height (P" + loop_counter + ") " + pnl_curCtrl.PanelGlazingBead_ArtNo.ToString(),
                                                           2, "pc(s)",
                                                           pnl_curCtrl.Panel_GlazingBeadHeight.ToString());

                                    Material_List.Rows.Add("Glass Width (" + pnl_curCtrl.Panel_GlassThickness + "-P" + loop_counter + ")",
                                                           1, "pc(s)",
                                                           pnl_curCtrl.Panel_GlassWidth.ToString());

                                    Material_List.Rows.Add("Glass Height (" + pnl_curCtrl.Panel_GlassThickness + "-P" + loop_counter + ")",
                                                           1, "pc(s)",
                                                           pnl_curCtrl.Panel_GlassHeight.ToString());

                                    Material_List.Rows.Add("Glazing Spacer (KBC70)",
                                                           1, "pc(s)", "");

                                    Material_List.Rows.Add("Sealant-WH (Glass)",
                                                           pnl_curCtrl.Panel_SealantWHQty,
                                                           "pc(s)",
                                                           "");
                                    loop_counter++;
                                }
                            }
                        }

                    }
                    else if (frame.GetVisiblePanels().Count() == 1 && frame.GetVisibleMultiPanels().Count() == 0)
                    {
                        IPanelModel pnl = frame.GetVisiblePanels().ToList()[0];
                        pnl.SetPanelExplosionValues_Panel(Divider_ArticleNo.None, DividerModel.DividerType.Mullion);

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

                        Material_List.Rows.Add("Sealant-WH (Glass)",
                                               pnl.Panel_SealantWHQty,
                                               "pc(s)",
                                               "");
                    }

                    Material_List.Rows.Add("PU Foaming",
                                           frame.Frame_PUFoamingQty, "can", "");
                    Material_List.Rows.Add("Sealant-WH (Frame)",
                                           frame.Frame_SealantWHQty, "pc(s)", "");
                    Material_List.Rows.Add("Glazing Seal",
                                           glazing_seal, "mm","");
                }
            }


            var query = from r in Material_List.AsEnumerable()
                        group r by new
                        {
                            Description = r.Field<string>("Description"),
                            Unit = r.Field<string>("Unit"),
                            Size = r.Field<string>("Size")
                        } into g
                        select new
                        {
                            Description = g.Key.Description,
                            Qty = g.Sum(r => r.Field<int>("Qty")),
                            Unit = g.Key.Unit,
                            Size = g.Key.Size
                        };

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
