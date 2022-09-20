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
        public int Quotation_Id { get; set; }

        public List<IWindoorModel> Lst_Windoor { get; set; }

        [Required(ErrorMessage = "Quotation reference number is Required")]
        public string Quotation_ref_no { get; set; }
        public DateTime Quotation_Date { get; set; }

        public int Frame_PUFoamingQty_Total { get; set; }
        public int Frame_SealantWHQty_Total { get; set; }
        public int Glass_SealantWHQty_Total { get; set; }
        public int GlazingSpacer_TotalQty { get; set; }
        public int GlazingSeal_TotalQty { get; set; }
        public int Screws_for_Fabrication { get; set; }
        public int Screws_for_Installation { get; set; }
        public int Screws_for_6050Frame { get; set; }
        public int Screws_for_6055Frame { get; set; }
        public int ACC_for_6050 { get; set; }
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
            bool slidingChck = false;
            foreach (IFrameModel frame in item.lst_frame)
            {
                perFrame = true;
                slidingChck = false;

                frame.SetExplosionValues_Frame();

                frame_width += frame.Frame_Width;
                frame_height += frame.Frame_Height;
                totalFrames_width += (frame.Frame_Width * 2);
                totalFrames_height += (frame.Frame_Height * 2);

                total_screws_fabrication += frame.Add_framePerimeter_screws4fab();

                if (!screws_for_inst_where.Contains("Frame"))
                {
                    screws_for_inst_where = "Frame";
                }

                frame.Insert_frameInfo_MaterialList(Material_List);

                if (frame.Frame_SlidingRailsQty == 3)
                {
                    frame.Insert_frameInfoForPremi_MaterialList(Material_List);
                }

                if (frame.Frame_BotFrameArtNo != BottomFrameTypes._7507)
                {
                    frame.Insert_BottomFrame_MaterialList(Material_List);
                }

                if (frame.Frame_If_InwardMotorizedCasement)
                {
                    frame.Insert_MilledFrameInfo_MaterialList(Material_List);
                    total_screws_fabrication += frame.Add_MilledFrameWidth_screws4fab();
                }

                if (frame.Lst_MultiPanel.Count() >= 1 && frame.Lst_Panel.Count() == 0)
                {
                    #region MultiPanel Parent
                    foreach (IMultiPanelModel mpnl in frame.Lst_MultiPanel)
                    {
                        if (mpnl.MPanel_DividerEnabled)
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
                                    if (mpnl.MPanel_Type == "Transom" && div_nxtCtrl != null)
                                    {
                                        div_nxtCtrl.SetExplosionValues_Div();

                                        div_nxtCtrl.Insert_DivProfile_DivReinf_Info_MaterialList(Material_List);
                                        div_nxtCtrl.Insert_MechJoint_MaterialList(Material_List);

                                        int mj_screws = div_nxtCtrl.Add_MechJoint_screws4fab();
                                        add_screws_fab_mech_joint += mj_screws;

                                        int explosionLength_screws = div_nxtCtrl.Add_ExplosionLength_screws4fab();
                                        total_screws_fabrication += explosionLength_screws;

                                        if (!screws_for_inst_where.Contains("Transom"))
                                        {
                                            screws_for_inst_where += ", Transom";
                                        }

                                        div_nxtCtrl.Insert_CladdingProfile_MaterialList(Material_List);

                                        int total_cladd = div_nxtCtrl.Add_TotalCladdingSize_Screws4Cladding();
                                        total_cladding_size += total_cladd;

                                        if (div_nxtCtrl.Div_claddingBracketVisibility == true)
                                        {
                                            div_nxtCtrl.Insert_CladdingBracket4Concrete_MaterialList(Material_List);

                                            div_nxtCtrl.Insert_CladdingBracket4UPVC_MaterialList(Material_List);
                                        }

                                        int total_cladd4concrete = div_nxtCtrl.Add_CladdingBracket4Concrete_screws4fab();
                                        add_screws_fab_cladingBracket += total_cladd4concrete;

                                        int total_cladd4UPVC = div_nxtCtrl.Add_CladdingBracket4UPVC_screws4fab();
                                        add_screws_fab_cladingBracket += total_cladd4UPVC;

                                        int total_cladd4concrete_xpbolts = div_nxtCtrl.Add_CladdBracket4Concrete_expbolts();
                                        exp_bolt += total_cladd4concrete_xpbolts;

                                        int total_cladd4UPVC_xpbolts = div_nxtCtrl.Add_CladdBracket4UPVC_expbolts();
                                        exp_bolt += total_cladd4UPVC_xpbolts;
                                    }

                                    if (div_nxtCtrl.Div_ChkDM == false && !mullion_already_added && mpnl.MPanel_Type == "Mullion")
                                    {
                                        mullion_already_added = true;

                                        div_nxtCtrl.SetExplosionValues_Div();

                                        div_nxtCtrl.Insert_DivProfile_DivReinf_Info_MaterialList(Material_List);

                                        int explosionLength_screws = div_nxtCtrl.Add_ExplosionLength_screws4fab();
                                        total_screws_fabrication += explosionLength_screws;

                                        if (!screws_for_inst_where.Contains("Mullion"))
                                        {
                                            screws_for_inst_where += ", Mullion";
                                        }

                                        div_nxtCtrl.Insert_MechJoint_MaterialList(Material_List);

                                        int mj_screws = div_nxtCtrl.Add_MechJoint_screws4fab();
                                        add_screws_fab_mech_joint += mj_screws;
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
                                                                                  mpnl.MPanel_DividerEnabled,
                                                                                  0,
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
                                                                                  mpnl.MPanel_DividerEnabled,
                                                                                  0,
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

                                            if (div_nxtCtrl.Div_ChkDM == false && pnl_curCtrl.Panel_AdjStrikerArtNo != null && pnl_curCtrl.Panel_AdjStrikerQty > 0)
                                            {
                                                pnl_curCtrl.Insert_AdjustableStriker_MaterialList(Material_List);
                                                add_screws_fab_striker += pnl_curCtrl.Panel_AdjStrikerQty; //Adj Striker
                                            }


                                            if (div_nxtCtrl.Div_ChkDM == true && div_nxtCtrl.Div_DMPanel == pnl_curCtrl)
                                            {
                                                div_nxtCtrl.Insert_DummyMullion_MaterialList(Material_List);
                                                div_nxtCtrl.Insert_Endcap4DM_MaterialList(Material_List);

                                                int expHt_screws = div_nxtCtrl.Add_ExplosionLength_screws4fab();
                                                total_screws_fabrication += expHt_screws;

                                                if (div_nxtCtrl.Div_DMArtNo == DummyMullion_ArticleNo._385P)
                                                {
                                                    if (div_nxtCtrl.Div_DMStrikerArtNo != null)
                                                    {
                                                        div_nxtCtrl.Insert_DMStriker_MaterialList(Material_List);
                                                    }
                                                }

                                                int dmStriker_screws = div_nxtCtrl.Add_DMStriker_screws4fab();
                                                add_screws_fab_striker += dmStriker_screws;

                                                int endcap_screws = div_nxtCtrl.Add_EndCapDM_screws4fab();
                                                add_screws_fab_endcap += endcap_screws;

                                                if ((frame.Frame_ArtNo == FrameProfile_ArticleNo._7507 && pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395) == false)
                                                {
                                                    div_nxtCtrl.Insert_FixedCam_MaterialList(Material_List);
                                                    add_screws_fab_fxdcam += (2 * 2); //2 * 2pcs,FixedCam

                                                    div_nxtCtrl.Insert_SnapNKeep_MaterialList(Material_List);

                                                    int snapNkeep_screws = div_nxtCtrl.Add_SnapNKeep_screws4fab();
                                                    add_screws_fab_snapInKeep += snapNkeep_screws;

                                                    if (div_nxtCtrl.Div_DMArtNo == DummyMullion_ArticleNo._7533)
                                                    {
                                                        div_nxtCtrl.Insert_AlumSpacer_MaterialList(Material_List);

                                                        int alumSpacer_screws = div_nxtCtrl.Add_AlumSpacer_screws4fab();
                                                        add_screws_fab_alum += alumSpacer_screws;
                                                    }
                                                }

                                                if (div_nxtCtrl.Div_DMPanel != null &&
                                                   (div_nxtCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395 ||
                                                     div_nxtCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._374))
                                                {
                                                    div_nxtCtrl.Insert_LeverEspag_MaterialList(Material_List);

                                                    int leverEspag_screws = div_nxtCtrl.Add_LeverEspag_screws4fab();
                                                    add_screws_fab_espag += leverEspag_screws;
                                                }

                                                if (div_nxtCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395 ||
                                                    div_nxtCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                                    div_nxtCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                                                {
                                                    div_nxtCtrl.Insert_ShootboltStriker_MaterialList(Material_List);
                                                    add_screws_fab_shootbolt += 2; //Shootbolt striker

                                                    if (div_nxtCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                                        div_nxtCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                                                    {
                                                        div_nxtCtrl.Insert_ShootboltReverse_MaterialList(Material_List);
                                                        add_screws_fab_shootbolt += 2; //(qty * 2),shootboltReverse
                                                    }

                                                    div_nxtCtrl.Insert_ShootboltNonReverse_MaterialList(Material_List);
                                                    add_screws_fab_shootbolt += (3 * 2); //(qty * 2),ShootboltNonReverse
                                                }
                                            }
                                            else if (div_nxtCtrl.Div_ChkDM == false && !mullion_already_added)
                                            {
                                                mullion_already_added = true;
                                                div_nxtCtrl.Insert_DivProfile_DivReinf_Info_MaterialList(Material_List);

                                                div_nxtCtrl.Insert_MechJoint_MaterialList(Material_List);

                                                int explosionLength_screws = div_nxtCtrl.Add_ExplosionLength_screws4fab();
                                                total_screws_fabrication += explosionLength_screws;

                                                int mj_screws = div_nxtCtrl.Add_MechJoint_screws4fab();
                                                add_screws_fab_mech_joint += mj_screws;

                                                if (!screws_for_inst_where.Contains("Mullion"))
                                                {
                                                    screws_for_inst_where += ", Mullion";
                                                }
                                            }

                                            div_nxtCtrl.Insert_CladdingProfile_MaterialList(Material_List);

                                            int total_cladd = div_nxtCtrl.Add_TotalCladdingSize_Screws4Cladding();
                                            total_cladding_size += total_cladd;

                                            if (div_nxtCtrl.Div_claddingBracketVisibility == true)
                                            {
                                                if (div_nxtCtrl.Div_CladdingBracketForConcreteQTY > 0)
                                                {
                                                    div_nxtCtrl.Insert_CladdingBracket4Concrete_MaterialList(Material_List);

                                                    int claddingBracketForConcrete_screws = div_nxtCtrl.Add_CladdingBracket4Concrete_screws4fab();
                                                    add_screws_fab_cladingBracket += claddingBracketForConcrete_screws;

                                                    int claddingBracketForConcrete_expBolt = div_nxtCtrl.Add_CladdBracket4Concrete_expbolts();
                                                    exp_bolt += claddingBracketForConcrete_expBolt;
                                                }

                                                if (div_nxtCtrl.Div_CladdingBracketForUPVCQTY > 0)
                                                {
                                                    div_nxtCtrl.Insert_CladdingBracket4UPVC_MaterialList(Material_List);

                                                    int claddingBracketForUPVC_screws = div_nxtCtrl.Add_CladdingBracket4UPVC_screws4fab();
                                                    add_screws_fab_cladingBracket += claddingBracketForUPVC_screws;

                                                    int claddingBracketForUPVC_expBolt = div_nxtCtrl.Add_CladdBracket4UPVC_expbolts();
                                                    exp_bolt += claddingBracketForUPVC_expBolt;
                                                }
                                            }
                                        }
                                    }

                                    if (div_prevCtrl != null)
                                    {
                                        if (mpnl.MPanel_Type == "Mullion")
                                        {
                                            div_prevCtrl.SetExplosionValues_Div();

                                            if (div_prevCtrl.Div_ChkDM == false && pnl_curCtrl.Panel_AdjStrikerArtNo != null && pnl_curCtrl.Panel_AdjStrikerQty > 0)
                                            {
                                                pnl_curCtrl.Insert_AdjustableStriker_MaterialList(Material_List);

                                                add_screws_fab_striker += pnl_curCtrl.Panel_AdjStrikerQty;
                                            }

                                            if (div_prevCtrl.Div_ChkDM == true && div_prevCtrl.Div_DMPanel == pnl_curCtrl)
                                            {
                                                div_prevCtrl.Insert_DummyMullion_MaterialList(Material_List);

                                                div_prevCtrl.Insert_Endcap4DM_MaterialList(Material_List);

                                                int expLength_screws = div_prevCtrl.Add_ExplosionLength_screws4fab();
                                                total_screws_fabrication += expLength_screws;

                                                div_prevCtrl.Insert_DMStriker_MaterialList(Material_List);

                                                int DMStriker_screws = div_prevCtrl.Add_DMStriker_screws4fab();
                                                add_screws_fab_striker += DMStriker_screws;

                                                int endCapDM_screws = div_prevCtrl.Add_EndCapDM_screws4fab();
                                                add_screws_fab_endcap += endCapDM_screws;

                                                if ((frame.Frame_ArtNo == FrameProfile_ArticleNo._7507 && pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395) == false)
                                                {
                                                    div_prevCtrl.Insert_FixedCam_MaterialList(Material_List);

                                                    add_screws_fab_fxdcam += (2 * 2); //2 * 2pcs,FixedCam

                                                    div_prevCtrl.Insert_SnapNKeep_MaterialList(Material_List);

                                                    int snapNkeep_screws = div_prevCtrl.Add_SnapNKeep_screws4fab();
                                                    add_screws_fab_snapInKeep += snapNkeep_screws;

                                                    if (div_prevCtrl.Div_DMArtNo == DummyMullion_ArticleNo._7533)
                                                    {
                                                        div_prevCtrl.Insert_AlumSpacer_MaterialList(Material_List);

                                                        int alumSpacer_screws = div_prevCtrl.Add_AlumSpacer_screws4fab();
                                                        add_screws_fab_alum += alumSpacer_screws;
                                                    }
                                                }

                                                if (div_prevCtrl.Div_DMPanel != null &&
                                                    (div_prevCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395 ||
                                                     div_prevCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._374))
                                                {
                                                    div_prevCtrl.Insert_LeverEspag_MaterialList(Material_List);

                                                    int leverEspag_screws = div_prevCtrl.Add_LeverEspag_screws4fab();
                                                    add_screws_fab_espag += leverEspag_screws;
                                                }

                                                if (div_prevCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395 ||
                                                    div_prevCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                                    div_prevCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                                                {
                                                    div_prevCtrl.Insert_ShootboltStriker_MaterialList(Material_List);
                                                    add_screws_fab_shootbolt += 2; //Shootbolt striker

                                                    if (div_prevCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                                        div_prevCtrl.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                                                    {
                                                        div_prevCtrl.Insert_ShootboltReverse_MaterialList(Material_List);
                                                        add_screws_fab_shootbolt += 2; //(qty * 2),shootboltReverse
                                                    }

                                                    div_prevCtrl.Insert_ShootboltNonReverse_MaterialList(Material_List);
                                                    add_screws_fab_shootbolt += (3 * 2); //(qty * 2),ShootboltNonReverse
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
                                        int sashPerimeter_screws = pnl_curCtrl.Add_SashPerimeter_screws4fab();
                                        total_screws_fabrication += sashPerimeter_screws;

                                        pnl_curCtrl.Insert_SashInfo_MaterialList(Material_List);

                                        if (pnl_curCtrl.Panel_Type.Contains("Fixed") == false)
                                        {
                                            pnl_curCtrl.Insert_CoverProfileInfo_MaterialList(Material_List);
                                        }

                                        if (perFrame == true)
                                        {

                                            if (pnl_curCtrl.Panel_MotorizedOptionVisibility == true)
                                            {
                                                if (pnl_curCtrl.Panel_Type == "Awning Panel")
                                                {
                                                    pnl_curCtrl.Insert_MotorizedInfo_MaterialList(Material_List);

                                                    int hinge_screws = pnl_curCtrl.Add_Hinges_screws4fab();
                                                    add_screws_fab_hinges += hinge_screws;

                                                    int motor_screws = pnl_curCtrl.Add_MotorizedMech_screws4Inst();
                                                    total_screws_installation += motor_screws;

                                                    total_screws_installation += (4 * pnl_curCtrl.Panel_MotorizedMechSetQty * 2);
                                                }
                                            }
                                            perFrame = false;
                                        }

                                        if (pnl_curCtrl.Panel_MotorizedOptionVisibility == false)
                                        {
                                            if (pnl_curCtrl.Panel_Type.Contains("Awning"))
                                            {
                                                pnl_curCtrl.Insert_FrictionStay_MaterialList(Material_List);

                                                if (pnl_curCtrl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm26)
                                                {
                                                    pnl_curCtrl.Insert_SnapNKeep_MaterialList(Material_List);

                                                    pnl_curCtrl.Insert_FixedCam_MaterialList(Material_List);
                                                }

                                                int fsAW_screws = pnl_curCtrl.Add_FGAwning_screws4fab();
                                                add_screws_fab_fs_or_rs += fsAW_screws;

                                                pnl_curCtrl.Insert_PlasticWedge_MaterialList(Material_List);

                                            }
                                            else if (pnl_curCtrl.Panel_Type.Contains("Casement"))
                                            {
                                                if (pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                                {
                                                    if (pnl_curCtrl.Panel_HingeOptions == HingeOption._FrictionStay)
                                                    {
                                                        pnl_curCtrl.Insert_FrictionStay_MaterialList(Material_List);

                                                        int FSCasement_screws = pnl_curCtrl.Add_FSCasement_screws4fab();
                                                        add_screws_fab_fs_or_rs += FSCasement_screws;


                                                    }
                                                    else if (pnl_curCtrl.Panel_HingeOptions == HingeOption._2DHinge)
                                                    {
                                                        pnl_curCtrl.Insert_2dHinge_MaterialList(Material_List);

                                                        add_screws_fab_hinges += (3 * pnl_curCtrl.Panel_2DHingeQty_nonMotorized);
                                                    }
                                                    pnl_curCtrl.Insert_PlasticWedge_MaterialList(Material_List);

                                                }
                                                else if (frame.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                                                {
                                                    if (pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                                    {
                                                        pnl_curCtrl.Insert_3dHinge_MaterialList(Material_List);
                                                        add_screws_fab_hinges += (6 * pnl_curCtrl.Panel_3dHingeQty);//3D Hinge

                                                        pnl_curCtrl.Insert_RestrictorStay_MaterialList(Material_List);
                                                        add_screws_fab_fs_or_rs += (6 * pnl_curCtrl.Panel_RestrictorStayQty);//RestrictorStay

                                                        if (frame.Frame_Height > 2499)
                                                        {
                                                            pnl_curCtrl.Insert_WeldableCornerJoint_MaterialList(Material_List);

                                                            add_screws_fab_weldableCJ += (8 * 2); //WeldableCornerJoint
                                                        }
                                                    }
                                                    else if (pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                                    {
                                                        pnl_curCtrl.Insert_NTCenterHinge_MaterialList(Material_List);
                                                        add_screws_fab_hinges += (2 * 1); //NT Center Hinge

                                                        pnl_curCtrl.Insert_StayBearingK_MaterialList(Material_List);
                                                        add_screws_fab_stayBearing += (4 * 2); //4 * qty//StayBearingK

                                                        pnl_curCtrl.Insert_StayBearingPin_MaterialList(Material_List);

                                                        string basecol = "";
                                                        if (item.WD_BaseColor == Base_Color._Ivory || item.WD_BaseColor == Base_Color._White)
                                                        {
                                                            basecol = "W/White";
                                                        }
                                                        else if (item.WD_BaseColor == Base_Color._DarkBrown)
                                                        {
                                                            basecol = "DB";
                                                        }

                                                        pnl_curCtrl.Insert_StayBearingCover_MaterialList(Material_List, basecol);

                                                        pnl_curCtrl.Insert_TopCornerHingeCover_MaterialList(Material_List, basecol);

                                                        pnl_curCtrl.Insert_TopCornerHinge_MaterialList(Material_List);

                                                        if (pnl_curCtrl.Panel_ChkText == "L")
                                                        {
                                                            add_screws_fab_hinges += (1 * 2); //qty * 2 //Top Corner Hinge, Left 

                                                        }
                                                        else if (pnl_curCtrl.Panel_ChkText == "R")
                                                        {
                                                            add_screws_fab_hinges += (1 * 2); //qty * 2 //Top Corner Hinge, Right
                                                        }

                                                        pnl_curCtrl.Insert_TopCornerHingeSpacer_MaterialList(Material_List);
                                                        add_screws_fab_hinges += (1 * 3); //qty * 3,TopCornerHingeSpacer

                                                        pnl_curCtrl.Insert_CornerHingeK_MaterialList(Material_List);
                                                        add_screws_fab_hinges += (1 * 2); //qty * 2,Corner Hinge

                                                        pnl_curCtrl.Insert_CornerPivotRestK_MaterialList(Material_List);
                                                        add_screws_fab_pivotRest += (1 * 4); //qty * 4,Corner Pivot Rest K

                                                        pnl_curCtrl.Insert_CornerHingeCoverK_MaterialList(Material_List, basecol);

                                                        pnl_curCtrl.Insert_CoverForCornerPivotRestVertical_MaterialList(Material_List, basecol);

                                                        pnl_curCtrl.Insert_CoverForCornerPivotRest_MaterialList(Material_List, basecol);
                                                        add_screws_fab_pivotRest += 1;
                                                    }
                                                }
                                            }

                                            if (pnl_curCtrl.Panel_HingeOptions == HingeOption._FrictionStay && pnl_curCtrl.Panel_MiddleCloserPairQty > 0)
                                            {
                                                pnl_curCtrl.Insert_MiddleCloser_MaterialList(Material_List);
                                                add_screws_fab_mc += (4 * pnl_curCtrl.Panel_MiddleCloserPairQty);
                                            }

                                            if (pnl_curCtrl.Panel_HandleType != Handle_Type._Rotary &&
                                                pnl_curCtrl.Panel_HandleType != Handle_Type._None)
                                            {
                                                pnl_curCtrl.Insert_Extension_MaterialList(Material_List);

                                                int extensions_screws = pnl_curCtrl.Add_Extension_screws4fab();
                                                add_screws_fab_ext += extensions_screws;

                                                if (pnl_curCtrl.Panel_CornerDriveArtNo != CornerDrive_ArticleNo._None &&
                                                    pnl_curCtrl.Panel_CornerDriveArtNo != null)
                                                {
                                                    pnl_curCtrl.Insert_CornerDrive_MaterialList(Material_List);
                                                    add_screws_fab_corDrive += (2 * 2); //2 * 2pcs,CornerDrive
                                                }
                                            }

                                            if (pnl_curCtrl.Panel_HandleType == Handle_Type._Rotoswing)
                                            {
                                                pnl_curCtrl.Insert_RotoswingHandle_MaterialList(Material_List);

                                                if (pnl_curCtrl.Panel_Type.Contains("Awning"))
                                                {
                                                    pnl_curCtrl.Insert_StrikerA_MaterialList(Material_List);

                                                    if (pnl_curCtrl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957 ||
                                                            pnl_curCtrl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957 ||
                                                            pnl_curCtrl.Panel_ExtensionRightArtNo == Extension_ArticleNo._639957 ||
                                                            pnl_curCtrl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                                                    {
                                                        pnl_curCtrl.Insert_StrikerC_MaterialList(Material_List);
                                                    }

                                                    int strikerAC_screws = pnl_curCtrl.Add_StrikerAC_screws4fab();
                                                    add_screws_fab_striker += strikerAC_screws;
                                                }
                                                else if (pnl_curCtrl.Panel_Type.Contains("Casement"))
                                                {
                                                    if (pnl_curCtrl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                                    {
                                                        pnl_curCtrl.Insert_StrikerC_MaterialList(Material_List);

                                                        if (pnl_curCtrl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                                        {
                                                            pnl_curCtrl.Insert_StrikerA_MaterialList(Material_List);
                                                        }

                                                        int strikerAC_screws = pnl_curCtrl.Add_StrikerAC_screws4fab();
                                                        add_screws_fab_striker += strikerAC_screws;
                                                    }
                                                }
                                            }
                                            else if (pnl_curCtrl.Panel_HandleType == Handle_Type._Rotary)
                                            {
                                                pnl_curCtrl.Insert_RotaryHandle_LockingKit_MaterialList(Material_List);
                                                add_screws_fab_handle += 9; //RotaryHandle_LockingKit
                                            }
                                            else if (pnl_curCtrl.Panel_HandleType == Handle_Type._Rio)
                                            {
                                                pnl_curCtrl.Insert_RioHandle_MaterialList(Material_List);

                                                pnl_curCtrl.Insert_ProfileKnobCylinder_MaterialList(Material_List);

                                                pnl_curCtrl.Insert_CylinderCover_MaterialList(Material_List);
                                            }
                                            else if (pnl_curCtrl.Panel_HandleType == Handle_Type._Rotoline)
                                            {
                                                pnl_curCtrl.Insert_RotolineHandle_MaterialList(Material_List);
                                            }
                                            else if (pnl_curCtrl.Panel_HandleType == Handle_Type._MVD)
                                            {
                                                pnl_curCtrl.Insert_MVDHandle_MaterialList(Material_List);

                                                pnl_curCtrl.Insert_ProfileKnobCylinder_MaterialList(Material_List);

                                                pnl_curCtrl.Insert_CylinderCover_MaterialList(Material_List);

                                                //string orient = "";
                                                //if (pnl_curCtrl.Panel_ChkText == "L")
                                                //{
                                                //    orient = "Left";
                                                //}
                                                //else if (pnl_curCtrl.Panel_ChkText == "R")
                                                //{
                                                //    orient = "Right";
                                                //}

                                                //Material_List.Rows.Add("Latch and deadbolt striker, " + orient + " " + pnl_curCtrl.Panel_LatchDeadboltStrikerArtNo.DisplayName,
                                                //                       1, "pc(s)",
                                                //                       "",
                                                //                       "Frame",
                                                //                       @"");
                                                //add_screws_fab_striker += 2;
                                            }

                                            if (pnl_curCtrl.Panel_HandleType != Handle_Type._Rotary)
                                            {
                                                if (pnl_curCtrl.Panel_EspagnoletteArtNo != Espagnolette_ArticleNo._None)
                                                {
                                                    pnl_curCtrl.Insert_Espagnolette_MaterialList(Material_List);
                                                }

                                                int espag_screws = pnl_curCtrl.Add_Espagnolette_screws4fab();
                                                add_screws_fab_espag += espag_screws;
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

                                    pnl_curCtrl.Insert_GlazingBead_MaterialList(Material_List, where);

                                    if ((pnl_curCtrl.Panel_Type.Contains("Awning") || pnl_curCtrl.Panel_Type.Contains("Casement")) &&
                                        pnl_curCtrl.Panel_GlassThickness == 6.0f &&
                                        pnl_curCtrl.Panel_SashPropertyVisibility == true)
                                    {
                                        pnl_curCtrl.Insert_GBSpacer_MaterialList(Material_List);
                                    }

                                    if (pnl_curCtrl.Panel_ChkGlazingAdaptor == true)
                                    {
                                        pnl_curCtrl.Insert_GlazingAdapator_MaterialList(Material_List, where);
                                    }

                                    string glassFilm = "";
                                    if (pnl_curCtrl.Panel_GlassFilm != GlassFilm_Types._None)
                                    {
                                        glassFilm = pnl_curCtrl.Panel_GlassFilm.DisplayName;
                                    }

                                    pnl_curCtrl.Insert_GlassInfo_MaterialList(Material_List, where, glassFilm);

                                    if (pnl_curCtrl.Panel_GeorgianBarArtNo != GeorgianBar_ArticleNo._None)
                                    {
                                        pnl_curCtrl.Insert_GeorgianBar_MaterialList(Material_List);
                                    }

                                    if (pnl_curCtrl.Panel_Type == "Fixed Panel" && pnl_curCtrl.Panel_SashPropertyVisibility == false)
                                    {
                                        glazing_spacer++;
                                    }

                                    total_glassWidth += (pnl_curCtrl.Panel_GlassWidth * 2);
                                    total_glassHeight += (pnl_curCtrl.Panel_GlassHeight * 2);

                                }
                            }
                        }
                        else if (mpnl.MPanel_DividerEnabled == false)
                        {
                            List<IPanelModel> panels = mpnl.MPanelLst_Panel;
                            List<IDividerModel> divs = mpnl.MPanelLst_Divider;
                            List<IMultiPanelModel> mpanels = mpnl.MPanelLst_MultiPanel;

                            //IMultiPanelModel mpnl_Parent_lvl3 = null;
                            string mpanel_placement = "",
                                   mpanelParentlvl2_placement = "",
                                   mpnl_Parent_lvl3_mpanelType = "";

                            int obj_count = mpnl.GetVisibleObjects().Count();
                            for (int i = 0; i < obj_count; i++)
                            {

                                mpanel_placement = mpnl.MPanel_Placement;
                                Control cur_ctrl = mpnl.GetVisibleObjects().ToList()[i];
                                IPanelModel pnl_curCtrl = panels.Find(pnl => pnl.Panel_Name == cur_ctrl.Name);
                                IMultiPanelModel mpnl_curCtrl = mpanels.Find(mpanel => mpanel.MPanel_Name == cur_ctrl.Name);

                                //Control nxt_ctrl, prevCtrl;

                                IDividerModel div_nxtCtrl = null,
                                        div_prevCtrl = null;

                                Divider_ArticleNo divArtNo_nxtCtrl = Divider_ArticleNo._None,
                                                    divArtNo_prevCtrl = Divider_ArticleNo._None,
                                                    divArtNo_LeftOrTop = Divider_ArticleNo._None,
                                                    divArtNo_RightOrBot = Divider_ArticleNo._None,
                                                    divArtNo_LeftOrTop_lvl3 = Divider_ArticleNo._None,
                                                    divArtNo_RightOrBot_lvl3 = Divider_ArticleNo._None;
                                bool divNxt_ifDM = false,
                                     divPrev_ifDM = false;

                                mpanel_placement = mpnl.MPanel_Placement;

                                int OverLappingPanel_Qty = 0;
                                foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                                {
                                    if (pnl.Panel_Overlap_Sash == OverlapSash._Left ||
                                        pnl.Panel_Overlap_Sash == OverlapSash._Right)
                                    {
                                        OverLappingPanel_Qty += 1;
                                    } 
                                }
  
                                if (pnl_curCtrl != null)
                                {
                                    pnl_curCtrl.SetPanelExplosionValues_Panel(divArtNo_nxtCtrl,
                                                                              divArtNo_prevCtrl,
                                                                              DividerModel.DividerType.None,
                                                                              mpnl.MPanel_DividerEnabled,
                                                                              OverLappingPanel_Qty,
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
                                    mpnl_curCtrl.SetMPanelExplosionValues_Panel(divArtNo_nxtCtrl,
                                                                                divArtNo_prevCtrl,
                                                                                DividerModel.DividerType.None,
                                                                                divArtNo_LeftOrTop,
                                                                                divArtNo_RightOrBot,
                                                                                mpnl_Parent_lvl3_mpanelType,
                                                                                divArtNo_LeftOrTop_lvl3,
                                                                                divArtNo_RightOrBot_lvl3,
                                                                                mpnl_curCtrl.MPanel_Placement,
                                                                                mpanel_placement,
                                                                                mpanelParentlvl2_placement);
                                }

                                if (pnl_curCtrl != null)
                                {
                                    if (item.WD_profile == "PremiLine Profile" && pnl_curCtrl.Panel_Type.Contains("Fixed"))
                                    {
                                        pnl_curCtrl.Insert_CoverProfileForPremiInfo_MaterialList(Material_List);
                                    }

                                    if (pnl_curCtrl.Panel_SashPropertyVisibility == true)
                                    {
                                        int sashPerimeter_screws = pnl_curCtrl.Add_SashPerimeter_screws4fab();
                                        total_screws_fabrication += sashPerimeter_screws;

                                        if (pnl_curCtrl.Panel_Type.Contains("Fixed") == false &&
                                            pnl_curCtrl.Panel_Type.Contains("Sliding") == false)
                                        {
                                            pnl_curCtrl.Insert_CoverProfileInfo_MaterialList(Material_List); // casement & awning
                                        }


                                        if (pnl_curCtrl.Panel_Type.Contains("Fixed") && pnl_curCtrl.Panel_ChkText == "dSash")
                                        {
                                            pnl_curCtrl.Insert_SpacerFixedSash_MaterialList(Material_List);
                                        }

                                        if (pnl_curCtrl.Panel_ChkText != "dSash")
                                        {
                                            pnl_curCtrl.Insert_AntiLiftDevice_MaterialList(Material_List);
                                        }

                                        //if (pnl_curCtrl.Panel_Spacer != null || pnl_curCtrl.Panel_ChkText == "dSash")
                                        //{
                                        pnl_curCtrl.Insert_Spacer_MaterialList(Material_List);
                                        //}

                                        if (pnl_curCtrl.Panel_GlazingRebateBlockArtNo != null)
                                        {
                                            pnl_curCtrl.Insert_GlazingRebateBlock_MaterialList(Material_List);
                                        }

                                        if (pnl_curCtrl.Panel_Type.Contains("Sliding"))
                                        {
                                            if (pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040 ||
                                                pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                                            {
                                                if (frame.Frame_SlidingRailsQty == 3)
                                                {
                                                    slidingChck = true;
                                                    pnl_curCtrl.Insert_GuideTrackProfile_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_AluminumTrack_MaterialList(Material_List);

                                                    if (perFrame == true)
                                                    {
                                                      
                                                        pnl_curCtrl.Insert_WeatherBar_MaterialList(Material_List);
                                                        pnl_curCtrl.Insert_WeatherBarFastener_MaterialList(Material_List);
                                                        pnl_curCtrl.Insert_WaterSeepage_MaterialList(Material_List);
                                                        pnl_curCtrl.Insert_BrushSeal_MaterialList(Material_List);
                                                        perFrame = false;
                                                    }

                                                    pnl_curCtrl.Insert_Rollers_MaterialList(Material_List);

                                                    if (pnl_curCtrl.Panel_EspagnoletteArtNo != Espagnolette_ArticleNo._None)
                                                    {
                                                        pnl_curCtrl.Insert_StrikerForSliding_MaterialList(Material_List);
                                                    }

                                                    if (pnl_curCtrl.Panel_ChkText != "dSash")
                                                    {
                                                        pnl_curCtrl.Insert_SealingBlock_MaterialList(Material_List);

                                                    }

                                                    if (pnl_curCtrl.Panel_Overlap_Sash == OverlapSash._Left ||
                                                        pnl_curCtrl.Panel_Overlap_Sash == OverlapSash._Right)
                                                    {
                                                        //if (OverLappingPanel_Qty != 0)
                                                        //{
                                                        pnl_curCtrl.Insert_Interlock_MaterialList(Material_List);
                                                        pnl_curCtrl.Insert_ExternsionForInterlock_MaterialList(Material_List);
                                                        // } 
                                                    }
                                                }
                                                else
                                                {
                                                    pnl_curCtrl.Insert_GuideTrackProfile_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_AluminumTrack_MaterialList(Material_List);

                                                    if (perFrame == true)
                                                    {
                                                        pnl_curCtrl.Insert_WeatherBar_MaterialList(Material_List);
                                                        pnl_curCtrl.Insert_WeatherBarFastener_MaterialList(Material_List);
                                                        pnl_curCtrl.Insert_WaterSeepage_MaterialList(Material_List);
                                                        pnl_curCtrl.Insert_BrushSeal_MaterialList(Material_List);

                                                        perFrame = false;
                                                    }


                                                    pnl_curCtrl.Insert_Rollers_MaterialList(Material_List);

                                                    if (pnl_curCtrl.Panel_EspagnoletteArtNo != Espagnolette_ArticleNo._None)
                                                    {
                                                        pnl_curCtrl.Insert_StrikerForSliding_MaterialList(Material_List);
                                                    }

                                                    if (pnl_curCtrl.Panel_ChkText != "dSash")
                                                    {
                                                        pnl_curCtrl.Insert_SealingBlock_MaterialList(Material_List);

                                                    }

                                                    if (pnl_curCtrl.Panel_Overlap_Sash == OverlapSash._Left ||
                                                        pnl_curCtrl.Panel_Overlap_Sash == OverlapSash._Right)
                                                    {
                                                        //if (OverLappingPanel_Qty != 0)
                                                        //{
                                                        pnl_curCtrl.Insert_Interlock_MaterialList(Material_List);
                                                        pnl_curCtrl.Insert_ExternsionForInterlock_MaterialList(Material_List);
                                                        // } 
                                                    }
                                                }


                                            }

                                        }


                                        pnl_curCtrl.Insert_SashInfo_MaterialList(Material_List);

                                        if (pnl_curCtrl.Panel_MotorizedOptionVisibility == false)
                                        {


                                            if (pnl_curCtrl.Panel_HingeOptions == HingeOption._FrictionStay && pnl_curCtrl.Panel_MiddleCloserPairQty > 0)
                                            {
                                                pnl_curCtrl.Insert_MiddleCloser_MaterialList(Material_List);
                                                add_screws_fab_mc += (4 * pnl_curCtrl.Panel_MiddleCloserPairQty);
                                            }

                                            if (pnl_curCtrl.Panel_HandleType != Handle_Type._Rotary &&
                                                pnl_curCtrl.Panel_HandleType != Handle_Type._None)
                                            {
                                                pnl_curCtrl.Insert_Extension_MaterialList(Material_List);

                                                int extensions_screws = pnl_curCtrl.Add_Extension_screws4fab();
                                                add_screws_fab_ext += extensions_screws;

                                                if (pnl_curCtrl.Panel_CornerDriveArtNo != CornerDrive_ArticleNo._None &&
                                                    pnl_curCtrl.Panel_CornerDriveArtNo != null)
                                                {
                                                    pnl_curCtrl.Insert_CornerDrive_MaterialList(Material_List);
                                                    add_screws_fab_corDrive += (2 * 2); //2 * 2pcs,CornerDrive
                                                }
                                            }

                                            if (pnl_curCtrl.Panel_HandleType == Handle_Type._Rotoswing)
                                            {
                                                pnl_curCtrl.Insert_RotoswingHandle_MaterialList(Material_List);

                                                if (pnl_curCtrl.Panel_Type.Contains("Casement"))
                                                {
                                                    if (pnl_curCtrl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                                    {
                                                        pnl_curCtrl.Insert_StrikerC_MaterialList(Material_List);

                                                        if (pnl_curCtrl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                                        {
                                                            pnl_curCtrl.Insert_StrikerA_MaterialList(Material_List);
                                                        }

                                                        int strikerAC_screws = pnl_curCtrl.Add_StrikerAC_screws4fab();
                                                        add_screws_fab_striker += strikerAC_screws;
                                                    }
                                                }
                                            }
                                            else if (pnl_curCtrl.Panel_HandleType == Handle_Type._Rotary)
                                            {
                                                pnl_curCtrl.Insert_RotaryHandle_LockingKit_MaterialList(Material_List);
                                                add_screws_fab_handle += 9; //RotaryHandle_LockingKit
                                            }
                                            else if (pnl_curCtrl.Panel_HandleType == Handle_Type._Rio)
                                            {
                                                pnl_curCtrl.Insert_RioHandle_MaterialList(Material_List);

                                                pnl_curCtrl.Insert_ProfileKnobCylinder_MaterialList(Material_List);

                                                pnl_curCtrl.Insert_CylinderCover_MaterialList(Material_List);
                                            }
                                            else if (pnl_curCtrl.Panel_HandleType == Handle_Type._Rotoline)
                                            {
                                                pnl_curCtrl.Insert_RotolineHandle_MaterialList(Material_List);
                                            }
                                            else if (pnl_curCtrl.Panel_HandleType == Handle_Type._MVD)
                                            {
                                                pnl_curCtrl.Insert_MVDHandle_MaterialList(Material_List);

                                                pnl_curCtrl.Insert_ProfileKnobCylinder_MaterialList(Material_List);

                                                pnl_curCtrl.Insert_CylinderCover_MaterialList(Material_List);

                                            }
                                            else if (pnl_curCtrl.Panel_HandleType == Handle_Type._D)
                                            {
                                                pnl_curCtrl.Insert_DHandle_MaterialList(Material_List);

                                                pnl_curCtrl.Insert_ScrewSetForDhandlesVariant_MaterialList(Material_List);
                                            }
                                            else if (pnl_curCtrl.Panel_HandleType == Handle_Type._D_IO_Locking)
                                            {
                                                pnl_curCtrl.Insert_DHandleIOLocking_MaterialList(Material_List);

                                                pnl_curCtrl.Insert_ScrewSetForDhandlesVariant_MaterialList(Material_List);
                                            }
                                            else if (pnl_curCtrl.Panel_HandleType == Handle_Type._DummyD)
                                            {
                                                pnl_curCtrl.Insert_DummyDHandle_MaterialList(Material_List);

                                                pnl_curCtrl.Insert_ScrewSetForDhandlesVariant_MaterialList(Material_List);
                                            }
                                            else if (pnl_curCtrl.Panel_HandleType == Handle_Type._PopUp)
                                            {
                                                pnl_curCtrl.Insert_PopUpHandle_MaterialList(Material_List);

                                                pnl_curCtrl.Insert_ScrewSetForDhandlesVariant_MaterialList(Material_List);
                                            }
                                            else if (pnl_curCtrl.Panel_HandleType == Handle_Type._RotoswingForSliding)
                                            {
                                                pnl_curCtrl.Insert_RotoswingForSlidingHandle_MaterialList(Material_List);
                                            }

                                            if (pnl_curCtrl.Panel_HandleType != Handle_Type._Rotary)
                                            {
                                                if (pnl_curCtrl.Panel_EspagnoletteArtNo != Espagnolette_ArticleNo._None)
                                                {
                                                    pnl_curCtrl.Insert_Espagnolette_MaterialList(Material_List);
                                                }

                                                int espag_screws = pnl_curCtrl.Add_Espagnolette_screws4fab();
                                                add_screws_fab_espag += espag_screws;
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

                                pnl_curCtrl.Insert_GlazingBead_MaterialList(Material_List, where);

                                if ((pnl_curCtrl.Panel_Type.Contains("Awning") || pnl_curCtrl.Panel_Type.Contains("Casement")) &&
                                    pnl_curCtrl.Panel_GlassThickness == 6.0f &&
                                    pnl_curCtrl.Panel_SashPropertyVisibility == true)
                                {
                                    pnl_curCtrl.Insert_GBSpacer_MaterialList(Material_List);
                                }

                                if (pnl_curCtrl.Panel_ChkGlazingAdaptor == true)
                                {
                                    pnl_curCtrl.Insert_GlazingAdapator_MaterialList(Material_List, where);
                                }

                                string glassFilm = "";
                                if (pnl_curCtrl.Panel_GlassFilm != GlassFilm_Types._None)
                                {
                                    glassFilm = pnl_curCtrl.Panel_GlassFilm.DisplayName;
                                }

                                pnl_curCtrl.Insert_GlassInfo_MaterialList(Material_List, where, glassFilm);

                                if (pnl_curCtrl.Panel_GeorgianBarArtNo != GeorgianBar_ArticleNo._None)
                                {
                                    pnl_curCtrl.Insert_GeorgianBar_MaterialList(Material_List);
                                }

                                if (pnl_curCtrl.Panel_Type == "Fixed Panel" && pnl_curCtrl.Panel_SashPropertyVisibility == false)
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
                        total_screws_fabrication += pnl.Add_SashPerimeter_screws4fab();
                        pnl.Insert_SashInfo_MaterialList(Material_List);

                        if (pnl.Panel_Type.Contains("Fixed") == false)
                        {
                            pnl.Insert_CoverProfileInfo_MaterialList(Material_List);
                        }

                        if (pnl.Panel_Type.Contains("Fixed") && pnl.Panel_ChkText == "dSash")
                        {
                            pnl.Insert_SpacerFixedSash_MaterialList(Material_List);
                        }

                        if (pnl.Panel_GlazingRebateBlockArtNo != null)
                        {
                            pnl.Insert_GlazingRebateBlock_MaterialList(Material_List);
                        }

                        if (pnl.Panel_Spacer != null || pnl.Panel_ChkText == "dSash")
                        {
                            pnl.Insert_Spacer_MaterialList(Material_List);
                        }

                        if (pnl.Panel_MotorizedOptionVisibility == true)
                        {
                            pnl.Insert_MotorizedInfo_MaterialList(Material_List);

                            int hinge_screws = pnl.Add_Hinges_screws4fab();
                            add_screws_fab_hinges += hinge_screws;

                            int motor_screws = pnl.Add_MotorizedMech_screws4Inst();
                            total_screws_installation += motor_screws;

                            total_screws_installation += (4 * pnl.Panel_MotorizedMechSetQty * 2);
                        }
                        else if (pnl.Panel_MotorizedOptionVisibility == false)
                        {
                            if (pnl.Panel_Type.Contains("Awning"))
                            {
                                pnl.Insert_FrictionStay_MaterialList(Material_List);

                                if (pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm26)
                                {
                                    pnl.Insert_SnapNKeep_MaterialList(Material_List);

                                    pnl.Insert_FixedCam_MaterialList(Material_List);
                                }

                                int fsAw_screws = pnl.Add_FGAwning_screws4fab();
                                add_screws_fab_fs_or_rs += fsAw_screws;

                                pnl.Insert_PlasticWedge_MaterialList(Material_List);
                            }
                            else if (pnl.Panel_Type.Contains("Casement"))
                            {
                                if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                {
                                    if (pnl.Panel_HingeOptions == HingeOption._FrictionStay)
                                    {
                                        pnl.Insert_FrictionStay_MaterialList(Material_List);

                                        int fs_screws = pnl.Add_FSCasement_screws4fab();
                                        add_screws_fab_fs_or_rs += fs_screws;
                                    }
                                    else if (pnl.Panel_HingeOptions == HingeOption._2DHinge)
                                    {
                                        pnl.Insert_2dHinge_MaterialList(Material_List);

                                        add_screws_fab_hinges += (3 * pnl.Panel_2DHingeQty_nonMotorized);
                                    }

                                    pnl.Insert_PlasticWedge_MaterialList(Material_List);
                                }
                                else if (frame.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                                {
                                    if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                    {
                                        pnl.Insert_3dHinge_MaterialList(Material_List);

                                        add_screws_fab_hinges += (6 * pnl.Panel_3dHingeQty);

                                        pnl.Insert_RestrictorStay_MaterialList(Material_List);

                                        add_screws_fab_fs_or_rs += (6 * pnl.Panel_RestrictorStayQty);

                                    }
                                    else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                    {
                                        pnl.Insert_NTCenterHinge_MaterialList(Material_List);
                                        add_screws_fab_hinges += (2 * 1); //NT Center Hinge

                                        pnl.Insert_StayBearingK_MaterialList(Material_List);
                                        add_screws_fab_stayBearing += (4 * 2); //Stay Bearing K

                                        pnl.Insert_StayBearingPin_MaterialList(Material_List);

                                        string basecol = "";
                                        if (item.WD_BaseColor == Base_Color._Ivory || item.WD_BaseColor == Base_Color._White)
                                        {
                                            basecol = "W/Ivory";
                                        }
                                        else if (item.WD_BaseColor == Base_Color._DarkBrown)
                                        {
                                            basecol = "DB";
                                        }

                                        pnl.Insert_StayBearingCover_MaterialList(Material_List, basecol);

                                        pnl.Insert_TopCornerHingeCover_MaterialList(Material_List, basecol);

                                        pnl.Insert_TopCornerHinge_MaterialList(Material_List);

                                        if (pnl.Panel_ChkText == "L")
                                        {
                                            add_screws_fab_hinges += (1 * 2); //qty * 2 //Top Corner Hinge, Left 
                                        }
                                        else if (pnl.Panel_ChkText == "R")
                                        {
                                            add_screws_fab_hinges += (1 * 2); //qty * 2 //Top Corner Hinge, Right
                                        }

                                        pnl.Insert_TopCornerHingeSpacer_MaterialList(Material_List);
                                        add_screws_fab_hinges += (1 * 3); //qty * 3 //TopCornerHingeSpacer

                                        pnl.Insert_CornerHingeK_MaterialList(Material_List);
                                        add_screws_fab_hinges += (1 * 2); //qty * 2 //Corner Hinge, K

                                        pnl.Insert_CornerPivotRestK_MaterialList(Material_List);
                                        add_screws_fab_pivotRest += (1 * 4); //qty * 1 //CornerPivotRestK

                                        pnl.Insert_CornerHingeCoverK_MaterialList(Material_List, basecol);

                                        pnl.Insert_CoverForCornerPivotRestVertical_MaterialList(Material_List, basecol);
                                        add_screws_fab_pivotRest += 1; //Cover for corner pivot rest, vertical

                                        pnl.Insert_CoverForCornerPivotRest_MaterialList(Material_List, basecol);

                                    }

                                    pnl.Insert_AdjustableStriker_MaterialList(Material_List);
                                    add_screws_fab_striker += (1 * pnl.Panel_AdjStrikerQty); //Adjustable Striker

                                    if (frame.Frame_Height > 2499)
                                    {
                                        pnl.Insert_WeldableCornerJoint_MaterialList(Material_List);

                                        add_screws_fab_weldableCJ += (8 * 2); //WeldableCornerJoint
                                    }

                                    if (frame.Frame_Type == FrameModel.Frame_Padding.Door)
                                    {
                                        pnl.Insert_SnapNKeep_MaterialList(Material_List);

                                        pnl.Insert_FixedCam_MaterialList(Material_List);


                                        int FixedCamAndSnapInKeepQty = (frame.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                                                         frame.Frame_BotFrameArtNo == BottomFrameTypes._None) ? 1 : 2;
                                        add_screws_fab_snapInKeep += FixedCamAndSnapInKeepQty * 2;
                                        add_screws_fab_fxdcam += FixedCamAndSnapInKeepQty * 2;
                                    }
                                }
                            }
                            if (pnl.Panel_Type.Contains("Sliding"))
                            {
                                if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040 ||
                                    pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                                {
                                    pnl.Insert_GuideTrackProfile_MaterialList(Material_List);
                                    pnl.Insert_AluminumTrack_MaterialList(Material_List);

                                    if (perFrame == true)
                                    {
                                        pnl.Insert_WeatherBar_MaterialList(Material_List);
                                        pnl.Insert_WeatherBarFastener_MaterialList(Material_List);
                                        pnl.Insert_WaterSeepage_MaterialList(Material_List);
                                        pnl.Insert_BrushSeal_MaterialList(Material_List);

                                        perFrame = false;
                                    }

                                    if (pnl.Panel_Overlap_Sash == OverlapSash._Left ||
                                        pnl.Panel_Overlap_Sash == OverlapSash._Right)
                                    {
                                        pnl.Insert_SealingBlock_MaterialList(Material_List);
                                        pnl.Insert_Interlock_MaterialList(Material_List);
                                        pnl.Insert_ExternsionForInterlock_MaterialList(Material_List);

                                    }

                                    pnl.Insert_Rollers_MaterialList(Material_List);
                                    pnl.Insert_AntiLiftDevice_MaterialList(Material_List);


                                    if (pnl.Panel_HandleType != Handle_Type._None)
                                    {
                                        pnl.Insert_StrikerForSliding_MaterialList(Material_List);
                                    }


                                    //int strikerSliding_screws = pnl_curCtrl.Add_StrikerAC_screws4fab();
                                    //add_screws_fab_striker += strikerAC_screws;
                                }

                            }

                            if (pnl.Panel_HingeOptions == HingeOption._FrictionStay && pnl.Panel_MiddleCloserPairQty > 0)
                            {
                                pnl.Insert_MiddleCloser_MaterialList(Material_List);
                                add_screws_fab_mc += (4 * pnl.Panel_MiddleCloserPairQty);//MC
                            }

                            if (pnl.Panel_HandleType != Handle_Type._Rotary &&
                                pnl.Panel_HandleType != Handle_Type._None)
                            {
                                pnl.Insert_Extension_MaterialList(Material_List);

                                int ext_screws = pnl.Add_Extension_screws4fab();
                                add_screws_fab_ext += ext_screws;

                                if (pnl.Panel_CornerDriveArtNo != CornerDrive_ArticleNo._None &&
                                    pnl.Panel_CornerDriveArtNo != null)
                                {
                                    pnl.Insert_CornerDrive_MaterialList(Material_List);
                                    add_screws_fab_corDrive += (2 * 2); //2 * 2pcs,CornerDrive
                                }
                            }

                            if (pnl.Panel_HandleType == Handle_Type._Rotoswing)
                            {
                                pnl.Insert_RotoswingHandle_MaterialList(Material_List);

                                if (pnl.Panel_Type.Contains("Awning"))
                                {
                                    pnl.Insert_StrikerA_MaterialList(Material_List);
                                }

                                if (pnl.Panel_Type.Contains("Casement") &&
                                    pnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                {
                                    pnl.Insert_StrikerA_MaterialList(Material_List);
                                }

                                if (pnl.Panel_Type.Contains("Awning"))
                                {
                                    if (pnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957 ||
                                        pnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957 ||
                                        pnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._639957 ||
                                        pnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                                    {
                                        pnl.Insert_StrikerC_MaterialList(Material_List);
                                    }
                                }
                                else if (pnl.Panel_Type.Contains("Casement") &&
                                         pnl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                {
                                    pnl.Insert_StrikerC_MaterialList(Material_List);
                                }

                                int striker_screws = pnl.Add_StrikerAC_screws4fab();

                                add_screws_fab_striker += striker_screws;
                            }
                            else if (pnl.Panel_HandleType == Handle_Type._Rotary)
                            {
                                pnl.Insert_RotaryHandle_LockingKit_MaterialList(Material_List);
                                add_screws_fab_handle += 9;
                            }
                            else if (pnl.Panel_HandleType == Handle_Type._Rio)
                            {
                                pnl.Insert_RioHandle_MaterialList(Material_List);
                                pnl.Insert_ProfileKnobCylinder_MaterialList(Material_List);
                                pnl.Insert_CylinderCover_MaterialList(Material_List);
                            }
                            else if (pnl.Panel_HandleType == Handle_Type._Rotoline)
                            {
                                pnl.Insert_RotolineHandle_MaterialList(Material_List);
                            }
                            else if (pnl.Panel_HandleType == Handle_Type._MVD)
                            {
                                pnl.Insert_MVDHandle_MaterialList(Material_List);
                                pnl.Insert_ProfileKnobCylinder_MaterialList(Material_List);
                                //pnl.Insert_WeldableCornerJoint_MaterialList(Material_List);

                                //add_screws_fab_weldableCJ += (8 * 2); //Weldable corner joint 

                                pnl.Insert_LatchAndDeadboltStriker_MaterialList(Material_List);
                                add_screws_fab_striker += 2;
                            }
                            else if (pnl.Panel_HandleType == Handle_Type._D)
                            {
                                pnl.Insert_DHandle_MaterialList(Material_List);

                                pnl.Insert_ScrewSetForDhandlesVariant_MaterialList(Material_List);
                            }
                            else if (pnl.Panel_HandleType == Handle_Type._D_IO_Locking)
                            {
                                pnl.Insert_DHandleIOLocking_MaterialList(Material_List);

                                pnl.Insert_ScrewSetForDhandlesVariant_MaterialList(Material_List);
                            }
                            else if (pnl.Panel_HandleType == Handle_Type._DummyD)
                            {
                                pnl.Insert_DummyDHandle_MaterialList(Material_List);

                                pnl.Insert_ScrewSetForDhandlesVariant_MaterialList(Material_List);
                            }
                            else if (pnl.Panel_HandleType == Handle_Type._PopUp)
                            {
                                pnl.Insert_PopUpHandle_MaterialList(Material_List);

                                pnl.Insert_ScrewSetForDhandlesVariant_MaterialList(Material_List);
                            }
                            else if (pnl.Panel_HandleType == Handle_Type._RotoswingForSliding)
                            {
                                pnl.Insert_RotoswingForSlidingHandle_MaterialList(Material_List);
                            }

                            if (pnl.Panel_HandleType != Handle_Type._Rotary)
                            {
                                pnl.Insert_Espagnolette_MaterialList(Material_List);

                                int espag_screws = pnl.Add_Espagnolette_screws4fab();
                                add_screws_fab_espag += espag_screws;
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

                    pnl.Insert_GlazingBead_MaterialList(Material_List, where);

                    if ((pnl.Panel_Type.Contains("Awning") || pnl.Panel_Type.Contains("Casement")) &&
                         pnl.Panel_GlassThickness == 6.0f &&
                         pnl.Panel_SashPropertyVisibility == true)
                    {
                        pnl.Insert_GBSpacer_MaterialList(Material_List);
                    }

                    if (pnl.Panel_ChkGlazingAdaptor == true)
                    {
                        pnl.Insert_GlazingAdapator_MaterialList(Material_List, where);
                    }

                    string glassFilm = "";
                    if (pnl.Panel_GlassFilm != GlassFilm_Types._None)
                    {
                        glassFilm = pnl.Panel_GlassFilm.DisplayName;
                    }

                    pnl.Insert_GlassInfo_MaterialList(Material_List, where, glassFilm);

                    if (pnl.Panel_GeorgianBarArtNo != GeorgianBar_ArticleNo._None)
                    {
                        pnl.Insert_GeorgianBar_MaterialList(Material_List);
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
                    #endregion
                }

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
            Screws_for_6050Frame = (int)Math.Ceiling((decimal)(totalFrames_width + totalFrames_height) / 300);
            Screws_for_6055Frame = (int)Math.Ceiling((decimal)(frame_width - 200) / 200 + 1);
            ACC_for_6050 = (int)Math.Ceiling((decimal)(frame_width - 200) / 400 + 1);

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
            if (slidingChck == true)
            {
                Material_List.Rows.Add("ACC FOR 6055 9D56",
                        ACC_for_6050, "pc(s)", "", screws_for_inst_where); // FRAME

                Material_List.Rows.Add("SCREW FOR 6055 S036",
                     Screws_for_6055Frame, "pc(s)", "", screws_for_inst_where); // FRAME
            }

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

        public void Select_Current_Windoor(IWindoorModel item)
        {
            foreach (IWindoorModel wndr_item in Lst_Windoor)
            {
                wndr_item.WD_Selected = false;
            }

            item.WD_Selected = true;
        }

        public QuotationModel(string quotation_ref_no,
                              List<IWindoorModel> lst_Windoor)
        {
            Quotation_ref_no = quotation_ref_no;
            Lst_Windoor = lst_Windoor;
        }
    }
}
