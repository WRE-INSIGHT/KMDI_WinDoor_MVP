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
                add_screws_fab_espag = 0,
                add_screws_fab_ext = 0,
                add_screws_fab_corDrive = 0,
                add_screws_fab_snapInKeep = 0,
                add_screws_fab_striker = 0,
                add_screws_fab_mc = 0,
                add_screws_fab_fs_or_rs = 0,
                add_screws_fab_alum = 0,
                add_screws_fab_fxdcam = 0,
                add_screws_fab_endcap = 0,
                add_screws_fab_hinges = 0,
                add_screws_fab_stayBearing = 0,
                add_screws_fab_pivotRest = 0,
                add_screws_fab_shootbolt = 0,
                add_screws_fab_weldableCJ = 0,
                add_screws_fab_cladingBracket = 0,
                add_screws_fab_handle = 0,
                add_screws_fab_mech_joint = 0,
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

                if (frame.Frame_If_InwardMotorizedCasement)
                {
                    Material_List.Rows.Add("Milled Frame " + frame.Frame_MilledArtNo.DisplayName,
                                           1, "pc(s)",
                                           frame.Frame_Width.ToString(),
                                           "Frame",
                                           @"|  |");

                    Material_List.Rows.Add("Milled Frame Reinf " + frame.Frame_MilledReinfArtNo.DisplayName,
                                           1, "pc(s)",
                                           frame.Frame_Width.ToString(),
                                           "Frame",
                                           @"|  |");

                    total_screws_fabrication += frame.Frame_Width;
                }

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

                            bool mullion_already_added = false;

                            if (pnl_curCtrl != null)
                            {
                                pnl_curCtrl.Panel_AdjStrikerQty = 0;

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
                                if (mpnl.MPanel_Type == "Transom")
                                {
                                    div_nxtCtrl.SetExplosionValues_Div();

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

                                    if (div_nxtCtrl.Div_claddingBracketVisibility == true)
                                    {
                                        if (div_nxtCtrl.Div_CladdingBracketForConcreteQTY > 0)
                                        {
                                            Material_List.Rows.Add("Bracket for concrete (10mm)",
                                                                   div_nxtCtrl.Div_CladdingBracketForConcreteQTY, "pc(s)",
                                                                   "",
                                                                   "CPL",
                                                                   @"|  |");

                                            add_screws_fab_cladingBracket += (div_nxtCtrl.Div_CladdingBracketForConcreteQTY * 3);

                                            exp_bolt += div_nxtCtrl.Div_CladdingBracketForConcreteQTY;
                                        }

                                        
                                        if (div_nxtCtrl.Div_CladdingBracketForUPVCQTY > 0)
                                        {
                                            Material_List.Rows.Add("Bracket for upvc(5mm)",
                                                                   div_nxtCtrl.Div_CladdingBracketForUPVCQTY, "pc(s)",
                                                                   "",
                                                                   "CPL",

                                                                   @"|  |");
                                            add_screws_fab_cladingBracket += (div_nxtCtrl.Div_CladdingBracketForConcreteQTY * 3);

                                            exp_bolt += div_nxtCtrl.Div_CladdingBracketForConcreteQTY;
                                        }
                                    }
                                }
                                if (div_nxtCtrl.Div_ChkDM == false && !mullion_already_added)
                                {
                                    mullion_already_added = true;

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

                                    Material_List.Rows.Add(mpnl.MPanel_Type + " Mechanical Joint " + div_nxtCtrl.Div_MechJoinArtNo.ToString(),
                                                           2, "pc(s)", "");

                                    if (div_nxtCtrl.Div_MechJoinArtNo == Divider_MechJointArticleNo._AV585)
                                    {
                                        add_screws_fab_mech_joint += (2 * 2); //qty * 2
                                    }
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
                                                                              div_nxtCtrl,
                                                                              div_prevCtrl,
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
                                                                              div_nxtCtrl,
                                                                              div_prevCtrl,
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
                                if (div_nxtCtrl != null)
                                {
                                    if (mpnl.MPanel_Type == "Mullion")
                                    {
                                        div_nxtCtrl.SetExplosionValues_Div();

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
                                            if (div_nxtCtrl.Div_EndcapDM == EndcapDM_ArticleNo._K385 ||
                                                div_nxtCtrl.Div_EndcapDM == EndcapDM_ArticleNo._K7533)
                                            {
                                                add_screws_fab_endcap += (1 * 2); // 1 * 2pcs
                                            }

                                            if (div_nxtCtrl.Div_DMArtNo == DummyMullion_ArticleNo._7533)
                                            {
                                                Material_List.Rows.Add("Fixed cam " + div_nxtCtrl.Div_FixedCamDM.ToString(),
                                                                       2, "pc(s)",
                                                                       "",
                                                                       "Sash");
                                                add_screws_fab_fxdcam += (2 * 2); //2 * 2pcs

                                                Material_List.Rows.Add("Snap-in Keep " + div_nxtCtrl.Div_SnapNKeepDM.ToString(),
                                                                       2, "pc(s)",
                                                                       "",
                                                                       "Frame");

                                                if (div_nxtCtrl.Div_SnapNKeepDM == SnapInKeep_ArticleNo._0400205 ||
                                                    div_nxtCtrl.Div_SnapNKeepDM == SnapInKeep_ArticleNo._0400215)
                                                {
                                                    add_screws_fab_snapInKeep += (2 * 2); //2 * 2pcs
                                                }

                                                Material_List.Rows.Add("Aluminum spacer for Dummy Mullion FC770 (80mm)",
                                                                       2, "pc(s)",
                                                                       "",
                                                                       "Dummy Mullion");
                                                Material_List.Rows.Add("Aluminum spacer for Dummy Mullion FC770 (50mm)",
                                                                       div_nxtCtrl.Div_AlumSpacer50Qty, "pc(s)",
                                                                       "",
                                                                       "Dummy Mullion");

                                                add_screws_fab_alum += (3 * 2); //3 * 2pcs (80mm)
                                                add_screws_fab_alum += (3 * div_nxtCtrl.Div_AlumSpacer50Qty); //3 (50mm)
                                            }

                                            if (div_nxtCtrl.Div_DMPanel != null &&
                                                div_nxtCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                            {
                                                Material_List.Rows.Add("Lever Espagnolette " + div_nxtCtrl.Div_LeverEspagArtNo.DisplayName,
                                                                       1, "pc(s)",
                                                                       "",
                                                                       "Dummy Mullion");
                                                add_screws_fab_espag += 8; //Lever Espagnolette

                                                Material_List.Rows.Add("Shootbolt, non-reverse " + div_nxtCtrl.Div_ShootboltNonReverseArtNo.DisplayName,
                                                                       2, "pc(s)",
                                                                       "",
                                                                       "Dummy Mullion");
                                                add_screws_fab_shootbolt += (2 * 2); //(qty * 2)

                                                int qty_sbStriker = 0;
                                                if (div_nxtCtrl.Div_LeverEspagArtNo == LeverEspagnolette_ArticleNo._625_205 ||
                                                    div_nxtCtrl.Div_LeverEspagArtNo == LeverEspagnolette_ArticleNo._625_206)
                                                {
                                                    qty_sbStriker = 1;
                                                }
                                                else if (div_nxtCtrl.Div_LeverEspagArtNo == LeverEspagnolette_ArticleNo._625_207)
                                                {
                                                    qty_sbStriker = 2;
                                                }
                                                Material_List.Rows.Add("Shootbolt striker " + div_nxtCtrl.Div_ShootboltStrikerArtNo.DisplayName,
                                                                       qty_sbStriker, "pc(s)",
                                                                       "",
                                                                       "Sash");
                                                add_screws_fab_shootbolt += qty_sbStriker; //Shootbolt striker
                                            }
                                        }
                                        else if (div_nxtCtrl.Div_ChkDM == false && !mullion_already_added)
                                        {
                                            mullion_already_added = true;

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

                                            Material_List.Rows.Add(mpnl.MPanel_Type + " Mechanical Joint " + div_nxtCtrl.Div_MechJoinArtNo.ToString(),
                                                                   2, "pc(s)", "");

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

                                        if (div_nxtCtrl.Div_claddingBracketVisibility == true)
                                        {
                                            if (div_nxtCtrl.Div_CladdingBracketForConcreteQTY > 0)
                                            {
                                                Material_List.Rows.Add("Bracket for concrete (10mm)",
                                                                       div_nxtCtrl.Div_CladdingBracketForConcreteQTY, "pc(s)",
                                                                       "",
                                                                       "CPL",
                                                                       @"|  |");

                                                add_screws_fab_cladingBracket += (div_nxtCtrl.Div_CladdingBracketForConcreteQTY * 3);

                                                exp_bolt += div_nxtCtrl.Div_CladdingBracketForConcreteQTY;
                                            }

                                            if (div_nxtCtrl.Div_CladdingBracketForUPVCQTY > 0)
                                            {
                                                Material_List.Rows.Add("Bracket for upvc(5mm)",
                                                                       div_nxtCtrl.Div_CladdingBracketForUPVCQTY, "pc(s)",
                                                                       "",
                                                                       "CPL",
                                                                       @"|  |");

                                                add_screws_fab_cladingBracket += (div_nxtCtrl.Div_CladdingBracketForUPVCQTY * 4);

                                                exp_bolt += div_nxtCtrl.Div_CladdingBracketForConcreteQTY;
                                            }
                                        }
                                    }
                                }

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
                                        Material_List.Rows.Add("Cover Profile " + pnl_curCtrl.Panel_CoverProfileArtNo.DisplayName,
                                                                   1, "pc(s)",
                                                                   pnl_curCtrl.Panel_DisplayWidth.ToString(),
                                                                   "Frame",
                                                                   @"|  |");

                                        if (pnl_curCtrl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                        {
                                            Material_List.Rows.Add("Cover Profile " + pnl_curCtrl.Panel_CoverProfileArtNo2.DisplayName,
                                                                   1, "pc(s)",
                                                                   pnl_curCtrl.Panel_DisplayWidth.ToString(),
                                                                   "Frame",
                                                                   @"|  |");
                                        }
                                    }

                                    if (perFrame == true)
                                    {
                                        if (pnl_curCtrl.Panel_MotorizedOptionVisibility == true)
                                        {
                                            if (pnl_curCtrl.Panel_Type == "Awning Panel")
                                            {
                                                Material_List.Rows.Add("30X25 Cover " + pnl_curCtrl.Panel_30x25CoverArtNo.ToString(),
                                                                       1, "pc(s)",
                                                                       frame.Frame_Width + 150,
                                                                       "Frame",
                                                                       @"");

                                                Material_List.Rows.Add("Divider " + pnl_curCtrl.Panel_MotorizedDividerArtNo.ToString(),
                                                                       1, "pc(s)",
                                                                       frame.Frame_Width + 150,
                                                                       "Frame",
                                                                       @"");

                                                Material_List.Rows.Add("Cover for motor " + pnl_curCtrl.Panel_CoverForMotorArtNo.ToString(),
                                                                       1, "pc(s)",
                                                                       frame.Frame_Width + 150,
                                                                       "Motorized Mechanism",
                                                                       @"");
                                            }
                                            else if (pnl_curCtrl.Panel_Type == "Casement Panel")
                                            {
                                                Material_List.Rows.Add("30X25 Cover " + pnl_curCtrl.Panel_30x25CoverArtNo.ToString(),
                                                                       1, "pc(s)",
                                                                       frame.Frame_Height + 150,
                                                                       "Frame",
                                                                       @"");

                                                Material_List.Rows.Add("Divider " + pnl_curCtrl.Panel_MotorizedDividerArtNo.ToString(),
                                                                       1, "pc(s)",
                                                                       frame.Frame_Height + 150,
                                                                       "Frame",
                                                                       @"");

                                                Material_List.Rows.Add("Cover for motor " + pnl_curCtrl.Panel_CoverForMotorArtNo.ToString(),
                                                                       1, "pc(s)",
                                                                       frame.Frame_Height + 150,
                                                                       "Motorized Mechanism",
                                                                       @"");
                                            }

                                            if (pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 ||
                                                pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                            {
                                                Material_List.Rows.Add("2D Hinge " + pnl_curCtrl.Panel_2dHingeArtNo.DisplayName,
                                                                       pnl_curCtrl.Panel_2DHingeQty, "pc(s)",
                                                                       "",
                                                                       "Sash & Frame",
                                                                       @"");

                                                add_screws_fab_hinges += (pnl_curCtrl.Panel_2DHingeQty * 3); //qty * 3

                                            }
                                            else if (pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                            {
                                                Material_List.Rows.Add("Butt Hinge " + pnl_curCtrl.Panel_ButtHingeArtNo.DisplayName,
                                                                       pnl_curCtrl.Panel_ButtHingeQty, "pc(s)",
                                                                       "",
                                                                       "",
                                                                       @"");

                                                add_screws_fab_hinges += (pnl_curCtrl.Panel_ButtHingeQty * 3); //qty * 3
                                            }

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
                                                add_screws_fab_fs_or_rs += 6; //for Storm26

                                                Material_List.Rows.Add("Snap-in Keep " + pnl_curCtrl.Panel_SnapInKeepArtNo.ToString(),
                                                                       2, "pc(s)",
                                                                       "",
                                                                       "Frame",
                                                                       @"");

                                                add_screws_fab_snapInKeep += (2 * 2); //2 * 2pcs

                                                Material_List.Rows.Add("Fixed Cam " + pnl_curCtrl.Panel_FixedCamArtNo.ToString(),
                                                                       2, "pc(s)",
                                                                       "",
                                                                       "Frame",
                                                                       @"");

                                                add_screws_fab_fxdcam += (2 * 2); //2 * 2pcs
                                            }
                                            else if (pnl_curCtrl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm8)
                                            {
                                                add_screws_fab_fs_or_rs += 3;
                                            }
                                            else if (pnl_curCtrl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._10HD ||
                                                     pnl_curCtrl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._12HD)
                                            {
                                                add_screws_fab_fs_or_rs += 4;
                                            }
                                            else if (pnl_curCtrl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._12HD)
                                            {
                                                add_screws_fab_fs_or_rs += 5;
                                            }
                                            else if (pnl_curCtrl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm22)
                                            {
                                                add_screws_fab_fs_or_rs += 6;
                                            }

                                            Material_List.Rows.Add("Plastic Wedge " + pnl_curCtrl.Panel_PlasticWedge.DisplayName,
                                                                   pnl_curCtrl.Panel_PlasticWedgeQty, "pc (s)",
                                                                   "",
                                                                   "Frame",
                                                                   @"");

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

                                                    if (pnl_curCtrl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._10HD)
                                                    {
                                                        add_screws_fab_fs_or_rs += 3;
                                                    }
                                                    else if (pnl_curCtrl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._12FS ||
                                                             pnl_curCtrl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._12HD)
                                                    {
                                                        add_screws_fab_fs_or_rs += 4;
                                                    }
                                                    else if (pnl_curCtrl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._12HD)
                                                    {
                                                        add_screws_fab_fs_or_rs += 5;
                                                    }
                                                    else if (pnl_curCtrl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._20HD)
                                                    {
                                                        add_screws_fab_fs_or_rs += 6;
                                                    }
                                                }
                                                else if (pnl_curCtrl.Panel_HingeOptions == HingeOption._2DHinge)
                                                {
                                                    Material_List.Rows.Add("2D hinge " + pnl_curCtrl.Panel_2dHingeArtNo_nonMotorized.ToString(),
                                                                           pnl_curCtrl.Panel_2DHingeQty_nonMotorized, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");

                                                    add_screws_fab_hinges += (3 * pnl_curCtrl.Panel_2DHingeQty_nonMotorized);
                                                }

                                                Material_List.Rows.Add("Plastic Wedge " + pnl_curCtrl.Panel_PlasticWedge.DisplayName,
                                                                       pnl_curCtrl.Panel_PlasticWedgeQty, "pc (s)",
                                                                       "",
                                                                       "Frame",
                                                                       @"");
                                            }
                                            else if (frame.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                                            {
                                                if (pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                                {
                                                    Material_List.Rows.Add("3D hinge " + pnl_curCtrl.Panel_3dHingeArtNo.DisplayName,
                                                                           pnl_curCtrl.Panel_3dHingeQty, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");
                                                    add_screws_fab_hinges += (6 * pnl_curCtrl.Panel_3dHingeQty);

                                                    Material_List.Rows.Add("Restrictor Stay " + pnl_curCtrl.Panel_RestrictorStayArtNo.DisplayName,
                                                                           pnl_curCtrl.Panel_RestrictorStayQty, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");
                                                    add_screws_fab_fs_or_rs += (6 * pnl_curCtrl.Panel_RestrictorStayQty);

                                                    if (frame.Frame_Height > 2499)
                                                    {
                                                        Material_List.Rows.Add("Weldable corner joint " + pnl_curCtrl.Panel_WeldableCArtNo.DisplayName,
                                                                               8, "pc(s)",
                                                                               "",
                                                                               "Sash",
                                                                               @"");
                                                        add_screws_fab_weldableCJ += (8 * 2);
                                                    }
                                                }
                                                else if (pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                                {
                                                    Material_List.Rows.Add("NT Center Hinge " + pnl_curCtrl.Panel_NTCenterHingeArticleNo.DisplayName,
                                                                           1, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");
                                                    add_screws_fab_hinges += (2 * 1); //2 * qty

                                                    Material_List.Rows.Add("Stay Bearing, K " + pnl_curCtrl.Panel_StayBearingKArtNo.DisplayName,
                                                                           2, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");
                                                    add_screws_fab_stayBearing += (4 * 2); //4 * qty

                                                    Material_List.Rows.Add("Stay Bearing Pin " + pnl_curCtrl.Panel_StayBearingPinArtNo.DisplayName,
                                                                           2, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");

                                                    string basecol = "";
                                                    if (item.WD_BaseColor == Base_Color._Ivory || item.WD_BaseColor == Base_Color._White)
                                                    {
                                                        basecol = "W/Ivory";
                                                    }
                                                    else if (item.WD_BaseColor == Base_Color._DarkBrown)
                                                    {
                                                        basecol = "DB";
                                                    }

                                                    Material_List.Rows.Add("Stay Bearing Cover, " + basecol + " " + pnl_curCtrl.Panel_StayBearingCoverArtNo.DisplayName,
                                                                           2, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");

                                                    Material_List.Rows.Add("Top Corner Hinge Cover, " + basecol + " " + pnl_curCtrl.Panel_TopCornerHingeCoverArtNo.DisplayName,
                                                                           2, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");

                                                    if (pnl_curCtrl.Panel_ChkText == "L")
                                                    {
                                                        Material_List.Rows.Add("Top Corner Hinge, Left " + pnl_curCtrl.Panel_TopCornerHingeArtNo.DisplayName,
                                                                               1, "pc(s)",
                                                                               "",
                                                                               "Sash & Frame",
                                                                               @"");
                                                        add_screws_fab_hinges += (1 * 2); //qty * 2

                                                    }
                                                    else if (pnl_curCtrl.Panel_ChkText == "R")
                                                    {
                                                        Material_List.Rows.Add("Top Corner Hinge, Right " + pnl_curCtrl.Panel_TopCornerHingeArtNo.DisplayName,
                                                                               1, "pc(s)",
                                                                               "",
                                                                               "Sash & Frame",
                                                                               @"");
                                                        add_screws_fab_hinges += (1 * 2); //qty * 2

                                                    }


                                                    Material_List.Rows.Add("Top Corner Hinge Spacer " + pnl_curCtrl.Panel_TopCornerHingeSpacerArtNo.DisplayName,
                                                                           1, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");
                                                    add_screws_fab_hinges += (1 * 3); //qty * 3

                                                    Material_List.Rows.Add("Corner Hinge, K " + pnl_curCtrl.Panel_CornerHingeKArtNo.DisplayName,
                                                                           1, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");
                                                    add_screws_fab_hinges += (1 * 2); //qty * 2

                                                    Material_List.Rows.Add("Corner Pivot Rest, K " + pnl_curCtrl.Panel_CornerPivotRestKArtNo.DisplayName,
                                                                           1, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");
                                                    add_screws_fab_pivotRest += (1 * 4); //qty * 4

                                                    Material_List.Rows.Add("Corner Hinge Cover K, " + basecol + " " + pnl_curCtrl.Panel_CornerHingeCoverKArtNo.DisplayName,
                                                                           1, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");

                                                    Material_List.Rows.Add("Cover for corner pivot rest, vertical, " + basecol + " " + pnl_curCtrl.Panel_CoverForCornerPivotRestVerticalArtNo.DisplayName,
                                                                           1, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");

                                                    Material_List.Rows.Add("Cover for corner pivot rest, " + basecol + " " + pnl_curCtrl.Panel_CoverForCornerPivotRestArtNo.DisplayName,
                                                                           1, "pc(s)",
                                                                           "",
                                                                           "Sash & Frame",
                                                                           @"");
                                                    add_screws_fab_pivotRest += 1;
                                                }
                                            }
                                        }

                                        if (pnl_curCtrl.Panel_MiddleCloserPairQty > 0)
                                        {
                                            Material_List.Rows.Add("Middle Closer " + pnl_curCtrl.Panel_MiddleCloserArtNo.ToString(),
                                                                   pnl_curCtrl.Panel_MiddleCloserPairQty, "pair (s)",
                                                                   "",
                                                                   "Sash & Frame",
                                                                   @"");

                                            add_screws_fab_mc += (4 * pnl_curCtrl.Panel_MiddleCloserPairQty);
                                        }

                                        if (pnl_curCtrl.Panel_HandleType != Handle_Type._Rotary && 
                                            pnl_curCtrl.Panel_HandleType != Handle_Type._None)
                                        {
                                            if (pnl_curCtrl.Panel_ExtensionTopArtNo != Extension_ArticleNo._None && pnl_curCtrl.Panel_ExtTopQty > 0)
                                            {
                                                Material_List.Rows.Add("Extension(Top) " + pnl_curCtrl.Panel_ExtensionTopArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtTopQty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionTopArtNo == Extension_ArticleNo._612978)
                                                {
                                                    add_screws_fab_ext += (3 * pnl_curCtrl.Panel_ExtTopQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionTopArtNo == Extension_ArticleNo._639957)
                                                {
                                                    add_screws_fab_ext += (5 * pnl_curCtrl.Panel_ExtTopQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionTopArtNo == Extension_ArticleNo._567639)
                                                {
                                                    add_screws_fab_ext += (2 * pnl_curCtrl.Panel_ExtTopQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionTopArtNo == Extension_ArticleNo._630956 ||
                                                         pnl_curCtrl.Panel_ExtensionTopArtNo == Extension_ArticleNo._641798)
                                                {
                                                    add_screws_fab_ext += (4 * pnl_curCtrl.Panel_ExtTopQty);
                                                }
                                            }
                                            if (pnl_curCtrl.Panel_ExtensionTop2ArtNo != Extension_ArticleNo._None && pnl_curCtrl.Panel_ExtTop2Qty > 0 && pnl_curCtrl.Panel_ExtTopChk == true)
                                            {
                                                Material_List.Rows.Add("Extension_2(Top) " + pnl_curCtrl.Panel_ExtensionTop2ArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtTop2Qty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._612978)
                                                {
                                                    add_screws_fab_ext += (3 * pnl_curCtrl.Panel_ExtTop2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._639957)
                                                {
                                                    add_screws_fab_ext += (5 * pnl_curCtrl.Panel_ExtTop2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._567639)
                                                {
                                                    add_screws_fab_ext += (2 * pnl_curCtrl.Panel_ExtTop2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._630956 ||
                                                         pnl_curCtrl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._641798)
                                                {
                                                    add_screws_fab_ext += (4 * pnl_curCtrl.Panel_ExtTop2Qty);
                                                }
                                            }
                                            if (pnl_curCtrl.Panel_ExtensionBotArtNo != Extension_ArticleNo._None && pnl_curCtrl.Panel_ExtBotQty > 0)
                                            {
                                                Material_List.Rows.Add("Extension(Bot) " + pnl_curCtrl.Panel_ExtensionBotArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtBotQty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionBotArtNo == Extension_ArticleNo._612978)
                                                {
                                                    add_screws_fab_ext += (3 * pnl_curCtrl.Panel_ExtBotQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionBotArtNo == Extension_ArticleNo._639957)
                                                {
                                                    add_screws_fab_ext += (5 * pnl_curCtrl.Panel_ExtBotQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionBotArtNo == Extension_ArticleNo._567639)
                                                {
                                                    add_screws_fab_ext += (2 * pnl_curCtrl.Panel_ExtBotQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionBotArtNo == Extension_ArticleNo._630956 ||
                                                         pnl_curCtrl.Panel_ExtensionBotArtNo == Extension_ArticleNo._641798)
                                                {
                                                    add_screws_fab_ext += (4 * pnl_curCtrl.Panel_ExtBotQty);
                                                }
                                            }
                                            if (pnl_curCtrl.Panel_ExtensionBot2ArtNo != Extension_ArticleNo._None && pnl_curCtrl.Panel_ExtBot2Qty > 0 && pnl_curCtrl.Panel_ExtBotChk == true)
                                            {
                                                Material_List.Rows.Add("Extension_2(Bot) " + pnl_curCtrl.Panel_ExtensionBot2ArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtBot2Qty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._612978)
                                                {
                                                    add_screws_fab_ext += (3 * pnl_curCtrl.Panel_ExtBot2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._639957)
                                                {
                                                    add_screws_fab_ext += (5 * pnl_curCtrl.Panel_ExtBot2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._567639)
                                                {
                                                    add_screws_fab_ext += (2 * pnl_curCtrl.Panel_ExtBot2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._630956 ||
                                                         pnl_curCtrl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._641798)
                                                {
                                                    add_screws_fab_ext += (4 * pnl_curCtrl.Panel_ExtBot2Qty);
                                                }
                                            }
                                            if (pnl_curCtrl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._None && pnl_curCtrl.Panel_ExtLeftQty > 0)
                                            {
                                                Material_List.Rows.Add("Extension(Left) " + pnl_curCtrl.Panel_ExtensionLeftArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtLeftQty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._612978)
                                                {
                                                    add_screws_fab_ext += (3 * pnl_curCtrl.Panel_ExtLeftQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957)
                                                {
                                                    add_screws_fab_ext += (5 * pnl_curCtrl.Panel_ExtLeftQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._567639)
                                                {
                                                    add_screws_fab_ext += (2 * pnl_curCtrl.Panel_ExtLeftQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._630956 ||
                                                         pnl_curCtrl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._641798)
                                                {
                                                    add_screws_fab_ext += (4 * pnl_curCtrl.Panel_ExtLeftQty);
                                                }
                                            }
                                            if (pnl_curCtrl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._None && pnl_curCtrl.Panel_ExtLeft2Qty > 0 && pnl_curCtrl.Panel_ExtLeftChk == true)
                                            {
                                                Material_List.Rows.Add("Extension_2(Left) " + pnl_curCtrl.Panel_ExtensionLeft2ArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtLeft2Qty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._612978)
                                                {
                                                    add_screws_fab_ext += (3 * pnl_curCtrl.Panel_ExtLeft2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957)
                                                {
                                                    add_screws_fab_ext += (5 * pnl_curCtrl.Panel_ExtLeft2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._567639)
                                                {
                                                    add_screws_fab_ext += (2 * pnl_curCtrl.Panel_ExtLeft2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._630956 ||
                                                         pnl_curCtrl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._641798)
                                                {
                                                    add_screws_fab_ext += (4 * pnl_curCtrl.Panel_ExtLeft2Qty);
                                                }
                                            }
                                            if (pnl_curCtrl.Panel_ExtensionRightArtNo != Extension_ArticleNo._None && pnl_curCtrl.Panel_ExtRightQty > 0)
                                            {
                                                Material_List.Rows.Add("Extension(Right) " + pnl_curCtrl.Panel_ExtensionRightArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtRightQty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionRightArtNo == Extension_ArticleNo._612978)
                                                {
                                                    add_screws_fab_ext += (3 * pnl_curCtrl.Panel_ExtRightQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionRightArtNo == Extension_ArticleNo._639957)
                                                {
                                                    add_screws_fab_ext += (5 * pnl_curCtrl.Panel_ExtRightQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionRightArtNo == Extension_ArticleNo._567639)
                                                {
                                                    add_screws_fab_ext += (2 * pnl_curCtrl.Panel_ExtRightQty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionRightArtNo == Extension_ArticleNo._630956 ||
                                                         pnl_curCtrl.Panel_ExtensionRightArtNo == Extension_ArticleNo._641798)
                                                {
                                                    add_screws_fab_ext += (4 * pnl_curCtrl.Panel_ExtRightQty);
                                                }
                                            }
                                            if (pnl_curCtrl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._None && pnl_curCtrl.Panel_ExtRight2Qty > 0 && pnl_curCtrl.Panel_ExtRightChk == true)
                                            {
                                                Material_List.Rows.Add("Extension_2(Right) " + pnl_curCtrl.Panel_ExtensionRight2ArtNo.ToString(),
                                                                       pnl_curCtrl.Panel_ExtRight2Qty, "pc (s)",
                                                                       "",
                                                                       "Sash",
                                                                       @"");

                                                if (pnl_curCtrl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._612978)
                                                {
                                                    add_screws_fab_ext += (3 * pnl_curCtrl.Panel_ExtRight2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                                                {
                                                    add_screws_fab_ext += (5 * pnl_curCtrl.Panel_ExtRight2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._567639)
                                                {
                                                    add_screws_fab_ext += (2 * pnl_curCtrl.Panel_ExtRight2Qty);
                                                }
                                                else if (pnl_curCtrl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._630956 ||
                                                         pnl_curCtrl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._641798)
                                                {
                                                    add_screws_fab_ext += (4 * pnl_curCtrl.Panel_ExtRight2Qty);
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

                                                add_screws_fab_corDrive += (2 * 2); //2 * 2pcs
                                            }
                                        }

                                        if (pnl_curCtrl.Panel_HandleType == Handle_Type._Rotoswing)
                                        {
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

                                                add_screws_fab_striker += pnl_curCtrl.Panel_StrikerQty_A;

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

                                                    add_screws_fab_striker += pnl_curCtrl.Panel_StrikerQty_C;
                                                }
                                            }
                                            else if (pnl_curCtrl.Panel_Type.Contains("Casement"))
                                            {
                                                if (pnl_curCtrl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                                {
                                                    Material_List.Rows.Add("Striker " + pnl_curCtrl.Panel_StrikerArtno_C.ToString(),
                                                                           pnl_curCtrl.Panel_StrikerQty_C, "pc (s)",
                                                                           "",
                                                                           "Frame",
                                                                           @"");

                                                    add_screws_fab_striker += pnl_curCtrl.Panel_StrikerQty_C;

                                                    if (pnl_curCtrl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                                    {
                                                        Material_List.Rows.Add("Striker " + pnl_curCtrl.Panel_StrikerArtno_A.ToString(),
                                                                               pnl_curCtrl.Panel_StrikerQty_A, "pc (s)",
                                                                               "",
                                                                               "Frame",
                                                                               @"");

                                                        add_screws_fab_striker += pnl_curCtrl.Panel_StrikerQty_A;
                                                    }
                                                }
                                            }
                                        }
                                        else if (pnl_curCtrl.Panel_HandleType == Handle_Type._Rotary)
                                        {
                                            Material_List.Rows.Add("Rotary handle " + pnl_curCtrl.Panel_RotaryArtNo.ToString(),
                                                                   1, "set (s)",
                                                                   "",
                                                                   "Sash",
                                                                   @"");

                                            Material_List.Rows.Add("Locking Kit " + pnl_curCtrl.Panel_LockingKitArtNo.ToString(),
                                                                   1, "set (s)",
                                                                   "",
                                                                   "Sash",
                                                                   @"");

                                            add_screws_fab_handle += 9;
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
                                            Material_List.Rows.Add("Rotoline handle " + pnl_curCtrl.Panel_RotolineArtNo.ToString(),
                                                                   1, "pc(s)",
                                                                   "",
                                                                   "Sash",
                                                                   @"");
                                        }
                                        else if (pnl_curCtrl.Panel_HandleType == Handle_Type._MVD)
                                        {
                                            Material_List.Rows.Add("MVD handle " + pnl_curCtrl.Panel_MVDArtNo.ToString(),
                                                                   1, "set",
                                                                   "",
                                                                   "Sash",
                                                                   @"");

                                            Material_List.Rows.Add("Profile Knob Cylinder " + pnl_curCtrl.Panel_ProfileKnobCylinderArtNo.ToString(),
                                                                   1, "pc(s)",
                                                                   "",
                                                                   "Sash",
                                                                   @"");

                                            string orient = "";
                                            if (pnl_curCtrl.Panel_ChkText == "L")
                                            {
                                                orient = "Left";
                                            }
                                            else if (pnl_curCtrl.Panel_ChkText == "R")
                                            {
                                                orient = "Right";
                                            }

                                            Material_List.Rows.Add("Latch and deadbolt striker, " + orient + " " + pnl_curCtrl.Panel_LatchDeadboltStrikerArtNo.DisplayName,
                                                                   1, "pc(s)",
                                                                   "",
                                                                   "Frame",
                                                                   @"");
                                            add_screws_fab_striker += 2;
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
                                                pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                                            {
                                                add_screws_fab_espag += 8;
                                            }
                                            else if (pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                                                     pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._630963)
                                            {
                                                add_screws_fab_espag += 2;
                                            }
                                            else if (pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807)
                                            {
                                                add_screws_fab_espag += 4;
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
                                                add_screws_fab_espag += 6;
                                            }
                                            else if (pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                                                     pnl_curCtrl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                                            {
                                                add_screws_fab_espag += 12;
                                            }
                                        }
                                    }
                                }

                                string where = "";
                                if (pnl_curCtrl.Panel_SashPropertyVisibility == true)
                                {
                                    where = "Sash";
                                }
                                else if (pnl_curCtrl.Panel_SashPropertyVisibility == false)
                                {
                                    where = "Frame";
                                }

                                Material_List.Rows.Add("Glazing Bead (P" + pnl_curCtrl.PanelGlass_ID + ") Width " + pnl_curCtrl.PanelGlazingBead_ArtNo.ToString(),
                                                       2, "pc(s)",
                                                       pnl_curCtrl.Panel_GlazingBeadWidth.ToString(),
                                                       where,
                                                       @"\  /");

                                Material_List.Rows.Add("Glazing Bead (P" + pnl_curCtrl.PanelGlass_ID + ") Height " + pnl_curCtrl.PanelGlazingBead_ArtNo.ToString(),
                                                       2, "pc(s)",
                                                       pnl_curCtrl.Panel_GlazingBeadHeight.ToString(),
                                                       where,
                                                       @"\  /");

                                if (pnl_curCtrl.Panel_ChkGlazingAdaptor == true)
                                {

                                    Material_List.Rows.Add("Glazing Adaptor (P" + pnl_curCtrl.PanelGlass_ID + ") Width " + pnl_curCtrl.Panel_GlazingAdaptorArtNo.DisplayName,
                                                           2, "pc(s)",
                                                           pnl_curCtrl.Panel_GlazingBeadWidth.ToString(),
                                                           where,
                                                           @"\  /");

                                    Material_List.Rows.Add("Glazing Adaptor (P" + pnl_curCtrl.PanelGlass_ID + ") Height " + pnl_curCtrl.Panel_GlazingAdaptorArtNo.DisplayName,
                                                           2, "pc(s)",
                                                           pnl_curCtrl.Panel_GlazingBeadHeight.ToString(),
                                                           where,
                                                           @"\  /");
                                }

                                string glassFilm = "";
                                if (pnl_curCtrl.Panel_GlassFilm != GlassFilm_Types._None)
                                {
                                    glassFilm = pnl_curCtrl.Panel_GlassFilm.DisplayName;
                                }

                                Material_List.Rows.Add("Glass (P" + pnl_curCtrl.PanelGlass_ID + ") Width - " + pnl_curCtrl.Panel_GlassThicknessDesc + " " + glassFilm,
                                                       1, "pc(s)",
                                                       pnl_curCtrl.Panel_GlassWidth.ToString(),
                                                       where,
                                                       @"\  /");

                                Material_List.Rows.Add("Glass (P" + pnl_curCtrl.PanelGlass_ID + ") Height - " + pnl_curCtrl.Panel_GlassThicknessDesc + " " + glassFilm,
                                                       1, "pc(s)",
                                                       pnl_curCtrl.Panel_GlassHeight.ToString(),
                                                       where,
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
                            Material_List.Rows.Add("Cover Profile " + pnl.Panel_CoverProfileArtNo.DisplayName,
                                                   1, "pc(s)",
                                                   pnl.Panel_DisplayWidth.ToString(),
                                                   "Frame",
                                                   @"|  |");

                            if (pnl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                            {
                                Material_List.Rows.Add("Cover Profile " + pnl.Panel_CoverProfileArtNo2.DisplayName,
                                                       1, "pc(s)",
                                                       pnl.Panel_DisplayWidth.ToString(),
                                                       "Frame",
                                                       @"|  |");
                            }
                        }

                        if (pnl.Panel_MotorizedOptionVisibility == true)
                        {
                            if (pnl.Panel_Type == "Awning Panel")
                            {
                                Material_List.Rows.Add("30X25 Cover " + pnl.Panel_30x25CoverArtNo.ToString(),
                                                       1, "pc(s)",
                                                       frame.Frame_Width + 150,
                                                       "Frame",
                                                       @"");

                                Material_List.Rows.Add("Divider " + pnl.Panel_MotorizedDividerArtNo.ToString(),
                                                       1, "pc(s)",
                                                       frame.Frame_Width + 150,
                                                       "Frame",
                                                       @"");

                                Material_List.Rows.Add("Cover for motor " + pnl.Panel_CoverForMotorArtNo.ToString(),
                                                       1, "pc(s)",
                                                       frame.Frame_Width + 150,
                                                       "Motorized Mechanism",
                                                       @"");

                            }
                            else if (pnl.Panel_Type == "Casement Panel")
                            {
                                Material_List.Rows.Add("30X25 Cover " + pnl.Panel_30x25CoverArtNo.ToString(),
                                                       1, "pc(s)",
                                                       frame.Frame_Height + 150,
                                                       "Frame",
                                                       @"");

                                Material_List.Rows.Add("Divider " + pnl.Panel_MotorizedDividerArtNo.ToString(),
                                                       1, "pc(s)",
                                                       frame.Frame_Height + 150,
                                                       "Frame",
                                                       @"");

                                Material_List.Rows.Add("Cover for motor " + pnl.Panel_CoverForMotorArtNo.ToString(),
                                                       1, "pc(s)",
                                                       frame.Frame_Height + 150,
                                                       "Motorized Mechanism",
                                                       @"");
                            }

                            if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 ||
                                pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                            {
                                Material_List.Rows.Add("2D Hinge " + pnl.Panel_2dHingeArtNo.DisplayName,
                                                       pnl.Panel_2DHingeQty, "pc(s)",
                                                       "",
                                                       "Sash & Frame",
                                                       @"");

                                add_screws_fab_hinges += (pnl.Panel_2DHingeQty * 3); //qty * 3

                            }
                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                            {
                                Material_List.Rows.Add("Butt Hinge " + pnl.Panel_ButtHingeArtNo.DisplayName,
                                                       pnl.Panel_ButtHingeQty, "pc(s)",
                                                       "",
                                                       "",
                                                       @"");

                                add_screws_fab_hinges += (pnl.Panel_ButtHingeQty * 3); //qty * 3
                            }
                            Material_List.Rows.Add("Motorized Mechanism " + pnl.Panel_MotorizedMechArtNo.DisplayName,
                                                   pnl.Panel_MotorizedMechQty, "pc(s)",
                                                   "",
                                                   "Sash",
                                                   @"");

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
                                    add_screws_fab_fs_or_rs += 6; //for Storm26

                                    Material_List.Rows.Add("Snap-in Keep " + pnl.Panel_SnapInKeepArtNo.ToString(),
                                                           2, "pc(s)",
                                                           "",
                                                           "Frame",
                                                           @"");

                                    add_screws_fab_snapInKeep += (2 * 2); //2 * 2pcs

                                    Material_List.Rows.Add("Fixed Cam " + pnl.Panel_FixedCamArtNo.ToString(),
                                                           2, "pc(s)",
                                                           "",
                                                           "Frame",
                                                           @"");

                                    add_screws_fab_fxdcam += (2 * 2); //2 * 2pcs
                                }
                                else if (pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm8)
                                {
                                    add_screws_fab_fs_or_rs += 3;
                                }
                                else if (pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._10HD ||
                                         pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._12HD)
                                {
                                    add_screws_fab_fs_or_rs += 4;
                                }
                                else if (pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._16HD)
                                {
                                    add_screws_fab_fs_or_rs += 5;
                                }
                                else if (pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm22)
                                {
                                    add_screws_fab_fs_or_rs += 6;
                                }

                                Material_List.Rows.Add("Plastic Wedge " + pnl.Panel_PlasticWedge.DisplayName,
                                                       pnl.Panel_PlasticWedgeQty, "pc (s)",
                                                       "",
                                                       "Frame",
                                                       @"");

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

                                        if (pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._10HD)
                                        {
                                            add_screws_fab_fs_or_rs += 3;
                                        }
                                        else if (pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._12FS ||
                                                 pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._12HD)
                                        {
                                            add_screws_fab_fs_or_rs += 4;
                                        }
                                        else if (pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._16HD)
                                        {
                                            add_screws_fab_fs_or_rs += 5;
                                        }
                                        else if (pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._20HD)
                                        {
                                            add_screws_fab_fs_or_rs += 6;
                                        }
                                    }
                                    else if (pnl.Panel_HingeOptions == HingeOption._2DHinge)
                                    {
                                        Material_List.Rows.Add("2D hinge " + pnl.Panel_2dHingeArtNo_nonMotorized.ToString(),
                                                               pnl.Panel_2DHingeQty_nonMotorized, "pc(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");

                                        add_screws_fab_hinges += (3 * pnl.Panel_2DHingeQty_nonMotorized);
                                    }

                                    Material_List.Rows.Add("Plastic Wedge " + pnl.Panel_PlasticWedge.DisplayName,
                                                           pnl.Panel_PlasticWedgeQty, "pc (s)",
                                                           "",
                                                           "Frame",
                                                           @"");
                                }
                                else if (frame.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                                {
                                    if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                    {
                                        Material_List.Rows.Add("3D hinge " + pnl.Panel_3dHingeArtNo.DisplayName,
                                                               pnl.Panel_3dHingeQty, "pc(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");
                                        add_screws_fab_hinges += (6 * pnl.Panel_3dHingeQty);

                                        Material_List.Rows.Add("Restrictor Stay " + pnl.Panel_RestrictorStayArtNo.DisplayName,
                                                               pnl.Panel_RestrictorStayQty, "pc(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");
                                        add_screws_fab_fs_or_rs += (6 * pnl.Panel_RestrictorStayQty);

                                    }
                                    else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                    {
                                        Material_List.Rows.Add("NT Center Hinge " + pnl.Panel_NTCenterHingeArticleNo.DisplayName,
                                                                1, "pc(s)",
                                                                "",
                                                                "Sash & Frame",
                                                                @"");
                                        add_screws_fab_hinges += (2 * 1); //2 * qty


                                        Material_List.Rows.Add("Stay Bearing, K " + pnl.Panel_StayBearingKArtNo.DisplayName,
                                                               2, "pc(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");
                                        add_screws_fab_stayBearing += (4 * 2); //4 * qty

                                        Material_List.Rows.Add("Stay Bearing Pin " + pnl.Panel_StayBearingPinArtNo.DisplayName,
                                                               2, "pc(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");

                                        string basecol = "";
                                        if (item.WD_BaseColor == Base_Color._Ivory || item.WD_BaseColor == Base_Color._White)
                                        {
                                            basecol = "W/Ivory";
                                        }
                                        else if (item.WD_BaseColor == Base_Color._DarkBrown)
                                        {
                                            basecol = "DB";
                                        }

                                        Material_List.Rows.Add("Stay Bearing Cover, " + basecol + " " + pnl.Panel_StayBearingCoverArtNo.DisplayName,
                                                               2, "pc(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");

                                        Material_List.Rows.Add("Top Corner Hinge Cover, " + basecol + " " + pnl.Panel_TopCornerHingeCoverArtNo.DisplayName,
                                                               2, "pc(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");

                                        if (pnl.Panel_ChkText == "L")
                                        {
                                            Material_List.Rows.Add("Top Corner Hinge, Left " + pnl.Panel_TopCornerHingeArtNo.DisplayName,
                                                                   1, "pc(s)",
                                                                   "",
                                                                   "Sash & Frame",
                                                                   @"");
                                            add_screws_fab_hinges += (1 * 2); //qty * 2

                                        }
                                        else if (pnl.Panel_ChkText == "R")
                                        {
                                            Material_List.Rows.Add("Top Corner Hinge, Right " + pnl.Panel_TopCornerHingeArtNo.DisplayName,
                                                                   1, "pc(s)",
                                                                   "",
                                                                   "Sash & Frame",
                                                                   @"");
                                            add_screws_fab_hinges += (1 * 2); //qty * 2
                                        }

                                        Material_List.Rows.Add("Top Corner Hinge Spacer " + pnl.Panel_TopCornerHingeSpacerArtNo.DisplayName,
                                                               1, "pc(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");
                                        add_screws_fab_hinges += (1 * 3); //qty * 3

                                        Material_List.Rows.Add("Corner Hinge, K " + pnl.Panel_CornerHingeKArtNo.DisplayName,
                                                               1, "pc(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");
                                        add_screws_fab_hinges += (1 * 2); //qty * 2

                                        Material_List.Rows.Add("Corner Pivot Rest, K " + pnl.Panel_CornerPivotRestKArtNo.DisplayName,
                                                               1, "pc(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");
                                        add_screws_fab_pivotRest += (1 * 4); //qty * 1

                                        Material_List.Rows.Add("Corner Hinge Cover K, " + basecol + " " + pnl.Panel_CornerHingeCoverKArtNo.DisplayName,
                                                               1, "pc(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");

                                        Material_List.Rows.Add("Cover for corner pivot rest, vertical, " + basecol + " " + pnl.Panel_CoverForCornerPivotRestVerticalArtNo.DisplayName,
                                                               1, "pc(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");
                                        add_screws_fab_pivotRest += 1;

                                        Material_List.Rows.Add("Cover for corner pivot rest, " + basecol + " " + pnl.Panel_CoverForCornerPivotRestArtNo.DisplayName,
                                                               1, "pc(s)",
                                                               "",
                                                               "Sash & Frame",
                                                               @"");

                                    }
                                    Material_List.Rows.Add("Adjustable Striker " + pnl.Panel_AdjStrikerArtNo.DisplayName,
                                                           pnl.Panel_AdjStrikerQty, "pc(s)",
                                                           "",
                                                           "Frame",
                                                           @"");

                                    add_screws_fab_striker += (1 * pnl.Panel_AdjStrikerQty);
                                }

                            }

                            if (pnl.Panel_MiddleCloserPairQty > 0)
                            {
                                Material_List.Rows.Add("Middle Closer " + pnl.Panel_MiddleCloserArtNo.ToString(),
                                                       pnl.Panel_MiddleCloserPairQty, "pair (s)",
                                                       "",
                                                       "Sash & Frame",
                                                       @"");

                                add_screws_fab_mc += (4 * pnl.Panel_MiddleCloserPairQty);
                            }

                            if (pnl.Panel_HandleType != Handle_Type._Rotary &&
                                pnl.Panel_HandleType != Handle_Type._None)
                            {
                                if (pnl.Panel_ExtensionTopArtNo != Extension_ArticleNo._None && pnl.Panel_ExtTopQty > 0)
                                {
                                    Material_List.Rows.Add("Extension(Top) " + pnl.Panel_ExtensionTopArtNo.ToString(),
                                                           pnl.Panel_ExtTopQty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionTopArtNo == Extension_ArticleNo._612978)
                                    {
                                        add_screws_fab_ext += (3 * pnl.Panel_ExtTopQty);
                                    }
                                    else if (pnl.Panel_ExtensionTopArtNo == Extension_ArticleNo._639957)
                                    {
                                        add_screws_fab_ext += (5 * pnl.Panel_ExtTopQty);
                                    }
                                    else if (pnl.Panel_ExtensionTopArtNo == Extension_ArticleNo._567639)
                                    {
                                        add_screws_fab_ext += (2 * pnl.Panel_ExtTopQty);
                                    }
                                    else if (pnl.Panel_ExtensionTopArtNo == Extension_ArticleNo._630956 ||
                                             pnl.Panel_ExtensionTopArtNo == Extension_ArticleNo._641798)
                                    {
                                        add_screws_fab_ext += (4 * pnl.Panel_ExtTopQty);
                                    }
                                }
                                if (pnl.Panel_ExtensionTop2ArtNo != Extension_ArticleNo._None && pnl.Panel_ExtTop2Qty > 0 && pnl.Panel_ExtTopChk == true)
                                {
                                    Material_List.Rows.Add("Extension_2(Top) " + pnl.Panel_ExtensionTop2ArtNo.ToString(),
                                                           pnl.Panel_ExtTop2Qty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._612978)
                                    {
                                        add_screws_fab_ext += (3 * pnl.Panel_ExtTop2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._639957)
                                    {
                                        add_screws_fab_ext += (5 * pnl.Panel_ExtTop2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._567639)
                                    {
                                        add_screws_fab_ext += (2 * pnl.Panel_ExtTop2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._630956 ||
                                             pnl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._641798)
                                    {
                                        add_screws_fab_ext += (4 * pnl.Panel_ExtTop2Qty);
                                    }
                                }
                                if (pnl.Panel_ExtensionBotArtNo != Extension_ArticleNo._None && pnl.Panel_ExtBotQty > 0)
                                {
                                    Material_List.Rows.Add("Extension(Bot) " + pnl.Panel_ExtensionBotArtNo.ToString(),
                                                           pnl.Panel_ExtBotQty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionBotArtNo == Extension_ArticleNo._612978)
                                    {
                                        add_screws_fab_ext += (3 * pnl.Panel_ExtBotQty);
                                    }
                                    else if (pnl.Panel_ExtensionBotArtNo == Extension_ArticleNo._639957)
                                    {
                                        add_screws_fab_ext += (5 * pnl.Panel_ExtBotQty);
                                    }
                                    else if (pnl.Panel_ExtensionBotArtNo == Extension_ArticleNo._567639)
                                    {
                                        add_screws_fab_ext += (2 * pnl.Panel_ExtBotQty);
                                    }
                                    else if (pnl.Panel_ExtensionBotArtNo == Extension_ArticleNo._630956 ||
                                             pnl.Panel_ExtensionBotArtNo == Extension_ArticleNo._641798)
                                    {
                                        add_screws_fab_ext += (4 * pnl.Panel_ExtBotQty);
                                    }
                                }
                                if (pnl.Panel_ExtensionBot2ArtNo != Extension_ArticleNo._None && pnl.Panel_ExtBot2Qty > 0 && pnl.Panel_ExtBotChk == true)
                                {
                                    Material_List.Rows.Add("Extension_2(Bot) " + pnl.Panel_ExtensionBot2ArtNo.ToString(),
                                                           pnl.Panel_ExtBot2Qty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._612978)
                                    {
                                        add_screws_fab_ext += (3 * pnl.Panel_ExtBot2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._639957)
                                    {
                                        add_screws_fab_ext += (5 * pnl.Panel_ExtBot2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._567639)
                                    {
                                        add_screws_fab_ext += (2 * pnl.Panel_ExtBot2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._630956 ||
                                             pnl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._641798)
                                    {
                                        add_screws_fab_ext += (4 * pnl.Panel_ExtBot2Qty);
                                    }
                                }
                                if (pnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._None && pnl.Panel_ExtLeftQty > 0)
                                {
                                    Material_List.Rows.Add("Extension(Left) " + pnl.Panel_ExtensionLeftArtNo.ToString(),
                                                           pnl.Panel_ExtLeftQty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._612978)
                                    {
                                        add_screws_fab_ext += (3 * pnl.Panel_ExtLeftQty);
                                    }
                                    else if (pnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957)
                                    {
                                        add_screws_fab_ext += (5 * pnl.Panel_ExtLeftQty);
                                    }
                                    else if (pnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._567639)
                                    {
                                        add_screws_fab_ext += (2 * pnl.Panel_ExtLeftQty);
                                    }
                                    else if (pnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._630956 ||
                                             pnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._641798)
                                    {
                                        add_screws_fab_ext += (4 * pnl.Panel_ExtLeftQty);
                                    }
                                }
                                if (pnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._None && pnl.Panel_ExtLeft2Qty > 0 && pnl.Panel_ExtLeftChk == true)
                                {
                                    Material_List.Rows.Add("Extension_2(Left) " + pnl.Panel_ExtensionLeft2ArtNo.ToString(),
                                                           pnl.Panel_ExtLeft2Qty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._612978)
                                    {
                                        add_screws_fab_ext += (3 * pnl.Panel_ExtLeft2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957)
                                    {
                                        add_screws_fab_ext += (5 * pnl.Panel_ExtLeft2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._567639)
                                    {
                                        add_screws_fab_ext += (2 * pnl.Panel_ExtLeft2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._630956 ||
                                             pnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._641798)
                                    {
                                        add_screws_fab_ext += (4 * pnl.Panel_ExtLeft2Qty);
                                    }
                                }
                                if (pnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._None && pnl.Panel_ExtRightQty > 0)
                                {
                                    Material_List.Rows.Add("Extension(Right) " + pnl.Panel_ExtensionRightArtNo.ToString(),
                                                           pnl.Panel_ExtRightQty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._612978)
                                    {
                                        add_screws_fab_ext += (3 * pnl.Panel_ExtRightQty);
                                    }
                                    else if (pnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._639957)
                                    {
                                        add_screws_fab_ext += (5 * pnl.Panel_ExtRightQty);
                                    }
                                    else if (pnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._567639)
                                    {
                                        add_screws_fab_ext += (2 * pnl.Panel_ExtRightQty);
                                    }
                                    else if (pnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._630956 ||
                                             pnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._641798)
                                    {
                                        add_screws_fab_ext += (4 * pnl.Panel_ExtRightQty);
                                    }
                                }
                                if (pnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._None && pnl.Panel_ExtRight2Qty > 0 && pnl.Panel_ExtRightChk == true)
                                {
                                    Material_List.Rows.Add("Extension_2(Right) " + pnl.Panel_ExtensionRight2ArtNo.ToString(),
                                                           pnl.Panel_ExtRight2Qty, "pc (s)",
                                                           "",
                                                           "Sash",
                                                           @"");

                                    if (pnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._612978)
                                    {
                                        add_screws_fab_ext += (3 * pnl.Panel_ExtRight2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                                    {
                                        add_screws_fab_ext += (5 * pnl.Panel_ExtRight2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._567639)
                                    {
                                        add_screws_fab_ext += (2 * pnl.Panel_ExtRight2Qty);
                                    }
                                    else if (pnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._630956 ||
                                             pnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._641798)
                                    {
                                        add_screws_fab_ext += (4 * pnl.Panel_ExtRight2Qty);
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

                                    add_screws_fab_corDrive += (2 * 2); //2 * 2pcs
                                }
                            }

                            if (pnl.Panel_HandleType == Handle_Type._Rotoswing)
                            {
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

                                    add_screws_fab_striker += pnl.Panel_StrikerQty_A;

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

                                        add_screws_fab_striker += pnl.Panel_StrikerQty_C;
                                    }
                                }
                                else if (pnl.Panel_Type.Contains("Casement"))
                                {
                                    if (pnl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                    {
                                        Material_List.Rows.Add("Striker " + pnl.Panel_StrikerArtno_C.ToString(),
                                                               pnl.Panel_StrikerQty_C, "pc (s)",
                                                               "",
                                                               "Frame",
                                                               @"");

                                        add_screws_fab_striker += pnl.Panel_StrikerQty_C;

                                        if (pnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                        {
                                            Material_List.Rows.Add("Striker " + pnl.Panel_StrikerArtno_A.ToString(),
                                                               pnl.Panel_StrikerQty_A, "pc (s)",
                                                               "",
                                                               "Frame",
                                                               @"");

                                            add_screws_fab_striker += pnl.Panel_StrikerQty_A;
                                        }
                                    }
                                }
                            }
                            else if (pnl.Panel_HandleType == Handle_Type._Rotary)
                            {
                                Material_List.Rows.Add("Rotary handle " + pnl.Panel_RotaryArtNo.ToString(),
                                                       1, "set (s)",
                                                       "",
                                                       "Sash",
                                                       @"");

                                Material_List.Rows.Add("Locking Kit " + pnl.Panel_LockingKitArtNo.ToString(),
                                                       1, "set (s)",
                                                       "",
                                                       "Sash",
                                                       @"");

                                add_screws_fab_handle += 9;
                            }
                            else if (pnl.Panel_HandleType == Handle_Type._Rio)
                            {
                                Material_List.Rows.Add("Rio handle " + pnl.Panel_RioArtNo.ToString(),
                                                       1, "pc(s)",
                                                       "",
                                                       "Sash",
                                                       @"");

                                Material_List.Rows.Add("Profile Knob Cylinder " + pnl.Panel_ProfileKnobCylinderArtNo.ToString(),
                                                       1, "pc(s)",
                                                       "",
                                                       "Sash",
                                                       @"");

                                Material_List.Rows.Add("Cylinder Cover " + pnl.Panel_CylinderCoverArtNo.ToString(),
                                                       1, "pc(s)",
                                                       "",
                                                       "Sash",
                                                       @"");
                            }
                            else if (pnl.Panel_HandleType == Handle_Type._Rotoline)
                            {
                                Material_List.Rows.Add("Rotoline handle " + pnl.Panel_RotolineArtNo.ToString(),
                                                       1, "pc(s)",
                                                       "",
                                                       "Sash",
                                                       @"");
                            }
                            else if (pnl.Panel_HandleType == Handle_Type._MVD)
                            {
                                Material_List.Rows.Add("MVD handle " + pnl.Panel_MVDArtNo.ToString(),
                                                       1, "set",
                                                       "",
                                                       "Sash",
                                                       @"");

                                Material_List.Rows.Add("Profile Knob Cylinder " + pnl.Panel_ProfileKnobCylinderArtNo.ToString(),
                                                       1, "pc(s)",
                                                       "",
                                                       "Sash",
                                                       @"");

                                Material_List.Rows.Add("Weldable corner joint " + pnl.Panel_WeldableCArtNo.DisplayName,
                                                       8, "pc(s)",
                                                       "",
                                                       "Sash",
                                                       @"");
                                add_screws_fab_weldableCJ += (8 * 2);

                                string orient = "";
                                if (pnl.Panel_ChkText == "L")
                                {
                                    orient = "Left";
                                }
                                else if (pnl.Panel_ChkText == "R")
                                {
                                    orient = "Right";
                                }

                                Material_List.Rows.Add("Latch and deadbolt striker, " + orient + " " + pnl.Panel_LatchDeadboltStrikerArtNo.DisplayName,
                                                       1, "pc(s)",
                                                       "",
                                                       "Frame",
                                                       @"");
                                add_screws_fab_striker += 2;
                            }

                            if (pnl.Panel_HandleType != Handle_Type._Rotary)
                            {
                                Material_List.Rows.Add("Espagnolette " + pnl.Panel_EspagnoletteArtNo.ToString(),
                                                       1, "pc (s)",
                                                       "",
                                                       "Sash",
                                                       @"");

                                if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                                    pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                                {
                                    add_screws_fab_espag += 8;
                                }
                                else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                                         pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._630963)
                                {
                                    add_screws_fab_espag += 2;
                                }
                                else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807)
                                {
                                    add_screws_fab_espag += 4;
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
                                    add_screws_fab_espag += 6;
                                }
                                else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                                         pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                                {
                                    add_screws_fab_espag += 12;
                                }
                            }
                        }
                    }

                    string where = "";
                    if (pnl.Panel_SashPropertyVisibility == true)
                    {
                        where = "Sash";
                    }
                    else if (pnl.Panel_SashPropertyVisibility == false)
                    {
                        where = "Frame";
                    }

                    Material_List.Rows.Add("Glazing Bead (P" + pnl.PanelGlass_ID + ") Width " + pnl.PanelGlazingBead_ArtNo.ToString(),
                                           2, "pc(s)",
                                           pnl.Panel_GlazingBeadWidth.ToString(),
                                           where,
                                           @"\  /");

                    Material_List.Rows.Add("Glazing Bead (P" + pnl.PanelGlass_ID + ") Height " + pnl.PanelGlazingBead_ArtNo.ToString(),
                                           2, "pc(s)",
                                           pnl.Panel_GlazingBeadHeight.ToString(),
                                           where,
                                           @"\  /");

                    if (pnl.Panel_ChkGlazingAdaptor == true)
                    {
                        Material_List.Rows.Add("Glazing Adaptor (P" + pnl.PanelGlass_ID + ") Width" + pnl.Panel_GlazingAdaptorArtNo.DisplayName,
                                               2, "pc(s)",
                                               pnl.Panel_GlazingBeadWidth.ToString(),
                                               where,
                                               @"\  /");

                        Material_List.Rows.Add("Glazing Adaptor (P" + pnl.PanelGlass_ID + ") Height " + pnl.Panel_GlazingAdaptorArtNo.DisplayName,
                                               2, "pc(s)",
                                               pnl.Panel_GlazingBeadHeight.ToString(),
                                               where,
                                               @"\  /");
                    }

                    string glassFilm = "";
                    if (pnl.Panel_GlassFilm != GlassFilm_Types._None)
                    {
                        glassFilm = pnl.Panel_GlassFilm.DisplayName;
                    }

                    Material_List.Rows.Add("Glass (P" + pnl.PanelGlass_ID + ") Width - " + pnl.Panel_GlassThicknessDesc + " " + glassFilm,
                                           1, "pc(s)",
                                           pnl.Panel_GlassWidth.ToString(),
                                           where,
                                           @"\  /");

                    Material_List.Rows.Add("Glass (P" + pnl.PanelGlass_ID + ") Height - " + pnl.Panel_GlassThicknessDesc + " " + glassFilm,
                                           1, "pc(s)",
                                           pnl.Panel_GlassHeight.ToString(),
                                           where,
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
            int add_screws = add_screws_fab_espag +
                             add_screws_fab_ext +
                             add_screws_fab_corDrive +
                             add_screws_fab_snapInKeep +
                             add_screws_fab_striker +
                             add_screws_fab_mc +
                             add_screws_fab_fs_or_rs +
                             add_screws_fab_alum +
                             add_screws_fab_fxdcam +
                             add_screws_fab_endcap +
                             add_screws_fab_hinges +
                             add_screws_fab_stayBearing +
                             add_screws_fab_pivotRest +
                             add_screws_fab_shootbolt +
                             add_screws_fab_weldableCJ +
                             add_screws_fab_cladingBracket +
                             add_screws_fab_handle +
                             add_screws_fab_mech_joint;
            Screws_for_Fabrication = fixing_screw + add_screws;
            Screws_for_Installation = fixing_screw + total_screws_installation;
            Screws_for_Cladding = (int)(Math.Ceiling((decimal)total_cladding_size / 300));

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

            Material_List.Rows.Add("Expansion Bolts FRA003",
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

            if (Screws_for_Cladding > 0)
            {
                Material_List.Rows.Add("Screws for Cladding 10 x 38",
                                       Screws_for_Cladding, "pc(s)", "", "");

            }
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

            decimal rounded = Math.Round(item.WD_PlasticCover, 2);
            Material_List.Rows.Add("Plastic Cover",
                                   rounded.ToString(),
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
