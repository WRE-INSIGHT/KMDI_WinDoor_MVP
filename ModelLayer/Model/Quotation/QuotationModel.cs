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
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation
{
    public class QuotationModel : IQuotationModel
    {
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
                    frame.SetExplosionValues_Frame();

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

                    int glazing_seal = 0,
                        glazing_spacer = 0,
                        total_glassWidth = 0,
                        total_glassHeight = 0;

                    if (frame.GetVisibleMultiPanels().Count() >= 1 && frame.GetVisiblePanels().Count() == 0)
                    {
                        int loop_counter = 1;

                        foreach (IMultiPanelModel mpnl in frame.GetVisibleMultiPanels())
                        {
                            List<IPanelModel> panels = mpnl.GetVisiblePanels().ToList();
                            List<IDividerModel> divs = mpnl.GetVisibleDividers().ToList();
                            List<IMultiPanelModel> mpanels = mpnl.GetVisibleMultiPanels().ToList();

                            IDividerModel divTopOrLeft = null,
                                          divBotOrRight = null;

                            if (mpnl.MPanel_Parent.Name.Contains("Multi"))
                            {
                                IMultiPanelModel mpnl_Parent = mpnl.MPanel_ParentModel;
                                Control mpnl_ctrl = mpnl_Parent.MPanelLst_Objects.Find(mpanel => mpanel.Name == mpnl.MPanel_Name);
                                int mpnl_ndx = mpnl_Parent.MPanelLst_Objects.IndexOf(mpnl_ctrl);
                                Control div_nxtctrl, div_prevctrl;

                                if (mpnl.MPanel_Placement == "First")
                                {
                                    div_nxtctrl = mpnl_Parent.MPanelLst_Objects[mpnl_ndx + 1];
                                    divBotOrRight = mpnl_Parent.MPanelLst_Divider.Find(div => div.Div_Name == div_nxtctrl.Name);
                                }
                                else if (mpnl.MPanel_Placement == "Somewhere in Between")
                                {
                                    div_nxtctrl = mpnl_Parent.MPanelLst_Objects[mpnl_ndx + 1];
                                    div_prevctrl = mpnl_Parent.MPanelLst_Objects[mpnl_ndx - 1];

                                    divTopOrLeft = mpnl_Parent.MPanelLst_Divider.Find(div => div.Div_Name == div_prevctrl.Name);
                                    divBotOrRight = mpnl_Parent.MPanelLst_Divider.Find(div => div.Div_Name == div_nxtctrl.Name);
                                }
                                else if (mpnl.MPanel_Placement == "Last")
                                {
                                    div_prevctrl = mpnl_Parent.MPanelLst_Objects[mpnl_ndx - 1];
                                    divTopOrLeft = mpnl_Parent.MPanelLst_Divider.Find(div => div.Div_Name == div_prevctrl.Name);
                                }
                            }

                            int obj_count = mpnl.GetVisibleObjects().Count();
                            for (int i = 0; i < obj_count; i += 2)
                            {
                                Control cur_ctrl = mpnl.GetVisibleObjects().ToList()[i];
                                IPanelModel pnl_curCtrl = panels.Find(pnl => pnl.Panel_Name == cur_ctrl.Name);
                                IMultiPanelModel mpnl_curCtrl = mpanels.Find(mpanel => mpanel.MPanel_Name == cur_ctrl.Name);

                                IDividerModel div_nxtCtrl = null,
                                              div_prevCtrl = null;
                                Control nxt_ctrl, prevCtrl;

                                if (pnl_curCtrl != null)
                                {
                                    if (pnl_curCtrl.Panel_Placement == "First")
                                    {
                                        nxt_ctrl = mpnl.GetVisibleObjects().ToList()[i + 1];
                                        div_nxtCtrl = divs.Find(div => div.Div_Name == nxt_ctrl.Name);
                                    }
                                    else if (pnl_curCtrl.Panel_Placement == "Somewhere in Between")
                                    {
                                        nxt_ctrl = mpnl.GetVisibleObjects().ToList()[i + 1];
                                        div_nxtCtrl = divs.Find(div => div.Div_Name == nxt_ctrl.Name);

                                        prevCtrl = mpnl.GetVisibleObjects().ToList()[i - 1];
                                        div_prevCtrl = divs.Find(div => div.Div_Name == prevCtrl.Name);
                                    }
                                    else if (pnl_curCtrl.Panel_Placement == "Last")
                                    {
                                        prevCtrl = mpnl.GetVisibleObjects().ToList()[i - 1];
                                        div_prevCtrl = divs.Find(div => div.Div_Name == prevCtrl.Name);
                                    }
                                }

                                if (mpnl_curCtrl != null)
                                {
                                    if (mpnl_curCtrl.MPanel_Placement == "First")
                                    {
                                        nxt_ctrl = mpnl.GetVisibleObjects().ToList()[i + 1];
                                        div_nxtCtrl = divs.Find(div => div.Div_Name == nxt_ctrl.Name);
                                    }
                                    else if (mpnl_curCtrl.MPanel_Placement == "Somewhere in Between")
                                    {
                                        nxt_ctrl = mpnl.GetVisibleObjects().ToList()[i + 1];
                                        div_nxtCtrl = divs.Find(div => div.Div_Name == nxt_ctrl.Name);

                                        prevCtrl = mpnl.GetVisibleObjects().ToList()[i - 1];
                                        div_prevCtrl = divs.Find(div => div.Div_Name == prevCtrl.Name);
                                    }
                                    else if (mpnl_curCtrl.MPanel_Placement == "Last")
                                    {
                                        prevCtrl = mpnl.GetVisibleObjects().ToList()[i - 1];
                                        div_prevCtrl = divs.Find(div => div.Div_Name == prevCtrl.Name);
                                    }
                                }

                                if (i + 1 < obj_count)
                                {
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
                                        Divider_ArticleNo divArtNo_nxtCtrl = Divider_ArticleNo._None,
                                                          divArtNo_prevCtrl = Divider_ArticleNo._None,
                                                          divArtNo_LeftOrTop = Divider_ArticleNo._None,
                                                          divArtNo_RightOrBot = Divider_ArticleNo._None;
                                        if (div_nxtCtrl != null)
                                        {
                                            divArtNo_nxtCtrl = div_nxtCtrl.Div_ArtNo;
                                        }
                                        if (div_prevCtrl != null)
                                        {
                                            divArtNo_prevCtrl = div_prevCtrl.Div_ArtNo;
                                        }
                                        if (divTopOrLeft != null)
                                        {
                                            divArtNo_LeftOrTop = divTopOrLeft.Div_ArtNo;
                                        }
                                        if (divBotOrRight != null)
                                        {
                                            divArtNo_RightOrBot = divBotOrRight.Div_ArtNo;
                                        }

                                        pnl_curCtrl.SetPanelExplosionValues_Panel(divArtNo_nxtCtrl,
                                                                                  divArtNo_prevCtrl,
                                                                                  div_nxtCtrl.Div_Type,
                                                                                  divArtNo_LeftOrTop,
                                                                                  divArtNo_RightOrBot);
                                    }
                                }
                                else if (i + 1 == obj_count)
                                {
                                    if (pnl_curCtrl != null)
                                    {
                                        Divider_ArticleNo divArtNo_nxtCtrl = Divider_ArticleNo._None,
                                                          divArtNo_prevCtrl = Divider_ArticleNo._None,
                                                          divArtNo_LeftOrTop = Divider_ArticleNo._None,
                                                          divArtNo_RightOrBot = Divider_ArticleNo._None;
                                        if (div_nxtCtrl != null)
                                        {
                                            divArtNo_nxtCtrl = div_nxtCtrl.Div_ArtNo;
                                        }
                                        if (div_prevCtrl != null)
                                        {
                                            divArtNo_prevCtrl = div_prevCtrl.Div_ArtNo;
                                        }
                                        if (divTopOrLeft != null)
                                        {
                                            divArtNo_LeftOrTop = divTopOrLeft.Div_ArtNo;
                                        }
                                        if (divBotOrRight != null)
                                        {
                                            divArtNo_RightOrBot = divBotOrRight.Div_ArtNo;
                                        }

                                        pnl_curCtrl.SetPanelExplosionValues_Panel(divArtNo_nxtCtrl,
                                                                                  divArtNo_prevCtrl,
                                                                                  div_prevCtrl.Div_Type,
                                                                                  divArtNo_LeftOrTop,
                                                                                  divArtNo_RightOrBot);
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
                                    glazing_spacer++;

                                    total_glassWidth += (pnl_curCtrl.Panel_GlassWidth * 2);
                                    total_glassHeight += (pnl_curCtrl.Panel_GlassHeight * 2);

                                    loop_counter++;
                                }
                            }
                        }
                    }
                    else if (frame.GetVisiblePanels().Count() == 1 && frame.GetVisibleMultiPanels().Count() == 0)
                    {
                        IPanelModel pnl = frame.GetVisiblePanels().ToList()[0];
                        pnl.SetPanelExplosionValues_Panel(true);

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
                        glazing_spacer++;

                        total_glassWidth += (pnl.Panel_GlassWidth * 2);
                        total_glassHeight += (pnl.Panel_GlassHeight * 2);

                        if (pnl.Panel_GlassThickness == Glass_Thickness._13mm ||
                            pnl.Panel_GlassThickness == Glass_Thickness._14mm ||
                            pnl.Panel_GlassThickness == Glass_Thickness._24mm)
                        {
                            glazing_seal += pnl.Panel_GlazingBeadWidth + pnl.Panel_GlazingBeadHeight;
                        }
                    }

                    Material_List.Rows.Add("PU Foaming",
                                           frame.Frame_PUFoamingQty, "can", "");

                    Material_List.Rows.Add("Sealant-WH (Frame)",
                                           frame.Frame_SealantWHQty, "pc(s)", "");

                    int sealantWH_glass = (int)(Math.Ceiling((decimal)(total_glassWidth + total_glassHeight) / 6842));

                    Material_List.Rows.Add("Sealant-WH (Glass)",
                                           sealantWH_glass,
                                           "pc(s)",
                                           "");

                    Material_List.Rows.Add("Glazing Spacer (KBC70)",
                                           glazing_spacer, "pc(s)", "");

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

            DataTable dt = new DataTable();
            dt.Columns.Add(CreateColumn("Description", "Description", "System.String"));
            dt.Columns.Add(CreateColumn("Qty", "Qty", "System.Int32"));
            dt.Columns.Add(CreateColumn("Unit", "Unit", "System.String"));
            dt.Columns.Add(CreateColumn("Size", "Size", "System.String"));

            foreach (var item in query)
            {
                DataRow row = dt.NewRow();
                row["Description"] = item.Description;
                row["Qty"] = item.Qty;
                row["Unit"] = item.Unit;
                row["Size"] = item.Size;

                dt.Rows.Add(row);
            }

            Material_List = dt;

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
