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
                int totalFrames_width = 0,
                    totalFrames_height = 0,
                     total_glassWidth = 0,
                     total_glassHeight = 0;

                foreach (IFrameModel frame in item.GetAllVisibleFrames())
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
                                    div_nxtCtrl.SetPanelExplosionValues_Div();

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
                                                                                  div_prevCtrl.Div_Type,
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
                                    if (pnl_curCtrl.Panel_GlassThickness == Glass_Thickness._13mm ||
                                        pnl_curCtrl.Panel_GlassThickness == Glass_Thickness._14mm ||
                                        pnl_curCtrl.Panel_GlassThickness == Glass_Thickness._24mm)
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

                        if (pnl.Panel_GlassThickness == Glass_Thickness._13mm ||
                            pnl.Panel_GlassThickness == Glass_Thickness._14mm ||
                            pnl.Panel_GlassThickness == Glass_Thickness._24mm)
                        {
                            glazing_seal += (pnl.Panel_GlazingBeadWidth * 2) + (pnl.Panel_GlazingBeadHeight * 2);
                        }
                    }

                    Material_List.Rows.Add("Glazing Spacer (KBC70)",
                                           glazing_spacer, "pc(s)", "");

                    Material_List.Rows.Add("Glazing Seal",
                                           glazing_seal, "mm","");
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

            int totalFrames_width = 0,
                totalFrames_height = 0,
                total_glassWidth = 0,
                total_glassHeight = 0,
                glazing_seal = 0,
                glazing_spacer = 0;

            foreach (IFrameModel frame in item.GetAllVisibleFrames())
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

                if (frame.Lst_MultiPanel.Count() >= 1 && frame.Lst_Panel.Count() == 0)
                {
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
                                div_nxtCtrl.SetPanelExplosionValues_Div();

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
                                if (pnl_curCtrl.Panel_GlassThickness == Glass_Thickness._13mm ||
                                    pnl_curCtrl.Panel_GlassThickness == Glass_Thickness._14mm ||
                                    pnl_curCtrl.Panel_GlassThickness == Glass_Thickness._24mm)
                                {
                                    glazing_seal += (pnl_curCtrl.Panel_GlazingBeadWidth * 2) + (pnl_curCtrl.Panel_GlazingBeadHeight * 2);
                                }

                                Material_List.Rows.Add("Glazing Bead Width (P" + pnl_curCtrl.PanelGlass_ID + ") " + pnl_curCtrl.PanelGlazingBead_ArtNo.ToString(),
                                                           2, "pc(s)",
                                                           pnl_curCtrl.Panel_GlazingBeadWidth.ToString());

                                Material_List.Rows.Add("Glazing Bead Height (P" + pnl_curCtrl.PanelGlass_ID + ") " + pnl_curCtrl.PanelGlazingBead_ArtNo.ToString(),
                                                       2, "pc(s)",
                                                       pnl_curCtrl.Panel_GlazingBeadHeight.ToString());

                                Material_List.Rows.Add("Glass Width (" + pnl_curCtrl.Panel_GlassThickness + "-P" + pnl_curCtrl.PanelGlass_ID + ")",
                                                       1, "pc(s)",
                                                       pnl_curCtrl.Panel_GlassWidth.ToString());

                                Material_List.Rows.Add("Glass Height (" + pnl_curCtrl.Panel_GlassThickness + "-P" + pnl_curCtrl.PanelGlass_ID + ")",
                                                       1, "pc(s)",
                                                       pnl_curCtrl.Panel_GlassHeight.ToString());
                                glazing_spacer++;

                                total_glassWidth += (pnl_curCtrl.Panel_GlassWidth * 2);
                                total_glassHeight += (pnl_curCtrl.Panel_GlassHeight * 2);

                            }
                        }
                    }
                }
                else if (frame.Lst_Panel.Count() == 1 && frame.Lst_MultiPanel.Count() == 0)
                {
                    IPanelModel pnl = frame.Lst_Panel[0];
                    pnl.SetPanelExplosionValues_Panel(true);

                    Material_List.Rows.Add("Glazing Bead Width (P" + pnl.PanelGlass_ID + ") " + pnl.PanelGlazingBead_ArtNo.ToString(),
                                               2, "pc(s)",
                                               pnl.Panel_GlazingBeadWidth.ToString());

                    Material_List.Rows.Add("Glazing Bead Height (P" + pnl.PanelGlass_ID + ") " + pnl.PanelGlazingBead_ArtNo.ToString(),
                                           2, "pc(s)",
                                           pnl.Panel_GlazingBeadHeight.ToString());

                    Material_List.Rows.Add("Glass Width (" + pnl.Panel_GlassThickness + "-P" + pnl.PanelGlass_ID + ")",
                                           1, "pc(s)",
                                           pnl.Panel_GlassWidth.ToString());

                    Material_List.Rows.Add("Glass Height (" + pnl.Panel_GlassThickness + "-P" + pnl.PanelGlass_ID + ")",
                                           1, "pc(s)",
                                           pnl.Panel_GlassHeight.ToString());
                    glazing_spacer++;

                    total_glassWidth += (pnl.Panel_GlassWidth * 2);
                    total_glassHeight += (pnl.Panel_GlassHeight * 2);

                    if (pnl.Panel_GlassThickness == Glass_Thickness._13mm ||
                        pnl.Panel_GlassThickness == Glass_Thickness._14mm ||
                        pnl.Panel_GlassThickness == Glass_Thickness._24mm)
                    {
                        glazing_seal += (pnl.Panel_GlazingBeadWidth * 2) + (pnl.Panel_GlazingBeadHeight * 2);
                    }
                }

            }


            Frame_PUFoamingQty_Total = (int)Math.Ceiling((decimal)(totalFrames_width + totalFrames_height) / 29694);
            Frame_SealantWHQty_Total = (int)Math.Ceiling((decimal)(totalFrames_width + totalFrames_height) / 3570);
            Glass_SealantWHQty_Total = (int)(Math.Ceiling((decimal)(total_glassWidth + total_glassHeight) / 6842));
            GlazingSpacer_TotalQty = glazing_spacer;
            GlazingSeal_TotalQty = glazing_seal;

            Material_List.Rows.Add("PU Foaming",
                                   Frame_PUFoamingQty_Total, "can", "");

            Material_List.Rows.Add("Sealant-WH (Frame)",
                                   Frame_SealantWHQty_Total, "pc(s)", "");

            Material_List.Rows.Add("Sealant-WH (Glass)",
                                   Glass_SealantWHQty_Total,
                                   "pc(s)",
                                   "");

            Material_List.Rows.Add("Glazing Spacer (KBC70)",
                                   GlazingSpacer_TotalQty, "pc(s)", "");

            Material_List.Rows.Add("Glazing Seal",
                                   GlazingSeal_TotalQty, "mm", "");

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

            foreach (var element in query)
            {
                DataRow row = dt.NewRow();
                row["Description"] = element.Description;
                row["Qty"] = element.Qty;
                row["Unit"] = element.Unit;
                row["Size"] = element.Size;

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
