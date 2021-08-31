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

        public int Frame_PUFoamingQty_Total { get; set; }
        public int Frame_SealantWHQty_Total { get; set; }
        public int Glass_SealantWHQty_Total { get; set; }
        public int GlazingSpacer_TotalQty { get; set; }
        public int GlazingSeal_TotalQty { get; set; }
        public int Screws_for_Fabrication { get; set; }
        public int Screws_for_Installation { get; set; }
        public int Screws_for_Cladding { get; set; }
        public int Expansion_BoltQty_Total { get; set; }
        public int Rebate_Qty { get; set; }
        public int Plastic_CoverQty_Total { get; set; }

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

            foreach (IWindoorModel item in Lst_Windoor)
            {
                int totalFrames_width = 0,
                    totalFrames_height = 0,
                     total_glassWidth = 0,
                     total_glassHeight = 0;

                foreach (IFrameModel frame in item.lst_frame)
                {
                    frame.SetExplosionValues_Frame();

                    totalFrames_width += (frame.Frame_Width * 2);
                    totalFrames_height += (frame.Frame_Height * 2);

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
                        glazing_spacer = 0;

                    if (frame.Lst_MultiPanel.Count() >= 1 && frame.Lst_Panel.Count() == 0)
                    {
                        int loop_counter = 1;

                        foreach (IMultiPanelModel mpnl in frame.Lst_MultiPanel)
                        {
                            List<IPanelModel> panels = mpnl.MPanelLst_Panel;
                            List<IDividerModel> divs = mpnl.MPanelLst_Divider;
                            List<IMultiPanelModel> mpanels = mpnl.MPanelLst_MultiPanel;

                            IDividerModel divTopOrLeft = null,
                                          divBotOrRight = null,
                                          divTopOrLeft_lvl3 = null,
                                          divBotOrRight_lvl3 = null;

                            IMultiPanelModel mpnl_Parent_lvl3 = null;
                            string mpanel_placement = "",
                                   mpanelParentlvl2_placement = "",
                                   mpnl_Parent_lvl3_mpanelType = "";

                            if (mpnl.MPanel_Parent.Name.Contains("Multi")) //2nd level stack
                            {
                                mpanel_placement = mpnl.MPanel_Placement;
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

                            if (mpnl.MPanel_ParentModel != null)
                            {
                                if (mpnl.MPanel_ParentModel.MPanel_Parent.Name.Contains("Multi")) //3rd level stack
                                {
                                    mpnl_Parent_lvl3 = mpnl.MPanel_ParentModel.MPanel_ParentModel;
                                    mpanelParentlvl2_placement = mpnl.MPanel_ParentModel.MPanel_Placement;
                                    mpnl_Parent_lvl3_mpanelType = mpnl_Parent_lvl3.MPanel_Type;

                                    Control mpnl_ctrl_lvl3 = mpnl_Parent_lvl3.MPanelLst_Objects.Find(mpanel => mpanel.Name == mpnl.MPanel_ParentModel.MPanel_Name);
                                    int mpnl_ndx_lvl3 = mpnl_Parent_lvl3.MPanelLst_Objects.IndexOf(mpnl_ctrl_lvl3);
                                    Control div_nxtctrl_lvl3, div_prevctrl_lvl3;

                                    if (mpnl.MPanel_ParentModel.MPanel_Placement == "First")
                                    {
                                        div_nxtctrl_lvl3 = mpnl_Parent_lvl3.MPanelLst_Objects[mpnl_ndx_lvl3 + 1];
                                        divBotOrRight_lvl3 = mpnl_Parent_lvl3.MPanelLst_Divider.Find(div => div.Div_Name == div_nxtctrl_lvl3.Name);
                                    }
                                    else if (mpnl.MPanel_ParentModel.MPanel_Placement == "Somewhere in Between")
                                    {
                                        div_nxtctrl_lvl3 = mpnl_Parent_lvl3.MPanelLst_Objects[mpnl_ndx_lvl3 + 1];
                                        div_prevctrl_lvl3 = mpnl_Parent_lvl3.MPanelLst_Objects[mpnl_ndx_lvl3 - 1];

                                        divTopOrLeft_lvl3 = mpnl_Parent_lvl3.MPanelLst_Divider.Find(div => div.Div_Name == div_prevctrl_lvl3.Name);
                                        divBotOrRight_lvl3 = mpnl_Parent_lvl3.MPanelLst_Divider.Find(div => div.Div_Name == div_nxtctrl_lvl3.Name);
                                    }
                                    else if (mpnl.MPanel_ParentModel.MPanel_Placement == "Last")
                                    {
                                        div_prevctrl_lvl3 = mpnl_Parent_lvl3.MPanelLst_Objects[mpnl_ndx_lvl3 - 1];
                                        divTopOrLeft_lvl3 = mpnl_Parent_lvl3.MPanelLst_Divider.Find(div => div.Div_Name == div_prevctrl_lvl3.Name);
                                    }
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
                                    div_nxtCtrl.SetExplosionValues_Div();

                                    if (mpnl.MPanel_Type == "Mullion")
                                    {
                                        Material_List.Rows.Add(mpnl.MPanel_Type + " Height " + div_nxtCtrl.Div_ArtNo.ToString(),
                                                           1, "pc(s)",
                                                           div_nxtCtrl.Div_ExplosionHeight.ToString());
                                        Material_List.Rows.Add(mpnl.MPanel_Type + " Reinforcement Height " + div_nxtCtrl.Div_ReinfArtNo.ToString(),
                                                               1, "pc(s)",
                                                               div_nxtCtrl.Div_ReinfHeight.ToString());
                                    }
                                    else if (mpnl.MPanel_Type == "Transom")
                                    {
                                        Material_List.Rows.Add(mpnl.MPanel_Type + " Width " + div_nxtCtrl.Div_ArtNo.ToString(),
                                                           1, "pc(s)",
                                                           div_nxtCtrl.Div_ExplosionWidth.ToString());
                                        Material_List.Rows.Add(mpnl.MPanel_Type + " Reinforcement Width " + div_nxtCtrl.Div_ReinfArtNo.ToString(),
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
                                                          divArtNo_RightOrBot = Divider_ArticleNo._None,
                                                          divArtNo_LeftOrTop_lvl3 = Divider_ArticleNo._None,
                                                          divArtNo_RightOrBot_lvl3 = Divider_ArticleNo._None;
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

                                        if (pnl_curCtrl.Panel_Placement == "First")
                                        {
                                            if (divTopOrLeft_lvl3 != null)
                                            {
                                                divArtNo_LeftOrTop_lvl3 = divTopOrLeft_lvl3.Div_ArtNo;
                                            }
                                        }
                                        else if (pnl_curCtrl.Panel_Placement == "Last")
                                        {
                                            if (divBotOrRight_lvl3 != null)
                                            {
                                                divArtNo_RightOrBot_lvl3 = divBotOrRight_lvl3.Div_ArtNo;
                                            }

                                        }

                                        pnl_curCtrl.SetPanelExplosionValues_Panel(divArtNo_nxtCtrl,
                                                                                  divArtNo_prevCtrl,
                                                                                  div_nxtCtrl.Div_Type,
                                                                                  div_nxtCtrl.Div_ChkDM,
                                                                                  div_prevCtrl.Div_ChkDM,
                                                                                  divArtNo_LeftOrTop,
                                                                                  divArtNo_RightOrBot,
                                                                                  mpnl_Parent_lvl3_mpanelType,
                                                                                  divArtNo_LeftOrTop_lvl3,
                                                                                  divArtNo_RightOrBot_lvl3,
                                                                                  pnl_curCtrl.Panel_Placement,
                                                                                  mpanel_placement,
                                                                                  mpanelParentlvl2_placement);
                                    }
                                }
                                else if (i + 1 == obj_count)
                                {
                                    if (pnl_curCtrl != null)
                                    {
                                        Divider_ArticleNo divArtNo_nxtCtrl = Divider_ArticleNo._None,
                                                          divArtNo_prevCtrl = Divider_ArticleNo._None,
                                                          divArtNo_LeftOrTop = Divider_ArticleNo._None,
                                                          divArtNo_RightOrBot = Divider_ArticleNo._None,
                                                          divArtNo_LeftOrTop_lvl3 = Divider_ArticleNo._None,
                                                          divArtNo_RightOrBot_lvl3 = Divider_ArticleNo._None;
                                        bool divNxt_ifDM = false, divPrev_ifDM = false;

                                        if (div_nxtCtrl != null)
                                        {
                                            divArtNo_nxtCtrl = div_nxtCtrl.Div_ArtNo;
                                            divNxt_ifDM = div_nxtCtrl.Div_ChkDM;
                                        }
                                        if (div_prevCtrl != null)
                                        {
                                            divArtNo_prevCtrl = div_prevCtrl.Div_ArtNo;
                                            divPrev_ifDM = div_prevCtrl.Div_ChkDM;
                                        }
                                        if (divTopOrLeft != null)
                                        {
                                            divArtNo_LeftOrTop = divTopOrLeft.Div_ArtNo;
                                        }
                                        if (divBotOrRight != null)
                                        {
                                            divArtNo_RightOrBot = divBotOrRight.Div_ArtNo;
                                        }

                                        if (pnl_curCtrl.Panel_Placement == "First")
                                        {
                                            if (divTopOrLeft_lvl3 != null)
                                            {
                                                divArtNo_LeftOrTop_lvl3 = divTopOrLeft_lvl3.Div_ArtNo;
                                            }
                                        }
                                        else if (pnl_curCtrl.Panel_Placement == "Last")
                                        {
                                            if (divBotOrRight_lvl3 != null)
                                            {
                                                divArtNo_RightOrBot_lvl3 = divBotOrRight_lvl3.Div_ArtNo;
                                            }

                                        }

                                        pnl_curCtrl.SetPanelExplosionValues_Panel(divArtNo_nxtCtrl,
                                                                                  divArtNo_prevCtrl,
                                                                                  div_prevCtrl.Div_Type,
                                                                                  divNxt_ifDM,
                                                                                  divPrev_ifDM,
                                                                                  divArtNo_LeftOrTop,
                                                                                  divArtNo_RightOrBot,
                                                                                  mpnl_Parent_lvl3_mpanelType,
                                                                                  divArtNo_LeftOrTop_lvl3,
                                                                                  divArtNo_RightOrBot_lvl3,
                                                                                  pnl_curCtrl.Panel_Placement,
                                                                                  mpanel_placement,
                                                                                  mpanelParentlvl2_placement);
                                    }
                                }

                                if (pnl_curCtrl != null)
                                {
                                    if (pnl_curCtrl.Panel_GlassThickness == 13.0f ||
                                        pnl_curCtrl.Panel_GlassThickness == 14.0f ||
                                        pnl_curCtrl.Panel_GlassThickness == 24.0f)
                                    {
                                        glazing_seal += (pnl_curCtrl.Panel_GlazingBeadWidth * 2) + (pnl_curCtrl.Panel_GlazingBeadHeight * 2);
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
                    else if (frame.Lst_Panel.Count() == 1 && frame.Lst_MultiPanel.Count() == 0)
                    {
                        IPanelModel pnl = frame.Lst_Panel[0];
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

                        if (pnl.Panel_GlassThickness == 13.0f ||
                            pnl.Panel_GlassThickness == 14.0f ||
                            pnl.Panel_GlassThickness == 24.0f)
                        {
                            glazing_seal += (pnl.Panel_GlazingBeadWidth * 2) + (pnl.Panel_GlazingBeadHeight * 2);
                        }
                    }

                    Material_List.Rows.Add("Glazing Spacer (KBC70)",
                                           glazing_spacer, "pc(s)", "");

                    Material_List.Rows.Add("Glazing Seal",
                                           glazing_seal, "mm", "");
                }

                Frame_PUFoamingQty_Total = (int)Math.Ceiling((decimal)(totalFrames_width + totalFrames_height) / 29694);
                Frame_SealantWHQty_Total = (int)Math.Ceiling((decimal)(totalFrames_width + totalFrames_height) / 3570);
                Glass_SealantWHQty_Total = (int)(Math.Ceiling((decimal)(total_glassWidth + total_glassHeight) / 6842));

                Material_List.Rows.Add("PU Foaming",
                                       Frame_PUFoamingQty_Total, "can", "");

                Material_List.Rows.Add("Sealant-WH (Frame)",
                                       Frame_SealantWHQty_Total, "pc(s)", "");

                Material_List.Rows.Add("Sealant-WH (Glass)",
                                       Glass_SealantWHQty_Total,
                                       "pc(s)",
                                       "");

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

        public DataTable GetListOfMaterials(IWindoorModel item)
        {
            DataTable Material_List = new DataTable();
            Material_List.Columns.Add(CreateColumn("Description", "Description", "System.String"));
            Material_List.Columns.Add(CreateColumn("Qty", "Qty", "System.Int32"));
            Material_List.Columns.Add(CreateColumn("Unit", "Unit", "System.String"));
            Material_List.Columns.Add(CreateColumn("Size", "Size", "System.String"));
            Material_List.Columns.Add(CreateColumn("Where", "Where", "System.String"));
            Material_List.Columns.Add(CreateColumn("Cut", "Cut", "System.String"));

            int totalFrames_width = 0,
                totalFrames_height = 0,
                total_glassWidth = 0,
                total_glassHeight = 0,
                glazing_seal = 0,
                glazing_spacer = 0,
                total_screws_fabrication = 0,
                total_screws_installation = 0,
                total_cladding_size = 0,
                additional_screws_fabrication = 0,
                exp_bolt = 0,
                frame_width = 0,
                frame_height = 0;

            string screws_for_inst_where = "";

            bool perFrame = false;

            foreach (IFrameModel frame in item.lst_frame)
            {
                perFrame = true;

                frame.SetExplosionValues_Frame();

                frame_width += frame.Frame_Width;
                frame_height += frame.Frame_Height;
                totalFrames_width += (frame.Frame_Width * 2);
                totalFrames_height += (frame.Frame_Height * 2);
                total_screws_fabrication += ((frame.Frame_Width * 2) + (frame.Frame_Height * 2));

                if (!screws_for_inst_where.Contains("Frame"))
                {
                    screws_for_inst_where = "Frame";
                }

                Material_List.Rows.Add("Frame Width " + frame.Frame_ArtNo.ToString(),
                                       2, "pc(s)",
                                       frame.Frame_ExplosionWidth.ToString(),
                                       "Frame",
                                       @"\  /");

                Material_List.Rows.Add("Frame Height " + frame.Frame_ArtNo.ToString(),
                                       2, "pc(s)",
                                       frame.Frame_ExplosionHeight,
                                       "Frame",
                                       @"\  /");

                Material_List.Rows.Add("Frame Reinf Width " + frame.Frame_ReinfArtNo.ToString(),
                                       2, "pc(s)",
                                       frame.Frame_ReinfWidth.ToString(),
                                       "Frame",
                                       @"|  |");

                Material_List.Rows.Add("Frame Reinf Height " + frame.Frame_ReinfArtNo.ToString(),
                                       2, "pc(s)",
                                       frame.Frame_ReinfHeight.ToString(),
                                       "Frame",
                                       @"|  |");

                if (frame.Lst_MultiPanel.Count() >= 1 && frame.Lst_Panel.Count() == 0)
                {
                    #region MultiPanel Parent
                    foreach (IMultiPanelModel mpnl in frame.Lst_MultiPanel)
                    {
                        List<IPanelModel> panels = mpnl.MPanelLst_Panel;
                        List<IDividerModel> divs = mpnl.MPanelLst_Divider;
                        List<IMultiPanelModel> mpanels = mpnl.MPanelLst_MultiPanel;

                        IDividerModel divTopOrLeft = null,
                                      divBotOrRight = null,
                                      divTopOrLeft_lvl3 = null,
                                      divBotOrRight_lvl3 = null;

                        IMultiPanelModel mpnl_Parent_lvl3 = null;
                        string mpanel_placement = "",
                               mpanelParentlvl2_placement = "",
                               mpnl_Parent_lvl3_mpanelType = "";

                        if (mpnl.MPanel_Parent.Name.Contains("Multi")) //2nd level stack
                        {
                            mpanel_placement = mpnl.MPanel_Placement;
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

                        if (mpnl.MPanel_ParentModel != null)
                        {
                            if (mpnl.MPanel_ParentModel.MPanel_Parent.Name.Contains("Multi")) //3rd level stack
                            {
                                mpnl_Parent_lvl3 = mpnl.MPanel_ParentModel.MPanel_ParentModel;
                                mpanelParentlvl2_placement = mpnl.MPanel_ParentModel.MPanel_Placement;
                                mpnl_Parent_lvl3_mpanelType = mpnl_Parent_lvl3.MPanel_Type;

                                Control mpnl_ctrl_lvl3 = mpnl_Parent_lvl3.MPanelLst_Objects.Find(mpanel => mpanel.Name == mpnl.MPanel_ParentModel.MPanel_Name);
                                int mpnl_ndx_lvl3 = mpnl_Parent_lvl3.MPanelLst_Objects.IndexOf(mpnl_ctrl_lvl3);
                                Control div_nxtctrl_lvl3, div_prevctrl_lvl3;

                                if (mpnl.MPanel_ParentModel.MPanel_Placement == "First")
                                {
                                    div_nxtctrl_lvl3 = mpnl_Parent_lvl3.MPanelLst_Objects[mpnl_ndx_lvl3 + 1];
                                    divBotOrRight_lvl3 = mpnl_Parent_lvl3.MPanelLst_Divider.Find(div => div.Div_Name == div_nxtctrl_lvl3.Name);
                                }
                                else if (mpnl.MPanel_ParentModel.MPanel_Placement == "Somewhere in Between")
                                {
                                    div_nxtctrl_lvl3 = mpnl_Parent_lvl3.MPanelLst_Objects[mpnl_ndx_lvl3 + 1];
                                    div_prevctrl_lvl3 = mpnl_Parent_lvl3.MPanelLst_Objects[mpnl_ndx_lvl3 - 1];

                                    divTopOrLeft_lvl3 = mpnl_Parent_lvl3.MPanelLst_Divider.Find(div => div.Div_Name == div_prevctrl_lvl3.Name);
                                    divBotOrRight_lvl3 = mpnl_Parent_lvl3.MPanelLst_Divider.Find(div => div.Div_Name == div_nxtctrl_lvl3.Name);
                                }
                                else if (mpnl.MPanel_ParentModel.MPanel_Placement == "Last")
                                {
                                    div_prevctrl_lvl3 = mpnl_Parent_lvl3.MPanelLst_Objects[mpnl_ndx_lvl3 - 1];
                                    divTopOrLeft_lvl3 = mpnl_Parent_lvl3.MPanelLst_Divider.Find(div => div.Div_Name == div_prevctrl_lvl3.Name);
                                }
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
                                div_nxtCtrl.SetExplosionValues_Div();

                                if (mpnl.MPanel_Type == "Mullion")
                                {
                                    if (div_nxtCtrl.Div_ChkDM == true)
                                    {
                                        Material_List.Rows.Add("Dummy Mullion Height " + div_nxtCtrl.Div_DMArtNo.ToString(),
                                                               1, "pc(s)",
                                                               div_nxtCtrl.Div_ExplosionHeight.ToString(),
                                                               div_nxtCtrl.Div_Bounded,
                                                               @"[  ]");
                                        Material_List.Rows.Add("Endcap for Dummy Mullion " + div_nxtCtrl.Div_EndcapDM.ToString(),
                                                               2, "pc(s)",
                                                               "",
                                                               "Dummy Mullion");
                                        Material_List.Rows.Add("Fixed cam " + div_nxtCtrl.Div_FixedCamDM.ToString(),
                                                               2, "pc(s)",
                                                               "",
                                                               "Sash");
                                        Material_List.Rows.Add("Snap and Keep " + div_nxtCtrl.Div_SnapNKeepDM.ToString(),
                                                               2, "pc(s)",
                                                               "",
                                                               "Frame");
                                        Material_List.Rows.Add("Aluminum spacer for Dummy Mullion FC770 (80mm)",
                                                               2, "pc(s)",
                                                               "",
                                                               "Dummy Mullion");
                                        Material_List.Rows.Add("Aluminum spacer for Dummy Mullion FC770 (50mm)",
                                                               div_nxtCtrl.Div_AlumSpacer50Qty, "pc(s)",
                                                               "",
                                                               "Dummy Mullion");
                                    }
                                    else if (div_nxtCtrl.Div_ChkDM == false)
                                    {
                                        Material_List.Rows.Add(mpnl.MPanel_Type + " Height " + div_nxtCtrl.Div_ArtNo.ToString(),
                                                               1, "pc(s)",
                                                               div_nxtCtrl.Div_ExplosionHeight.ToString(),
                                                               div_nxtCtrl.Div_Bounded,
                                                               @"[  ]");
                                        Material_List.Rows.Add(mpnl.MPanel_Type + " Reinforcement Height " + div_nxtCtrl.Div_ReinfArtNo.ToString(),
                                                               1, "pc(s)",
                                                               div_nxtCtrl.Div_ReinfHeight.ToString(),
                                                               mpnl.MPanel_Type,
                                                               @"|  |");

                                        total_screws_fabrication += div_nxtCtrl.Div_ExplosionHeight;

                                        if (!screws_for_inst_where.Contains("Mullion"))
                                        {
                                            screws_for_inst_where += ", Mullion";
                                        }
                                    }

                                    foreach (int cladding_size in div_nxtCtrl.Div_CladdingSizeList.Values)
                                    {
                                        total_cladding_size += cladding_size;

                                        Material_List.Rows.Add("Cladding Profile " + div_nxtCtrl.Div_CladdingProfileArtNo.ToString(),
                                                               1, "pc(s)",
                                                               cladding_size.ToString(),
                                                               mpnl.MPanel_Type,
                                                               @"|  |");

                                        Material_List.Rows.Add("Cladding Reinforcement " + div_nxtCtrl.Div_CladdingReinfArtNo.ToString(),
                                                               1, "pc(s)",
                                                               cladding_size.ToString(),
                                                               "CPL",
                                                               @"|  |");
                                    }
                                }
                                else if (mpnl.MPanel_Type == "Transom")
                                {
                                    Material_List.Rows.Add(mpnl.MPanel_Type + " Width " + div_nxtCtrl.Div_ArtNo.ToString(),
                                                           1, "pc(s)",
                                                           div_nxtCtrl.Div_ExplosionWidth.ToString(),
                                                           div_nxtCtrl.Div_Bounded,
                                                           @"[  ]");
                                    Material_List.Rows.Add(mpnl.MPanel_Type + " Reinforcement Width " + div_nxtCtrl.Div_ReinfArtNo.ToString(),
                                                           1, "pc(s)",
                                                           div_nxtCtrl.Div_ReinfWidth.ToString(),
                                                           mpnl.MPanel_Type,
                                                           @"|  |");

                                    total_screws_fabrication += div_nxtCtrl.Div_ExplosionWidth;

                                    if (!screws_for_inst_where.Contains("Transom"))
                                    {
                                        screws_for_inst_where += ", Transom";
                                    }

                                    foreach (int cladding_size in div_nxtCtrl.Div_CladdingSizeList.Values)
                                    {
                                        total_cladding_size += cladding_size;

                                        Material_List.Rows.Add("Cladding Profile " + div_nxtCtrl.Div_CladdingProfileArtNo.ToString(),
                                                               1, "pc(s)",
                                                               cladding_size.ToString(),
                                                               mpnl.MPanel_Type,
                                                               @"|  |");

                                        Material_List.Rows.Add("Cladding Reinforcement " + div_nxtCtrl.Div_CladdingReinfArtNo.ToString(),
                                                               1, "pc(s)",
                                                               cladding_size.ToString(),
                                                               "CPL",
                                                               @"|  |");
                                    }
                                }
                                if (div_nxtCtrl.Div_ChkDM == false)
                                {
                                    Material_List.Rows.Add(mpnl.MPanel_Type + " Mechanical Joint " + div_nxtCtrl.Div_MechJoinArtNo.ToString(),
                                                           2, "pc(s)", "");
                                }
                                if (div_nxtCtrl.Div_MechJoinArtNo == Divider_MechJointArticleNo._AV585)
                                {
                                    additional_screws_fabrication += 2;
                                }

                                Divider_ArticleNo divArtNo_nxtCtrl = Divider_ArticleNo._None,
                                                  divArtNo_prevCtrl = Divider_ArticleNo._None,
                                                  divArtNo_LeftOrTop = Divider_ArticleNo._None,
                                                  divArtNo_RightOrBot = Divider_ArticleNo._None,
                                                  divArtNo_LeftOrTop_lvl3 = Divider_ArticleNo._None,
                                                  divArtNo_RightOrBot_lvl3 = Divider_ArticleNo._None;
                                bool divNxt_ifDM = false,
                                     divPrev_ifDM = false;

                                if (div_nxtCtrl != null)
                                {
                                    divArtNo_nxtCtrl = div_nxtCtrl.Div_ArtNo;
                                    divNxt_ifDM = div_nxtCtrl.Div_ChkDM;
                                }
                                if (div_prevCtrl != null)
                                {
                                    divArtNo_prevCtrl = div_prevCtrl.Div_ArtNo;
                                    divPrev_ifDM = div_prevCtrl.Div_ChkDM;
                                }
                                if (divTopOrLeft != null)
                                {
                                    divArtNo_LeftOrTop = divTopOrLeft.Div_ArtNo;
                                }
                                if (divBotOrRight != null)
                                {
                                    divArtNo_RightOrBot = divBotOrRight.Div_ArtNo;
                                }


                                if (pnl_curCtrl != null)
                                {
                                    if (pnl_curCtrl.Panel_Placement == "First")
                                    {
                                        if (divTopOrLeft_lvl3 != null)
                                        {
                                            divArtNo_LeftOrTop_lvl3 = divTopOrLeft_lvl3.Div_ArtNo;
                                        }
                                    }
                                    else if (pnl_curCtrl.Panel_Placement == "Last")
                                    {
                                        if (divBotOrRight_lvl3 != null)
                                        {
                                            divArtNo_RightOrBot_lvl3 = divBotOrRight_lvl3.Div_ArtNo;
                                        }
                                    }

                                    pnl_curCtrl.SetPanelExplosionValues_Panel(divArtNo_nxtCtrl,
                                                                              divArtNo_prevCtrl,
                                                                              div_nxtCtrl.Div_Type,
                                                                              divNxt_ifDM,
                                                                              divPrev_ifDM,
                                                                              divArtNo_LeftOrTop,
                                                                              divArtNo_RightOrBot,
                                                                              mpnl_Parent_lvl3_mpanelType,
                                                                              divArtNo_LeftOrTop_lvl3,
                                                                              divArtNo_RightOrBot_lvl3,
                                                                              pnl_curCtrl.Panel_Placement,
                                                                              mpanel_placement,
                                                                              mpanelParentlvl2_placement);
                                }
                                else if (mpnl_curCtrl != null)
                                {
                                    if (mpnl_curCtrl.MPanel_Placement == "First")
                                    {
                                        if (divTopOrLeft_lvl3 != null)
                                        {
                                            divArtNo_LeftOrTop_lvl3 = divTopOrLeft_lvl3.Div_ArtNo;
                                        }
                                    }
                                    else if (mpnl_curCtrl.MPanel_Placement == "Last")
                                    {
                                        if (divBotOrRight_lvl3 != null)
                                        {
                                            divArtNo_RightOrBot_lvl3 = divBotOrRight_lvl3.Div_ArtNo;
                                        }
                                    }

                                    mpnl_curCtrl.SetMPanelExplosionValues_Panel(divArtNo_nxtCtrl,
                                                                                divArtNo_prevCtrl,
                                                                                div_nxtCtrl.Div_Type,
                                                                                divArtNo_LeftOrTop,
                                                                                divArtNo_RightOrBot,
                                                                                mpnl_Parent_lvl3_mpanelType,
                                                                                divArtNo_LeftOrTop_lvl3,
                                                                                divArtNo_RightOrBot_lvl3,
                                                                                mpnl_curCtrl.MPanel_Placement,
                                                                                mpanel_placement,
                                                                                mpanelParentlvl2_placement);
                                }
                            }
                            else if (i + 1 == obj_count)
                            {
                                Divider_ArticleNo divArtNo_nxtCtrl = Divider_ArticleNo._None,
                                                  divArtNo_prevCtrl = Divider_ArticleNo._None,
                                                  divArtNo_LeftOrTop = Divider_ArticleNo._None,
                                                  divArtNo_RightOrBot = Divider_ArticleNo._None,
                                                  divArtNo_LeftOrTop_lvl3 = Divider_ArticleNo._None,
                                                  divArtNo_RightOrBot_lvl3 = Divider_ArticleNo._None;
                                bool divNxt_ifDM = false,
                                    divPrev_ifDM = false;

                                if (div_nxtCtrl != null)
                                {
                                    divArtNo_nxtCtrl = div_nxtCtrl.Div_ArtNo;
                                    divNxt_ifDM = div_nxtCtrl.Div_ChkDM;
                                }
                                if (div_prevCtrl != null)
                                {
                                    divArtNo_prevCtrl = div_prevCtrl.Div_ArtNo;
                                    divPrev_ifDM = div_prevCtrl.Div_ChkDM;
                                }
                                if (divTopOrLeft != null)
                                {
                                    divArtNo_LeftOrTop = divTopOrLeft.Div_ArtNo;
                                }
                                if (divBotOrRight != null)
                                {
                                    divArtNo_RightOrBot = divBotOrRight.Div_ArtNo;
                                }

                                if (pnl_curCtrl != null)
                                {
                                    if (pnl_curCtrl.Panel_Placement == "First")
                                    {
                                        if (divTopOrLeft_lvl3 != null)
                                        {
                                            divArtNo_LeftOrTop_lvl3 = divTopOrLeft_lvl3.Div_ArtNo;
                                        }
                                    }
                                    else if (pnl_curCtrl.Panel_Placement == "Last")
                                    {
                                        if (divBotOrRight_lvl3 != null)
                                        {
                                            divArtNo_RightOrBot_lvl3 = divBotOrRight_lvl3.Div_ArtNo;
                                        }
                                    }

                                    pnl_curCtrl.SetPanelExplosionValues_Panel(divArtNo_nxtCtrl,
                                                                              divArtNo_prevCtrl,
                                                                              div_prevCtrl.Div_Type,
                                                                              divNxt_ifDM,
                                                                              divPrev_ifDM,
                                                                              divArtNo_LeftOrTop,
                                                                              divArtNo_RightOrBot,
                                                                              mpnl_Parent_lvl3_mpanelType,
                                                                              divArtNo_LeftOrTop_lvl3,
                                                                              divArtNo_RightOrBot_lvl3,
                                                                              pnl_curCtrl.Panel_Placement,
                                                                              mpanel_placement,
                                                                              mpanelParentlvl2_placement);
                                }
                                else if (mpnl_curCtrl != null)
                                {
                                    if (mpnl_curCtrl.MPanel_Placement == "First")
                                    {
                                        if (divTopOrLeft_lvl3 != null)
                                        {
                                            divArtNo_LeftOrTop_lvl3 = divTopOrLeft_lvl3.Div_ArtNo;
                                        }
                                    }
                                    else if (mpnl_curCtrl.MPanel_Placement == "Last")
                                    {
                                        if (divBotOrRight_lvl3 != null)
                                        {
                                            divArtNo_RightOrBot_lvl3 = divBotOrRight_lvl3.Div_ArtNo;
                                        }
                                    }

                                    mpnl_curCtrl.SetMPanelExplosionValues_Panel(divArtNo_nxtCtrl,
                                                                                divArtNo_prevCtrl,
                                                                                div_prevCtrl.Div_Type,
                                                                                divArtNo_LeftOrTop,
                                                                                divArtNo_RightOrBot,
                                                                                mpnl_Parent_lvl3_mpanelType,
                                                                                divArtNo_LeftOrTop_lvl3,
                                                                                divArtNo_RightOrBot_lvl3,
                                                                                mpnl_curCtrl.MPanel_Placement,
                                                                                mpanel_placement,
                                                                                mpanelParentlvl2_placement);
                                }
                            }

                            if (pnl_curCtrl != null)
                            {
                                double glassThickness_roundUP = Math.Ceiling(pnl_curCtrl.Panel_GlassThickness);

                                if (glassThickness_roundUP == 13.0f ||
                                    glassThickness_roundUP == 14.0f ||
                                    glassThickness_roundUP == 24.0f)
                                {
                                    glazing_seal += (pnl_curCtrl.Panel_GlazingBeadWidth * 2) + (pnl_curCtrl.Panel_GlazingBeadHeight * 2);
                                }

                                if (pnl_curCtrl.Panel_SashPropertyVisibility == true)
                                {
                                    total_screws_fabrication += ((pnl_curCtrl.Panel_SashWidth * 2) + (pnl_curCtrl.Panel_SashHeight * 2));

                                    Material_List.Rows.Add("Sash Width " + pnl_curCtrl.Panel_SashProfileArtNo.ToString(),
                                                           2, "pc(s)",
                                                           pnl_curCtrl.Panel_SashWidth.ToString(),
                                                           "Sash",
                                                           @"\  /");

                                    Material_List.Rows.Add("Sash Height " + pnl_curCtrl.Panel_SashProfileArtNo.ToString(),
                                                           2, "pc(s)",
                                                           pnl_curCtrl.Panel_SashHeight.ToString(),
                                                           "Sash",
                                                           @"\  /");

                                    Material_List.Rows.Add("Sash Reinf Width " + pnl_curCtrl.Panel_SashReinfArtNo.ToString(),
                                                           2, "pc(s)",
                                                           pnl_curCtrl.Panel_SashReinfWidth.ToString(),
                                                           "Sash",
                                                           @"|  |");

                                    Material_List.Rows.Add("Sash Reinf Height " + pnl_curCtrl.Panel_SashReinfArtNo.ToString(),
                                                           2, "pc(s)",
                                                           pnl_curCtrl.Panel_SashReinfHeight.ToString(),
                                                           "Sash",
                                                           @"|  |");

                                    if (pnl_curCtrl.Panel_Type.Contains("Fixed") == false)
                                    {
                                        Material_List.Rows.Add("Cover Profile " + pnl_curCtrl.Panel_CoverProfileArtNo.ToString(),
                                                                   1, "pc(s)",
                                                                   frame.Frame_Width.ToString(),
                                                                   "Frame",
                                                                   @"|  |");

                                        Material_List.Rows.Add("Cover Profile " + pnl_curCtrl.Panel_CoverProfileArtNo2.ToString(),
                                                               1, "pc(s)",
                                                               frame.Frame_Width.ToString(),
                                                               "Frame",
                                                               @"|  |");

                                    }

                                    if (perFrame == true)
                                    {
                                        if (pnl_curCtrl.Panel_MotorizedOptionVisibility == true)
                                        {
                                            Material_List.Rows.Add("30X25 Cover " + pnl_curCtrl.Panel_30x25CoverArtNo.ToString(),
                                                   1, "pc(s)",
                                                   frame.Frame_Width,
                                                   "Frame",
                                                   @"");

                                            Material_List.Rows.Add("Divider " + pnl_curCtrl.Panel_MotorizedDividerArtNo.ToString(),
                                                                   1, "pc(s)",
                                                                   frame.Frame_Width,
                                                                   "Frame",
                                                                   @"");

                                            Material_List.Rows.Add("Cover for motor " + pnl_curCtrl.Panel_CoverForMotorArtNo.ToString(),
                                                                   1, "pc(s)",
                                                                   frame.Frame_Width + 150,
                                                                   "Frame",
                                                                   @"");

                                            Material_List.Rows.Add("2D Hinge " + pnl_curCtrl.Panel_2dHingeArtNo.ToString(),
                                                                   pnl_curCtrl.Panel_2DHingeQty, "pair(s)",
                                                                   "",
                                                                   "Sash & Frame",
                                                                   @"");

                                            additional_screws_fabrication += 3;

                                            Material_List.Rows.Add("Motorized Mechanism " + pnl_curCtrl.Panel_MotorizedMechArtNo.ToString(),
                                                                   pnl_curCtrl.Panel_MotorizedMechQty, "pc(s)",
                                                                   "",
                                                                   "Sash",
                                                                   @"");

                                            if (pnl_curCtrl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._409990E)
                                            {
                                                total_screws_installation += (20 * pnl_curCtrl.Panel_MotorizedMechQty);
                                            }
                                            else if (pnl_curCtrl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41555B ||
                                                     pnl_curCtrl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41556C)
                                            {
                                                total_screws_installation += (10 * pnl_curCtrl.Panel_MotorizedMechQty);
                                            }

                                            Material_List.Rows.Add("Push Button Switch " + pnl_curCtrl.Panel_PushButtonSwitchArtNo.ToString(),
                                                                   pnl_curCtrl.Panel_MotorizedMechSetQty, "pc(s)",
                                                                   "",
                                                                   "Concrete",
                                                                   @"");

                                            Material_List.Rows.Add("False pole " + pnl_curCtrl.Panel_FalsePoleArtNo.ToString(),
                                                                   pnl_curCtrl.Panel_MotorizedMechSetQty * 2, "pc(s)",
                                                                   "",
                                                                   "Concrete",
                                                                   @"");

                                            total_screws_installation += 4;

                                            Material_List.Rows.Add("Supporting Frame " + pnl_curCtrl.Panel_SupportingFrameArtNo.ToString(),
                                                                   pnl_curCtrl.Panel_MotorizedMechSetQty, "pc(s)",
                                                                   "",
                                                                   "Concrete",
                                                                   @"");

                                            Material_List.Rows.Add("Plate " + pnl_curCtrl.Panel_PlateArtNo.ToString(),
                                                                   pnl_curCtrl.Panel_MotorizedMechSetQty, "pc(s)",
                                                                   "",
                                                                   "Concrete",
                                                                   @"");
                                        }
                                        perFrame = false;
                                    }

                                    if (pnl_curCtrl.Panel_MotorizedOptionVisibility == false)
                                    {
                                        if (pnl_curCtrl.Panel_Type.Contains("Awning"))
                                        {
                                            Material_List.Rows.Add("Friction Stay " + pnl_curCtrl.Panel_FrictionStayArtNo.ToString(),
                                                                   1, "pair(s)",
                                                                   "",
                                                                   "Sash & Frame",
                                                                   @"");

                                            if (pnl_curCtrl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm26)
                                            {
                                                additional_screws_fabrication += 6; //for Storm26

                                                Material_List.Rows.Add("Snap-in Keep " + pnl_curCtrl.Panel_SnapInKeepArtNo.ToString(),
                                                                       2, "pc(s)",
                                                                       "",
                                                                       "Frame",
                                                                       @"");

                                                additional_screws_fabrication += 4;

                                                Material_List.Rows.Add("Plastic Wedge " + pnl_curCtrl.Panel_PlasticWedge.DisplayName,
                                                                       pnl_curCtrl.Panel_PlasticWedgeQty, "pc (s)",
                                                                       "",
                                                                       "Frame",
                                                                       @"");

                                                Material_List.Rows.Add("Fixed Cam " + pnl_curCtrl.Panel_FixedCamArtNo.ToString(),
                                                                       2, "pc(s)",
                                                                       "",
                                                                       "Frame",
                                                                       @"");

                                                additional_screws_fabrication += 4;
                                            }
                                            else if (pnl_curCtrl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm8)
                                            {
                                                additional_screws_fabrication += 3;
                                            }
                                            else if (pnl_curCtrl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._477254 ||
                                                     pnl_curCtrl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._A2121C1261)
                                            {
                                                additional_screws_fabrication += 4;
                                            }
                                            else if (pnl_curCtrl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._A212C16161)
                                            {
                                                additional_screws_fabrication += 5;
                                            }
                                            else if (pnl_curCtrl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm22)
                                            {
                                                additional_screws_fabrication += 6;
                                            }
                                        }
                                        else if (pnl_curCtrl.Panel_Type.Contains("Casement"))
                                        {
                                            if (pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                            {
                                                if (pnl_curCtrl.Panel_HingeOptions == HingeOption._FrictionStay)
                                                {
                                                    Material_List.Rows.Add("Friction Stay " + pnl_curCtrl.Panel_FSCasementArtNo.ToString(),
                                                                           1, "pair(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");

                                                }
                                                else if (pnl_curCtrl.Panel_HingeOptions == HingeOption._2DHinge)
                                                {
                                                    Material_List.Rows.Add("2D hinge " + pnl_curCtrl.Panel_2dHingeArtNo_nonMotorized.ToString(),
                                                                           pnl_curCtrl.Panel_2DHingeQty_nonMotorized, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");
                                                }
                                            }

                                            Material_List.Rows.Add("Plastic Wedge " + pnl_curCtrl.Panel_PlasticWedge.DisplayName,
                                                                   pnl_curCtrl.Panel_PlasticWedgeQty, "pc (s)",
                                                                   "",
                                                                   "Frame",
                                                                   @"");

                                            if (pnl_curCtrl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._485770)
                                            {
                                                additional_screws_fabrication += 3;
                                            }
                                            else if (pnl_curCtrl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._A235B12161 ||
                                                     pnl_curCtrl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._A212C12161)
                                            {
                                                additional_screws_fabrication += 4;
                                            }
                                            else if (pnl_curCtrl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._A212C16161)
                                            {
                                                additional_screws_fabrication += 5;
                                            }
                                            else if (pnl_curCtrl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._A212C20161)
                                            {
                                                additional_screws_fabrication += 6;
                                            }
                                        }


                                        if (pnl_curCtrl.Panel_HandleType == Handle_Type._Rotoswing)
                                        {
                                            if (pnl_curCtrl.Panel_ExtTopQty > 0)
                                            {
                                                Material_List.Rows.Add("Extension(Top) " + pnl_curCtrl.Panel_ExtensionTopArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtTopQty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionTopArtNo == Extension_ArticleNo._612978)
                                                {
                                                    additional_screws_fabrication += (3 * pnl_curCtrl.Panel_ExtTopQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionTopArtNo == Extension_ArticleNo._639957)
                                                {
                                                    additional_screws_fabrication += (5 * pnl_curCtrl.Panel_ExtTopQty);
                                                }
                                            }
                                            if (pnl_curCtrl.Panel_ExtTop2Qty > 0)
                                            {
                                                Material_List.Rows.Add("Extension_2(Top) " + pnl_curCtrl.Panel_ExtensionTop2ArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtTop2Qty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._612978)
                                                {
                                                    additional_screws_fabrication += (3 * pnl_curCtrl.Panel_ExtTop2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._639957)
                                                {
                                                    additional_screws_fabrication += (5 * pnl_curCtrl.Panel_ExtTop2Qty);
                                                }
                                            }
                                            if (pnl_curCtrl.Panel_ExtBotQty > 0)
                                            {
                                                Material_List.Rows.Add("Extension(Bot) " + pnl_curCtrl.Panel_ExtensionBotArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtBotQty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionBotArtNo == Extension_ArticleNo._612978)
                                                {
                                                    additional_screws_fabrication += (3 * pnl_curCtrl.Panel_ExtBotQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionBotArtNo == Extension_ArticleNo._639957)
                                                {
                                                    additional_screws_fabrication += (5 * pnl_curCtrl.Panel_ExtBotQty);
                                                }
                                            }
                                            if (pnl_curCtrl.Panel_ExtBot2Qty > 0)
                                            {
                                                Material_List.Rows.Add("Extension_2(Bot) " + pnl_curCtrl.Panel_ExtensionBot2ArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtBot2Qty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._612978)
                                                {
                                                    additional_screws_fabrication += (3 * pnl_curCtrl.Panel_ExtBot2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._639957)
                                                {
                                                    additional_screws_fabrication += (5 * pnl_curCtrl.Panel_ExtBot2Qty);
                                                }
                                            }
                                            if (pnl_curCtrl.Panel_ExtLeftQty > 0)
                                            {
                                                Material_List.Rows.Add("Extension(Left) " + pnl_curCtrl.Panel_ExtensionLeftArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtLeftQty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._612978)
                                                {
                                                    additional_screws_fabrication += (3 * pnl_curCtrl.Panel_ExtLeftQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957)
                                                {
                                                    additional_screws_fabrication += (5 * pnl_curCtrl.Panel_ExtLeftQty);
                                                }
                                            }
                                            if (pnl_curCtrl.Panel_ExtLeft2Qty > 0)
                                            {
                                                Material_List.Rows.Add("Extension_2(Left) " + pnl_curCtrl.Panel_ExtensionLeft2ArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtLeft2Qty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._612978)
                                                {
                                                    additional_screws_fabrication += (3 * pnl_curCtrl.Panel_ExtLeft2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957)
                                                {
                                                    additional_screws_fabrication += (5 * pnl_curCtrl.Panel_ExtLeft2Qty);
                                                }
                                            }
                                            if (pnl_curCtrl.Panel_ExtRightQty > 0)
                                            {
                                                Material_List.Rows.Add("Extension(Right) " + pnl_curCtrl.Panel_ExtensionRightArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtRightQty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionRightArtNo == Extension_ArticleNo._612978)
                                                {
                                                    additional_screws_fabrication += (3 * pnl_curCtrl.Panel_ExtRightQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionRightArtNo == Extension_ArticleNo._639957)
                                                {
                                                    additional_screws_fabrication += (5 * pnl_curCtrl.Panel_ExtRightQty);
                                                }
                                            }
                                            if (pnl_curCtrl.Panel_ExtRight2Qty > 0)
                                            {
                                                Material_List.Rows.Add("Extension_2(Right) " + pnl_curCtrl.Panel_ExtensionRight2ArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtRight2Qty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._612978)
                                                {
                                                    additional_screws_fabrication += (3 * pnl_curCtrl.Panel_ExtRight2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                                                {
                                                    additional_screws_fabrication += (5 * pnl_curCtrl.Panel_ExtRight2Qty);
                                                }
                                            }

                                            if (pnl_curCtrl.Panel_CornerDriveArtNo != CornerDrive_ArticleNo._None &&
                                                pnl_curCtrl.Panel_CornerDriveArtNo != null)
                                            {
                                                Material_List.Rows.Add("Corner Drive " + pnl_curCtrl.Panel_CornerDriveArtNo.ToString(),
                                                                       2, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                additional_screws_fabrication += 4;
                                            }

                                            Material_List.Rows.Add("Rotoswing handle " + pnl_curCtrl.Panel_RotoswingArtNo.ToString(),
                                                                   1, "pc (s)",
                                                                   "",
                                                                   "Sash",
                                                                   @"");

                                            if (pnl_curCtrl.Panel_Type.Contains("Awning"))
                                            {
                                                Material_List.Rows.Add("Striker " + pnl_curCtrl.Panel_StrikerArtno_A.ToString(),
                                                                       pnl_curCtrl.Panel_StrikerQty_A, "pc (s)",
                                                                       "",
                                                                       "Frame",
                                                                       @"");

                                                additional_screws_fabrication += pnl_curCtrl.Panel_StrikerQty_A;

                                                if (pnl_curCtrl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957 ||
                                                        pnl_curCtrl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957 ||
                                                        pnl_curCtrl.Panel_ExtensionRightArtNo == Extension_ArticleNo._639957 ||
                                                        pnl_curCtrl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                                                {
                                                    Material_List.Rows.Add("Striker " + pnl_curCtrl.Panel_StrikerArtno_C.ToString(),
                                                                       pnl_curCtrl.Panel_StrikerQty_C, "pc (s)",
                                                                       "",
                                                                       "Frame",
                                                                       @"");

                                                    additional_screws_fabrication += pnl_curCtrl.Panel_StrikerQty_C;
                                                }
                                            }
                                            else if (pnl_curCtrl.Panel_Type.Contains("Casement"))
                                            {
                                                if (pnl_curCtrl.Panel_CornerDriveArtNo != CornerDrive_ArticleNo._None)
                                                {
                                                    Material_List.Rows.Add("Striker " + pnl_curCtrl.Panel_StrikerArtno_C.ToString(),
                                                                       pnl_curCtrl.Panel_StrikerQty_C, "pc (s)",
                                                                       "",
                                                                       "Frame",
                                                                       @"");

                                                    additional_screws_fabrication += pnl_curCtrl.Panel_StrikerQty_C;

                                                    Material_List.Rows.Add("Striker " + pnl_curCtrl.Panel_StrikerArtno_A.ToString(),
                                                                           pnl_curCtrl.Panel_StrikerQty_A, "pc (s)",
                                                                           "",
                                                                           "Frame",
                                                                           @"");

                                                    additional_screws_fabrication += pnl_curCtrl.Panel_StrikerQty_A;
                                                }
                                            }

                                            Material_List.Rows.Add("Middle Closer " + pnl_curCtrl.Panel_MiddleCloserArtNo.ToString(),
                                                                   pnl_curCtrl.Panel_MiddleCloserPairQty, "pair (s)",
                                                                   "",
                                                                   "Sash & Frame",
                                                                   @"");

                                            additional_screws_fabrication += (4 * pnl_curCtrl.Panel_MiddleCloserPairQty);
                                        }
                                        else if (pnl_curCtrl.Panel_HandleType == Handle_Type._Rotary)
                                        {
                                            Material_List.Rows.Add("Rotary handle " + pnl_curCtrl.Panel_RotaryArtNo.ToString(),
                                                                   1, "set (s)",
                                                                   "",
                                                                   "Frame & Sash",
                                                                   @"");

                                            Material_List.Rows.Add("Locking Kit " + pnl_curCtrl.Panel_LockingKitArtNo.ToString(),
                                                                   1, "set (s)",
                                                                   "",
                                                                   "Sash",
                                                                   @"");

                                            additional_screws_fabrication += 9;
                                        }
                                        else if (pnl_curCtrl.Panel_HandleType == Handle_Type._Rio)
                                        {
                                            Material_List.Rows.Add("Rio handle " + pnl_curCtrl.Panel_RioArtNo.ToString(),
                                                                   1, "pc(s)",
                                                                   "",
                                                                   "Sash",
                                                                   @"");

                                            Material_List.Rows.Add("Profile Knob Cylinder " + pnl_curCtrl.Panel_ProfileKnobCylinderArtNo.ToString(),
                                                                   1, "pc(s)",
                                                                   "",
                                                                   "Sash",
                                                                   @"");

                                            Material_List.Rows.Add("Cylinder Cover " + pnl_curCtrl.Panel_CylinderCoverArtNo.ToString(),
                                                                   1, "pc(s)",
                                                                   "",
                                                                   "Sash",
                                                                   @"");
                                        }
                                        else if (pnl_curCtrl.Panel_HandleType == Handle_Type._Rotoline)
                                        {
                                            Material_List.Rows.Add("Rio handle " + pnl_curCtrl.Panel_RotolineArtNo.ToString(),
                                                                   1, "pc(s)",
                                                                   "",
                                                                   "Sash",
                                                                   @"");
                                        }
                                        else if (pnl_curCtrl.Panel_HandleType == Handle_Type._MVD)
                                        {
                                            Material_List.Rows.Add("MVD handle " + pnl_curCtrl.Panel_MVDArtNo.ToString(),
                                                                   1, "pc(s)",
                                                                   "",
                                                                   "Sash",
                                                                   @"");

                                            Material_List.Rows.Add("Profile Knob Cylinder " + pnl_curCtrl.Panel_ProfileKnobCylinderArtNo.ToString(),
                                                                   1, "pc(s)",
                                                                   "",
                                                                   "Sash",
                                                                   @"");

                                        }

                                        if (pnl_curCtrl.Panel_HandleType != Handle_Type._Rotary)
                                        {
                                            if (pnl_curCtrl.Panel_EspagnoletteArtNo != Espagnolette_ArticleNo._None)
                                            {
                                                Material_List.Rows.Add("Espagnolette " + pnl_curCtrl.Panel_EspagnoletteArtNo.ToString(),
                                                                       1, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");
                                            }

                                            if (pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                                                pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT ||
                                                pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_205 ||
                                                pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_206 ||
                                                pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_207)
                                            {
                                                additional_screws_fabrication += 8;
                                            }
                                            else if (pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                                                     pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._630963)
                                            {
                                                additional_screws_fabrication += 2;
                                            }
                                            else if (pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807)
                                            {
                                                additional_screws_fabrication += 4;
                                            }
                                            else if (pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809 ||
                                                     pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A00006 ||
                                                     pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A01006 ||
                                                     pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                                                     pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206 ||
                                                     pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                                                     pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206 ||
                                                     pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A06206)
                                            {
                                                additional_screws_fabrication += 6;
                                            }
                                            else if (pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                                                     pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                                            {
                                                additional_screws_fabrication += 12;
                                            }
                                        }
                                    }
                                }

                                Material_List.Rows.Add("Glazing Bead Width (P" + pnl_curCtrl.PanelGlass_ID + ") " + pnl_curCtrl.PanelGlazingBead_ArtNo.ToString(),
                                                       2, "pc(s)",
                                                       pnl_curCtrl.Panel_GlazingBeadWidth.ToString(),
                                                       "Frame",
                                                       @"\  /");

                                Material_List.Rows.Add("Glazing Bead Height (P" + pnl_curCtrl.PanelGlass_ID + ") " + pnl_curCtrl.PanelGlazingBead_ArtNo.ToString(),
                                                       2, "pc(s)",
                                                       pnl_curCtrl.Panel_GlazingBeadHeight.ToString(),
                                                       "Frame",
                                                       @"\  /");

                                string glassFilm = "";
                                if (pnl_curCtrl.Panel_GlassFilm != GlassFilm_Types._None)
                                {
                                    glassFilm = pnl_curCtrl.Panel_GlassFilm.DisplayName;
                                }

                                Material_List.Rows.Add("Glass Width (P" + pnl_curCtrl.PanelGlass_ID + "-" + pnl_curCtrl.Panel_GlassThicknessDesc + " " + glassFilm + ")",
                                                       1, "pc(s)",
                                                       pnl_curCtrl.Panel_GlassWidth.ToString(),
                                                       "Frame",
                                                       @"\  /");

                                Material_List.Rows.Add("Glass Height (P" + pnl_curCtrl.PanelGlass_ID + "-" + pnl_curCtrl.Panel_GlassThicknessDesc + " " + glassFilm + ")",
                                                       1, "pc(s)",
                                                       pnl_curCtrl.Panel_GlassHeight.ToString(),
                                                       "Frame",
                                                       @"\  /");

                                if (pnl_curCtrl.Panel_GeorgianBarArtNo != GeorgianBar_ArticleNo._None)
                                {
                                    Material_List.Rows.Add("Georgian bar P" + pnl_curCtrl.PanelGlass_ID + " (Horizontal) " + pnl_curCtrl.Panel_GeorgianBarArtNo.ToString(),
                                                           pnl_curCtrl.Panel_GeorgianBar_HorizontalQty * 2, "pc(s)",
                                                           pnl_curCtrl.Panel_GlassWidth + 5,
                                                           "Glass",
                                                           "");

                                    Material_List.Rows.Add("Georgian bar P" + pnl_curCtrl.PanelGlass_ID + " (Vertical) " + pnl_curCtrl.Panel_GeorgianBarArtNo.ToString(),
                                                           pnl_curCtrl.Panel_GeorgianBar_VerticalQty * 2, "pc(s)",
                                                           pnl_curCtrl.Panel_GlassHeight + 5,
                                                           "Glass",
                                                           "");
                                }

                                if (pnl_curCtrl.Panel_Type == "Fixed Panel")
                                {
                                    glazing_spacer++;
                                }

                                total_glassWidth += (pnl_curCtrl.Panel_GlassWidth * 2);
                                total_glassHeight += (pnl_curCtrl.Panel_GlassHeight * 2);

                            }
                        }
                    }
                    #endregion
                }
                else if (frame.Lst_Panel.Count() == 1 && frame.Lst_MultiPanel.Count() == 0)
                {
                    #region Frame Parent

                    IPanelModel pnl = frame.Lst_Panel[0];
                    pnl.SetPanelExplosionValues_Panel(true);

                    if (pnl.Panel_SashPropertyVisibility == true)
                    {
                        total_screws_fabrication += ((pnl.Panel_SashWidth * 2) + (pnl.Panel_SashHeight * 2));

                        Material_List.Rows.Add("Sash Width " + pnl.Panel_SashProfileArtNo.ToString(),
                                               2, "pc(s)",
                                               pnl.Panel_SashWidth.ToString(),
                                               "Sash",
                                               @"\  /");

                        Material_List.Rows.Add("Sash Height " + pnl.Panel_SashProfileArtNo.ToString(),
                                               2, "pc(s)",
                                               pnl.Panel_SashHeight.ToString(),
                                               "Sash",
                                               @"\  /");

                        Material_List.Rows.Add("Sash Reinf Width " + pnl.Panel_SashReinfArtNo.ToString(),
                                               2, "pc(s)",
                                               pnl.Panel_SashReinfWidth.ToString(),
                                               "Sash",
                                               @"|  |");

                        Material_List.Rows.Add("Sash Reinf Height " + pnl.Panel_SashReinfArtNo.ToString(),
                                               2, "pc(s)",
                                               pnl.Panel_SashReinfHeight.ToString(),
                                               "Sash",
                                               @"|  |");

                        if (pnl.Panel_Type.Contains("Fixed") == false)
                        {
                            Material_List.Rows.Add("Cover Profile " + pnl.Panel_CoverProfileArtNo.ToString(),
                                                   1, "pc(s)",
                                                   frame.Frame_Width.ToString(),
                                                   "Frame",
                                                   @"|  |");

                            Material_List.Rows.Add("Cover Profile " + pnl.Panel_CoverProfileArtNo2.ToString(),
                                                   1, "pc(s)",
                                                   frame.Frame_Width.ToString(),
                                                   "Frame",
                                                   @"|  |");
                        }

                        if (pnl.Panel_MotorizedOptionVisibility == true)
                        {
                            Material_List.Rows.Add("30X25 Cover " + pnl.Panel_30x25CoverArtNo.ToString(),
                                                   1, "pc(s)",
                                                   frame.Frame_Width,
                                                   "Frame",
                                                   @"");

                            Material_List.Rows.Add("Divider " + pnl.Panel_MotorizedDividerArtNo.ToString(),
                                                   1, "pc(s)",
                                                   frame.Frame_Width,
                                                   "Frame",
                                                   @"");

                            Material_List.Rows.Add("Cover for motor " + pnl.Panel_CoverForMotorArtNo.ToString(),
                                                   1, "pc(s)",
                                                   frame.Frame_Width + 150,
                                                   "Frame",
                                                   @"");

                            Material_List.Rows.Add("2D Hinge " + pnl.Panel_2dHingeArtNo.ToString(),
                                                   pnl.Panel_2DHingeQty, "pair(s)",
                                                   "",
                                                   "Sash & Frame",
                                                   @"");

                            Material_List.Rows.Add("Motorized Mechanism " + pnl.Panel_MotorizedMechArtNo.ToString(),
                                                   pnl.Panel_MotorizedMechQty, "pc(s)",
                                                   "",
                                                   "Sash",
                                                   @"");

                            additional_screws_fabrication += 3;

                            if (pnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._409990E)
                            {
                                total_screws_installation += (20 * pnl.Panel_MotorizedMechQty);
                            }
                            else if (pnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41555B ||
                                     pnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41556C)
                            {
                                total_screws_installation += (10 * pnl.Panel_MotorizedMechQty);
                            }

                            Material_List.Rows.Add("Push Button Switch " + pnl.Panel_PushButtonSwitchArtNo.ToString(),
                                                   pnl.Panel_MotorizedMechSetQty, "pc(s)",
                                                   "",
                                                   "Concrete",
                                                   @"");

                            Material_List.Rows.Add("False pole " + pnl.Panel_FalsePoleArtNo.ToString(),
                                                   pnl.Panel_MotorizedMechSetQty * 2, "pc(s)",
                                                   "",
                                                   "Concrete",
                                                   @"");

                            total_screws_installation += 4;

                            Material_List.Rows.Add("Supporting Frame " + pnl.Panel_SupportingFrameArtNo.ToString(),
                                                   pnl.Panel_MotorizedMechSetQty, "pc(s)",
                                                   "",
                                                   "Concrete",
                                                   @"");

                            Material_List.Rows.Add("Plate " + pnl.Panel_PlateArtNo.ToString(),
                                                   pnl.Panel_MotorizedMechSetQty, "pc(s)",
                                                   "",
                                                   "Concrete",
                                                   @"");
                        }
                        else if (pnl.Panel_MotorizedOptionVisibility == false)
                        {
                            if (pnl.Panel_Type.Contains("Awning"))
                            {
                                Material_List.Rows.Add("Friction Stay " + pnl.Panel_FrictionStayArtNo.ToString(),
                                                       1, "pair(s)",
                                                       "",
                                                       "Sash & Frame",
                                                       @"");

                                if (pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm26)
                                {
                                    additional_screws_fabrication += 6; //for Storm26

                                    Material_List.Rows.Add("Snap-in Keep " + pnl.Panel_SnapInKeepArtNo.ToString(),
                                                           2, "pc(s)",
                                                           "",
                                                           "Frame",
                                                           @"");

                                    additional_screws_fabrication += 4;

                                    Material_List.Rows.Add("Plastic Wedge " + pnl.Panel_PlasticWedge.DisplayName,
                                                           pnl.Panel_PlasticWedgeQty, "pc (s)",
                                                           "",
                                                           "Frame",
                                                           @"");

                                    Material_List.Rows.Add("Fixed Cam " + pnl.Panel_FixedCamArtNo.ToString(),
                                                           2, "pc(s)",
                                                           "",
                                                           "Frame",
                                                           @"");

                                    additional_screws_fabrication += 4;
                                }
                                else if (pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm8)
                                {
                                    additional_screws_fabrication += 3;
                                }
                                else if (pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._477254 ||
                                         pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._A2121C1261)
                                {
                                    additional_screws_fabrication += 4;
                                }
                                else if (pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._A212C16161)
                                {
                                    additional_screws_fabrication += 5;
                                }
                                else if (pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm22)
                                {
                                    additional_screws_fabrication += 6;
                                }
                            }
                            else if (pnl.Panel_Type.Contains("Casement"))
                            {
                                if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                {
                                    if (pnl.Panel_HingeOptions == HingeOption._FrictionStay)
                                    {
                                        Material_List.Rows.Add("Friction Stay " + pnl.Panel_FSCasementArtNo.ToString(),
                                                               1, "pair(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");

                                    }
                                    else if (pnl.Panel_HingeOptions == HingeOption._2DHinge)
                                    {
                                        Material_List.Rows.Add("2D hinge " + pnl.Panel_2dHingeArtNo_nonMotorized.ToString(),
                                                               pnl.Panel_2DHingeQty_nonMotorized, "pc(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");
                                    }
                                }

                                Material_List.Rows.Add("Plastic Wedge " + pnl.Panel_PlasticWedge.DisplayName,
                                                       pnl.Panel_PlasticWedgeQty, "pc (s)",
                                                       "",
                                                       "Frame",
                                                       @"");

                                if (pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._485770)
                                {
                                    additional_screws_fabrication += 3;
                                }
                                else if (pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._A235B12161 ||
                                         pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._A212C12161)
                                {
                                    additional_screws_fabrication += 4;
                                }
                                else if (pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._A212C16161)
                                {
                                    additional_screws_fabrication += 5;
                                }
                                else if (pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._A212C20161)
                                {
                                    additional_screws_fabrication += 6;
                                }
                            }

                            if (pnl.Panel_HandleType == Handle_Type._Rotoswing)
                            {
                                if (pnl.Panel_ExtTopQty > 0)
                                {
                                    Material_List.Rows.Add("Extension(Top) " + pnl.Panel_ExtensionTopArtNo.ToString(),
                                                           pnl.Panel_ExtTopQty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionTopArtNo == Extension_ArticleNo._612978)
                                    {
                                        additional_screws_fabrication += (3 * pnl.Panel_ExtTopQty);
                                    }
                                    else if (pnl.Panel_ExtensionTopArtNo == Extension_ArticleNo._639957)
                                    {
                                        additional_screws_fabrication += (5 * pnl.Panel_ExtTopQty);
                                    }
                                }
                                if (pnl.Panel_ExtTop2Qty > 0)
                                {
                                    Material_List.Rows.Add("Extension_2(Top) " + pnl.Panel_ExtensionTop2ArtNo.ToString(),
                                                           pnl.Panel_ExtTop2Qty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._612978)
                                    {
                                        additional_screws_fabrication += (3 * pnl.Panel_ExtTop2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._639957)
                                    {
                                        additional_screws_fabrication += (5 * pnl.Panel_ExtTop2Qty);
                                    }
                                }
                                if (pnl.Panel_ExtBotQty > 0)
                                {
                                    Material_List.Rows.Add("Extension(Bot) " + pnl.Panel_ExtensionBotArtNo.ToString(),
                                                           pnl.Panel_ExtBotQty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionBotArtNo == Extension_ArticleNo._612978)
                                    {
                                        additional_screws_fabrication += (3 * pnl.Panel_ExtBotQty);
                                    }
                                    else if (pnl.Panel_ExtensionBotArtNo == Extension_ArticleNo._639957)
                                    {
                                        additional_screws_fabrication += (5 * pnl.Panel_ExtBotQty);
                                    }
                                }
                                if (pnl.Panel_ExtBot2Qty > 0)
                                {
                                    Material_List.Rows.Add("Extension_2(Bot) " + pnl.Panel_ExtensionBot2ArtNo.ToString(),
                                                           pnl.Panel_ExtBot2Qty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._612978)
                                    {
                                        additional_screws_fabrication += (3 * pnl.Panel_ExtBot2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._639957)
                                    {
                                        additional_screws_fabrication += (5 * pnl.Panel_ExtBot2Qty);
                                    }
                                }
                                if (pnl.Panel_ExtLeftQty > 0)
                                {
                                    Material_List.Rows.Add("Extension(Left) " + pnl.Panel_ExtensionLeftArtNo.ToString(),
                                                           pnl.Panel_ExtLeftQty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._612978)
                                    {
                                        additional_screws_fabrication += (3 * pnl.Panel_ExtLeftQty);
                                    }
                                    else if (pnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957)
                                    {
                                        additional_screws_fabrication += (5 * pnl.Panel_ExtLeftQty);
                                    }
                                }
                                if (pnl.Panel_ExtLeft2Qty > 0)
                                {
                                    Material_List.Rows.Add("Extension_2(Left) " + pnl.Panel_ExtensionLeft2ArtNo.ToString(),
                                                           pnl.Panel_ExtLeft2Qty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._612978)
                                    {
                                        additional_screws_fabrication += (3 * pnl.Panel_ExtLeft2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957)
                                    {
                                        additional_screws_fabrication += (5 * pnl.Panel_ExtLeft2Qty);
                                    }
                                }
                                if (pnl.Panel_ExtRightQty > 0)
                                {
                                    Material_List.Rows.Add("Extension(Right) " + pnl.Panel_ExtensionRightArtNo.ToString(),
                                                           pnl.Panel_ExtRightQty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._612978)
                                    {
                                        additional_screws_fabrication += (3 * pnl.Panel_ExtRightQty);
                                    }
                                    else if (pnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._639957)
                                    {
                                        additional_screws_fabrication += (5 * pnl.Panel_ExtRightQty);
                                    }
                                }
                                if (pnl.Panel_ExtRight2Qty > 0)
                                {
                                    Material_List.Rows.Add("Extension_2(Right) " + pnl.Panel_ExtensionRight2ArtNo.ToString(),
                                                           pnl.Panel_ExtRight2Qty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._612978)
                                    {
                                        additional_screws_fabrication += (3 * pnl.Panel_ExtRight2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                                    {
                                        additional_screws_fabrication += (5 * pnl.Panel_ExtRight2Qty);
                                    }
                                }

                                if (pnl.Panel_CornerDriveArtNo != CornerDrive_ArticleNo._None &&
                                    pnl.Panel_CornerDriveArtNo != null)
                                {
                                    Material_List.Rows.Add("Corner Drive " + pnl.Panel_CornerDriveArtNo.ToString(),
                                                           2, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    additional_screws_fabrication += 4;
                                }

                                Material_List.Rows.Add("Rotoswing handle " + pnl.Panel_RotoswingArtNo.ToString(),
                                                       1, "pc (s)",
                                                       "",
                                                       "Sash",
                                                       @"");

                                if (pnl.Panel_Type.Contains("Awning"))
                                {
                                    Material_List.Rows.Add("Striker " + pnl.Panel_StrikerArtno_A.ToString(),
                                                           pnl.Panel_StrikerQty_A, "pc (s)",
                                                           "",
                                                           "Frame",
                                                           @"");

                                    additional_screws_fabrication += pnl.Panel_StrikerQty_A;

                                    if (pnl.Panel_DisplayHeight >= 2100)
                                    {
                                        if (pnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957 ||
                                            pnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957 ||
                                            pnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._639957 ||
                                            pnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                                        {
                                            Material_List.Rows.Add("Striker " + pnl.Panel_StrikerArtno_C.ToString(),
                                                               pnl.Panel_StrikerQty_C, "pc (s)",
                                                               "",
                                                               "Frame",
                                                               @"");

                                            additional_screws_fabrication += pnl.Panel_StrikerQty_C;
                                        }
                                    }

                                }
                                else if (pnl.Panel_Type.Contains("Casement"))
                                {
                                    Material_List.Rows.Add("Striker " + pnl.Panel_StrikerArtno_C.ToString(),
                                                           pnl.Panel_StrikerQty_C, "pc (s)",
                                                           "",
                                                           "Frame",
                                                           @"");

                                    additional_screws_fabrication += pnl.Panel_StrikerQty_C;

                                    if (pnl.Panel_DisplayHeight >= 2100)
                                    {
                                        if (pnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                        {
                                            Material_List.Rows.Add("Striker " + pnl.Panel_StrikerArtno_A.ToString(),
                                                               pnl.Panel_StrikerQty_A, "pc (s)",
                                                               "",
                                                               "Frame",
                                                               @"");

                                            additional_screws_fabrication += pnl.Panel_StrikerQty_A;
                                        }
                                    }
                                }

                                Material_List.Rows.Add("Middle Closer " + pnl.Panel_MiddleCloserArtNo.ToString(),
                                                       pnl.Panel_MiddleCloserPairQty, "pair (s)",
                                                       "",
                                                       "Sash & Frame",
                                                       @"");

                                additional_screws_fabrication += (4 * pnl.Panel_MiddleCloserPairQty);
                            }
                            else if (pnl.Panel_HandleType == Handle_Type._Rotary)
                            {
                                Material_List.Rows.Add("Rotary handle " + pnl.Panel_RotaryArtNo.ToString(),
                                                       1, "set (s)",
                                                       "",
                                                       "Frame & Sash",
                                                       @"");

                                Material_List.Rows.Add("Locking Kit " + pnl.Panel_LockingKitArtNo.ToString(),
                                                       1, "set (s)",
                                                       "",
                                                       "Sash",
                                                       @"");

                                additional_screws_fabrication += 9;
                            }

                            if (pnl.Panel_HandleType != Handle_Type._Rotary)
                            {
                                Material_List.Rows.Add("Espagnolette " + pnl.Panel_EspagnoletteArtNo.ToString(),
                                                       1, "pc (s)",
                                                       "",
                                                       "Sash",
                                                       @"");

                                if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                                    pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT ||
                                    pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_205 ||
                                    pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_206 ||
                                    pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_207)
                                {
                                    additional_screws_fabrication += 8;
                                }
                                else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                                         pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._630963)
                                {
                                    additional_screws_fabrication += 2;
                                }
                                else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807)
                                {
                                    additional_screws_fabrication += 4;
                                }
                                else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809 ||
                                         pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A00006 ||
                                         pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A01006 ||
                                         pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                                         pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206 ||
                                         pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                                         pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206 ||
                                         pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A06206)
                                {
                                    additional_screws_fabrication += 6;
                                }
                                else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                                         pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                                {
                                    additional_screws_fabrication += 12;
                                }
                            }
                        }
                    }

                    Material_List.Rows.Add("Glazing Bead Width (P" + pnl.PanelGlass_ID + ") " + pnl.PanelGlazingBead_ArtNo.ToString(),
                                           2, "pc(s)",
                                           pnl.Panel_GlazingBeadWidth.ToString(),
                                           "Frame",
                                           @"\  /");

                    Material_List.Rows.Add("Glazing Bead Height (P" + pnl.PanelGlass_ID + ") " + pnl.PanelGlazingBead_ArtNo.ToString(),
                                           2, "pc(s)",
                                           pnl.Panel_GlazingBeadHeight.ToString(),
                                           "Frame",
                                           @"\  /");

                    string glassFilm = "";
                    if (pnl.Panel_GlassFilm != GlassFilm_Types._None)
                    {
                        glassFilm = pnl.Panel_GlassFilm.DisplayName;
                    }

                    Material_List.Rows.Add("Glass Width (P" + pnl.PanelGlass_ID + "-" + pnl.Panel_GlassThicknessDesc + " " + glassFilm + ")",
                                           1, "pc(s)",
                                           pnl.Panel_GlassWidth.ToString(),
                                           "Frame",
                                           @"\  /");

                    Material_List.Rows.Add("Glass Height (P" + pnl.PanelGlass_ID + "-" + pnl.Panel_GlassThicknessDesc + " " + glassFilm + ")",
                                           1, "pc(s)",
                                           pnl.Panel_GlassHeight.ToString(),
                                           "Frame",
                                           @"\  /");

                    if (pnl.Panel_GeorgianBarArtNo != GeorgianBar_ArticleNo._None)
                    {
                        Material_List.Rows.Add("Georgian bar P" + pnl.PanelGlass_ID + " (Horizontal) " + pnl.Panel_GeorgianBarArtNo.ToString(),
                                               pnl.Panel_GeorgianBar_HorizontalQty * 2, "pc(s)",
                                               pnl.Panel_GlassWidth + 5,
                                               "Glass",
                                               "");

                        Material_List.Rows.Add("Georgian bar P" + pnl.PanelGlass_ID + " (Vertical) " + pnl.Panel_GeorgianBarArtNo.ToString(),
                                               pnl.Panel_GeorgianBar_VerticalQty * 2, "pc(s)",
                                               pnl.Panel_GlassHeight + 5,
                                               "Glass",
                                               "");
                    }

                    if (pnl.Panel_Type == "Fixed Panel")
                    {
                        glazing_spacer++;
                    }

                    total_glassWidth += (pnl.Panel_GlassWidth * 2);
                    total_glassHeight += (pnl.Panel_GlassHeight * 2);

                    double glassThickness_roundUP = Math.Ceiling(pnl.Panel_GlassThickness);

                    if (glassThickness_roundUP == 13.0f ||
                        glassThickness_roundUP == 14.0f ||
                        glassThickness_roundUP == 24.0f)
                    {
                        glazing_seal += (pnl.Panel_GlazingBeadWidth * 2) + (pnl.Panel_GlazingBeadHeight * 2);
                    }
                }
                #endregion

                exp_bolt += (int)Math.Ceiling((decimal)((frame.Frame_Width * 2) + (frame.Frame_Height * 2)) / 700);
            }

            Frame_PUFoamingQty_Total = (int)Math.Ceiling((decimal)(totalFrames_width + totalFrames_height) / 29694);
            Frame_SealantWHQty_Total = (int)Math.Ceiling((decimal)(totalFrames_width + totalFrames_height) / 3570);
            Glass_SealantWHQty_Total = (int)(Math.Ceiling((decimal)(total_glassWidth + total_glassHeight) / 6842));
            GlazingSpacer_TotalQty = glazing_spacer;
            GlazingSeal_TotalQty = glazing_seal;

            int fixing_screw = (int)(Math.Ceiling((decimal)total_screws_fabrication / 300));
            Screws_for_Fabrication = fixing_screw + additional_screws_fabrication;
            Screws_for_Installation = fixing_screw + total_screws_installation;
            Screws_for_Cladding = total_cladding_size / 300;

            Plastic_CoverQty_Total = (frame_width * frame_height) * 2;
            Expansion_BoltQty_Total = exp_bolt;
            Rebate_Qty = 2 * 2 * Expansion_BoltQty_Total;

            Material_List.Rows.Add("PU Foaming",
                                   Frame_PUFoamingQty_Total, "can", "", "Frame");

            Material_List.Rows.Add("Sealant-WH (Frame)",
                                   Frame_SealantWHQty_Total, "pc(s)", "", "Frame");

            Material_List.Rows.Add("Sealant-WH (Glass)",
                                   Glass_SealantWHQty_Total,
                                   "pc(s)",
                                   "",
                                   "Frame"); // Frame or Sash

            Material_List.Rows.Add("Exp bolt FRA003",
                                   Expansion_BoltQty_Total,
                                   "pc(s)",
                                   "",
                                   "Frame");

            Material_List.Rows.Add("Rebate",
                                   Rebate_Qty,
                                   "pc(s)",
                                   "",
                                   "Frame");

            if (GlazingSpacer_TotalQty > 0)
            {
                Material_List.Rows.Add("Glazing Spacer (KBC70)",
                                       GlazingSpacer_TotalQty, "pc(s)", "", "Frame");
            }

            if (GlazingSeal_TotalQty > 0)
            {
                Material_List.Rows.Add("Glazing Seal 9073",
                                       GlazingSeal_TotalQty, "mm", "", "GB");
            }

            Material_List.Rows.Add("Screws for Fabrication wt 10x15",
                                   Screws_for_Fabrication, "pc(s)", "", screws_for_inst_where); // FRAME, SASH, TRANSOM & MULLION

            Material_List.Rows.Add("Screws for Installation",
                                   Screws_for_Installation, "pc(s)", "", screws_for_inst_where); // FRAME, SASH, TRANSOM & MULLION

            Material_List.Rows.Add("Screws for Cladding 10 x 38",
                                   Screws_for_Cladding, "pc(s)", "", "");

            var query = from r in Material_List.AsEnumerable()
                        group r by new
                        {
                            Description = r.Field<string>("Description"),
                            Unit = r.Field<string>("Unit"),
                            Size = r.Field<string>("Size"),
                            Where = r.Field<string>("Where"),
                            Cut = r.Field<string>("Cut")
                        } into g
                        select new
                        {
                            Description = g.Key.Description,
                            Qty = g.Sum(r => r.Field<int>("Qty")),
                            Unit = g.Key.Unit,
                            Size = g.Key.Size,
                            Where = g.Key.Where,
                            Cut = g.Key.Cut
                        };

            DataTable dt = new DataTable();
            dt.Columns.Add(CreateColumn("Description", "Description", "System.String"));
            dt.Columns.Add(CreateColumn("Qty", "Qty", "System.String"));
            dt.Columns.Add(CreateColumn("Unit", "Unit", "System.String"));
            dt.Columns.Add(CreateColumn("Size", "Size", "System.String"));
            dt.Columns.Add(CreateColumn("Where", "Where", "System.String"));
            dt.Columns.Add(CreateColumn("Cut", "Cut", "System.String"));

            foreach (var element in query)
            {
                DataRow row = dt.NewRow();
                row["Description"] = element.Description;
                row["Qty"] = element.Qty;
                row["Unit"] = element.Unit;
                row["Size"] = element.Size;
                row["Where"] = element.Where;
                row["Cut"] = element.Cut;

                dt.Rows.Add(row);
            }

            Material_List = dt;

            Material_List.Rows.Add("Plastic Cover",
                                   item.WD_PlasticCover.ToString(),
                                   "kg",
                                   "",
                                   "Frame");

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
