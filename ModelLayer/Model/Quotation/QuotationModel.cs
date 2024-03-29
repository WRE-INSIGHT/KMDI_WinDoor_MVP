﻿using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Frame.FrameModel;

namespace ModelLayer.Model.Quotation
{
    public class QuotationModel : IQuotationModel
    {
        public int Quotation_Id { get; set; }
        public List<decimal> lstTotalPrice { get; set; }
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
        public decimal PricingFactor { get; set; }
        public DateTime Date_Assigned { get; set; }
        public DateTime Date_Assigned_Mainpresenter { get; set; }

        public string Customer_Ref_Number { get; set; }
        public BillOfMaterialsFilter BOM_Filter { get; set; }
        public bool BOM_Status { get; set; }
        public string BOMandItemlistStatus { get; set; }
        public bool itemSelectStatus { get; set; }
        public bool ProvinceIntownOrOutoftown { get; set; }//Intown = true , OutOfTown = false
        public bool FactorChange { get; set; }



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
                frame_height = 0,
                MechJointConnectorQty = 0;

            string screws_for_inst_where = "";

            bool perFrame = false,
                 SlidingMotorizePerFrame = false,
                 TopHungPerFrame = false,
                 slidingChck = false;
            foreach (IFrameModel frame in item.lst_frame)
            {
                perFrame = true;
                SlidingMotorizePerFrame = true;
                TopHungPerFrame = true;
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
                    frame.Insert_frameInfoForPremi_MaterialList(Material_List); // 2nd frame
                }

                if (frame.Frame_ScreenOption == true)
                {
                    frame.Insert_frameInfoForScreen_MaterialList(Material_List); // add another frame
                }

                if (frame.Frame_Type == Frame_Padding.Door &&
                    frame.Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                    frame.Frame_If_SlidingTypeTopHung == false)
                {
                    frame.Insert_ConnectingProfile_MaterialList(Material_List);
                }

                if (frame.Frame_BotFrameArtNo != BottomFrameTypes._7507 &&
                    frame.Frame_BotFrameArtNo != BottomFrameTypes._6052 &&
                    frame.Frame_BotFrameArtNo != BottomFrameTypes._None)
                {
                    frame.Insert_BottomFrame_MaterialList(Material_List);
                }

                if (frame.Frame_If_InwardMotorizedCasement)
                {
                    frame.Insert_MilledFrameInfo_MaterialList(Material_List);
                    total_screws_fabrication += frame.Add_MilledFrameWidth_screws4fab();
                }

                if (frame.Frame_If_SlidingTypeTopHung == true &&
                    frame.Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                    frame.Frame_BotFrameArtNo == BottomFrameTypes._None &&
                    frame.Frame_CladdingQty != 0)
                {
                    frame.Insert_CladdingProfile_MaterialList(Material_List);
                }

                if (frame.Lst_MultiPanel.Count() >= 1 && frame.Lst_Panel.Count() == 0)
                {
                    #region MultiPanel Parent
                    foreach (IMultiPanelModel mpnl in frame.Lst_MultiPanel)
                    {
                        IDividerModel divTopOrLeft = null,
                                        divBotOrRight = null,
                                        divTopOrLeft_lvl3 = null,
                                        divBotOrRight_lvl3 = null;

                        IMultiPanelModel mpnl_Parent_lvl3 = null;
                        string mpanel_placement = "",
                               mpanelParentlvl2_placement = "",
                               mpnl_Parent_lvl3_mpanelType = "",
                               mpnl_Stacks = "";

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
                                    ////divTopOrLeft_lvl3 = mpnl_Parent_lvl3.MPanelLst_Divider.Find(div => div.Div_Name == div_prevctrl_lvl3.Name);
                                }
                            }
                        }
                        #region WithDivider 
                        if (mpnl.MPanel_DividerEnabled)
                        {
                            List<IPanelModel> panels = mpnl.MPanelLst_Panel;
                            List<IDividerModel> divs = mpnl.MPanelLst_Divider;
                            List<IMultiPanelModel> mpanels = mpnl.MPanelLst_MultiPanel;

                            foreach (IDividerModel divArtNo in divs)
                            {
                                if (divArtNo.Div_ArtNo == Divider_ArticleNo._6052)
                                {
                                    MechJointConnectorQty += 2;
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

                                bool mullion_already_added = false,
                                     boundedByBottomFrame = false;

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

                                        #region CheckBoundedByBottomFrame
                                        if (frame.Frame_BotFrameArtNo != BottomFrameTypes._7507 &&
                                            frame.Frame_BotFrameArtNo != BottomFrameTypes._6052)
                                        {
                                            if (mpnl.MPanel_Parent.Name.Contains("Multi")) //2nd level stack
                                            {
                                                if (mpnl_curCtrl != null)
                                                {
                                                    if (mpnl_curCtrl.MPanel_Placement == "Last")
                                                    {
                                                        boundedByBottomFrame = true;
                                                    }
                                                }
                                            }
                                            else if (mpnl.MPanel_Parent.Name.Contains("Frame"))
                                            {
                                                if (pnl_curCtrl != null)
                                                {
                                                    if (pnl_curCtrl.Panel_Placement == "Last") //lvl 1
                                                    {
                                                        boundedByBottomFrame = true;
                                                    }
                                                }
                                            }

                                            if (mpnl.MPanel_ParentModel != null)
                                            {
                                                if (mpnl.MPanel_ParentModel.MPanel_Parent.Name.Contains("Multi")) //3rd level stack
                                                {
                                                    if (mpnl_curCtrl != null)
                                                    {
                                                        if (mpnl_curCtrl.MPanel_Placement == "Last")
                                                        {
                                                            if (mpnl.MPanel_ParentModel.MPanel_Placement == "Last")
                                                            {
                                                                boundedByBottomFrame = true;
                                                            }
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                        #endregion
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

                                        #region CheckBoundedByBottomFrame
                                        if (frame.Frame_BotFrameArtNo != BottomFrameTypes._7507 &&
                                            frame.Frame_BotFrameArtNo != BottomFrameTypes._6052)
                                        {
                                            if (mpnl.MPanel_Parent.Name.Contains("Multi")) //2nd level sta ck
                                            {
                                                if (mpnl.MPanel_Placement == "Last")
                                                {
                                                    boundedByBottomFrame = true;
                                                }
                                            }
                                            else if (mpnl.MPanel_Parent.Name.Contains("Frame"))
                                            {
                                                if (pnl_curCtrl != null) //lvl 1
                                                {
                                                    boundedByBottomFrame = true;
                                                }
                                            }

                                            if (mpnl.MPanel_ParentModel != null)
                                            {
                                                if (mpnl.MPanel_ParentModel.MPanel_Parent.Name.Contains("Multi")) //3rd level stack
                                                {
                                                    if (mpnl_curCtrl != null)
                                                    {
                                                        if (mpnl_curCtrl.MPanel_Placement == "Last")
                                                        {
                                                            if (mpnl.MPanel_ParentModel.MPanel_Placement == "Last")
                                                            {
                                                                boundedByBottomFrame = true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
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
                                                                                  boundedByBottomFrame,
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
                                            #region CheckIfBoundedByBottomFrame 
                                            if (frame.Frame_BotFrameArtNo != BottomFrameTypes._7507 &&
                                            frame.Frame_BotFrameArtNo != BottomFrameTypes._6052)
                                            {
                                                if (mpnl.MPanel_Type == "Transom")
                                                {

                                                    if (divBotOrRight_lvl3 != null) //(mpnl.MPanel_ParentModel.MPanel_Parent.Name.Contains("Multi")) //3rd level stack
                                                    {
                                                        if (mpnl.MPanel_ParentModel.MPanel_Placement == "Last")
                                                        {
                                                            boundedByBottomFrame = true;
                                                        }
                                                    }
                                                    else if (mpnl.MPanel_Parent.Name.Contains("Multi")) //2nd level stack
                                                    {
                                                        if (pnl_curCtrl != null)
                                                        {
                                                            if (pnl_curCtrl.Panel_Placement == "Last")
                                                            {
                                                                boundedByBottomFrame = true;
                                                            }
                                                        }
                                                    }
                                                    else if (mpnl.MPanel_Parent.Name.Contains("Frame"))
                                                    {
                                                        if (pnl_curCtrl != null)
                                                        {
                                                            if (pnl_curCtrl.Panel_Placement == "Last") //lvl 1
                                                            {
                                                                boundedByBottomFrame = true;
                                                            }
                                                        }
                                                    }
                                                }


                                                if (mpnl.MPanel_Type == "Mullion")
                                                {
                                                    if (divBotOrRight_lvl3 != null) //(mpnl.MPanel_ParentModel.MPanel_Parent.Name.Contains("Multi")) //3rd level stack
                                                    {
                                                        if (mpnl.MPanel_Placement == "Last")
                                                        {
                                                            boundedByBottomFrame = true;
                                                        }
                                                    }
                                                    else if (mpnl.MPanel_Parent.Name.Contains("Multi")) //2nd level stack
                                                    {
                                                        if (mpnl.MPanel_Placement == "Last")
                                                        {
                                                            boundedByBottomFrame = true;
                                                        }
                                                    }
                                                    else if (mpnl.MPanel_Parent.Name.Contains("Frame"))
                                                    {
                                                        if (pnl_curCtrl != null) //lvl 1
                                                        {
                                                            boundedByBottomFrame = true;
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion
                                        }

                                        pnl_curCtrl.SetPanelExplosionValues_Panel(divArtNo_nxtCtrl,
                                                                                  divArtNo_prevCtrl,
                                                                                  div_prevCtrl.Div_Type,
                                                                                  mpnl.MPanel_DividerEnabled,
                                                                                  0,
                                                                                  boundedByBottomFrame,
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

                                //Console.WriteLine("bottom frame:" + boundedByBottomFrame);

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
                                                    if (frame.Frame_Type == FrameModel.Frame_Padding.Window)
                                                    {
                                                        div_nxtCtrl.Insert_FixedCam_MaterialList(Material_List);
                                                        add_screws_fab_fxdcam += (2 * 2); //2 * 2pcs,FixedCam

                                                        div_nxtCtrl.Insert_SnapNKeep_MaterialList(Material_List);

                                                        int snapNkeep_screws = div_nxtCtrl.Add_SnapNKeep_screws4fab();
                                                        add_screws_fab_snapInKeep += snapNkeep_screws;
                                                    }

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
                                                    if (frame.Frame_Type == FrameModel.Frame_Padding.Window)
                                                    {
                                                        div_prevCtrl.Insert_FixedCam_MaterialList(Material_List);

                                                        add_screws_fab_fxdcam += (2 * 2); //2 * 2pcs,FixedCam

                                                        div_prevCtrl.Insert_SnapNKeep_MaterialList(Material_List);

                                                        int snapNkeep_screws = div_prevCtrl.Add_SnapNKeep_screws4fab();
                                                        add_screws_fab_snapInKeep += snapNkeep_screws;
                                                    }

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
                                                    //pnl_curCtrl.MotorizeMechQty();
                                                    //int mechanism;
                                                    //if (item.lst_frame.Count == 0)
                                                    //{
                                                    //    mechanism = pnl_curCtrl.Panel_MotorizedMechQty;
                                                    //}
                                                    //else
                                                    //{
                                                    //    mechanism = pnl_curCtrl.Panel_MultiFrmMotorizedMechQty;
                                                    //}
                                                    pnl_curCtrl.Insert_MotorizedInfo_MaterialList(Material_List, pnl_curCtrl.MotorizeMechQty());

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


                                                    if (frame.Frame_Type == FrameModel.Frame_Padding.Door)
                                                    {
                                                        //if (frame.Frame_BotFrameArtNo == BottomFrameTypes._None)
                                                        //{
                                                        //    pnl.Insert_FillerProfileForNoBotFrameInfo_MaterialList(Material_List);
                                                        //    pnl.Insert_BrushSealForNoBotFrame_MaterialList(Material_List);
                                                        //}

                                                        pnl_curCtrl.Insert_SnapNKeep_MaterialList(Material_List);

                                                        pnl_curCtrl.Insert_FixedCam_MaterialList(Material_List);


                                                        int FixedCamAndSnapInKeepQty = (frame.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                                                                         frame.Frame_BotFrameArtNo == BottomFrameTypes._None) ? 1 : 2;
                                                        add_screws_fab_snapInKeep += FixedCamAndSnapInKeepQty * 2;
                                                        add_screws_fab_fxdcam += FixedCamAndSnapInKeepQty * 2;
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
                                    else if (pnl_curCtrl.Panel_Type.Contains("Louver"))
                                    {
                                        pnl_curCtrl.Insert_CoverProfileInfo_MaterialList(Material_List);
                                        pnl_curCtrl.Insert_PlantOnWeatherStripHead_MaterialList(Material_List);
                                        pnl_curCtrl.Insert_PlantOnWeatherStripSeal_MaterialList(Material_List);
                                        pnl_curCtrl.Insert_LouvreFrameWeatherStripHead_MaterialList(Material_List);
                                        pnl_curCtrl.Insert_LouvreFrameBottomWeatherStrip_MaterialList(Material_List);
                                        pnl_curCtrl.Insert_RubberSeal_MaterialList(Material_List);
                                        pnl_curCtrl.Insert_CasementSeal_MaterialList(Material_List);
                                        pnl_curCtrl.Insert_SealForHandle_MaterialList(Material_List);
                                        pnl_curCtrl.Insert_LouvreGallerySet_MaterialList(Material_List);
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
                                    if (!pnl_curCtrl.Panel_Type.Contains("Louver"))
                                    {
                                        pnl_curCtrl.Insert_GlazingBead_MaterialList(Material_List, where);
                                    }

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
                        #region NoDivider 
                        else if (mpnl.MPanel_DividerEnabled == false)
                        {
                            List<IPanelModel> panels = mpnl.MPanelLst_Panel;
                            List<IDividerModel> divs = mpnl.MPanelLst_Divider;
                            List<IMultiPanelModel> mpanels = mpnl.MPanelLst_MultiPanel;

                            int obj_count = mpnl.GetVisibleObjects().Count();
                            for (int i = 0; i < obj_count; i++)
                            {


                                Control cur_ctrl = mpnl.GetVisibleObjects().ToList()[i];
                                IPanelModel pnl_curCtrl = panels.Find(pnl => pnl.Panel_Name == cur_ctrl.Name);
                                IMultiPanelModel mpnl_curCtrl = mpanels.Find(mpanel => mpanel.MPanel_Name == cur_ctrl.Name);



                                IDividerModel div_nxtCtrl = null,
                                        div_prevCtrl = null;

                                Divider_ArticleNo divArtNo_nxtCtrl = Divider_ArticleNo._None,
                                                    divArtNo_prevCtrl = Divider_ArticleNo._None,
                                                    divArtNo_LeftOrTop = Divider_ArticleNo._None,
                                                    divArtNo_RightOrBot = Divider_ArticleNo._None,
                                                    divArtNo_LeftOrTop_lvl3 = Divider_ArticleNo._None,
                                                    divArtNo_RightOrBot_lvl3 = Divider_ArticleNo._None;
                                bool divNxt_ifDM = false,
                                     divPrev_ifDM = false,
                                     boundedByBottomFrame = false;

                                //mpanel_placement = mpnl.MPanel_Placement; 

                                #region ChckBoundedByBotFrame
                                if (frame.Frame_BotFrameArtNo != BottomFrameTypes._7507 &&
                                            frame.Frame_BotFrameArtNo != BottomFrameTypes._6052)
                                {
                                    if (mpnl.MPanel_Type == "Transom")
                                    {

                                        if (divTopOrLeft_lvl3 != null || divBotOrRight_lvl3 != null)//(mpnl.MPanel_ParentModel.MPanel_Parent.Name.Contains("Multi")) //3rd level stack
                                        {
                                            if (mpnl.MPanel_ParentModel.MPanel_Placement == "Last")
                                            {
                                                boundedByBottomFrame = true;
                                            }
                                        }
                                        else if (mpnl.MPanel_Parent.Name.Contains("Multi")) //2nd level stack
                                        {
                                            if (pnl_curCtrl != null)
                                            {
                                                if (pnl_curCtrl.Panel_Placement == "Last")
                                                {
                                                    boundedByBottomFrame = true;
                                                }
                                            }
                                        }
                                        else if (mpnl.MPanel_Parent.Name.Contains("Frame"))
                                        {
                                            if (pnl_curCtrl != null)
                                            {
                                                if (pnl_curCtrl.Panel_Placement == "Last") //lvl 1
                                                {
                                                    boundedByBottomFrame = true;
                                                }
                                            }
                                        }
                                    }


                                    if (mpnl.MPanel_Type == "Mullion")
                                    {
                                        if ((divTopOrLeft_lvl3 != null || divBotOrRight_lvl3 != null))//(mpnl.MPanel_ParentModel.MPanel_Parent.Name.Contains("Multi")) //3rd level stack
                                        {
                                            if (mpnl.MPanel_Placement == "Last")
                                            {
                                                boundedByBottomFrame = true;
                                            }
                                        }
                                        else if (mpnl.MPanel_Parent.Name.Contains("Multi")) //2nd level stack
                                        {
                                            if (mpnl.MPanel_Placement == "Last")
                                            {
                                                boundedByBottomFrame = true;
                                            }
                                        }
                                        else if (mpnl.MPanel_Parent.Name.Contains("Frame"))
                                        {
                                            if (pnl_curCtrl != null) //lvl 1
                                            {
                                                boundedByBottomFrame = true;
                                            }
                                        }
                                    }
                                }
                                #endregion

                                //Console.WriteLine("no div bottom frame:" + boundedByBottomFrame);


                                int OverLappingPanel_Qty = 0,
                                    perimeterBrushSeal = 0,
                                    perimeterFinPlate = 0;

                                foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                                {
                                    if (pnl.Panel_Overlap_Sash == OverlapSash._Left ||
                                        pnl.Panel_Overlap_Sash == OverlapSash._Right)
                                    {
                                        OverLappingPanel_Qty += 1;
                                    }
                                    else if (pnl.Panel_Overlap_Sash == OverlapSash._Both)
                                    {
                                        OverLappingPanel_Qty += 2;
                                    }
                                    pnl.Panel_OverLappingPanelQty = OverLappingPanel_Qty;


                                    if (pnl.Panel_Type.Contains("Sliding"))
                                    {
                                        perimeterBrushSeal += pnl.Panel_SashHeight - 5;
                                        if (frame.Frame_If_SlidingTypeTopHung == true)
                                        {
                                            perimeterFinPlate += pnl.Panel_SashWidth - 5;
                                        }
                                    }
                                    else if (pnl.Panel_Type.Contains("Fixed"))
                                    {
                                        perimeterBrushSeal += pnl.Panel_SashHeight + 10;
                                    }
                                    pnl.TopHungbrushSealPerimeter = perimeterBrushSeal;
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
                                                                              DividerModel.DividerType.None,
                                                                              mpnl.MPanel_DividerEnabled,
                                                                              OverLappingPanel_Qty,
                                                                              boundedByBottomFrame,
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
                                    if (item.WD_profile == "PremiLine Profile" &&
                                        pnl_curCtrl.Panel_Type.Contains("Fixed") &&
                                        frame.Frame_If_SlidingTypeTopHung == false)
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

                                            if (frame.Frame_If_SlidingTypeTopHung == true &&
                                                frame.Frame_ConnectionType == FrameConnectionType._None)
                                            {
                                                pnl_curCtrl.Insert_ConnectingProfile_MaterialList(Material_List);
                                                pnl_curCtrl.Insert_Interlock_Tophung_ForFixed_MaterialList(Material_List);
                                                pnl_curCtrl.Insert_ExternsionForInterlock_Tophung_MaterialList(Material_List);
                                                pnl_curCtrl.Insert_PVCSettingPlate_MaterialList(Material_List);
                                            }
                                        }

                                        if (pnl_curCtrl.Panel_ChkText != "dSash")
                                        {
                                            pnl_curCtrl.Insert_AntiLiftDevice_MaterialList(Material_List);
                                        }

                                        //if (pnl_curCtrl.Panel_Spacer != null) //|| pnl_curCtrl.Panel_ChkText == "dSash"
                                        //{
                                        pnl_curCtrl.Panel_SpacerArtNo = Spacer_ArticleNo._M063;
                                        pnl_curCtrl.Insert_Spacer_MaterialList(Material_List);
                                        //}

                                        if (pnl_curCtrl.Panel_GlazingRebateBlockArtNo != null)
                                        {
                                            pnl_curCtrl.Insert_GlazingRebateBlock_MaterialList(Material_List);
                                        }


                                        if (pnl_curCtrl.Panel_Overlap_Sash != OverlapSash._None)
                                        {
                                            int bothOverlapQtyMultiplier = 1;
                                            if (pnl_curCtrl.Panel_Overlap_Sash == OverlapSash._Both)
                                            {
                                                bothOverlapQtyMultiplier = 2;
                                            }
                                            if (frame.Frame_If_SlidingTypeTopHung == false)
                                            {
                                                pnl_curCtrl.Insert_Interlock_MaterialList(Material_List, bothOverlapQtyMultiplier);
                                                pnl_curCtrl.Insert_ExternsionForInterlock_MaterialList(Material_List, bothOverlapQtyMultiplier);
                                            }
                                        }

                                        if (frame.Frame_If_SlidingTypeTopHung == true &&
                                            frame.Frame_ConnectionType == FrameConnectionType._None)
                                        {
                                            if (TopHungPerFrame == true)
                                            {
                                                pnl_curCtrl.Insert_CoverProfileForTopHungInfo_MaterialList(Material_List);
                                                pnl_curCtrl.Insert_BrushSealForTopHung_MaterialList(Material_List, perimeterBrushSeal);
                                                pnl_curCtrl.Insert_SlidingSashBottomGuide_MaterialList(Material_List, OverLappingPanel_Qty);
                                                pnl_curCtrl.Insert_BrushForSliding_MaterialList(Material_List, perimeterFinPlate);

                                                TopHungPerFrame = false;
                                            }
                                        }

                                        if (pnl_curCtrl.Panel_Type.Contains("Sliding"))
                                        {
                                            if (pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040 ||
                                                pnl_curCtrl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                                            {
                                                if (frame.Frame_If_SlidingTypeTopHung == true &&
                                                    frame.Frame_ConnectionType == FrameConnectionType._None)
                                                {
                                                    pnl_curCtrl.Insert_SlidingAccessoriesRoller_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_Interlock_Tophung_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_ExternsionForInterlock_Tophung_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_GUPremilineTopTrack_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_FinPlate_MaterialList(Material_List);

                                                }

                                                if (frame.Frame_SlidingRailsQty == 3)
                                                {
                                                    slidingChck = true;
                                                }
                                                else
                                                {
                                                    slidingChck = false;
                                                }

                                                //if (frame.Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                                                //{
                                                //    frame.Insert_ConnectorType_MaterialList(Material_List);
                                                //}

                                                pnl_curCtrl.Insert_GuideTrackProfile_MaterialList(Material_List);
                                                pnl_curCtrl.Insert_AluminumTrack_MaterialList(Material_List);

                                                if (frame.Frame_If_SlidingTypeTopHung == false &&
                                                    perFrame == true)
                                                {
                                                    pnl_curCtrl.Insert_WeatherBar_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_EndCapForWeatherBar_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_WeatherBarFastener_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_WaterSeepage_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_BrushSeal_MaterialList(Material_List);

                                                    perFrame = false;
                                                }

                                                pnl_curCtrl.Insert_Rollers_MaterialList(Material_List);

                                                if (pnl_curCtrl.Panel_EspagnoletteArtNo != Espagnolette_ArticleNo._None &&
                                                    pnl_curCtrl.Panel_Overlap_Sash != OverlapSash._None)
                                                {
                                                    pnl_curCtrl.Insert_StrikerForSliding_MaterialList(Material_List);
                                                }

                                                if (pnl_curCtrl.Panel_ChkText != "dSash")
                                                {
                                                    pnl_curCtrl.Insert_SealingBlock_MaterialList(Material_List);
                                                }

                                                if (frame.Frame_Type == FrameModel.Frame_Padding.Door &&
                                                    frame.Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                                                    pnl_curCtrl.Panel_DisplayHeight >= 3200)
                                                {
                                                    pnl_curCtrl.Insert_AluminumPullHandle_MaterialList(Material_List);
                                                }

                                                if (pnl_curCtrl.Panel_MotorizedOptionVisibility == true &&
                                                    SlidingMotorizePerFrame == true)
                                                {
                                                    pnl_curCtrl.Insert_GS100TEMHMCOVERENDCAP3p5m_MaterialList(Material_List);
                                                    frame.Insert_GS100EMTrackProfile2p6n3m_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_TrackRail6m_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_MicrocellOneSafetySensor_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_AutoDoorBracketForGS100Upvc_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_GS100EndCapScrewMp5andLSupport_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_EuroLeadButtonWhite_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_ToothbeltEMCM62m_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_GuBeaZenMicrowaveSensorSilver_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_SlidingDoorKitGS100s1_MaterialList(Material_List);
                                                    pnl_curCtrl.Insert_GS100CoverKit_MaterialList(Material_List);
                                                    SlidingMotorizePerFrame = false;
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
                        #endregion
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
                            pnl.Insert_MotorizedInfo_MaterialList(Material_List, pnl.Panel_MotorizedMechQty);

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
                                        if (frame.Frame_BotFrameArtNo == BottomFrameTypes._None)
                                        {
                                            pnl.Insert_FillerProfileForNoBotFrameInfo_MaterialList(Material_List);
                                            pnl.Insert_BrushSealForNoBotFrame_MaterialList(Material_List);
                                        }

                                        pnl.Insert_SnapNKeep_MaterialList(Material_List);

                                        pnl.Insert_FixedCam_MaterialList(Material_List);


                                        int FixedCamAndSnapInKeepQty = (frame.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                                                         frame.Frame_BotFrameArtNo == BottomFrameTypes._None) ? 1 : 2;
                                        add_screws_fab_snapInKeep += FixedCamAndSnapInKeepQty * 2;
                                        add_screws_fab_fxdcam += FixedCamAndSnapInKeepQty * 2;
                                    }
                                }
                            }
                            else if (pnl.Panel_Type.Contains("Sliding"))
                            {
                                if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040 ||
                                    pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                                {

                                    //if (frame.Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                                    //{
                                    //    frame.Insert_ConnectorType_MaterialList(Material_List);
                                    //}

                                    pnl.Insert_GuideTrackProfile_MaterialList(Material_List);
                                    pnl.Insert_AluminumTrack_MaterialList(Material_List);

                                    if (perFrame == true)
                                    {
                                        pnl.Insert_WeatherBar_MaterialList(Material_List);
                                        pnl.Insert_EndCapForWeatherBar_MaterialList(Material_List);
                                        pnl.Insert_WeatherBarFastener_MaterialList(Material_List);
                                        pnl.Insert_WaterSeepage_MaterialList(Material_List);
                                        pnl.Insert_BrushSeal_MaterialList(Material_List);

                                        perFrame = false;
                                    }

                                    if (pnl.Panel_Overlap_Sash != OverlapSash._None)
                                    {
                                        int bothOverlapQtyMultiplier = 1;
                                        if (pnl.Panel_Overlap_Sash == OverlapSash._Both)
                                        {
                                            bothOverlapQtyMultiplier = 2;
                                        }
                                        pnl.Insert_SealingBlock_MaterialList(Material_List);

                                        if (frame.Frame_If_SlidingTypeTopHung == false)
                                        {
                                            pnl.Insert_Interlock_MaterialList(Material_List, bothOverlapQtyMultiplier);
                                            pnl.Insert_ExternsionForInterlock_MaterialList(Material_List, bothOverlapQtyMultiplier);
                                        }
                                    }
                                    if (pnl.Panel_RollersTypes != null)
                                    {
                                        pnl.Insert_Rollers_MaterialList(Material_List);

                                    }
                                    pnl.Insert_AntiLiftDevice_MaterialList(Material_List);


                                    if (pnl.Panel_HandleType != Handle_Type._None)
                                    {
                                        pnl.Insert_StrikerForSliding_MaterialList(Material_List);
                                    }

                                    if (frame.Frame_Type == FrameModel.Frame_Padding.Door &&
                                        frame.Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                                        pnl.Panel_DisplayHeight >= 3200)
                                    {
                                        pnl.Insert_AluminumPullHandle_MaterialList(Material_List);
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

                    if (pnl.Panel_Type.Contains("Louver"))
                    {
                        pnl.Insert_CoverProfileInfo_MaterialList(Material_List);
                        pnl.Insert_PlantOnWeatherStripHead_MaterialList(Material_List);
                        pnl.Insert_PlantOnWeatherStripSeal_MaterialList(Material_List);
                        pnl.Insert_LouvreFrameWeatherStripHead_MaterialList(Material_List);
                        pnl.Insert_LouvreFrameBottomWeatherStrip_MaterialList(Material_List);
                        pnl.Insert_RubberSeal_MaterialList(Material_List);
                        pnl.Insert_CasementSeal_MaterialList(Material_List);
                        pnl.Insert_SealForHandle_MaterialList(Material_List);
                        pnl.Insert_LouvreGallerySet_MaterialList(Material_List);
                    }

                    if (!pnl.Panel_Type.Contains("Louver"))
                    {
                        pnl.Insert_GlazingBead_MaterialList(Material_List, where);
                    }

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
                if (MechJointConnectorQty != 0 || frame.Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                {
                    frame.Insert_MechanicalJointConnector_MaterialList(Material_List, MechJointConnectorQty);
                    frame.Insert_SealingElement_MaterialList(Material_List);
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

            if (item.WD_profile == "PremiLine Profile")
            {
                Material_List.Rows.Add("Screws for 6050 Frame",
                                  Screws_for_6050Frame, "pc(s)", "", screws_for_inst_where); // FRAME, SASH, TRANSOM & MULLION
            }

            if (slidingChck == true && item.WD_profile == "PremiLine Profile")
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



        #region VariablesForPricing

        int CostPerPoints = 60,
             GeorgianBarVerticalQty = 0,
            GeorgianBarHorizontalQty = 0;

        bool ChckDM = false,
             ChckPlasticWedge = false,
             chckAlumPullHandle = false,
             check1stFrame = false,
            chckPerFrameMotorMech = false,
            OneSideFoil_whiteBase = false,
            chckPerFrameSlidingMats = false;

        string BOM_divDesc,
               HandleDesc,
               lvrgBlades,
               ChckHandleType,
               bladeType;


        decimal
        #region FrameAndSashPrice

                FramePricePerLinearMeter_7502_WoodGrain = 465.13m,
                FramePricePerLinearMeter_7502_White = 332.57m,
                FramePricePerLinearMeter_7502_White_1sideFoil = 398.85m,
                FramePricePerLinearMeter_7507_WoodGrain = 507.99m,
                FramePricePerLinearMeter_7507_White = 354.28m,
                FramePricePerLinearMeter_7507_White_1sideFoil = 431.14m,
                FramePricePerLinearMeter_2060_White = 271.35m,//G58
                FramePricePerLinearMeter_6050_WoodGrain = 483.36m,
                FramePricePerLinearMeter_6050_White = 378.19m,
                FramePricePerLinearMeter_6050_White_1sideFoil = 430.77m,
                FramePricePerLinearMeter_6052_WoodGrain = 725.02m,//704.60m, 2/22/23
                FramePricePerLinearMeter_6052_White = 567.15m,//563.48m, 2/22/23
                FramePricePerLinearMeter_6052_White_1sideFoil = 634.04m,
                FramePricePerLinearMeter_6052Milled_WoodGrain = 590m,
                FramePricePerLinearMeter_6052Milled_White = 567.15m,
                FramePricePerLinearMeter_6052Milled_White_1sideFoil = 634.04m,
                FramePricePerLinearMeter_6055_WoodGrain = 310.04m,
                FramePricePerLinearMeter_6055_White = 254.74m,
                FrameReinPricePerLinearMeter_7502 = 123.55m,
                FrameReinPricePerLinearMeter_7507 = 406.86m,
                G58ReinPricePerLinearMeter_V226 = 140.69m,//G58 reinforcement for frame, sash and divider
                FrameReinPricePerLinearMeter_6050 = 114.76m,
                FrameReinPricePerLinearMeter_6052 = 194.68m,
                FrameReinPricePerLinearMeter_6055 = 255.33m,


                SashPricePerLinearMeter_7581_WoodGrain = 550.13m,
                SashPricePerLinearMeter_7581_White = 375.30m,
                SashPricePerLinearMeter_7581_White_1sideFoil = 462.72m,
                SashPricePerLinearMeter_373_WoodGrain = 712.66m,
                SashPricePerLinearMeter_373_White = 511.72m,
                SashPricePerLinearMeter_373_White_1sideFoil = 612.19m,
                SashPricePerLinearMeter_374_WoodGrain = 801.83m,
                SashPricePerLinearMeter_374_White = 511.72m,
                SashPricePerLinearMeter_374_White_1sideFoil = 676.74m,
                SashPricePerLinearMeter_395_WoodGrain = 556.57m,
                SashPricePerLinearMeter_395_White = 412.47m,
                SashPricePerLinearMeter_395_White_1sideFoil = 489.52m,
                SashPricePerLinearMeter_2067_White = 303.50m,
                SashPricePerLinearMeter_6040_WoodGrain = 500.00m,// 550.13m,
                SashPricePerLinearMeter_6040_White = 325.00m, //373.94m,
                SashPricePerLinearMeter_6040_White_1sideFoil = 460.61m,
                SashPricePerLinearMeter_6041_WoodGrain = 683.91m,
                SashPricePerLinearMeter_6041_White = 483.13m,
                SashPricePerLinearMeter_6041_White_1sideFoil = 583.52m,
                SashReinPricePerLinearMeter_7581 = 89.86m,
                SashReinPricePerLinearMeter_373And374 = 835.18m,
                SashReinPricePerLinearMeter_395 = 305.14m,
                SashReinPricePerLinearMeter_6040 = 287.58m,
                SashReinPricePerLinearMeter_6041 = 655.49m,

                ExtensionProfile15mmPricePerLinearMeter_WoodGrain = 910.00m,
                ExtensionProfile15mmPricePerLinearMeter_White = 790.00m,

                FramePerimeter,
                FramePrice,
                FrameReinPrice,
                FramePricePerLinearMeter,
                FrameReinPricePerLinearMeter,
                FrameThresholdPricePerLinearMeter,

                ExtensionProfile15mmPricePerLinearMeter,

                SashPerimeter,
                SashPrice = 0,
                SashReinPrice,
                SashPricePerLinearMeter,
                SashReinPricePerLinearMeter,

                ExtensionProfile15mmPrice,



        #endregion
        #region Mullion/TransomPrice

                Divider_7536_PricePerSqrMeter = 663.32m,
                Divider_7538_PricePerSqrMeter = 817.34m,
                Divider_2069_PricePerSqrMeter = 284.12m, // G58
                DividerRein_7536_PricePerSqrMeter = 406.86m,
                DividerRein_7538_PricePerSqrMeter = 858.52m,

                claddingPricePerLinearMeter = 907.62m,//profile and reinforcement price
                claddingPrice,

                DivPrice,
                DividerPricePerSqrMeter,
                DividerReinPricePerSqrMeter,
                DivReinPrice,
        #endregion
        #region DummyMullionPrice

                DummyMullionPricePerLinearMeter_7533_WoodGrain = 608.75m,
                DummyMullionPricePerLinearMeter_385_WoodGrain = 580.72m,
                DummyMullionPricePerLinearMeter_7533_White = 608.75m,
                DummyMullionPricePerLinearMeter_385_White = 580.72m,

                DMPrice,
                DMReinforcementPrice,
                DummyMullionPricePerLinearMeter,
        #endregion
        #region GlassPrice

        #region single

        PVC_SheetWood_6mm_PricepPerSqrMeter = 3700.00m,
        PVC_SheetWood_12mm_PricePerSqrMeter = 7400.00m,
        PVC_SheetWood_8mm_White_PricePerSqrMeter = 2900.00m,
        PVC_SheetWood_8mm_Foiled_PricePerSqrMeter = 3700.00m,
        Glass_6mmClr_PricePerSqrMeter = 670.00m,
        Glass_8mmClr_PricePerSqrMeter = 1662.00m,
        Glass_10mmClr_PricePerSqrMeter = 1662.00m,
        Glass_12mmClr_PricePerSqrMeter = 1941.00m,
        Glass_12mmClrOversized_PricePerSqrMeter = 6000.00m,
        Glass_12mmTempTintedOversized_PricePerSqrMeter = 7050.00m,
        Glass_6mmTemp_PricePerSqrMeter = 1614.00m,
        Glass_8mmTemp_PricePerSqrMeter = 3201.00m,
        Glass_10mmTemp_PricePerSqrMeter = 3201.00m,
        Glass_12mmTemp_PricePerSqrMeter = 3619.00m,
        Glass_15mmTemp_PricePerSqrMeter = 12000.00m,
        Glass_19mmTemp_PricePerSqrMeter = 15500.00m,


        Glass_6mmTempTinted_PricePerSqrMeter = 1929.00m,


        FrostedFilmPrice_PricePerSqrMeter = 880.00m,

        Glass_6mmAnnealedTinted_Brnz_Bl_Grn_Gry = 985.00m,
        Glass_8mmAnnealedTinted_Brnz_Bl_Grn_Gry = 2334.00m,
        Glass_10mmAnnealedTinted_Brnz_Bl_Grn_Gry = 2334.00m,
        Glass_12mmAnnealedTinted_Brnz_Bl_Grn_Gry = 2709.00m,
        Glass_6mmTempTinted_Brnz_Bl_Grn_Gry = 1929.00m,
        Glass_8mmTempTinted_Brnz_Bl_Grn_Gry = 3872.00m,
        Glass_10mmTempTinted_Brnz_Bl_Grn_Gry = 3872.00m,
        Glass_12mmTempTinted_Brnz_Bl_Grn_Gry = 4387.00m,


        Glass_6mmAnnealedClr_HrdCtd_LowE = 2000.00m,
        Glass_8mmAnnealedClr_HrdCtd_LowE = 3200.00m,
        Glass_10mmAnnealedClr_HrdCtd_LowE = 4900.00m,
        Glass_6mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 2300.00m,
        Glass_8mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 3850.00m,
        Glass_10mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 4200.00m,

        Glass_6mmTempClr_HrdCtd_LowE = 2550.00m,
        Glass_8mmTempClr_HrdCtd_LowE = 3800.00m,
        Glass_10mmTempClr_HrdCtd_LowE = 5500.00m,
        Glass_12mmTempClr_HrdCtd_LowE = 7900.00m,
        Glass_6mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 3100.00m,
        Glass_8mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 4450.00m,
        Glass_10mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 5350.00m,

        Glass_8mmTempHeatSoakedClr = 3801.00m,
        Glass_10mmTempHeatSoakedClr = 3801.00m,

        Glass_6mmTempHeatSoakedClr_HrdCtd_LowE = 3350.00m,
        Glass_8mmTempHeatSoakedClr_HrdCtd_LowE = 4350.00m,
        Glass_10mmTempHeatSoakedClr_HrdCtd_LowE = 5350.00m,

        Glass_8mmAnnealed_ReflectiveClr = 2600.00m,
        Glass_6mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry = 2150.00m,
        Glass_10mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry = 3105.00m,

        Glass_8mmTemp_ReflectiveClr = 3350.00m,
        Glass_6mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry = 3125.10m,
        Glass_8mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry = 3800.00m,
        Glass_10mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry = 3906.00m,
        Glass_6mmTemp_ReflectiveGold_HrdCtd_LowE = 3600.00m,

        #endregion

        #region Double
        //Insulated
        Glass_Double_24mmTemp_SolarBan = 20000.00m,
        Glass_Double_20mmSelfCleaning_TempClr = 8700.00m,
        Glass_Double_24mmSelfCleaning_TempClr = 10400.00m,
        Glass_Double_24mmAnnealedBronze_Argon_AnnealedClr_Argon = 4300.00m,

        Glass_Double_18mmAnnealedClr_AirSS_AnnealedClr = 2800.00m,
        Glass_Double_23mmAnnealedClr_AirSS_AnnealedClr = 3300.00m,
        Glass_Double_23mmAnnealedClr_AirSS_AnnealedTinted = 3615.00m,
        Glass_Double_23mmAnnealedTinted_AirSS_AnnealedTinted = 3930.00m,

        Glass_Double_18mmTempClr_AirSS_AnnealedClr = 3100.00m,
        Glass_Double_18mmTempClr_Argon_TempClr = 4200.00m,
        Glass_Double_24mmTempClr_Argon_TempClr = 5188.00m,
        Glass_Double_18mmTempClr_Argon_TempTinted = 4500.00m,
        Glass_Double_23mmAnnealedClr_AirSS_TempTinted = 5550.00m,
        Glass_Double_24mmTempClr_Argon_TempTinted = 6110.00m,

        Glass_Double_18mmAnnealedClr_AirSS_AnnealedClrHrCtdLowe = 3400.00m,
        Glass_Double_24mmAnnealedClr_Argon_AnnealedClrHrdCtdLowe = 4550.00m,
        Glass_Double_18mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe = 3800.00m,
        Glass_Double_24mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe = 5100.00m,

        Glass_Double_18mmAnnealedClr_AirSS_TempClrHrdCtdLowe = 4000.00m,
        Glass_Double_18mmTempClr_AirSS_TempClrHrdCtdLowe = 4200.00m,
        Glass_Double_18mmTempClr_Argon_TempClrHrdCtdLowe = 5000.00m,
        Glass_Double_24mmAnnealedClr_Argon_TempClrHrdCtdLowe = 5500.00m,
        Glass_Double_23mmTempClr_Argon_TempClrHrdCtdLowe = 5700.00m,
        Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe = 6300.00m,//05/26/23 5900.00
        Glass_Double_18mmTempTinted_Argon_TempClrHrdCtdLowe = 5500.00m,
        Glass_Double_24mmTempTinted_Argon_TempClrHrdCtdLowe = 6600.00m,

        Glass_Double_24mmTempHeatSoakedClr_Argon_TempHeatSoakedClrHrdCtdLowe = 7500.00m,


        //Laminated       
        Glass_Double_11mmTempClr_SGInt_TempClr = 5800.00m,
        Glass_Double_12mmTempClr_SGInt_TempClr = 5850.00m,
        Glass_Double_13mmTempClr_SGInt_TempClr = 8000.00m,
        Glass_Double_21mmTempClr_SGInt_TempClr = 11650.00m,
        Glass_Double_25mmTempClr_SGInt_TempClr = 12750.00m,

        Glass_Double_9mmTempClrLowe_ClrPvb_TempClr = 5650.00m,
        Glass_Double_13mmTempClrLowe_ClrPvb_TempClr = 6850.00m,
        Glass_Double_23mmTempClrLowe_ClrPvb_TempClr = 14850.00m,

        Glass_Double_9mmTempClr_ClrPvb_TempTinted = 5000.00m,
        Glass_Double_10mmTempClr_ClrPvb_TempTinted = 5200.00m,
        Glass_Double_11mmTempClr_ClrPvb_TempTinted = 5500.00m,
        Glass_Double_13mmTempClr_ClrPvb_TempTinted = 6150.00m,

        Glass_Double_9mmTempTinted_ClrPvb_TempTinted = 5500.00m,
        Glass_Double_12mmTempTinted_ClrPvb_TempTinted = 6300.00m,
        Glass_Double_13mmTempTinted_ClrPvb_TempTinted = 6500.00m,

        Glass_Double_12mmTempClrLowe_ClrPvb_TempTinted = 7200.00m,

        Glass_Double_13mmTempHeatSoakedClr_Pvb_TempHeatSoakedClr = 7500.00m,

        Glass_Double_6mmAnnealedClr_ClrPvb_AnnealedClr = 2350.00m,
        Glass_Double_8mmAnnealedClr_ClrPvb_AnnealedClr = 2800.00m,
        Glass_Double_11mmAnnealedClr_ClrPvb_AnnealedClr = 3900.00m,
        Glass_Double_12mmAnnealedClr_ClrPvb_AnnealedClr = 4100.00m,
        Glass_Double_21mmAnnealedClr_ClrPvb_AnnealedClr = 8000.00m,

        Glass_Double_7mmAnnealedClrLowe_ClrPvb_AnnealedClr = 3800.00m,
        Glass_Double_11mmAnnealedClrLowe_ClrPvb_AnnealedClr = 5000.00m,
        Glass_Double_12mmAnnealedClrLowe_ClrPvb_AnnealedClr = 5500.00m,
        Glass_Double_5mmAnnealedClrLowe_ClrPvb_AnnealedTinted = 4200.00m,

        Glass_Double_6mmAnnealedTinted_ClrPvb_AnnealedClr = 2950.00m,
        Glass_Double_11mmAnnealedTinted_ClrPvb_AnnealedClr = 4216.00m,
        Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedClr = 4600.00m,

        Glass_Double_6mmAnnealedClr_WhitePvb_AnnealedClr = 2900.00m,
        Glass_Double_8mmAnnealedClr_WhitePvb_AnnealedClr = 3300.00m,
        Glass_Double_11mmAnnealedClr_WhitePvb_AnnealedClr = 5325.00m,

        Glass_Double_12mmAnnealedClr_SGInt_AnnealedClr = 5285.00m,

        Glass_Double_7mmTempClr_ClrPvb_TempClr = 4050.00m,
        Glass_Double_9mmTempClr_ClrPvb_TempClr = 4600.00m,
        Glass_Double_11mmTempClr_ClrPvb_TempClr = 5200.00m,
        Glass_Double_12mmTempClr_ClrPvb_TempClr = 5300.00m,
        Glass_Double_13mmTempClr_ClrPvb_TempClr = 5400.00m,

        Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedTinted = 4600.00m,
        Glass_Double_8mmAnnealedTinted_ClrPvb_AnnealedClr = 4200.00m,
        Glass_Double_12mmTempTinted_ClrPvb_TempClrLowe = 6600.00m,
        Glass_Double_9mmTempClr_WhitePvb_TempClr = 5700.00m,
        Glass_Double_13mmTempClr_WhitePvb_TempClr = 6500.00m,
        Glass_Double_9mmTempClr_WhitePvb_TempClrHrdCtdLowe = 6800.00m,
        Glass_Double_13mmTempClr_WhitePvb_TempClrHrdCtdLowe = 8000.00m,

        #endregion

        #region Triple
        //Insulated
        Glass_Triple_24mmAnnealedClr_AirSS_AnnealedClr_AirSS_AnnealedClr = 4900.00m,
        Glass_Triple_24mmTempClr_AirSS_AnnealedClr_AirSS_TempClr = 6100.00m,
        Glass_Triple_24mmTempClr_AirSs_TempClr_AirSS_TempClr = 8250.00m,
        Glass_Triple_24mmTempClr_Argon_AnnealedClr_Argon_TempClrLowE = 8350.00m,

        //Laminated

        #endregion


        _4millFilmPrice_PricePerSqrMeter = 2600m,

        FilmPrice,
        GlassPrice,
        #endregion
        #region FittingAndSupplies

        FS_16HD_casementPricePerPiece = 825.81m,
                FS_26HD_casementPricePerPiece = 1839.35m,

                RestrictorStayPricePerPiece = 161.18m,
                CornerDrivePricePerPiece = 150.11m, // standard top= 103.17, bot = 118.82
                SnapInKeepPricePerPiece = 67.79m,
                _35mmBacksetEspagWithCylinder = 1346.78m,
                MiddleCLoserPricePerPiece = 18.57m,

                StayBearingPricePerPiece = 41.44m,
                StayBearingPinPricePerPiece = 8.03m,
                CoverStayBearingPricePerPiece = 16.37m,
                CoverCornerHingePricePerPiece = 8.37m,
                CornerPivotRestPricePerPiece = 85.25m,
                TopCornerHingePricePerPiece = 158.48m,
                CorverCornerPivotRestPricePerPiece = 25.49m,
                CorverCornerPivotRestVerticalPricePerPiece = 8.87m,

                RotoswingHanldePricePerPiece = 257.93m,
                RotoswingHanldeForSlidingPricePerPiece = 1123.91m,
                RioHandlePricePerPiece = 481.49m,
                PopUpHandlePricePerPiece = 250m,
                DHandlePricePerPiece = 500m,
                DummyDHandlePricePerPiece = 1000m,
                DHandleInOutLockingPricePerPiece = 1300m,

                Espag741012_PricePerPiece = 284.15m,
                LeverEspagPricePerPiece = 825.81m,
                TiltAndTurnEspag_N110A00006PricePerPiece = 254.39m,
                TiltAndTurnEspag_N110A01006PricePerPiece = 465.89m,
                TiltAndTurnEspag_N110A02206PricePerPiece = 518.40m,
                TiltAndTurnEspag_N110A03206PricePerPiece = 570.91m,
                TiltAndTurnEspag_N110A04206PricePerPiece = 623.42m,
                TiltAndTurnEspag_N110A05206PricePerPiece = 675.18m,
                TiltAndTurnEspag_N110A06206PricePerPiece = 727.69m,

                _2DHingePricePerPiece = 278.94m,
                _3DHingePricePerPiece = 990.95m,
                NTCenterHingePricePerPiece = 170.50m,

                ShootBoltStrikerPricePerPiece = 57.29m,
                ShootBoltReversePricePerPiece = 368.25m,
                ShootBoltNonReversePricePerPiece = 242.71m,

                StrikerPricePerPiece = 57.08m,
                StrikerLRPricePerPiece = 52.01m,//sliding
                StrikerForDMPricePerPiece = 62.27m,
                AdjustableStrikerPricePerPiece = 20.72m,
                LatchDeadboltStrikerPricePerPiece = 446.37m,

                MVDHandlePricePerPiece = 985.01m,
                MVDGearPricePerPiece = 1585.92m,

                Extension_639957PricePerPiece = 170.50m,
                Extension_567639PricePerPiece = 134.04m,
                //Extension_N299A01006PricePerPiece = 118.82m,
                MVDExtensionPricePerPiece = 183.80m,

                HDRollerPricePerPiece = 566.06m,
                GURollerPricePerPiece = 1323.08m,
                MotorizeMechPrice = 15000.00m,
                MotorizeMechHeavyDutyPrice = 39000.00m,
                MotorizeMechUsingRemotePrice = 19500.00m,
                MotorizeMechRemotePricePerPiece = 4500.00m,

                RemoteForMotorizeMechPrice,

                RestrictorStayPrice,
                SnapInKeepPrice,
                _3DHingePrice,
                GbPrice,
                _35mmBacksetEspagWithCylinderPrice,
                EspagBasePrice,
                EspagPrice,
                LeverEspagPrice,
                StayBearingPrice,
                StayBearingPinPrice,
                CornerDrivePrice,
                CoverStayBearingPrice,
                CoverCornerHingePrice,
                CornerPivotRestPrice,
                TopCornerHingePrice,
                CorverCornerPivotRestPrice,
                CorverCornerPivotRestVerticalPrice,
                MiddleCLoserPrice,
                NTCenterHingePrice,
                LatchDeadboltStrikerPrice,
                StrikerPrice,
                StrikerLRPrice,
                ShootBoltStrikerPrice,
                ShootBoltReversePrice,
                ShootBoltNonReversePrice,
                RollerPrice,
                HandlePrice,
                HandleBasePrice = 0,
                FSPrice,
                FSBasePrice,
                _2DHingePrice,
                ExtensionPrice,
                ExtensionBasePrice,

                RollerBasePrice,
                MotorizePrice,
                MotorizeMechPricePerPiece,
        #endregion
        #region Accessories

        EndCapPricePerPiece = 282.96m,
                MechanicalJoint_AV585PricePerPiece = 87.34m,
                MechanicalJoint_9U18PricePerPiece = 138.45m,
                GBSpacerPricePerPiece = 5.01m,
                PlasticWedgePricePerPiece = 10.09m,
                BarFastenerPricePerPiece = 4.40m,
                SealingBlockPricePerPiece = 63.75m,
                SpacerFixSashPricePerPiece = 21.42m,

                EndCapPrice,
                MechJointPrice,
                GBSpacerPrice,
                PlasticWedgePrice,
                WeatherBarFastenerPrice,
                SealingBlockPrice,
                SpacerFixSashPrice,

                MechanicalJointPricePerPiece,
        #endregion
        #region AncillaryProfile
            GlazingGasketPricePerLinearMeter = 32.64m,
            GlazingBeadPricePerLinearMeter = 256.62m,
            GlazingBead_G58PricePerLinearMeter = 117.72m,
            GeorgianBar_0724Price_White = 264.89m,
            GeorgianBar_0724Price_Woodgrain = 312.36m,
            GeorgianBar_0726Price_White = 403.05m,
            GeorgianBar_0726Price_Woodgrain = 467.22m,
            CoverProfile_0914Price = 20.68m,
            CoverProfile_0373Price = 105.41m,
            ThresholdForC70PricePerPiece = 1229.34m,
            ThresholdForPremiPricePerPiece = 1181.84m,
            WeatherBarPricePerPiece = 236.75m,
            GuideTrackPricePerLinearMeter = 157.18m,
            InterlockPricePerPiece = 333.77m,
            ExtensionForInterlockPricePerPiece = 789.01m,
            AluminumTrackPricePerLinearMeter = 251.10m,
            WaterSeepagePricePerLinearMeter = 378.47m,//alum //153.73m,//pvc
            AluminumPullHandlePricePerLinearMeter = 2480.18m,
            GlazingAdaptorPricePerMeter = 250.00m,

            GlazingAdaptorPrice,
            GlazingGasketPrice,
            GeorgianBarCost,
            CoverProfileCost,
            ThresholdPrice,
            WeatherBarPrice,
            GuideTrackPrice,
            InterlockPrice,
            ExtensionForInterlockPrice,
            AlumTrackPrice,
            WaterSeepagePrice,
            AluminumPullHandlePrice,

            GeorgianBarPrice,
            CoverProfilePrice,

            GlazingBeadPerimeter,
        #endregion
        #region LouverMatsPrice
        LouvreFrameWeatherStripHeadPricePerMeter = 108.45m, // 629/5.8
            LouvreFrameBottomWeatherStripPricePerMeter = 87.07m, // 505/5.8
            PlantonWeatherStripHeadPricePerMeter = 153.79m, // 892/5.8
            PlantonWeatherStripSillPricePerMeter = 190.86m, // 1107/5.8

            LouvreFrameWeatherStripHeadPowderCoatingPrice = 39.9504m,// =10.15*3.28*1.2
            LouvreFrameBottomWeatherStripPowderCoatingPrice = 36.9984m,// =9.4*3.28*1.2
            PlantonWeatherStripHeadPowderCoatingPrice = 89.1504m,// =22.65*3.28*1.2
            PlantonWeatherStripSillPowderCoatingPrice = 79.9008m, // =20.3*3.28*1.2

            BubbleSealPricePerMeter = 57.00m,
            GalleryAdaptorPricePerMeter = 63.97m,

            forex = 55m,

            GalleryPrice_2blades_usingSingleHandle = 327.00m,
            GalleryPrice_3blades_usingSingleHandle = 529.00m,
            GalleryPrice_4blades_usingSingleHandle = 671.00m,
            GalleryPrice_5blades_usingSingleHandle = 834.00m,
            GalleryPrice_6blades_usingSingleHandle = 983.00m,
            GalleryPrice_7blades_usingSingleHandle = 1217.00m,
            GalleryPrice_8blades_usingSingleHandle = 1360.00m,
            GalleryPrice_9blades_usingSingleHandle = 1505.00m,
            GalleryPrice_10blades_usingSingleHandle = 1662.00m,
            GalleryPrice_11blades_usingSingleHandle = 1820.00m,
            GalleryPrice_12blades_usingSingleHandle = 1963.00m,
            GalleryPrice_13blades_usingSingleHandle = 2203.00m,
            GalleryPrice_14blades_usingSingleHandle = 2349.00m,
            GalleryPrice_15blades_usingSingleHandle = 2489.00m,
            GalleryPrice_16blades_usingSingleHandle = 2651.00m,
            GalleryPrice_17blades_usingSingleHandle = 2810.00m,

            GalleryPrice_2blades_usingDualHandleOrRingpullHandle = 422.00m,
            GalleryPrice_3blades_usingDualHandleOrRingpullHandle = 579.00m,
            GalleryPrice_4blades_usingDualHandleOrRingpullHandle = 721.00m,
            GalleryPrice_5blades_usingDualHandleOrRingpullHandle = 884.00m,
            GalleryPrice_6blades_usingDualHandleOrRingpullHandle = 1033.00m,
            GalleryPrice_7blades_usingDualHandleOrRingpullHandle = 1317.00m,
            GalleryPrice_8blades_usingDualHandleOrRingpullHandle = 1460.00m,
            GalleryPrice_9blades_usingDualHandleOrRingpullHandle = 1605.00m,
            GalleryPrice_10blades_usingDualHandleOrRingpullHandle = 1762.00m,
            GalleryPrice_11blades_usingDualHandleOrRingpullHandle = 1920.00m,
            GalleryPrice_12blades_usingDualHandleOrRingpullHandle = 2063.00m,
            GalleryPrice_13blades_usingDualHandleOrRingpullHandle = 2303.00m,
            GalleryPrice_14blades_usingDualHandleOrRingpullHandle = 2449.00m,
            GalleryPrice_15blades_usingDualHandleOrRingpullHandle = 2649.00m,
            GalleryPrice_16blades_usingDualHandleOrRingpullHandle = 2811.00m,
            GalleryPrice_17blades_usingDualHandleOrRingpullHandle = 2970.00m,

            GalleryPrice_3blades_usingMotorizeMechanism = 173.40m,
            GalleryPrice_4blades_usingMotorizeMechanism = 179.92m,
            GalleryPrice_5blades_usingMotorizeMechanism = 185.34m,
            GalleryPrice_6blades_usingMotorizeMechanism = 190.93m,
            GalleryPrice_7blades_usingMotorizeMechanism = 211.29m,
            GalleryPrice_8blades_usingMotorizeMechanism = 218.47m,
            GalleryPrice_9blades_usingMotorizeMechanism = 222.46m,
            GalleryPrice_10blades_usingMotorizeMechanism = 227.99m,
            GalleryPrice_11blades_usingMotorizeMechanism = 233.74m,
            GalleryPrice_12blades_usingMotorizeMechanism = 239.10m,
            GalleryPrice_13blades_usingMotorizeMechanism = 260.98m,
            GalleryPrice_14blades_usingMotorizeMechanism = 265.06m,
            GalleryPrice_15blades_usingMotorizeMechanism = 270.52m,
            GalleryPrice_16blades_usingMotorizeMechanism = 278.80m,
            GalleryPrice_17blades_usingMotorizeMechanism = 284.82m,

            SecurityKit_2blades = 546.00m,
            SecurityKit_3blades = 819.00m,
            SecurityKit_4blades = 1092.00m,
            SecurityKit_5blades = 1365.00m,
            SecurityKit_6blades = 1638.00m,
            SecurityKit_7blades = 1911.00m,
            SecurityKit_8blades = 2184.00m,
            SecurityKit_9blades = 2457.00m,
            SecurityKit_10blades = 2730.00m,
            SecurityKit_11blades = 3003.00m,
            SecurityKit_12blades = 3276.00m,
            SecurityKit_13blades = 3549.00m,
            SecurityKit_14blades = 3822.00m,
            SecurityKit_15blades = 4095.00m,
            SecurityKit_16blades = 4368.00m,
            SecurityKit_17blades = 4641.00m,

            RingpullLeverHandlePricePerPiece = 1500.00m,
            TubularPricePerLinearMeter = 1000.00m,

            LouvreFrameWeatherStripHeadPrice,
            LouvreFrameBottomWeatherStripPrice,
            PlantonWeatherStripHeadPrice,
            PlantonWeatherStripSillPrice,
            PowerKitIncludingWiresPrice,

            BubbleSealPrice,
            GalleryAdaptorPrice,
            GalleryPrice,
            GlassBladePrice,

            MillFinishCost,
            PowderCoatedWhiteIvoryCost,
            TwoSideFoiledWoodGrainCost,
            OneSidedFoiledCost,

            LouverPrice,
            LouverCost,
            SecurityKitPrice,
            SecurityKitCost,

            RingpullLeverHandlePrice,
            TubularPrice,

        #endregion
        #region Mesh
        SecurityMeshPricePerSquaremeter = 2904.00m,
        WireMeshPricePerSquaremeter = 2904.00m,
        PetMeshPricePerSquaremeter = 650.00m,
        TuffMeshPricePerSquaremeter = 401.70m,
        PhiferMeshPricePerSquaremeter = 132.72m,


        SecurityMeshPrice,
        WireMeshPrice,
        PetMeshPrice,
        TuffMeshPrice,
        PhiferMeshPrice,

        AluminumFramePricePerSquaremeter = 844.49m,
        AluminumFramePrice,

        MeshPrice,
        MeshCost,
        #endregion


                BrushSealPricePerLinearMeter = 15.80m,
                SealantPricePerCan_BrownBlack = 430m,
                SealantPricePerCan_Clear = 170m,
                PUFoamingPricePerCan = 210m,

                BrushSealPrice,
                SealantPricePerCan,
                SealantPrice,
                PUFoamingPrice,

                MaterialCostBreakDownBase,

                ProfileColorPoints = 0,
                CostingPoints = 0,
                InstallationPoints = 0,
                LaborCost = 0,
                InstallationCost = 0,
                MaterialCost = 0,
                FittingAndSuppliesCost,
                AccesorriesCost,
                AncillaryProfileCost,
                TotaPrice,
                BaseTotalPrice,
                BaseTotalPriceWithFactor,

                provinceBaseMultiplier;
        #endregion

        #region changePriceBasedOnDate
        DateTime cus_ref_date;
        public void changePriceBasedonDate()
        {
            cus_ref_date = Date_Assigned;

            if (Date_Assigned_Mainpresenter == DateTime.Parse("01-01-0001"))
            {
                Date_Assigned_Mainpresenter = Date_Assigned;
            }

            if (Date_Assigned != Date_Assigned_Mainpresenter)
            {
                cus_ref_date = Date_Assigned_Mainpresenter;
            }

            DateTime _junedateoldago = DateTime.Parse("06-04-2023");

            DateTime inc_price_date = DateTime.Parse("10-15-2022");
            //DateTime inc_price_date_2 = DateTime.Parse("05-04-2023");//waterseepage 
            DateTime inc_price_date_3 = DateTime.Parse("05-11-2023");  // waterseepage
            DateTime inc_price_date_4 = DateTime.Parse("05-26-2023");  //Double //Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe 
            DateTime inc_price_date_5 = DateTime.Parse("06-22-2023");  //6052 white and woodgrain frame,  DividerRein_7536_PricePerSqrMeter
            DateTime inc_price_date_6 = DateTime.Parse("07-20-2023");  //change, patch date
            DateTime inc_price_date_7 = DateTime.Parse("08-04-2023"); // MotorizeMechRemotePricePerPiece 
            DateTime inc_price_date_8 = DateTime.Parse("08-30-2023"); // 6 mm Tempered Clear w/ HardCoated Low-E remove desc hardcoated 


            if (cus_ref_date >= inc_price_date && cus_ref_date <= _junedateoldago)
            {
                #region setnewPrice
                #region FrameAndSashPrice
                FramePricePerLinearMeter_7502_WoodGrain = 465.13m;
                FramePricePerLinearMeter_7502_White = 332.57m;
                FramePricePerLinearMeter_7507_WoodGrain = 507.99m;
                FramePricePerLinearMeter_7507_White = 354.28m;
                FramePricePerLinearMeter_2060_White = 271.35m;//G58
                FramePricePerLinearMeter_6050_WoodGrain = 483.36m;
                FramePricePerLinearMeter_6050_White = 378.19m;
                FramePricePerLinearMeter_6052_WoodGrain = 704.60m;
                FramePricePerLinearMeter_6052_White = 563.48m;
                FrameReinPricePerLinearMeter_7502 = 123.55m;
                FrameReinPricePerLinearMeter_7507 = 406.86m;
                G58ReinPricePerLinearMeter_V226 = 140.69m;//G58 reinforcement for frame; sash and divider
                FrameReinPricePerLinearMeter_6050 = 114.76m;
                FrameReinPricePerLinearMeter_6052 = 194.68m;

                SashPricePerLinearMeter_7581_WoodGrain = 550.13m;
                SashPricePerLinearMeter_7581_White = 375.30m;
                SashPricePerLinearMeter_373_WoodGrain = 712.66m;
                SashPricePerLinearMeter_373_White = 511.72m;
                SashPricePerLinearMeter_374_WoodGrain = 801.83m;
                SashPricePerLinearMeter_374_White = 511.72m;
                SashPricePerLinearMeter_395_WoodGrain = 556.57m;
                SashPricePerLinearMeter_395_White = 412.47m;
                SashPricePerLinearMeter_2067_White = 303.50m;
                SashPricePerLinearMeter_6040_WoodGrain = 500;// 550.13m;
                SashPricePerLinearMeter_6040_White = 325; //373.94m;
                SashPricePerLinearMeter_6041_WoodGrain = 683.91m;
                SashPricePerLinearMeter_6041_White = 483.13m;
                SashReinPricePerLinearMeter_7581 = 89.86m;
                SashReinPricePerLinearMeter_373And374 = 835.18m;
                SashReinPricePerLinearMeter_395 = 305.14m;
                SashReinPricePerLinearMeter_6040 = 287.58m;
                SashReinPricePerLinearMeter_6041 = 655.49m;

                #endregion
                #region Mullion/TransomPrice
                Divider_7536_PricePerSqrMeter = 663.32m;
                Divider_7538_PricePerSqrMeter = 817.34m;
                Divider_2069_PricePerSqrMeter = 284.12m; // G58
                DividerRein_7536_PricePerSqrMeter = 866.23m;
                DividerRein_7538_PricePerSqrMeter = 858.52m;

                claddingPricePerLinearMeter = 907.62m;//profile and reinforcement price

                #endregion
                #region DummyMullionPrice
                DummyMullionPricePerLinearMeter_7533_WoodGrain = 608.75m;
                DummyMullionPricePerLinearMeter_385_WoodGrain = 580.72m;
                DummyMullionPricePerLinearMeter_7533_White = 608.75m;
                DummyMullionPricePerLinearMeter_385_White = 580.72m;
                #endregion

                #region GlassPrice

                #region single

                Glass_6mmClr_PricePerSqrMeter = 670.00m;
                Glass_8mmClr_PricePerSqrMeter = 1662.00m;
                Glass_10mmClr_PricePerSqrMeter = 1662.00m;
                Glass_12mmClr_PricePerSqrMeter = 1941.00m;
                Glass_6mmTemp_PricePerSqrMeter = 1614.00m;
                Glass_8mmTemp_PricePerSqrMeter = 3201.00m;
                Glass_10mmTemp_PricePerSqrMeter = 3201.00m;
                Glass_12mmTemp_PricePerSqrMeter = 3619.00m;
                Glass_12mmClrOversized_PricePerSqrMeter = 6000.00m;


                Glass_6mmAnnealedTinted_Brnz_Bl_Grn_Gry = 985.00m;
                Glass_8mmAnnealedTinted_Brnz_Bl_Grn_Gry = 2334.00m;
                Glass_10mmAnnealedTinted_Brnz_Bl_Grn_Gry = 2334.00m;
                Glass_12mmAnnealedTinted_Brnz_Bl_Grn_Gry = 2709.00m;
                Glass_6mmTempTinted_Brnz_Bl_Grn_Gry = 1929.00m;
                Glass_8mmTempTinted_Brnz_Bl_Grn_Gry = 3872.00m;
                Glass_10mmTempTinted_Brnz_Bl_Grn_Gry = 3872.00m;
                Glass_12mmTempTinted_Brnz_Bl_Grn_Gry = 4387.00m;

                Glass_6mmAnnealedClr_HrdCtd_LowE = 2000.00m;
                Glass_8mmAnnealedClr_HrdCtd_LowE = 3200.00m;
                Glass_10mmAnnealedClr_HrdCtd_LowE = 4900.00m;
                Glass_6mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 2300.00m;
                Glass_8mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 3850.00m;
                Glass_10mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 4200.00m;

                Glass_6mmTempClr_HrdCtd_LowE = 2550.00m;
                Glass_8mmTempClr_HrdCtd_LowE = 3800.00m;
                Glass_10mmTempClr_HrdCtd_LowE = 5500.00m;
                Glass_6mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 3100.00m;
                Glass_8mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 4450.00m;
                Glass_10mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 5350.00m;

                Glass_8mmTempHeatSoakedClr = 3801.00m;
                Glass_10mmTempHeatSoakedClr = 3801.00m;

                Glass_6mmTempHeatSoakedClr_HrdCtd_LowE = 3350.00m;
                Glass_8mmTempHeatSoakedClr_HrdCtd_LowE = 4350.00m;
                Glass_10mmTempHeatSoakedClr_HrdCtd_LowE = 5350.00m;

                Glass_8mmAnnealed_ReflectiveClr = 2600.00m;
                Glass_6mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry = 2150.00m;
                Glass_10mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry = 3105.00m;

                Glass_8mmTemp_ReflectiveClr = 3350.00m;
                Glass_6mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry = 3125.10m;
                Glass_8mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry = 3800.00m;
                Glass_10mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry = 3906.00m;
                Glass_6mmTemp_ReflectiveGold_HrdCtd_LowE = 3600.00m;

                #endregion

                #region Double
                //Insulated
                Glass_Double_24mmTemp_SolarBan = 20000.00m;
                Glass_Double_20mmSelfCleaning_TempClr = 8700.00m;
                Glass_Double_24mmSelfCleaning_TempClr = 10400.00m;
                Glass_Double_24mmAnnealedBronze_Argon_AnnealedClr_Argon = 4300.00m;

                Glass_Double_18mmAnnealedClr_AirSS_AnnealedClr = 2800.00m;
                Glass_Double_23mmAnnealedClr_AirSS_AnnealedClr = 3300.00m;
                Glass_Double_23mmAnnealedClr_AirSS_AnnealedTinted = 3615.00m;
                Glass_Double_23mmAnnealedTinted_AirSS_AnnealedTinted = 3930.00m;

                Glass_Double_18mmTempClr_AirSS_AnnealedClr = 3100.00m;
                Glass_Double_18mmTempClr_Argon_TempClr = 4200.00m;
                Glass_Double_24mmTempClr_Argon_TempClr = 5188.00m;
                Glass_Double_18mmTempClr_Argon_TempTinted = 4500.00m;
                Glass_Double_23mmAnnealedClr_AirSS_TempTinted = 5550.00m;
                Glass_Double_24mmTempClr_Argon_TempTinted = 6110.00m;

                Glass_Double_18mmAnnealedClr_AirSS_AnnealedClrHrCtdLowe = 3400.00m;
                Glass_Double_24mmAnnealedClr_Argon_AnnealedClrHrdCtdLowe = 4550.00m;
                Glass_Double_18mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe = 3800.00m;
                Glass_Double_24mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe = 5100.00m;

                Glass_Double_18mmAnnealedClr_AirSS_TempClrHrdCtdLowe = 4000.00m;
                Glass_Double_18mmTempClr_AirSS_TempClrHrdCtdLowe = 4200.00m;
                Glass_Double_18mmTempClr_Argon_TempClrHrdCtdLowe = 5000.00m;
                Glass_Double_24mmAnnealedClr_Argon_TempClrHrdCtdLowe = 5500.00m;
                Glass_Double_23mmTempClr_Argon_TempClrHrdCtdLowe = 5700.00m;
                Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe = 5900.00m;
                Glass_Double_18mmTempTinted_Argon_TempClrHrdCtdLowe = 5500.00m;
                Glass_Double_24mmTempTinted_Argon_TempClrHrdCtdLowe = 6600.00m;

                Glass_Double_24mmTempHeatSoakedClr_Argon_TempHeatSoakedClrHrdCtdLowe = 7500.00m;


                //Laminated       
                Glass_Double_11mmTempClr_SGInt_TempClr = 5800.00m;
                Glass_Double_12mmTempClr_SGInt_TempClr = 5850.00m;
                Glass_Double_13mmTempClr_SGInt_TempClr = 8000.00m;
                Glass_Double_21mmTempClr_SGInt_TempClr = 11650.00m;
                Glass_Double_25mmTempClr_SGInt_TempClr = 12750.00m;
                Glass_Double_9mmTempClrLowe_ClrPvb_TempClr = 5650.00m;
                Glass_Double_13mmTempClrLowe_ClrPvb_TempClr = 6850.00m;
                Glass_Double_23mmTempClrLowe_ClrPvb_TempClr = 14850.00m;
                Glass_Double_9mmTempClr_ClrPvb_TempTinted = 5000.00m;
                Glass_Double_10mmTempClr_ClrPvb_TempTinted = 5200.00m;
                Glass_Double_11mmTempClr_ClrPvb_TempTinted = 5500.00m;
                Glass_Double_13mmTempClr_ClrPvb_TempTinted = 6150.00m;
                Glass_Double_9mmTempTinted_ClrPvb_TempTinted = 5500.00m;
                Glass_Double_12mmTempTinted_ClrPvb_TempTinted = 6300.00m;
                Glass_Double_13mmTempTinted_ClrPvb_TempTinted = 6500.00m;
                Glass_Double_12mmTempClrLowe_ClrPvb_TempTinted = 7200.00m;
                Glass_Double_13mmTempHeatSoakedClr_Pvb_TempHeatSoakedClr = 7500.00m;

                Glass_Double_6mmAnnealedClr_ClrPvb_AnnealedClr = 2350.00m;
                Glass_Double_8mmAnnealedClr_ClrPvb_AnnealedClr = 2800.00m;
                Glass_Double_11mmAnnealedClr_ClrPvb_AnnealedClr = 3900.00m;
                Glass_Double_12mmAnnealedClr_ClrPvb_AnnealedClr = 4100.00m;
                Glass_Double_21mmAnnealedClr_ClrPvb_AnnealedClr = 8000.00m;
                Glass_Double_7mmAnnealedClrLowe_ClrPvb_AnnealedClr = 3800.00m;
                Glass_Double_11mmAnnealedClrLowe_ClrPvb_AnnealedClr = 5000.00m;
                Glass_Double_12mmAnnealedClrLowe_ClrPvb_AnnealedClr = 5500.00m;
                Glass_Double_5mmAnnealedClrLowe_ClrPvb_AnnealedTinted = 4200.00m;
                Glass_Double_6mmAnnealedTinted_ClrPvb_AnnealedClr = 2950.00m;
                Glass_Double_11mmAnnealedTinted_ClrPvb_AnnealedClr = 4216.00m;
                Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedClr = 4600.00m;
                Glass_Double_6mmAnnealedClr_WhitePvb_AnnealedClr = 2900.00m;
                Glass_Double_8mmAnnealedClr_WhitePvb_AnnealedClr = 3300.00m;
                Glass_Double_11mmAnnealedClr_WhitePvb_AnnealedClr = 5325.00m;
                Glass_Double_12mmAnnealedClr_SGInt_AnnealedClr = 5285.00m;
                Glass_Double_7mmTempClr_ClrPvb_TempClr = 4050.00m;
                Glass_Double_9mmTempClr_ClrPvb_TempClr = 4600.00m;
                Glass_Double_11mmTempClr_ClrPvb_TempClr = 5200.00m;
                Glass_Double_12mmTempClr_ClrPvb_TempClr = 5300.00m;
                Glass_Double_13mmTempClr_ClrPvb_TempClr = 5400.00m;

                Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedTinted = 4600.00m;
                Glass_Double_8mmAnnealedTinted_ClrPvb_AnnealedClr = 4200.00m;
                Glass_Double_12mmTempTinted_ClrPvb_TempClrLowe = 6600.00m;
                Glass_Double_9mmTempClr_WhitePvb_TempClr = 5700.00m;
                Glass_Double_13mmTempClr_WhitePvb_TempClr = 6500.00m;
                Glass_Double_9mmTempClr_WhitePvb_TempClrHrdCtdLowe = 6800.00m;
                Glass_Double_13mmTempClr_WhitePvb_TempClrHrdCtdLowe = 8000.00m;

                #endregion

                #region Triple
                //Insulated
                Glass_Triple_24mmAnnealedClr_AirSS_AnnealedClr_AirSS_AnnealedClr = 4900.00m;
                Glass_Triple_24mmTempClr_AirSS_AnnealedClr_AirSS_TempClr = 6100.00m;
                Glass_Triple_24mmTempClr_AirSs_TempClr_AirSS_TempClr = 8250.00m;
                Glass_Triple_24mmTempClr_Argon_AnnealedClr_Argon_TempClrLowE = 8350.00m;

                //Laminated

                #endregion


                _4millFilmPrice_PricePerSqrMeter = 2600m;
                #endregion

                #region FittingAndSupplies
                FS_16HD_casementPricePerPiece = 825.81m;
                FS_26HD_casementPricePerPiece = 1839.35m;

                RestrictorStayPricePerPiece = 161.18m;
                CornerDrivePricePerPiece = 150.11m; // standard top= 103.17; bot = 118.82
                SnapInKeepPricePerPiece = 67.79m;
                _35mmBacksetEspagWithCylinder = 1346.78m;
                MiddleCLoserPricePerPiece = 18.57m;

                StayBearingPricePerPiece = 41.44m;
                StayBearingPinPricePerPiece = 8.03m;
                CoverStayBearingPricePerPiece = 16.37m;
                CoverCornerHingePricePerPiece = 8.37m;
                CornerPivotRestPricePerPiece = 85.25m;
                TopCornerHingePricePerPiece = 158.48m;
                CorverCornerPivotRestPricePerPiece = 25.49m;
                CorverCornerPivotRestVerticalPricePerPiece = 8.87m;

                RotoswingHanldePricePerPiece = 257.93m;
                RotoswingHanldeForSlidingPricePerPiece = 1123.91m;
                RioHandlePricePerPiece = 481.49m;

                Espag741012_PricePerPiece = 284.15m;
                LeverEspagPricePerPiece = 825.81m;
                TiltAndTurnEspag_N110A00006PricePerPiece = 254.39m;
                TiltAndTurnEspag_N110A01006PricePerPiece = 465.89m;
                TiltAndTurnEspag_N110A02206PricePerPiece = 518.40m;
                TiltAndTurnEspag_N110A03206PricePerPiece = 570.91m;
                TiltAndTurnEspag_N110A04206PricePerPiece = 623.42m;
                TiltAndTurnEspag_N110A05206PricePerPiece = 675.18m;
                TiltAndTurnEspag_N110A06206PricePerPiece = 727.69m;

                _2DHingePricePerPiece = 278.94m;
                _3DHingePricePerPiece = 990.95m;
                NTCenterHingePricePerPiece = 170.50m;

                ShootBoltStrikerPricePerPiece = 57.29m;
                ShootBoltReversePricePerPiece = 368.25m;
                ShootBoltNonReversePricePerPiece = 242.71m;

                StrikerPricePerPiece = 57.08m;
                StrikerLRPricePerPiece = 52.01m;//sliding
                StrikerForDMPricePerPiece = 62.27m;
                AdjustableStrikerPricePerPiece = 20.72m;
                LatchDeadboltStrikerPricePerPiece = 446.37m;

                MVDHandlePricePerPiece = 985.01m;
                MVDGearPricePerPiece = 1585.92m;

                Extension_639957PricePerPiece = 170.50m;
                Extension_567639PricePerPiece = 134.04m;
                //Extension_N299A01006PricePerPiece = 118.82m;
                MVDExtensionPricePerPiece = 183.80m;

                HDRollerPricePerPiece = 566.06m;
                GURollerPricePerPiece = 1323.08m;

                #endregion
                #region Accessories
                EndCapPricePerPiece = 282.96m;
                MechanicalJoint_AV585PricePerPiece = 87.34m;
                MechanicalJoint_9U18PricePerPiece = 138.45m;
                GBSpacerPricePerPiece = 5.01m;
                PlasticWedgePricePerPiece = 10.09m;
                BarFastenerPricePerPiece = 4.40m;
                SealingBlockPricePerPiece = 63.75m;
                SpacerFixSashPricePerPiece = 21.42m;

                #endregion
                #region AncillaryProfile
                GlazingGasketPricePerLinearMeter = 32.64m;
                GlazingBeadPricePerLinearMeter = 256.62m;
                GlazingBead_G58PricePerLinearMeter = 117.72m;
                GeorgianBar_0724Price_White = 264.89m;
                GeorgianBar_0724Price_Woodgrain = 312.36m;
                GeorgianBar_0726Price_White = 403.05m;
                GeorgianBar_0726Price_Woodgrain = 467.22m;
                CoverProfile_0914Price = 20.68m;
                CoverProfile_0373Price = 105.41m;
                ThresholdForC70PricePerPiece = 1229.34m;
                ThresholdForPremiPricePerPiece = 1181.84m;
                WeatherBarPricePerPiece = 236.75m;
                GuideTrackPricePerLinearMeter = 157.18m;
                InterlockPricePerPiece = 333.77m;
                ExtensionForInterlockPricePerPiece = 789.01m;
                AluminumTrackPricePerLinearMeter = 251.10m;
                WaterSeepagePricePerLinearMeter = 153.73m;
                AluminumPullHandlePricePerLinearMeter = 2480.18m;

                #endregion
                BrushSealPricePerLinearMeter = 15.80m;
                SealantPricePerCan_BrownBlack = 430m;
                SealantPricePerCan_Clear = 170m;
                PUFoamingPricePerCan = 210m;

                ProfileColorPoints = 0;
                CostingPoints = 0;
                InstallationPoints = 0;
                LaborCost = 0;
                InstallationCost = 0;
                MaterialCost = 0;
                #endregion        

                if (cus_ref_date >= inc_price_date_3 && cus_ref_date < inc_price_date_4)
                {
                    // waterseepage
                    WaterSeepagePricePerLinearMeter = 378.47m;
                }
                else if (cus_ref_date >= inc_price_date_4 && cus_ref_date < inc_price_date_5)
                {
                    //Double //Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe 
                    WaterSeepagePricePerLinearMeter = 378.47m;
                    Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe = 6300.00m;
                }
            }
            else
            {
                #region setnewPrice
                #region FrameAndSashPrice
                FramePricePerLinearMeter_7502_WoodGrain = 465.13m;
                FramePricePerLinearMeter_7502_White = 332.57m;
                FramePricePerLinearMeter_7507_WoodGrain = 507.99m;
                FramePricePerLinearMeter_7507_White = 354.28m;
                FramePricePerLinearMeter_2060_White = 271.35m;//G58
                FramePricePerLinearMeter_6050_WoodGrain = 483.36m;
                FramePricePerLinearMeter_6050_White = 378.19m;
                FramePricePerLinearMeter_6052_WoodGrain = 704.60m;
                FramePricePerLinearMeter_6052_White = 563.48m;
                FrameReinPricePerLinearMeter_7502 = 123.55m;
                FrameReinPricePerLinearMeter_7507 = 406.86m;
                G58ReinPricePerLinearMeter_V226 = 140.69m;//G58 reinforcement for frame; sash and divider
                FrameReinPricePerLinearMeter_6050 = 114.76m;
                FrameReinPricePerLinearMeter_6052 = 194.68m;

                SashPricePerLinearMeter_7581_WoodGrain = 550.13m;
                SashPricePerLinearMeter_7581_White = 375.30m;
                SashPricePerLinearMeter_373_WoodGrain = 712.66m;
                SashPricePerLinearMeter_373_White = 511.72m;
                SashPricePerLinearMeter_374_WoodGrain = 801.83m;
                SashPricePerLinearMeter_374_White = 511.72m;
                SashPricePerLinearMeter_395_WoodGrain = 556.57m;
                SashPricePerLinearMeter_395_White = 412.47m;
                SashPricePerLinearMeter_2067_White = 303.50m;
                SashPricePerLinearMeter_6040_WoodGrain = 500;// 550.13m;
                SashPricePerLinearMeter_6040_White = 325; //373.94m;
                SashPricePerLinearMeter_6041_WoodGrain = 683.91m;
                SashPricePerLinearMeter_6041_White = 483.13m;
                SashReinPricePerLinearMeter_7581 = 89.86m;
                SashReinPricePerLinearMeter_373And374 = 835.18m;
                SashReinPricePerLinearMeter_395 = 305.14m;
                SashReinPricePerLinearMeter_6040 = 287.58m;
                SashReinPricePerLinearMeter_6041 = 655.49m;

                #endregion
                #region Mullion/TransomPrice
                Divider_7536_PricePerSqrMeter = 663.32m;
                Divider_7538_PricePerSqrMeter = 817.34m;
                Divider_2069_PricePerSqrMeter = 284.12m; // G58
                DividerRein_7536_PricePerSqrMeter = 866.23m;//406.86m
                DividerRein_7538_PricePerSqrMeter = 858.52m;

                claddingPricePerLinearMeter = 907.62m;//profile and reinforcement price

                #endregion
                #region DummyMullionPrice
                DummyMullionPricePerLinearMeter_7533_WoodGrain = 608.75m;
                DummyMullionPricePerLinearMeter_385_WoodGrain = 580.72m;
                DummyMullionPricePerLinearMeter_7533_White = 608.75m;
                DummyMullionPricePerLinearMeter_385_White = 580.72m;
                #endregion
                #region GlassPrice

                #region single

                Glass_6mmClr_PricePerSqrMeter = 670.00m;
                Glass_8mmClr_PricePerSqrMeter = 1662.00m;
                Glass_10mmClr_PricePerSqrMeter = 1662.00m;
                Glass_12mmClr_PricePerSqrMeter = 1941.00m;
                Glass_6mmTemp_PricePerSqrMeter = 1614.00m;
                Glass_8mmTemp_PricePerSqrMeter = 3201.00m;
                Glass_10mmTemp_PricePerSqrMeter = 3201.00m;
                Glass_12mmTemp_PricePerSqrMeter = 3619.00m;
                Glass_15mmTemp_PricePerSqrMeter = 12000.00m;
                Glass_12mmClrOversized_PricePerSqrMeter = 6000.00m;
                Glass_12mmTempTintedOversized_PricePerSqrMeter = 7050.00m;


                Glass_6mmAnnealedTinted_Brnz_Bl_Grn_Gry = 985.00m;
                Glass_8mmAnnealedTinted_Brnz_Bl_Grn_Gry = 2334.00m;
                Glass_10mmAnnealedTinted_Brnz_Bl_Grn_Gry = 2334.00m;
                Glass_12mmAnnealedTinted_Brnz_Bl_Grn_Gry = 2709.00m;
                Glass_6mmTempTinted_Brnz_Bl_Grn_Gry = 1929.00m;
                Glass_8mmTempTinted_Brnz_Bl_Grn_Gry = 3872.00m;
                Glass_10mmTempTinted_Brnz_Bl_Grn_Gry = 3872.00m;
                Glass_12mmTempTinted_Brnz_Bl_Grn_Gry = 4387.00m;

                Glass_6mmAnnealedClr_HrdCtd_LowE = 2000.00m;
                Glass_8mmAnnealedClr_HrdCtd_LowE = 3200.00m;
                Glass_10mmAnnealedClr_HrdCtd_LowE = 4900.00m;
                Glass_6mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 2300.00m;
                Glass_8mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 3850.00m;
                Glass_10mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 4200.00m;

                Glass_6mmTempClr_HrdCtd_LowE = 2550.00m;
                Glass_8mmTempClr_HrdCtd_LowE = 3800.00m;
                Glass_10mmTempClr_HrdCtd_LowE = 5500.00m;
                Glass_12mmTempClr_HrdCtd_LowE = 7900.00m;
                Glass_6mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 3100.00m;
                Glass_8mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 4450.00m;
                Glass_10mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry = 5350.00m;

                Glass_8mmTempHeatSoakedClr = 3801.00m;
                Glass_10mmTempHeatSoakedClr = 3801.00m;

                Glass_6mmTempHeatSoakedClr_HrdCtd_LowE = 3350.00m;
                Glass_8mmTempHeatSoakedClr_HrdCtd_LowE = 4350.00m;
                Glass_10mmTempHeatSoakedClr_HrdCtd_LowE = 5350.00m;

                Glass_8mmAnnealed_ReflectiveClr = 2600.00m;
                Glass_6mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry = 2150.00m;
                Glass_10mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry = 3105.00m;

                Glass_8mmTemp_ReflectiveClr = 3350.00m;
                Glass_6mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry = 3125.10m;
                Glass_8mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry = 3800.00m;
                Glass_10mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry = 3906.00m;
                Glass_6mmTemp_ReflectiveGold_HrdCtd_LowE = 3600.00m;

                #endregion

                #region Double
                //Insulated
                Glass_Double_24mmTemp_SolarBan = 20000.00m;
                Glass_Double_20mmSelfCleaning_TempClr = 8700.00m;
                Glass_Double_24mmSelfCleaning_TempClr = 10400.00m;
                Glass_Double_24mmAnnealedBronze_Argon_AnnealedClr_Argon = 4300.00m;

                Glass_Double_18mmAnnealedClr_AirSS_AnnealedClr = 2800.00m;
                Glass_Double_23mmAnnealedClr_AirSS_AnnealedClr = 3300.00m;
                Glass_Double_23mmAnnealedClr_AirSS_AnnealedTinted = 3615.00m;
                Glass_Double_23mmAnnealedTinted_AirSS_AnnealedTinted = 3930.00m;

                Glass_Double_18mmTempClr_AirSS_AnnealedClr = 3100.00m;
                Glass_Double_18mmTempClr_Argon_TempClr = 4200.00m;
                Glass_Double_24mmTempClr_Argon_TempClr = 5188.00m;
                Glass_Double_18mmTempClr_Argon_TempTinted = 4500.00m;
                Glass_Double_23mmAnnealedClr_AirSS_TempTinted = 5550.00m;
                Glass_Double_24mmTempClr_Argon_TempTinted = 6110.00m;

                Glass_Double_18mmAnnealedClr_AirSS_AnnealedClrHrCtdLowe = 3400.00m;
                Glass_Double_24mmAnnealedClr_Argon_AnnealedClrHrdCtdLowe = 4550.00m;
                Glass_Double_18mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe = 3800.00m;
                Glass_Double_24mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe = 5100.00m;

                Glass_Double_18mmAnnealedClr_AirSS_TempClrHrdCtdLowe = 4000.00m;
                Glass_Double_18mmTempClr_AirSS_TempClrHrdCtdLowe = 4200.00m;
                Glass_Double_18mmTempClr_Argon_TempClrHrdCtdLowe = 5000.00m;
                Glass_Double_24mmAnnealedClr_Argon_TempClrHrdCtdLowe = 5500.00m;
                Glass_Double_23mmTempClr_Argon_TempClrHrdCtdLowe = 5700.00m;
                Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe = 5900.00m;
                Glass_Double_18mmTempTinted_Argon_TempClrHrdCtdLowe = 5500.00m;
                Glass_Double_24mmTempTinted_Argon_TempClrHrdCtdLowe = 6600.00m;

                Glass_Double_24mmTempHeatSoakedClr_Argon_TempHeatSoakedClrHrdCtdLowe = 7500.00m;


                //Laminated       
                Glass_Double_11mmTempClr_SGInt_TempClr = 5800.00m;
                Glass_Double_12mmTempClr_SGInt_TempClr = 5850.00m;
                Glass_Double_13mmTempClr_SGInt_TempClr = 8000.00m;
                Glass_Double_21mmTempClr_SGInt_TempClr = 11650.00m;
                Glass_Double_25mmTempClr_SGInt_TempClr = 12750.00m;
                Glass_Double_9mmTempClrLowe_ClrPvb_TempClr = 5650.00m;
                Glass_Double_13mmTempClrLowe_ClrPvb_TempClr = 6850.00m;
                Glass_Double_23mmTempClrLowe_ClrPvb_TempClr = 14850.00m;
                Glass_Double_9mmTempClr_ClrPvb_TempTinted = 5000.00m;
                Glass_Double_10mmTempClr_ClrPvb_TempTinted = 5200.00m;
                Glass_Double_11mmTempClr_ClrPvb_TempTinted = 5500.00m;
                Glass_Double_13mmTempClr_ClrPvb_TempTinted = 6150.00m;
                Glass_Double_9mmTempTinted_ClrPvb_TempTinted = 5500.00m;
                Glass_Double_12mmTempTinted_ClrPvb_TempTinted = 6300.00m;
                Glass_Double_13mmTempTinted_ClrPvb_TempTinted = 6500.00m;
                Glass_Double_12mmTempClrLowe_ClrPvb_TempTinted = 7200.00m;
                Glass_Double_13mmTempHeatSoakedClr_Pvb_TempHeatSoakedClr = 7500.00m;

                Glass_Double_6mmAnnealedClr_ClrPvb_AnnealedClr = 2350.00m;
                Glass_Double_8mmAnnealedClr_ClrPvb_AnnealedClr = 2800.00m;
                Glass_Double_11mmAnnealedClr_ClrPvb_AnnealedClr = 3900.00m;
                Glass_Double_12mmAnnealedClr_ClrPvb_AnnealedClr = 4100.00m;
                Glass_Double_21mmAnnealedClr_ClrPvb_AnnealedClr = 8000.00m;
                Glass_Double_7mmAnnealedClrLowe_ClrPvb_AnnealedClr = 3800.00m;
                Glass_Double_11mmAnnealedClrLowe_ClrPvb_AnnealedClr = 5000.00m;
                Glass_Double_12mmAnnealedClrLowe_ClrPvb_AnnealedClr = 5500.00m;
                Glass_Double_5mmAnnealedClrLowe_ClrPvb_AnnealedTinted = 4200.00m;
                Glass_Double_6mmAnnealedTinted_ClrPvb_AnnealedClr = 2950.00m;
                Glass_Double_11mmAnnealedTinted_ClrPvb_AnnealedClr = 4216.00m;
                Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedClr = 4600.00m;
                Glass_Double_6mmAnnealedClr_WhitePvb_AnnealedClr = 2900.00m;
                Glass_Double_8mmAnnealedClr_WhitePvb_AnnealedClr = 3300.00m;
                Glass_Double_11mmAnnealedClr_WhitePvb_AnnealedClr = 5325.00m;
                Glass_Double_12mmAnnealedClr_SGInt_AnnealedClr = 5285.00m;
                Glass_Double_7mmTempClr_ClrPvb_TempClr = 4050.00m;
                Glass_Double_9mmTempClr_ClrPvb_TempClr = 4600.00m;
                Glass_Double_11mmTempClr_ClrPvb_TempClr = 5200.00m;
                Glass_Double_12mmTempClr_ClrPvb_TempClr = 5300.00m;
                Glass_Double_13mmTempClr_ClrPvb_TempClr = 5400.00m;

                Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedTinted = 4600.00m;
                Glass_Double_8mmAnnealedTinted_ClrPvb_AnnealedClr = 4200.00m;
                Glass_Double_12mmTempTinted_ClrPvb_TempClrLowe = 6600.00m;
                Glass_Double_9mmTempClr_WhitePvb_TempClr = 5700.00m;
                Glass_Double_13mmTempClr_WhitePvb_TempClr = 6500.00m;
                Glass_Double_9mmTempClr_WhitePvb_TempClrHrdCtdLowe = 6800.00m;
                Glass_Double_13mmTempClr_WhitePvb_TempClrHrdCtdLowe = 8000.00m;

                #endregion

                #region Triple
                //Insulated
                Glass_Triple_24mmAnnealedClr_AirSS_AnnealedClr_AirSS_AnnealedClr = 4900.00m;
                Glass_Triple_24mmTempClr_AirSS_AnnealedClr_AirSS_TempClr = 6100.00m;
                Glass_Triple_24mmTempClr_AirSs_TempClr_AirSS_TempClr = 8250.00m;
                Glass_Triple_24mmTempClr_Argon_AnnealedClr_Argon_TempClrLowE = 8350.00m;

                //Laminated

                #endregion


                _4millFilmPrice_PricePerSqrMeter = 2600m;
                #endregion
                #region FittingAndSupplies
                FS_16HD_casementPricePerPiece = 825.81m;
                FS_26HD_casementPricePerPiece = 1839.35m;

                RestrictorStayPricePerPiece = 161.18m;
                CornerDrivePricePerPiece = 150.11m; // standard top= 103.17; bot = 118.82
                SnapInKeepPricePerPiece = 67.79m;
                _35mmBacksetEspagWithCylinder = 1346.78m;
                MiddleCLoserPricePerPiece = 18.57m;

                StayBearingPricePerPiece = 41.44m;
                StayBearingPinPricePerPiece = 8.03m;
                CoverStayBearingPricePerPiece = 16.37m;
                CoverCornerHingePricePerPiece = 8.37m;
                CornerPivotRestPricePerPiece = 85.25m;
                TopCornerHingePricePerPiece = 158.48m;
                CorverCornerPivotRestPricePerPiece = 25.49m;
                CorverCornerPivotRestVerticalPricePerPiece = 8.87m;

                RotoswingHanldePricePerPiece = 257.93m;
                RotoswingHanldeForSlidingPricePerPiece = 1123.91m;
                RioHandlePricePerPiece = 481.49m;

                Espag741012_PricePerPiece = 284.15m;
                LeverEspagPricePerPiece = 825.81m;
                TiltAndTurnEspag_N110A00006PricePerPiece = 254.39m;
                TiltAndTurnEspag_N110A01006PricePerPiece = 465.89m;
                TiltAndTurnEspag_N110A02206PricePerPiece = 518.40m;
                TiltAndTurnEspag_N110A03206PricePerPiece = 570.91m;
                TiltAndTurnEspag_N110A04206PricePerPiece = 623.42m;
                TiltAndTurnEspag_N110A05206PricePerPiece = 675.18m;
                TiltAndTurnEspag_N110A06206PricePerPiece = 727.69m;

                _2DHingePricePerPiece = 278.94m;
                _3DHingePricePerPiece = 990.95m;
                NTCenterHingePricePerPiece = 170.50m;

                ShootBoltStrikerPricePerPiece = 57.29m;
                ShootBoltReversePricePerPiece = 368.25m;
                ShootBoltNonReversePricePerPiece = 242.71m;

                StrikerPricePerPiece = 57.08m;
                StrikerLRPricePerPiece = 52.01m;//sliding
                StrikerForDMPricePerPiece = 62.27m;
                AdjustableStrikerPricePerPiece = 20.72m;
                LatchDeadboltStrikerPricePerPiece = 446.37m;

                MVDHandlePricePerPiece = 985.01m;
                MVDGearPricePerPiece = 1585.92m;

                Extension_639957PricePerPiece = 170.50m;
                Extension_567639PricePerPiece = 134.04m;
                //Extension_N299A01006PricePerPiece = 118.82m;
                MVDExtensionPricePerPiece = 183.80m;

                HDRollerPricePerPiece = 566.06m;
                GURollerPricePerPiece = 1323.08m;
                MotorizeMechRemotePricePerPiece = 19445.50m;

                #endregion
                #region Accessories
                EndCapPricePerPiece = 282.96m;
                MechanicalJoint_AV585PricePerPiece = 87.34m;
                MechanicalJoint_9U18PricePerPiece = 138.45m;
                GBSpacerPricePerPiece = 5.01m;
                PlasticWedgePricePerPiece = 10.09m;
                BarFastenerPricePerPiece = 4.40m;
                SealingBlockPricePerPiece = 63.75m;
                SpacerFixSashPricePerPiece = 21.42m;

                #endregion
                #region AncillaryProfile
                GlazingGasketPricePerLinearMeter = 32.64m;
                GlazingBeadPricePerLinearMeter = 256.62m;
                GlazingBead_G58PricePerLinearMeter = 117.72m;
                GeorgianBar_0724Price_White = 264.89m;
                GeorgianBar_0724Price_Woodgrain = 312.36m;
                GeorgianBar_0726Price_White = 403.05m;
                GeorgianBar_0726Price_Woodgrain = 467.22m;
                CoverProfile_0914Price = 20.68m;
                CoverProfile_0373Price = 105.41m;
                ThresholdForC70PricePerPiece = 1229.34m;
                ThresholdForPremiPricePerPiece = 1181.84m;
                WeatherBarPricePerPiece = 236.75m;
                GuideTrackPricePerLinearMeter = 157.18m;
                InterlockPricePerPiece = 333.77m;
                ExtensionForInterlockPricePerPiece = 789.01m;
                AluminumTrackPricePerLinearMeter = 251.10m;
                WaterSeepagePricePerLinearMeter = 153.73m;
                AluminumPullHandlePricePerLinearMeter = 2480.18m;

                #endregion
                BrushSealPricePerLinearMeter = 15.80m;
                SealantPricePerCan_BrownBlack = 430m;
                SealantPricePerCan_Clear = 170m;
                PUFoamingPricePerCan = 210m;

                ProfileColorPoints = 0;
                CostingPoints = 0;
                InstallationPoints = 0;
                LaborCost = 0;
                InstallationCost = 0;
                MaterialCost = 0;
                #endregion

                if (cus_ref_date >= inc_price_date_3 && cus_ref_date < inc_price_date_4)
                {
                    // waterseepage
                    WaterSeepagePricePerLinearMeter = 378.47m;
                }
                else if (cus_ref_date >= inc_price_date_4 && cus_ref_date < inc_price_date_5)
                {
                    //Double //Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe 
                    WaterSeepagePricePerLinearMeter = 378.47m;
                    Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe = 6300.00m;
                }
                else if (cus_ref_date >= inc_price_date_5 && cus_ref_date < inc_price_date_6)
                {
                    //frame  baseprice 6052 // divider reinforcement 7536 
                    WaterSeepagePricePerLinearMeter = 378.47m;
                    Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe = 6300.00m;
                    FramePricePerLinearMeter_6052_WoodGrain = 725.02m;//704.60m, 2/22/23
                    FramePricePerLinearMeter_6052_White = 567.15m;//563.48m, 2/22/23
                    DividerRein_7536_PricePerSqrMeter = 406.86m;

                }
                else if (cus_ref_date >= inc_price_date_6 && cus_ref_date < inc_price_date_7)
                {
                    FramePricePerLinearMeter_6052_WoodGrain = 725.02m;//704.60m, 2/22/23
                    FramePricePerLinearMeter_6052_White = 567.15m;//563.48m, 2/22/23
                    FramePricePerLinearMeter_6052_White_1sideFoil = 634.04m;
                    FramePricePerLinearMeter_6052Milled_WoodGrain = 725.02m;
                    FramePricePerLinearMeter_6052Milled_White = 567.15m;
                    FramePricePerLinearMeter_6052Milled_White_1sideFoil = 634.04m;
                    WaterSeepagePricePerLinearMeter = 378.47m;
                    Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe = 6300.00m;
                    FramePricePerLinearMeter_6052_WoodGrain = 725.02m;//704.60m, 2/22/23
                    FramePricePerLinearMeter_6052_White = 567.15m;//563.48m, 2/22/23
                    DividerRein_7536_PricePerSqrMeter = 406.86m;
                }
                else if (cus_ref_date >= inc_price_date_7 && cus_ref_date < inc_price_date_8)
                {
                    FramePricePerLinearMeter_6052_WoodGrain = 725.02m;//704.60m, 2/22/23
                    FramePricePerLinearMeter_6052_White = 567.15m;//563.48m, 2/22/23
                    FramePricePerLinearMeter_6052_White_1sideFoil = 634.04m;
                    FramePricePerLinearMeter_6052Milled_WoodGrain = 725.02m;
                    FramePricePerLinearMeter_6052Milled_White = 567.15m;
                    FramePricePerLinearMeter_6052Milled_White_1sideFoil = 634.04m;
                    WaterSeepagePricePerLinearMeter = 378.47m;
                    Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe = 6300.00m;
                    FramePricePerLinearMeter_6052_WoodGrain = 725.02m;//704.60m, 2/22/23
                    FramePricePerLinearMeter_6052_White = 567.15m;//563.48m, 2/22/23
                    DividerRein_7536_PricePerSqrMeter = 406.86m;

                    MotorizeMechRemotePricePerPiece = 4500.00m;// 19445.50m                    
                }
                else if (cus_ref_date >= inc_price_date_8)
                {
                    FramePricePerLinearMeter_6052_WoodGrain = 725.02m;//704.60m, 2/22/23
                    FramePricePerLinearMeter_6052_White = 567.15m;//563.48m, 2/22/23
                    FramePricePerLinearMeter_6052_White_1sideFoil = 634.04m;
                    FramePricePerLinearMeter_6052Milled_WoodGrain = 725.02m;
                    FramePricePerLinearMeter_6052Milled_White = 567.15m;
                    FramePricePerLinearMeter_6052Milled_White_1sideFoil = 634.04m;
                    WaterSeepagePricePerLinearMeter = 378.47m;
                    Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe = 6300.00m;
                    FramePricePerLinearMeter_6052_WoodGrain = 725.02m;//704.60m, 2/22/23
                    FramePricePerLinearMeter_6052_White = 567.15m;//563.48m, 2/22/23
                    DividerRein_7536_PricePerSqrMeter = 406.86m;

                    MotorizeMechRemotePricePerPiece = 4500.00m;// 19445.50m 
                    Glass_6mmTempClr_HrdCtd_LowE = 2600.00m;//2550.00m
                }
            }

            #region motorized 1 day diff
            if (cus_ref_date < DateTime.Parse("08-02-2023"))
            {
                MotorizeMechUsingRemotePrice = 19500.00m;
            }
            else if (cus_ref_date >= DateTime.Parse("08-02-2023") && cus_ref_date < inc_price_date_7)
            {
                MotorizeMechUsingRemotePrice = 37250.00m;
            }
            else if (cus_ref_date >= inc_price_date_7)
            {
                MotorizeMechUsingRemotePrice = 19500.00m;
            }
            #endregion
        }

        #endregion

        #region changeConditionBaseOnDate 
        DateTime changeCondition_020323 = DateTime.Parse("02-03-2023"); // georgian bar 
        DateTime changeCondition_022323 = DateTime.Parse("02-23-2023"); // single pnl glass ht & wd
        DateTime changeCondition_033023 = DateTime.Parse("03-30-2023"); // for 2d hinge to FS 1pnl
        DateTime changeCondition_040423 = DateTime.Parse("04-04-2023"); // Div_Width => Div_ExplosionWidth , 1pnlFS from 2d hinge => friction stay
        DateTime changeCondition_061423 = DateTime.Parse("06-14-2023"); // friction stay size => art#
        DateTime changeCondition_072023 = DateTime.Parse("07-20-2023"); // points
        DateTime changeCondition_072723 = DateTime.Parse("07-27-2023"); // gb for sliding , gbar multiplier // remove mesh in total price // 1 side foil labor price and approve by costing  
        DateTime changeCondition_080323 = DateTime.Parse("08-03-2023"); // no espag
        DateTime changeCondition_112323 = DateTime.Parse("11-23-2023"); // remove fs in motorize
        DateTime changeCondition_011724 = DateTime.Parse("01-17-2024"); // weatherbar and etc per frame
        DateTime changeCondition_012424 = DateTime.Parse("01-24-2024"); //extension profile




        DateTime testDate = DateTime.Parse("01-24-2024");

        #endregion

        #region glassbasedprice variable
        //List<int> glassidholder = new List<int>();

        //decimal[] mp_arr1 = new decimal[20];
        //decimal[] mp_arr2 = new decimal[20];
        //decimal[] mp_arr3 = new decimal[20];
        //decimal[] mp_arr4 = new decimal[20];
        //decimal[] mp_arr5 = new decimal[20];
        //decimal[] mp_arr6 = new decimal[20];
        //decimal[] mp_arr7 = new decimal[20];

        //decimal
        //iterator = 1;
        //int indexer = 0;
        //int curr_mpaneID = 0;
        #endregion

        public DataTable ItemCostingPriceAndPoints()
        {
            lstTotalPrice = new List<decimal>();
            //lst_TotalPriceHistory = new List<string>();

            DataTable Price_List = new DataTable();
            Price_List.Columns.Add(CreateColumn("Description", "Description", "System.String"));
            Price_List.Columns.Add(CreateColumn("Base Price", "Base Price", "System.String"));
            Price_List.Columns.Add(CreateColumn("Nett", "Nett", "System.String"));
            Price_List.Columns.Add(CreateColumn("Mark-up", "Mark-up", "System.String"));
            Price_List.Columns.Add(CreateColumn("Subtotal", "Subtotal", "System.String"));
            Price_List.Columns.Add(CreateColumn("Filter", "Filter", "System.String"));

            changePriceBasedonDate();

            foreach (IWindoorModel wdm in Lst_Windoor)
            {

                //if (BOMandItemlistStatus == "PriceItemList")
                //{
                //    wdm.WD_Selected = true;
                //}

                if (wdm.WD_Selected == true || BOMandItemlistStatus == "PriceItemList") //|| FactorChange == true
                {

                    foreach (IFrameModel fr in wdm.lst_frame)
                    {
                        #region baseOnDimensionAndColorPointsif 
                        if (((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                           (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None)) &&
                           wdm.WD_BaseColor == Base_Color._White)
                        {
                            OneSideFoil_whiteBase = true;
                        }

                        if (fr.Frame_ArtNo != FrameProfile_ArticleNo._6050 &&
                            fr.Frame_ArtNo != FrameProfile_ArticleNo._6052 &&
                            fr.Frame_ArtNo != FrameProfile_ArticleNo._2060)
                        {
                            if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                            {
                                ProfileColorPoints = 13;

                                if (fr.Frame_Width >= 2000)
                                {
                                    ProfileColorPoints = 16;
                                }
                                else if (fr.Frame_Height >= 2000)
                                {
                                    ProfileColorPoints = 16;
                                }
                                else if (fr.Frame_Width >= 3000)
                                {
                                    ProfileColorPoints = 18;
                                }
                                else if (fr.Frame_Height >= 3000)
                                {
                                    ProfileColorPoints = 18;
                                }

                                if (cus_ref_date >= changeCondition_072023)
                                {
                                    if (fr.Frame_Width >= 3000 || fr.Frame_Height >= 3000)
                                    {
                                        ProfileColorPoints = 18;
                                    }
                                    else if (fr.Frame_Width >= 2000 || fr.Frame_Height >= 2000)
                                    {
                                        ProfileColorPoints = 16;
                                    }
                                }

                                if (OneSideFoil_whiteBase == true)
                                {
                                    ProfileColorPoints += 1;
                                }

                                //CostingPoints += ProfileColorPoints * 4;
                                //InstallationPoints += (ProfileColorPoints / 3) * 4;
                            }
                            else if (wdm.WD_BaseColor == Base_Color._DarkBrown)
                            {
                                ProfileColorPoints = 14;
                                if (fr.Frame_Width >= 2000)
                                {
                                    ProfileColorPoints = 18;
                                }
                                else if (fr.Frame_Height >= 2000)
                                {
                                    ProfileColorPoints = 18;
                                }
                                else if (fr.Frame_Width >= 3000)
                                {
                                    ProfileColorPoints = 19;
                                }
                                else if (fr.Frame_Height >= 3000)
                                {
                                    ProfileColorPoints = 19;
                                }

                                if (cus_ref_date >= changeCondition_072023)
                                {
                                    if (fr.Frame_Width >= 3000 || fr.Frame_Height >= 3000)
                                    {
                                        ProfileColorPoints = 19;
                                    }
                                    else if (fr.Frame_Width >= 2000 || fr.Frame_Height >= 2000)
                                    {
                                        ProfileColorPoints = 18;
                                    }
                                }
                            }
                        }
                        else if (fr.Frame_ArtNo == FrameProfile_ArticleNo._6050)
                        {
                            if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                            {
                                ProfileColorPoints = 16;

                                if (fr.Frame_Width >= 5000 || fr.Frame_Height >= 5000)
                                {
                                    ProfileColorPoints = 19;
                                }
                            }
                            else if (wdm.WD_BaseColor == Base_Color._DarkBrown || OneSideFoil_whiteBase == true)
                            {
                                ProfileColorPoints = 18;

                                if (fr.Frame_Width >= 5000 || fr.Frame_Height >= 5000)
                                {
                                    ProfileColorPoints = 21;
                                }
                            }
                        }
                        else if (fr.Frame_ArtNo == FrameProfile_ArticleNo._6052)
                        {
                            if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                            {
                                //ProfileColorPoints = 49;
                                ProfileColorPoints = 34;

                                if (fr.Frame_Width >= 5000 || fr.Frame_Height >= 5000)
                                {
                                    ProfileColorPoints = 37;
                                }
                            }
                            else if (wdm.WD_BaseColor == Base_Color._DarkBrown || OneSideFoil_whiteBase == true)
                            {
                                //ProfileColorPoints = 51;
                                ProfileColorPoints = 37;

                                if (fr.Frame_Width >= 5000 || fr.Frame_Height >= 5000)
                                {
                                    ProfileColorPoints = 40;
                                }
                            }
                        }
                        else if (fr.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                        {
                            if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                            {
                                ProfileColorPoints = 11;

                                if (fr.Frame_Width >= 2000)
                                {
                                    ProfileColorPoints = 14;
                                }
                                else if (fr.Frame_Height >= 2000)
                                {
                                    ProfileColorPoints = 14;
                                }
                                else if (fr.Frame_Width >= 3000)
                                {
                                    ProfileColorPoints = 16;
                                }
                                else if (fr.Frame_Height >= 3000)
                                {
                                    ProfileColorPoints = 16;
                                }

                                if (cus_ref_date >= changeCondition_072023)
                                {
                                    if (fr.Frame_Width >= 3000 || fr.Frame_Height >= 3000)
                                    {
                                        ProfileColorPoints = 16;
                                    }
                                    else if (fr.Frame_Width >= 2000 || fr.Frame_Height >= 2000)
                                    {
                                        ProfileColorPoints = 14;
                                    }
                                }

                                if (OneSideFoil_whiteBase == true)
                                {
                                    ProfileColorPoints += 1;
                                }

                                //CostingPoints += ProfileColorPoints * 4;
                                //InstallationPoints += (ProfileColorPoints / 3) * 4;
                            }
                            else if (wdm.WD_BaseColor == Base_Color._DarkBrown)
                            {
                                ProfileColorPoints = 12;
                                if (fr.Frame_Width >= 2000)
                                {
                                    ProfileColorPoints = 16;
                                }
                                else if (fr.Frame_Height >= 2000)
                                {
                                    ProfileColorPoints = 16;
                                }
                                else if (fr.Frame_Width >= 3000)
                                {
                                    ProfileColorPoints = 17;
                                }
                                else if (fr.Frame_Height >= 3000)
                                {
                                    ProfileColorPoints = 17;
                                }

                                if (cus_ref_date >= changeCondition_072023)
                                {
                                    if (fr.Frame_Width >= 3000 || fr.Frame_Height >= 3000)
                                    {
                                        ProfileColorPoints = 17;
                                    }
                                    else if (fr.Frame_Width >= 2000 || fr.Frame_Height >= 2000)
                                    {
                                        ProfileColorPoints = 16;
                                    }
                                }
                            }
                        }
                        CostingPoints += ProfileColorPoints * 4;
                        InstallationPoints += (ProfileColorPoints / 3) * 4;

                        #endregion

                        #region FramePrice
                        FramePerimeter = (fr.Frame_Height + fr.Frame_Width) * 2;

                        if (fr.Frame_ArtNo == FrameProfile_ArticleNo._7502)
                        {
                            if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                            {
                                FramePricePerLinearMeter = FramePricePerLinearMeter_7502_White;
                                if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                    (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                {
                                    FramePricePerLinearMeter = FramePricePerLinearMeter_7502_White_1sideFoil;
                                }
                            }
                            else
                            {
                                FramePricePerLinearMeter = FramePricePerLinearMeter_7502_WoodGrain;
                            }
                            FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_7502;
                        }
                        else if (fr.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                        {
                            if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                            {
                                FramePricePerLinearMeter = FramePricePerLinearMeter_7507_White;
                                if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                    (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                {
                                    FramePricePerLinearMeter = FramePricePerLinearMeter_7507_White_1sideFoil;
                                }
                            }
                            else
                            {
                                FramePricePerLinearMeter = FramePricePerLinearMeter_7507_WoodGrain;
                            }
                            FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_7507;
                        }
                        else if (fr.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                        {

                            FramePricePerLinearMeter = FramePricePerLinearMeter_2060_White;
                            FrameReinPricePerLinearMeter = G58ReinPricePerLinearMeter_V226;
                            GlazingGasketPrice += (FramePerimeter / 1000m) * GlazingGasketPricePerLinearMeter;
                        }
                        else if (fr.Frame_ArtNo == FrameProfile_ArticleNo._6050)
                        {
                            if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                            {
                                FramePricePerLinearMeter = FramePricePerLinearMeter_6050_White;
                            }
                            else
                            {
                                FramePricePerLinearMeter = FramePricePerLinearMeter_6050_WoodGrain;
                            }
                            FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_6050;
                        }
                        else if (fr.Frame_ArtNo == FrameProfile_ArticleNo._6052)
                        {
                            if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                            {
                                FramePricePerLinearMeter = FramePricePerLinearMeter_6052_White;
                            }
                            else
                            {
                                FramePricePerLinearMeter = FramePricePerLinearMeter_6052_WoodGrain;
                            }
                            FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_6052;
                        }

                        FramePrice += (FramePerimeter / 1000m) * FramePricePerLinearMeter;
                        FrameReinPrice += (FramePerimeter / 1000m) * FrameReinPricePerLinearMeter;
                        #endregion

                        #region 3RailsForPremi
                        if (fr.Frame_SlidingRailsQtyVisibility == true)
                        {
                            if (fr.Frame_SlidingRailsQty == 3)
                            {
                                if (fr.Frame_ArtNo == FrameProfile_ArticleNo._6050)
                                {
                                    if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                    {
                                        FramePricePerLinearMeter = FramePricePerLinearMeter_6055_White;
                                    }
                                    else
                                    {
                                        FramePricePerLinearMeter = FramePricePerLinearMeter_6055_WoodGrain;
                                    }
                                    FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_6055;
                                }
                                else if (fr.Frame_ArtNo == FrameProfile_ArticleNo._6052)
                                {
                                    if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                    {
                                        FramePricePerLinearMeter = FramePricePerLinearMeter_6052Milled_White;
                                    }
                                    else
                                    {
                                        FramePricePerLinearMeter = FramePricePerLinearMeter_6052Milled_WoodGrain;
                                    }
                                    FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_6052;
                                }

                                FramePrice += (FramePerimeter / 1000m) * FramePricePerLinearMeter;
                                FrameReinPrice += (FramePerimeter / 1000m) * FrameReinPricePerLinearMeter;
                            }
                        }
                        #endregion

                        #region additionalFrameForScreen
                        if (fr.Frame_ScreenOption == true)
                        {
                            if (fr.Frame_ArtNo == FrameProfile_ArticleNo._6050)
                            {
                                if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                {
                                    FramePricePerLinearMeter = FramePricePerLinearMeter_6055_White;
                                }
                                else
                                {
                                    FramePricePerLinearMeter = FramePricePerLinearMeter_6055_WoodGrain;
                                }
                                FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_6055;
                            }
                            else if (fr.Frame_ArtNo == FrameProfile_ArticleNo._6052)
                            {
                                if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                {
                                    FramePricePerLinearMeter = FramePricePerLinearMeter_6052Milled_White;
                                }
                                else
                                {
                                    FramePricePerLinearMeter = FramePricePerLinearMeter_6052Milled_WoodGrain;
                                }
                                FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_6052;
                            }

                            if (fr.Frame_ScreenHeightOption == true)
                            {
                                FramePrice += (FramePerimeter / 1000m) * FramePricePerLinearMeter;
                                FrameReinPrice += (FramePerimeter / 1000m) * FrameReinPricePerLinearMeter;
                            }
                            else
                            {
                                FramePrice += ((fr.Frame_Width * 2) / 1000m) * FramePricePerLinearMeter;
                                FrameReinPrice += ((fr.Frame_Width * 2) / 1000m) * FrameReinPricePerLinearMeter;
                            }
                        }
                        #endregion

                        #region ExtensionProfile
                        if ((fr.Frame_ArtNo == FrameProfile_ArticleNo._6050 || fr.Frame_ArtNo == FrameProfile_ArticleNo._6052) &&
                            fr.Frame_Width > 6000)
                        {
                            if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                            {
                                ExtensionProfile15mmPricePerLinearMeter = ExtensionProfile15mmPricePerLinearMeter_White;
                            }
                            else
                            {
                                ExtensionProfile15mmPricePerLinearMeter = ExtensionProfile15mmPricePerLinearMeter_WoodGrain;
                            }

                            ExtensionProfile15mmPrice += (fr.Frame_Width / 1000m) * ExtensionProfile15mmPricePerLinearMeter;
                        }

                        if (changeCondition_012424 <= cus_ref_date)
                        {
                            if ((fr.Frame_ArtNo == FrameProfile_ArticleNo._7502 || fr.Frame_ArtNo == FrameProfile_ArticleNo._7507 || fr.Frame_ArtNo == FrameProfile_ArticleNo._2060) &&
                            fr.Frame_Width > 6000)
                            {
                                if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                {
                                    ExtensionProfile15mmPricePerLinearMeter = ExtensionProfile15mmPricePerLinearMeter_White;
                                }
                                else
                                {
                                    ExtensionProfile15mmPricePerLinearMeter = ExtensionProfile15mmPricePerLinearMeter_WoodGrain;
                                }

                                ExtensionProfile15mmPrice += (fr.Frame_Width / 1000m) * ExtensionProfile15mmPricePerLinearMeter;
                            }
                        }
                        #endregion

                        #region Tubular
                        if (fr.Frame_TubularVisibility == true)
                        {
                            TubularPrice += ((fr.Frame_TubularWidth / 1000m) * TubularPricePerLinearMeter) + ((fr.Frame_TubularHeight / 1000m) * TubularPricePerLinearMeter);
                        }
                        #endregion

                        #region SealantPrice 
                        Frame_SealantWHQty_Total = (int)Math.Ceiling((decimal)((fr.Frame_Width * 2) + (fr.Frame_Height * 2)) / 3570);

                        if ((wdm.WD_BaseColor == Base_Color._Ivory || wdm.WD_BaseColor == Base_Color._White) && OneSideFoil_whiteBase == false)
                        {
                            SealantPricePerCan = SealantPricePerCan_Clear;
                        }
                        else if (wdm.WD_BaseColor == Base_Color._DarkBrown || OneSideFoil_whiteBase == true)
                        {
                            SealantPricePerCan = SealantPricePerCan_BrownBlack;
                        }
                        SealantPrice += Frame_SealantWHQty_Total * SealantPricePerCan;
                        #endregion 

                        #region bottomFramePrice
                        if (fr.Frame_BotFrameVisible == true &&
                            (fr.Frame_BotFrameArtNo != BottomFrameTypes._7507 &&
                             fr.Frame_BotFrameArtNo != BottomFrameTypes._6052))
                        {
                            FramePrice -= (fr.Frame_Width / 1000m) * FramePricePerLinearMeter;
                            FrameReinPrice -= (fr.Frame_Width / 1000m) * FrameReinPricePerLinearMeter;

                            if (fr.Frame_BotFrameArtNo == BottomFrameTypes._7789)
                            {
                                ThresholdPrice += (fr.Frame_Width / 1000m) * ThresholdForC70PricePerPiece;
                                FrameThresholdPricePerLinearMeter = ThresholdForC70PricePerPiece;
                            }
                            else if (fr.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                                     fr.Frame_BotFrameArtNo == BottomFrameTypes._A166)
                            {
                                ThresholdPrice += (fr.Frame_Width / 1000m) * ThresholdForPremiPricePerPiece;
                                FrameThresholdPricePerLinearMeter = ThresholdForPremiPricePerPiece;
                            }
                            else if (fr.Frame_BotFrameArtNo == BottomFrameTypes._None)
                            {
                                // do nothing
                            }
                            else
                            {
                                if (fr.Frame_BotFrameArtNo == BottomFrameTypes._7502)
                                {
                                    if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                    {
                                        FramePricePerLinearMeter = FramePricePerLinearMeter_7502_White;

                                        if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                            (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                        {
                                            FramePricePerLinearMeter = FramePricePerLinearMeter_7502_White_1sideFoil;
                                        }
                                    }
                                    else
                                    {
                                        FramePricePerLinearMeter = FramePricePerLinearMeter_7502_WoodGrain;
                                    }
                                    FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_7502;
                                }
                                else if (fr.Frame_BotFrameArtNo == BottomFrameTypes._7507)
                                {
                                    if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                    {
                                        FramePricePerLinearMeter = FramePricePerLinearMeter_7507_White;
                                        if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                            (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                        {
                                            FramePricePerLinearMeter = FramePricePerLinearMeter_7507_White_1sideFoil;
                                        }
                                    }
                                    else
                                    {
                                        FramePricePerLinearMeter = FramePricePerLinearMeter_7507_WoodGrain;
                                    }
                                    FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_7507;
                                }
                                else if (fr.Frame_BotFrameArtNo == BottomFrameTypes._6050)
                                {
                                    if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                    {
                                        FramePricePerLinearMeter = FramePricePerLinearMeter_6050_White;
                                    }
                                    else
                                    {
                                        FramePricePerLinearMeter = FramePricePerLinearMeter_6050_WoodGrain;
                                    }
                                    FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_6050;
                                }
                                else if (fr.Frame_BotFrameArtNo == BottomFrameTypes._6052)
                                {
                                    if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                    {
                                        FramePricePerLinearMeter = FramePricePerLinearMeter_6052_White;
                                    }
                                    else
                                    {
                                        FramePricePerLinearMeter = FramePricePerLinearMeter_6052_WoodGrain;
                                    }
                                    FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_6052;
                                }

                                FramePrice += (fr.Frame_Width / 1000m) * FramePricePerLinearMeter;
                                FrameReinPrice += (fr.Frame_Width / 1000m) * FrameReinPricePerLinearMeter;
                            }

                        }
                        #endregion

                        if (fr.Frame_ArtNo == FrameProfile_ArticleNo._7502)
                        {
                            ChckPlasticWedge = true;
                        }
                        else
                        {
                            ChckPlasticWedge = false;
                        }
                        chckPerFrameMotorMech = true;
                        chckPerFrameSlidingMats = true;
                        PUFoamingPrice += Frame_PUFoamingQty_Total * PUFoamingPricePerCan;

                        #region MultiPnl 
                        if (fr.Lst_MultiPanel.Count() >= 1 && fr.Lst_Panel.Count() == 0)//multi pnl
                        {
                            foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                            {
                                foreach (IDividerModel div in mpnl.MPanelLst_Divider)
                                {
                                    //CostingPoints -= 2 * ProfileColorPoints;
                                    //InstallationPoints -= 2 * ProfileColorPoints;

                                    #region Cladding
                                    if (div.Div_CladdingSizeList != null)
                                    {
                                        foreach (int cladding_size in div.Div_CladdingSizeList.Values)
                                        {
                                            claddingPrice += (cladding_size / 1000m) * claddingPricePerLinearMeter;
                                        }
                                    }
                                    #endregion

                                    #region Transom/MullionAndMechJointPrice 
                                    if (mpnl.MPanel_DividerEnabled == true)
                                    {
                                        if (mpnl.MPanel_Type == "Transom")
                                        {
                                            BOM_divDesc = "Transom";
                                            if (div.Div_ArtNo == Divider_ArticleNo._7536)
                                            {
                                                DividerPricePerSqrMeter = Divider_7536_PricePerSqrMeter;
                                                DividerReinPricePerSqrMeter = DividerRein_7536_PricePerSqrMeter;
                                                MechanicalJointPricePerPiece = MechanicalJoint_9U18PricePerPiece;
                                            }
                                            else if (div.Div_ArtNo == Divider_ArticleNo._7538)
                                            {
                                                DividerPricePerSqrMeter = Divider_7538_PricePerSqrMeter;
                                                DividerReinPricePerSqrMeter = DividerRein_7538_PricePerSqrMeter;
                                                MechanicalJointPricePerPiece = MechanicalJoint_AV585PricePerPiece;
                                            }
                                            else if (div.Div_ArtNo == Divider_ArticleNo._2069)
                                            {
                                                DividerPricePerSqrMeter = Divider_2069_PricePerSqrMeter;
                                                DividerReinPricePerSqrMeter = G58ReinPricePerLinearMeter_V226;
                                                MechanicalJointPricePerPiece = MechanicalJoint_9U18PricePerPiece; // for the meantime
                                            }
                                            else if (div.Div_ArtNo == Divider_ArticleNo._6052)
                                            {
                                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                                {
                                                    DividerPricePerSqrMeter = FramePricePerLinearMeter_6052_White;
                                                }
                                                else
                                                {
                                                    DividerPricePerSqrMeter = FramePricePerLinearMeter_6052_WoodGrain;
                                                }
                                                DividerReinPricePerSqrMeter = FrameReinPricePerLinearMeter_6052;
                                            }

                                            if (cus_ref_date <= changeCondition_040423)
                                            {
                                                DivPrice += ((div.Div_Width) / 1000m) * DividerPricePerSqrMeter;
                                            }
                                            else
                                            {
                                                DivPrice += ((div.Div_ExplosionWidth) / 1000m) * DividerPricePerSqrMeter;
                                            }
                                            DivReinPrice += ((div.Div_ReinfWidth) / 1000m) * DividerReinPricePerSqrMeter;
                                            MechJointPrice += MechanicalJointPricePerPiece * 2;
                                        }
                                        else if (mpnl.MPanel_Type == "Mullion")
                                        {
                                            if (div.Div_ChkDM == true)
                                            {
                                                #region DM_Endcap_SBoltStriker_Price
                                                if (div.Div_DMArtNo == DummyMullion_ArticleNo._7533)
                                                {
                                                    if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                                    {
                                                        DummyMullionPricePerLinearMeter = DummyMullionPricePerLinearMeter_7533_White;
                                                    }
                                                    else
                                                    {
                                                        DummyMullionPricePerLinearMeter = DummyMullionPricePerLinearMeter_7533_WoodGrain;
                                                    }
                                                }
                                                else if (div.Div_DMArtNo == DummyMullion_ArticleNo._385P)
                                                {
                                                    if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                                    {
                                                        DummyMullionPricePerLinearMeter = DummyMullionPricePerLinearMeter_385_White;
                                                    }
                                                    else
                                                    {
                                                        DummyMullionPricePerLinearMeter = DummyMullionPricePerLinearMeter_385_WoodGrain;
                                                    }
                                                    ShootBoltStrikerPrice += ShootBoltStrikerPricePerPiece;
                                                    ShootBoltReversePrice += ShootBoltReversePricePerPiece;
                                                    ShootBoltNonReversePrice += ShootBoltNonReversePricePerPiece * 3;
                                                }

                                                DMPrice += (div.Div_Height / 1000m) * DummyMullionPricePerLinearMeter;
                                                DMReinforcementPrice += (div.Div_Height / 1000m) * FrameReinPricePerLinearMeter_7502;

                                                ChckDM = true;
                                                EndCapPrice += EndCapPricePerPiece * 2;
                                                #endregion
                                            }
                                            else
                                            {
                                                #region Mullion


                                                ChckDM = false;

                                                BOM_divDesc = "Mullion";
                                                if (div.Div_ArtNo == Divider_ArticleNo._7536)
                                                {
                                                    DividerPricePerSqrMeter = Divider_7536_PricePerSqrMeter;
                                                    DividerReinPricePerSqrMeter = DividerRein_7536_PricePerSqrMeter;
                                                    MechanicalJointPricePerPiece = MechanicalJoint_9U18PricePerPiece;
                                                }

                                                else if (div.Div_ArtNo == Divider_ArticleNo._7538)
                                                {
                                                    DividerPricePerSqrMeter = Divider_7538_PricePerSqrMeter;
                                                    DividerReinPricePerSqrMeter = DividerRein_7538_PricePerSqrMeter;
                                                    MechanicalJointPricePerPiece = MechanicalJoint_AV585PricePerPiece;
                                                }
                                                else if (div.Div_ArtNo == Divider_ArticleNo._2069)
                                                {
                                                    DividerPricePerSqrMeter = Divider_2069_PricePerSqrMeter;
                                                    DividerReinPricePerSqrMeter = G58ReinPricePerLinearMeter_V226;
                                                    MechanicalJointPricePerPiece = MechanicalJoint_9U18PricePerPiece; // for the meantime
                                                }
                                                else if (div.Div_ArtNo == Divider_ArticleNo._6052)
                                                {
                                                    if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                                    {
                                                        DividerPricePerSqrMeter = FramePricePerLinearMeter_6052_White;
                                                    }
                                                    else
                                                    {
                                                        DividerPricePerSqrMeter = FramePricePerLinearMeter_6052_WoodGrain;
                                                    }
                                                    DividerReinPricePerSqrMeter = FrameReinPricePerLinearMeter_6052;
                                                }

                                                if (cus_ref_date <= changeCondition_040423)
                                                {
                                                    DivPrice += ((div.Div_Height) / 1000m) * DividerPricePerSqrMeter;
                                                }
                                                else
                                                {
                                                    DivPrice += ((div.Div_ExplosionHeight) / 1000m) * DividerPricePerSqrMeter;
                                                }

                                                DivReinPrice += ((div.Div_ReinfHeight) / 1000m) * DividerReinPricePerSqrMeter;
                                                MechJointPrice += MechanicalJointPricePerPiece * 2;
                                                #endregion
                                            }
                                        }

                                    }
                                    #endregion

                                    #region LeverEspagPrice
                                    if (div.Div_LeverEspagVisibility == true)
                                    {
                                        LeverEspagPrice += LeverEspagPricePerPiece;
                                    }
                                    #endregion

                                }
                                foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                                {
                                    if (pnl.Panel_SashPropertyVisibility == true)
                                    {
                                        #region Casement 
                                        if (pnl.Panel_Type.Contains("Casement"))
                                        {
                                            if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                            {
                                                MiddleCLoserPrice += MiddleCLoserPricePerPiece * pnl.Panel_MiddleCloserPairQty;

                                                if (pnl.Panel_HingeOptions == HingeOption._2DHinge)
                                                {
                                                    _2DHingePrice += _2DHingePricePerPiece * pnl.Panel_2DHingeQty_nonMotorized;
                                                }
                                                else if (pnl.Panel_HingeOptions == HingeOption._FrictionStay)
                                                {
                                                    if (pnl.Panel_MotorizedOptionVisibility == true && cus_ref_date >= changeCondition_112323)
                                                    {
                                                        //remove fs in motorize
                                                    }
                                                    else
                                                    {
                                                        if (cus_ref_date <= changeCondition_061423)
                                                        {
                                                            if (pnl.Panel_SashHeight >= 800)
                                                            {
                                                                FSPrice += FS_26HD_casementPricePerPiece * 2;
                                                                FSBasePrice = FS_26HD_casementPricePerPiece;
                                                            }
                                                            else
                                                            {
                                                                FSPrice += FS_16HD_casementPricePerPiece * 2;
                                                                FSBasePrice = FS_16HD_casementPricePerPiece;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._20HD)
                                                            {
                                                                FSPrice += FS_26HD_casementPricePerPiece * 2;
                                                                FSBasePrice = FS_26HD_casementPricePerPiece;
                                                            }
                                                            else if (pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._10HD ||
                                                                     pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._12FS ||
                                                                     pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._12HD ||
                                                                     pnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._16HD)
                                                            {
                                                                FSPrice += FS_16HD_casementPricePerPiece * 2;
                                                                FSBasePrice = FS_16HD_casementPricePerPiece;
                                                            }
                                                        }


                                                    }
                                                }

                                                if (pnl.Panel_ExtensionOptionsVisibility == true &&
                                                    pnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._None ||
                                                     pnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._None ||
                                                     pnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._None ||
                                                     pnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._None)
                                                {
                                                    if (pnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._630956 ||
                                                        pnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._630956 ||
                                                        pnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._630956 ||
                                                        pnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._630956)
                                                    {
                                                        ExtensionPrice += Extension_639957PricePerPiece;
                                                        ExtensionBasePrice = Extension_639957PricePerPiece;
                                                    }
                                                }

                                                if (pnl.Panel_HandleOptionsVisibility == true)
                                                {
                                                    if (pnl.Panel_HandleType == Handle_Type._Rotoswing)
                                                    {
                                                        HandlePrice += RotoswingHanldePricePerPiece;
                                                        HandleBasePrice = RotoswingHanldePricePerPiece;
                                                    }
                                                    else if (pnl.Panel_HandleType == Handle_Type._Rotary)
                                                    {
                                                        //wlang price ng rotaty 
                                                    }
                                                }
                                            }
                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374 || pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                            {
                                                #region Handle
                                                if (pnl.Panel_HandleOptionsVisibility == true)
                                                {
                                                    if (pnl.Panel_HandleType == Handle_Type._MVD)
                                                    {
                                                        HandlePrice += MVDHandlePricePerPiece;

                                                        LatchDeadboltStrikerPrice += LatchDeadboltStrikerPricePerPiece;
                                                        HandleBasePrice = MVDHandlePricePerPiece;

                                                    }
                                                    else if (pnl.Panel_HandleType == Handle_Type._Rio)
                                                    {
                                                        HandlePrice += RioHandlePricePerPiece;

                                                        HandleBasePrice = RioHandlePricePerPiece;
                                                    }
                                                    else if (pnl.Panel_HandleType == Handle_Type._Rotoline)
                                                    {
                                                        //wlang presyo ng rotoline
                                                    }
                                                }
                                                #endregion

                                                #region ExtensionPrice

                                                if (pnl.Panel_ExtensionOptionsVisibility == true &&
                                                    pnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._None ||
                                                    pnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._None ||
                                                    pnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._None ||
                                                    pnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._None)
                                                {
                                                    if (pnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._630956 ||
                                                        pnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._630956 ||
                                                        pnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._630956 ||
                                                        pnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._630956)
                                                    {
                                                        ExtensionPrice += MVDExtensionPricePerPiece;
                                                        ExtensionBasePrice = MVDExtensionPricePerPiece;
                                                    }
                                                    else if (pnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._630956 ||
                                                             pnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._630956 ||
                                                             pnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._630956 ||
                                                             pnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._630956)
                                                    {
                                                        ExtensionPrice += Extension_567639PricePerPiece;
                                                        ExtensionBasePrice = Extension_567639PricePerPiece;
                                                    }
                                                }
                                                #endregion

                                                if (ChckDM == true)
                                                {
                                                    StrikerPrice += AdjustableStrikerPricePerPiece * pnl.Panel_AdjStrikerQty;
                                                }

                                                RestrictorStayPrice += RestrictorStayPricePerPiece * 2;

                                                _35mmBacksetEspagWithCylinderPrice += _35mmBacksetEspagWithCylinder;

                                                _3DHingePrice += _3DHingePricePerPiece * pnl.Panel_3dHingeQty;
                                            }
                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                            {
                                                if (pnl.Panel_CenterHingeOptionsVisibility == true)
                                                {
                                                    if (pnl.Panel_CenterHingeOptions == CenterHingeOption._NTCenterHinge)
                                                    {
                                                        NTCenterHingePrice += NTCenterHingePricePerPiece;
                                                    }
                                                    else if (pnl.Panel_CenterHingeOptions == CenterHingeOption._MiddleCloser)
                                                    {
                                                        MiddleCLoserPrice += MiddleCLoserPricePerPiece * pnl.Panel_MiddleCloserPairQty;
                                                    }
                                                }

                                                if (pnl.Panel_HandleOptionsVisibility == true)
                                                {
                                                    if (pnl.Panel_HandleType == Handle_Type._Rotoswing)
                                                    {
                                                        HandlePrice += RotoswingHanldePricePerPiece;

                                                        HandleBasePrice = RotoswingHanldePricePerPiece;
                                                    }
                                                }

                                                StayBearingPrice += StayBearingPricePerPiece * 2;
                                                StayBearingPinPrice += StayBearingPinPricePerPiece * 2;
                                                TopCornerHingePrice += TopCornerHingePricePerPiece;
                                                CornerPivotRestPrice += CornerPivotRestPricePerPiece;
                                                CoverStayBearingPrice += CoverStayBearingPricePerPiece;
                                                CoverCornerHingePrice += CoverCornerHingePricePerPiece;
                                                CorverCornerPivotRestPrice += CorverCornerPivotRestPricePerPiece;
                                                CorverCornerPivotRestVerticalPrice += CorverCornerPivotRestVerticalPricePerPiece;
                                            }
                                            else if (pnl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                            {
                                                SnapInKeepPrice += SnapInKeepPricePerPiece * 2;
                                            }

                                            if (pnl.Panel_CornerDriveOptionsVisibility == true &&
                                                pnl.Panel_CornerDriveArtNo != CornerDrive_ArticleNo._None &&
                                                pnl.Panel_CornerDriveArtNo != null)
                                            {
                                                CornerDrivePrice += CornerDrivePricePerPiece * 2;
                                            }

                                            if (wdm.WD_profile == "PremiLine Profile" &&
                                                                                        (fr.Frame_ArtNo == FrameProfile_ArticleNo._6052 ||
                                                                                        fr.Frame_ArtNo == FrameProfile_ArticleNo._6050))
                                            {
                                                if (pnl.Panel_Overlap_Sash != OverlapSash._None)
                                                {
                                                    int bothOverlapQtyMultiplier = 1;
                                                    if (pnl.Panel_Overlap_Sash == OverlapSash._Both)
                                                    {
                                                        bothOverlapQtyMultiplier = 2;
                                                    }

                                                    InterlockPrice += (2 * bothOverlapQtyMultiplier) * InterlockPricePerPiece;
                                                    ExtensionForInterlockPrice += (2 * bothOverlapQtyMultiplier) * ExtensionForInterlockPricePerPiece;
                                                    SealingBlockPrice += (2 * bothOverlapQtyMultiplier) * SealingBlockPricePerPiece;
                                                }
                                            }
                                        }
                                        #endregion
                                        #region Awning
                                        else if (pnl.Panel_Type.Contains("Awning"))
                                        {

                                            if (pnl.Panel_HingeOptions == HingeOption._2DHinge || pnl.Panel_LouverMotorizeCheck == true)
                                            {
                                                _2DHingePrice += _2DHingePricePerPiece * pnl.Panel_2DHingeQty_nonMotorized;
                                            }
                                            else if (cus_ref_date < changeCondition_033023)
                                            {
                                                #region FSPrice
                                                if (pnl.Panel_SashHeight >= 800)
                                                {
                                                    FSPrice += FS_26HD_casementPricePerPiece * 2;
                                                    FSBasePrice = FS_26HD_casementPricePerPiece;
                                                }
                                                else
                                                {
                                                    FSPrice += FS_16HD_casementPricePerPiece * 2;
                                                    FSBasePrice = FS_16HD_casementPricePerPiece;
                                                }
                                                #endregion
                                            }
                                            else if (cus_ref_date > changeCondition_033023 &&
                                                     cus_ref_date <= changeCondition_040423)
                                            {
                                                if (pnl.Panel_HingeOptions == HingeOption._2DHinge)
                                                {
                                                    if (cus_ref_date <= changeCondition_061423)
                                                    {
                                                        #region FSPrice
                                                        if (pnl.Panel_SashHeight >= 800)
                                                        {
                                                            FSPrice += FS_26HD_casementPricePerPiece * 2;
                                                            FSBasePrice = FS_26HD_casementPricePerPiece;
                                                        }
                                                        else
                                                        {
                                                            FSPrice += FS_16HD_casementPricePerPiece * 2;
                                                            FSBasePrice = FS_16HD_casementPricePerPiece;
                                                        }
                                                        #endregion
                                                    }
                                                    else
                                                    {
                                                        #region FSPrice
                                                        if (pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm22 ||
                                                            pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm26)
                                                        {
                                                            FSPrice += FS_26HD_casementPricePerPiece * 2;
                                                            FSBasePrice = FS_26HD_casementPricePerPiece;

                                                            if (pnl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                                            {
                                                                SnapInKeepPrice += SnapInKeepPricePerPiece * 2;
                                                            }
                                                        }
                                                        else if (pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm8 ||
                                                                 pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._10HD ||
                                                                 pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._12HD ||
                                                                 pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._16HD)
                                                        {
                                                            FSPrice += FS_16HD_casementPricePerPiece * 2;
                                                            FSBasePrice = FS_16HD_casementPricePerPiece;
                                                        }
                                                        #endregion
                                                    }

                                                }
                                            }
                                            else if (pnl.Panel_HingeOptions == HingeOption._FrictionStay)
                                            {
                                                if (pnl.Panel_MotorizedOptionVisibility == true && cus_ref_date >= changeCondition_112323)
                                                {
                                                    //remove fs in motorize
                                                }
                                                else
                                                {
                                                    if (cus_ref_date <= changeCondition_061423)
                                                    {
                                                        #region FSPrice
                                                        if (pnl.Panel_SashHeight >= 800)
                                                        {
                                                            FSPrice += FS_26HD_casementPricePerPiece * 2;
                                                            FSBasePrice = FS_26HD_casementPricePerPiece;
                                                        }
                                                        else
                                                        {
                                                            FSPrice += FS_16HD_casementPricePerPiece * 2;
                                                            FSBasePrice = FS_16HD_casementPricePerPiece;
                                                        }
                                                        #endregion
                                                    }
                                                    else
                                                    {
                                                        #region FSPrice
                                                        if (pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm22 ||
                                                            pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm26)
                                                        {
                                                            FSPrice += FS_26HD_casementPricePerPiece * 2;
                                                            FSBasePrice = FS_26HD_casementPricePerPiece;

                                                            if (pnl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                                            {
                                                                SnapInKeepPrice += SnapInKeepPricePerPiece * 2;
                                                            }
                                                        }
                                                        else if (pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm8 ||
                                                                 pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._10HD ||
                                                                 pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._12HD ||
                                                                 pnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._16HD)
                                                        {
                                                            FSPrice += FS_16HD_casementPricePerPiece * 2;
                                                            FSBasePrice = FS_16HD_casementPricePerPiece;
                                                        }
                                                        #endregion
                                                    }
                                                }


                                            }

                                            MiddleCLoserPrice += MiddleCLoserPricePerPiece * pnl.Panel_MiddleCloserPairQty;

                                            if (pnl.Panel_HandleOptionsVisibility == true)
                                            {
                                                if (pnl.Panel_HandleType == Handle_Type._Rotoswing)
                                                {
                                                    HandlePrice += RotoswingHanldePricePerPiece;

                                                    HandleBasePrice = RotoswingHanldePricePerPiece;
                                                }
                                                else if (pnl.Panel_HandleType == Handle_Type._Rotary)
                                                {
                                                    //wlang price ng rotaty 
                                                }
                                            }
                                        }
                                        #endregion
                                        #region Sliding 
                                        else if (pnl.Panel_Type.Contains("Sliding"))
                                        {
                                            #region handle
                                            if (pnl.Panel_HandleOptionsVisibility == true)
                                            {
                                                if (pnl.Panel_HandleType == Handle_Type._Rotoswing)
                                                {
                                                    HandlePrice += RotoswingHanldePricePerPiece;

                                                    HandleBasePrice = RotoswingHanldePricePerPiece;
                                                }
                                                else if (pnl.Panel_HandleType == Handle_Type._RotoswingForSliding)
                                                {
                                                    HandlePrice += RotoswingHanldeForSlidingPricePerPiece;

                                                    HandleBasePrice = RotoswingHanldeForSlidingPricePerPiece;
                                                }
                                                else if (pnl.Panel_HandleType == Handle_Type._Rio)
                                                {
                                                    HandlePrice += RioHandlePricePerPiece;

                                                    HandleBasePrice = RioHandlePricePerPiece;
                                                }
                                                else if (pnl.Panel_HandleType == Handle_Type._PopUp)
                                                {
                                                    HandlePrice += PopUpHandlePricePerPiece;

                                                    HandleBasePrice = PopUpHandlePricePerPiece;
                                                }
                                                else if (pnl.Panel_HandleType == Handle_Type._D)
                                                {
                                                    HandlePrice += DHandlePricePerPiece;

                                                    HandleBasePrice = DHandlePricePerPiece;
                                                }
                                                else if (pnl.Panel_HandleType == Handle_Type._DummyD)
                                                {
                                                    HandlePrice += DummyDHandlePricePerPiece;

                                                    HandleBasePrice = RioHandlePricePerPiece;
                                                }
                                                else if (pnl.Panel_HandleType == Handle_Type._D_IO_Locking)
                                                {
                                                    HandlePrice += DHandleInOutLockingPricePerPiece;

                                                    HandleBasePrice = DHandleInOutLockingPricePerPiece;
                                                }
                                            }
                                            #endregion


                                            BrushSealPrice = ((pnl.Panel_Height / 1000m) * 2 * 2) * BrushSealPricePerLinearMeter; // 2qty 2perimeter

                                            if (pnl.Panel_RollersTypes == RollersTypes._TandemRoller ||
                                                pnl.Panel_RollersTypes == RollersTypes._HDRoller)
                                            {
                                                RollerPrice += 2 * HDRollerPricePerPiece;
                                                RollerBasePrice = HDRollerPricePerPiece;
                                            }
                                            else if (pnl.Panel_RollersTypes == RollersTypes._GURoller)
                                            {
                                                RollerPrice += 2 * GURollerPricePerPiece;
                                                RollerBasePrice = GURollerPricePerPiece;
                                            }

                                            if (pnl.Panel_HandleType != Handle_Type._None)
                                            {
                                                StrikerLRPrice += 1 * StrikerLRPricePerPiece;
                                            }

                                            if (changeCondition_011724 >= cus_ref_date)
                                            {
                                                WeatherBarPrice += (fr.Frame_Width / 1000m) * WeatherBarPricePerPiece;
                                                WeatherBarFastenerPrice += ((int)(fr.Frame_Width / 300)) * BarFastenerPricePerPiece;
                                                WaterSeepagePrice += (fr.Frame_Width / 1000) * WaterSeepagePricePerLinearMeter;
                                                GuideTrackPrice += ((GuideTrackPricePerLinearMeter * (fr.Frame_Width / 1000m)) * 2) * pnl.Panel_AluminumTrackQty;
                                                AlumTrackPrice += ((AluminumTrackPricePerLinearMeter * (fr.Frame_Width / 1000m)) * 2) * pnl.Panel_AluminumTrackQty;
                                            }
                                            else
                                            {
                                                if (chckPerFrameSlidingMats == true)
                                                {
                                                    WeatherBarPrice += (fr.Frame_Width / 1000m) * WeatherBarPricePerPiece;
                                                    WeatherBarFastenerPrice += ((int)(fr.Frame_Width / 300)) * BarFastenerPricePerPiece;
                                                    WaterSeepagePrice += (fr.Frame_Width / 1000) * WaterSeepagePricePerLinearMeter;
                                                    GuideTrackPrice += ((GuideTrackPricePerLinearMeter * (fr.Frame_Width / 1000m)) * 2) * pnl.Panel_AluminumTrackQty;
                                                    AlumTrackPrice += ((AluminumTrackPricePerLinearMeter * (fr.Frame_Width / 1000m)) * 2) * pnl.Panel_AluminumTrackQty;

                                                    chckPerFrameSlidingMats = false;
                                                }
                                            }




                                            if (pnl.Panel_Overlap_Sash != OverlapSash._None)
                                            {
                                                int bothOverlapQtyMultiplier = 1;
                                                if (pnl.Panel_Overlap_Sash == OverlapSash._Both)
                                                {
                                                    bothOverlapQtyMultiplier = 2;
                                                }

                                                InterlockPrice += (2 * bothOverlapQtyMultiplier) * InterlockPricePerPiece;
                                                ExtensionForInterlockPrice += (2 * bothOverlapQtyMultiplier) * ExtensionForInterlockPricePerPiece;
                                                SealingBlockPrice += (2 * bothOverlapQtyMultiplier) * SealingBlockPricePerPiece;
                                            }

                                            if (fr.Frame_Type == FrameModel.Frame_Padding.Door &&
                                                fr.Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                                                pnl.Panel_SashHeight >= 3100)
                                            {
                                                AluminumPullHandlePrice = ((pnl.Panel_SashHeight - 5) / 1000m) * AluminumPullHandlePricePerLinearMeter;
                                            }
                                        }
                                        #endregion

                                        #region dSash 
                                        if (pnl.Panel_ChkText == "dSash" && pnl.Panel_Type.Contains("Fixed"))
                                        {
                                            #region SashPrice 
                                            SashPerimeter = (pnl.Panel_SashHeight + pnl.Panel_SashWidth) * 2;

                                            if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                            {
                                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_7581_White;
                                                    if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                                       (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                                    {
                                                        SashPricePerLinearMeter = SashPricePerLinearMeter_7581_White_1sideFoil;
                                                    }
                                                }
                                                else
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_7581_WoodGrain;
                                                }

                                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_7581;
                                            }
                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                            {
                                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_374_White;
                                                    if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                                       (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                                    {
                                                        SashPricePerLinearMeter = SashPricePerLinearMeter_374_White_1sideFoil;
                                                    }
                                                }
                                                else
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_374_WoodGrain;
                                                }

                                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                            }
                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                                            {
                                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_373_White;
                                                    if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                                       (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                                    {
                                                        SashPricePerLinearMeter = SashPricePerLinearMeter_373_White_1sideFoil;
                                                    }
                                                }
                                                else
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_373_WoodGrain;
                                                }

                                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                            }
                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                            {
                                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_395_White;
                                                    if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                                       (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                                    {
                                                        SashPricePerLinearMeter = SashPricePerLinearMeter_395_White_1sideFoil;
                                                    }
                                                }
                                                else
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_395_WoodGrain;
                                                }

                                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_395;
                                            }
                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_2067_White;
                                                SashReinPricePerLinearMeter = G58ReinPricePerLinearMeter_V226;

                                                GlazingGasketPrice += (SashPerimeter / 1000) * GlazingGasketPricePerLinearMeter;
                                            }
                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                                            {
                                                if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_6040_White;
                                                }
                                                else
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_6040_WoodGrain;
                                                }

                                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6040;
                                            }
                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                                            {
                                                if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_6041_White;
                                                }
                                                else
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_6041_WoodGrain;
                                                }

                                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6041;
                                            }



                                            SashPrice += (SashPerimeter / 1000m) * SashPricePerLinearMeter;
                                            SashReinPrice += (SashPerimeter / 1000m) * SashReinPricePerLinearMeter;
                                            GbPrice += (SashPerimeter / 1000m) * GlazingBeadPricePerLinearMeter;
                                            #endregion

                                            MiddleCLoserPrice += MiddleCLoserPricePerPiece * pnl.Panel_MiddleCloserPairQty;
                                            SpacerFixSashPrice += 2 * SpacerFixSashPricePerPiece;

                                            if (wdm.WD_profile == "PremiLine Profile" &&
                                            (fr.Frame_ArtNo == FrameProfile_ArticleNo._6052 ||
                                            fr.Frame_ArtNo == FrameProfile_ArticleNo._6050))
                                            {
                                                if (pnl.Panel_Overlap_Sash != OverlapSash._None)
                                                {
                                                    int bothOverlapQtyMultiplier = 1;
                                                    if (pnl.Panel_Overlap_Sash == OverlapSash._Both)
                                                    {
                                                        bothOverlapQtyMultiplier = 2;
                                                    }

                                                    InterlockPrice += (2 * bothOverlapQtyMultiplier) * InterlockPricePerPiece;
                                                    ExtensionForInterlockPrice += (2 * bothOverlapQtyMultiplier) * ExtensionForInterlockPricePerPiece;
                                                    SealingBlockPrice += (2 * bothOverlapQtyMultiplier) * SealingBlockPricePerPiece;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            #region SashPrice 
                                            SashPerimeter = (pnl.Panel_SashHeight + pnl.Panel_SashWidth) * 2;

                                            if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                            {
                                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_7581_White;
                                                    if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                                      (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                                    {
                                                        SashPricePerLinearMeter = SashPricePerLinearMeter_7581_White_1sideFoil;
                                                    }
                                                }
                                                else
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_7581_WoodGrain;
                                                }

                                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_7581;
                                            }
                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                            {
                                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_374_White;
                                                    if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                                      (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                                    {
                                                        SashPricePerLinearMeter = SashPricePerLinearMeter_374_White_1sideFoil;
                                                    }
                                                }
                                                else
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_374_WoodGrain;
                                                }

                                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                            }
                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                                            {
                                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_373_White;
                                                    if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                                      (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                                    {
                                                        SashPricePerLinearMeter = SashPricePerLinearMeter_373_White_1sideFoil;
                                                    }
                                                }
                                                else
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_373_WoodGrain;
                                                }

                                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                            }
                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                            {
                                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_395_White;
                                                    if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                                      (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                                    {
                                                        SashPricePerLinearMeter = SashPricePerLinearMeter_395_White_1sideFoil;
                                                    }
                                                }
                                                else
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_395_WoodGrain;
                                                }

                                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_395;
                                            }
                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_2067_White;
                                                SashReinPricePerLinearMeter = G58ReinPricePerLinearMeter_V226;

                                                GlazingGasketPrice += (SashPerimeter / 1000) * GlazingGasketPricePerLinearMeter;
                                            }
                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                                            {
                                                if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_6040_White;
                                                }
                                                else
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_6040_WoodGrain;
                                                }

                                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6040;
                                            }
                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                                            {
                                                if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_6041_White;
                                                }
                                                else
                                                {
                                                    SashPricePerLinearMeter = SashPricePerLinearMeter_6041_WoodGrain;
                                                }

                                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6041;
                                            }


                                            SashPrice += (SashPerimeter / 1000m) * SashPricePerLinearMeter;
                                            SashReinPrice += (SashPerimeter / 1000m) * SashReinPricePerLinearMeter;
                                            if (cus_ref_date >= changeCondition_072723)
                                            {
                                                if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                                {
                                                    GbPrice += (SashPerimeter / 1000m) * GlazingBead_G58PricePerLinearMeter;
                                                }
                                                else
                                                {
                                                    GbPrice += (SashPerimeter / 1000m) * GlazingBeadPricePerLinearMeter;
                                                }
                                            }



                                            #endregion
                                        }
                                        #endregion

                                        if (pnl.Panel_GlassThickness == 6.0f)
                                        {
                                            GBSpacerPrice += GBSpacerPricePerPiece * 4;
                                        }

                                        if (ChckPlasticWedge == true)
                                        {
                                            PlasticWedgePrice += PlasticWedgePricePerPiece;
                                        }

                                        #region Motorize 
                                        if (pnl.Panel_MotorizedOptionVisibility == true)
                                        {
                                            if (pnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41555B ||
                                                pnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41556C)
                                            {
                                                MotorizeMechPricePerPiece = 15000m;
                                            }
                                            else if (pnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._409990E)
                                            {
                                                MotorizeMechPricePerPiece = 39000m;
                                            }
                                            else if (pnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41731V)
                                            {
                                                MotorizeMechPricePerPiece = MotorizeMechUsingRemotePrice;
                                            }

                                            if (chckPerFrameMotorMech == true)
                                            {
                                                MotorizePrice += MotorizeMechPricePerPiece * pnl.MotorizeMechQty();

                                                if (pnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41731V)
                                                {
                                                    RemoteForMotorizeMechPrice = MotorizeMechRemotePricePerPiece;
                                                }

                                                chckPerFrameMotorMech = false;
                                            }
                                        }
                                        #endregion

                                        #region EspagPrice

                                        if (pnl.Panel_EspagnoletteOptionsVisibility == true)
                                        {
                                            if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._None &&
                                                 cus_ref_date >= changeCondition_080323)
                                            {

                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A00006)
                                            {
                                                EspagPrice += TiltAndTurnEspag_N110A00006PricePerPiece;
                                                EspagBasePrice = TiltAndTurnEspag_N110A00006PricePerPiece;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A01006)
                                            {
                                                EspagPrice += TiltAndTurnEspag_N110A01006PricePerPiece;
                                                EspagBasePrice = TiltAndTurnEspag_N110A01006PricePerPiece;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206)
                                            {
                                                EspagPrice += TiltAndTurnEspag_N110A02206PricePerPiece;
                                                EspagBasePrice = TiltAndTurnEspag_N110A02206PricePerPiece;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                                            {
                                                EspagPrice += TiltAndTurnEspag_N110A03206PricePerPiece;
                                                EspagBasePrice = TiltAndTurnEspag_N110A03206PricePerPiece;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206)
                                            {
                                                EspagPrice += TiltAndTurnEspag_N110A04206PricePerPiece;
                                                EspagBasePrice = TiltAndTurnEspag_N110A04206PricePerPiece;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                                            {
                                                EspagPrice += TiltAndTurnEspag_N110A05206PricePerPiece;
                                                EspagBasePrice = TiltAndTurnEspag_N110A05206PricePerPiece;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A06206)
                                            {
                                                EspagPrice += TiltAndTurnEspag_N110A06206PricePerPiece;
                                                EspagBasePrice = TiltAndTurnEspag_N110A06206PricePerPiece;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._630963)
                                            {
                                                EspagPrice += MVDGearPricePerPiece;
                                                EspagBasePrice = MVDGearPricePerPiece;
                                            }
                                            else
                                            {
                                                EspagPrice += Espag741012_PricePerPiece;
                                                EspagBasePrice = Espag741012_PricePerPiece;
                                            }
                                        }
                                        #endregion

                                        #region StrikerPrice
                                        int Panel_StrikerQty_A = 0,
                                            Panel_StrikerQty_C = 0;


                                        if (pnl.Panel_Type.Contains("Awning"))
                                        {
                                            if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                                                pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807 ||
                                                pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809)
                                            {
                                                Panel_StrikerQty_A += 2;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                                                     pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                                            {
                                                Panel_StrikerQty_A += 3;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                                                     pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                                            {
                                                Panel_StrikerQty_A += 4;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                                                     pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                                            {
                                                Panel_StrikerQty_A += 1;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                                                     pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                                            {
                                                Panel_StrikerQty_A += 2;
                                            }

                                            if (pnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957)
                                            {
                                                Panel_StrikerQty_C += (1 * pnl.Panel_ExtLeftQty);
                                            }

                                            if (pnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957)
                                            {
                                                Panel_StrikerQty_C += (1 * pnl.Panel_ExtLeft2Qty);
                                            }

                                            if (pnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._639957)
                                            {
                                                Panel_StrikerQty_C += (1 * pnl.Panel_ExtRightQty);
                                            }

                                            if (pnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                                            {
                                                Panel_StrikerQty_C += (1 * pnl.Panel_ExtRight2Qty);
                                            }

                                            if (pnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                            {
                                                Panel_StrikerQty_A += 2;
                                            }
                                        }
                                        else if (pnl.Panel_Type.Contains("Casement"))
                                        {
                                            if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                                                pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807 ||
                                                pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809)
                                            {
                                                Panel_StrikerQty_C += 2;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                                                     pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                                            {
                                                Panel_StrikerQty_C += 3;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                                                     pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                                            {
                                                Panel_StrikerQty_C += 4;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                                                     pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                                            {
                                                Panel_StrikerQty_C += 1;
                                            }
                                            else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                                                     pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                                            {
                                                Panel_StrikerQty_C += 2;
                                            }

                                            if (pnl.Panel_ExtensionTopArtNo == Extension_ArticleNo._639957)
                                            {
                                                Panel_StrikerQty_C += (1 * pnl.Panel_ExtTopQty);
                                            }

                                            if (pnl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._639957)
                                            {
                                                Panel_StrikerQty_C += (1 * pnl.Panel_ExtTop2Qty);
                                            }

                                            if (pnl.Panel_ExtensionBotArtNo == Extension_ArticleNo._639957)
                                            {
                                                Panel_StrikerQty_C += (1 * pnl.Panel_ExtBotQty);
                                            }

                                            if (pnl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._639957)
                                            {
                                                Panel_StrikerQty_C += (1 * pnl.Panel_ExtBot2Qty);
                                            }

                                            if (pnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                            {
                                                Panel_StrikerQty_C += 1;
                                            }

                                            if (pnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                            {
                                                Panel_StrikerQty_A += 1;
                                            }
                                        }

                                        if (Panel_StrikerQty_A != 0 ||
                                            Panel_StrikerQty_C != 0)
                                        {
                                            StrikerPrice += (Panel_StrikerQty_A + Panel_StrikerQty_C) * StrikerPricePerPiece;
                                        }
                                        #endregion

                                        #region GeorgianBar
                                        if (pnl.Panel_GeorgianBarOptionVisibility == true)
                                        {
                                            int GBmultiplier = 1, multiplier = 1;

                                            if (cus_ref_date >= changeCondition_020323)
                                            {
                                                GBmultiplier = 2;
                                            }

                                            if (cus_ref_date >= changeCondition_072723)
                                            {
                                                multiplier = 2;
                                            }

                                            GeorgianBarHorizontalQty = pnl.Panel_GeorgianBar_HorizontalQty * GBmultiplier;
                                            GeorgianBarVerticalQty = pnl.Panel_GeorgianBar_VerticalQty * GBmultiplier;

                                            if (wdm.WD_BaseColor == Base_Color._Ivory ||
                                                wdm.WD_BaseColor == Base_Color._White)
                                            {
                                                if (pnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
                                                {
                                                    if (pnl.Panel_GeorgianBar_HorizontalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0724Price_White * multiplier;
                                                    }
                                                    if (pnl.Panel_GeorgianBar_VerticalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0724Price_White;
                                                    }
                                                    GeorgianBarPrice = GeorgianBar_0724Price_White;

                                                }
                                                else if (pnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0726)
                                                {
                                                    if (pnl.Panel_GeorgianBar_HorizontalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0726Price_White;
                                                    }
                                                    if (pnl.Panel_GeorgianBar_VerticalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0726Price_White;
                                                    }
                                                    GeorgianBarPrice = GeorgianBar_0726Price_White;
                                                }
                                            }
                                            else if (wdm.WD_BaseColor == Base_Color._DarkBrown)
                                            {
                                                if (pnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
                                                {
                                                    if (pnl.Panel_GeorgianBar_HorizontalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0724Price_Woodgrain;
                                                    }
                                                    if (pnl.Panel_GeorgianBar_VerticalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0724Price_Woodgrain;
                                                    }
                                                    GeorgianBarPrice = GeorgianBar_0724Price_Woodgrain;

                                                }
                                                else if (pnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0726)
                                                {
                                                    if (pnl.Panel_GeorgianBar_HorizontalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0726Price_Woodgrain;
                                                    }
                                                    if (pnl.Panel_GeorgianBar_VerticalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0726Price_Woodgrain;
                                                    }
                                                    GeorgianBarPrice = GeorgianBar_0726Price_Woodgrain;
                                                }
                                            }

                                        }
                                        #endregion

                                        #region CoverProfilePrice
                                        if ((pnl.Panel_Type.Contains("Sliding")))
                                        {
                                            CoverProfileCost += ((pnl.Panel_SashWidth / 1000m) * CoverProfile_0914Price) * 2;
                                            CoverProfilePrice = CoverProfile_0914Price;
                                        }
                                        else
                                        {
                                            CoverProfileCost += (pnl.Panel_SashWidth / 1000m) * CoverProfile_0914Price +
                                                                (pnl.Panel_SashWidth / 1000m) * CoverProfile_0373Price;
                                            CoverProfilePrice = CoverProfile_0914Price + CoverProfile_0373Price;
                                        }
                                        #endregion

                                        #region Glass 

                                        var GlassThcknessDesc_Holder = pnl.Panel_GlassThicknessDesc;
                                        if (GlassThcknessDesc_Holder != null)
                                        {
                                            if (GlassThcknessDesc_Holder.Contains("with Georgian Bar"))
                                            {
                                                pnl.Panel_GlassThicknessDesc = pnl.Panel_GlassThicknessDesc.Replace("with Georgian Bar", "").Replace(" ", " ");
                                            }
                                        }

                                        if (pnl.Panel_GlassType == GlassType._Single)
                                        {
                                            if (pnl.Panel_GlassType_Insu_Lami == "NA" || pnl.Panel_GlassType_Insu_Lami == "")
                                            {
                                                #region Single 

                                                if (pnl.Panel_GlassThicknessDesc.Contains("5 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmClr_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmClr_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear Oversized"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmClrOversized_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_12mmClrOversized_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Oversized"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmTempTintedOversized_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_12mmTempTintedOversized_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_12mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmTempTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_12mmTempTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealedClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealedClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealedClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealedClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealedClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealedClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Bronze") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Blue") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Green") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Bronze") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Blue") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Green") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Bronze") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Blue") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Green") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmTempClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_12mmTempClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Bronze") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Blue") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Green") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Bronze") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Blue") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Green") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Bronze") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Blue") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Green") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                }

                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Heat-Soaked Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempHeatSoakedClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempHeatSoakedClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Heat-Soaked Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempHeatSoakedClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempHeatSoakedClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Heat-Soaked Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempHeatSoakedClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempHeatSoakedClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Heat-Soaked Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempHeatSoakedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempHeatSoakedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Heat-Soaked Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempHeatSoakedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempHeatSoakedClr;
                                                }

                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm  Recflective Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealed_ReflectiveClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealed_ReflectiveClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTemp_ReflectiveClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTemp_ReflectiveClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Gold Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_ReflectiveGold_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTemp_ReflectiveGold_HrdCtd_LowE;
                                                }


                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmClr_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmClr_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmClr_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmClr_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmClr_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmClr_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmClr_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_12mmClr_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTemp_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTemp_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTemp_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTemp_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTemp_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmTemp_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_12mmTemp_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("15 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_15mmTemp_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_15mmTemp_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("19 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_19mmTemp_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_19mmTemp_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm PVC Sheet Wood(6-B2B)"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_12mm_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_12mm_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm PVC Sheet White"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_8mm_White_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_8mm_White_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm PVC Sheet Foiled"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_8mm_Foiled_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_8mm_Foiled_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm PVC Sheet Wood"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_6mm_PricepPerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_6mm_PricepPerSqrMeter;
                                                }

                                                else
                                                {
                                                    GlassPrice += 0;
                                                    pnl.Panel_GlassPricePerSqrMeter = 0;
                                                }

                                                #endregion 
                                            }
                                        }
                                        else if (pnl.Panel_GlassType == GlassType._Double)
                                        {
                                            if (pnl.Panel_GlassType_Insu_Lami == "Double Insulated")
                                            {
                                                #region Insulated
                                                if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Solarban Clear with Low-e + 12 Argon + 6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTemp_SolarBan;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTemp_SolarBan;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Self-Cleaning Tempered Clear + 12 Argon + 4 mm Tempered Clear with Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_20mmSelfCleaning_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_20mmSelfCleaning_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Self-Cleaning Tempered Clear + 12 Argon + 6 mm Tempered Clear with Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmSelfCleaning_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmSelfCleaning_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Bronze + 12 Argon + (3 mm Clear + 0.38 PVB + 3 Clear )"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedBronze_Argon_AnnealedClr_Argon;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedBronze_Argon_AnnealedClr_Argon;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Clear + 10 + 4 mm Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedClr_AirSS_AnnealedClrHrCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedClr_AirSS_AnnealedClrHrCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Clear + 12 Argon + 6 mm Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedClr_Argon_AnnealedClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedClr_Argon_AnnealedClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tinted + 10 Argon + 4 mm Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted + 12 Argon + 6 mm Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Clear + 10 + 4 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedClr_AirSS_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedClr_AirSS_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 + 4 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_AirSS_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_AirSS_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 Argon + 4 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_Argon_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_Argon_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Clear + 12 Argon + 6 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedClr_Argon_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedClr_Argon_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("5 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmTempClr_Argon_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmTempClr_Argon_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Tinted + 10 Argon + 4 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempTinted_Argon_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempTinted_Argon_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted + 12 Argon + 6 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempTinted_Argon_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempTinted_Argon_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Heat-Soaked Clear + 12 Argon + 6 mm Tempered Heat-Soaked Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempHeatSoakedClr_Argon_TempHeatSoakedClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempHeatSoakedClr_Argon_TempHeatSoakedClrHrdCtdLowe;

                                                }


                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Clear + 10 + 4 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedClr_AirSS_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedClr_AirSS_AnnealedClr;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("5 mm Clear + 12 + 6 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedClr_AirSS_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedClr_AirSS_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("5 mm Clear + 12 + 6 mm Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedClr_AirSS_AnnealedTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedClr_AirSS_AnnealedTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("5 mm Tinted + 12 + 6 mm Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedTinted_AirSS_AnnealedTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedTinted_AirSS_AnnealedTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 + 4 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_AirSS_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_AirSS_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 Argon + 4 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_Argon_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_Argon_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempClr_Argon_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempClr_Argon_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 Argon + 4 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_Argon_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_Argon_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("5 mm Clear + 12 + 6 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedClr_AirSS_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedClr_AirSS_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 12 Argon + 6 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempClr_Argon_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempClr_Argon_TempTinted;
                                                }

                                                #endregion
                                            }
                                            else if (pnl.Panel_GlassType_Insu_Lami == "Double Laminated")
                                            {
                                                #region Laminated

                                                if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 0.89  SG InterLayer + 5 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmTempClr_SGInt_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmTempClr_SGInt_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 0.89  SG InterLayer + 6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempClr_SGInt_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempClr_SGInt_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52  SG InterLayer + 6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_SGInt_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_SGInt_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear + 1.52  SG InterLayer + 10 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_21mmTempClr_SGInt_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_21mmTempClr_SGInt_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear + 1.52  SG InterLayer + 12 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_25mmTempClr_SGInt_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_25mmTempClr_SGInt_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear with Low-e + 1.52 + 4 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClrLowe_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClrLowe_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear with Low-e + 1.52  + 6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClrLowe_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClrLowe_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear with Low-e + 3.04 + 10 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmTempClrLowe_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmTempClrLowe_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52  + 4 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52  + 5 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_10mmTempClr_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_10mmTempClr_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52  + 6 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmTempClr_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmTempClr_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 6 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Tinted + 1.52 + 4 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempTinted_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempTinted_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted + 1.52  + 5 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempTinted_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempTinted_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted + 1.52 + 6 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempTinted_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempTinted_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("5 mm Tempered Clear with Low-e + 1.52 + 6 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempClrLowe_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempClrLowe_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Heat-Soaked Clear + 1.52 + 6 mm Tempered Heat-Soaked Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempHeatSoakedClr_Pvb_TempHeatSoakedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempHeatSoakedClr_Pvb_TempHeatSoakedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("3 mm  Clear + 0.38 + 3 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_6mmAnnealedClr_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_6mmAnnealedClr_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear + 0.76 + 4 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_8mmAnnealedClr_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_8mmAnnealedClr_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.76 + 5 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedClr_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedClr_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.76 + 6 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedClr_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedClr_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm  Clear + 3.04 + 8 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_21mmAnnealedClr_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_21mmAnnealedClr_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear with Low-e + 0.38 + 3 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_7mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_7mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear with Low-e + 0.76 + 5 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear with Low-e + 0.76 + 6 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear with Low-e + 0.76 + 1 mm  Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_5mmAnnealedClrLowe_ClrPvb_AnnealedTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_5mmAnnealedClrLowe_ClrPvb_AnnealedTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("3 mm  Tinted + 0.38 + 3 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_6mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_6mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted + 0.76 + 5 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted + 0.76 + 6 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("3 mm  Clear + 0.38 White PVB  + 3 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_6mmAnnealedClr_WhitePvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_6mmAnnealedClr_WhitePvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear + 0.76 White PVB  + 4 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_8mmAnnealedClr_WhitePvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_8mmAnnealedClr_WhitePvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.76 White PVB  + 5 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedClr_WhitePvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedClr_WhitePvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.89 SG Interlayer  + 6 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedClr_SGInt_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedClr_SGInt_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("3 mm Tempered Clear + 1.52 + 3 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_7mmTempClr_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_7mmTempClr_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52 + 4 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 4 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmTempClr_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmTempClr_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 5 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempClr_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempClr_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted + 0.76 + 6 mm  Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm  Tinted + 0.76 + 4 mm  Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_8mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_8mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                }


                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52 White PVB + 4 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 White PVB + 6 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted  + 1.52 + 5 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempTinted_ClrPvb_TempClrLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempTinted_ClrPvb_TempClrLowe;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52 White PVB + 4 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_WhitePvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_WhitePvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 White PVB + 6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_WhitePvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_WhitePvb_TempClr;
                                                }


                                                #endregion
                                            }
                                        }
                                        else if (pnl.Panel_GlassType == GlassType._Triple)
                                        {
                                            if (pnl.Panel_GlassType_Insu_Lami == "Triple Insulated")
                                            {
                                                #region Insulated

                                                if (pnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear + 6 + 4 mm  Clear + 6 + 4 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmAnnealedClr_AirSS_AnnealedClr_AirSS_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmAnnealedClr_AirSS_AnnealedClr_AirSS_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 6 + 4 mm  Clear + 6 + 4 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmTempClr_AirSS_AnnealedClr_AirSS_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmTempClr_AirSS_AnnealedClr_AirSS_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 6 + 4 mm Tempered Clear + 6 + 4 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmTempClr_AirSs_TempClr_AirSS_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmTempClr_AirSs_TempClr_AirSS_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 6 Argon + 4 mm  Clear + 6 Argon + 4 mm Tempered Clear with Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmTempClr_Argon_AnnealedClr_Argon_TempClrLowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmTempClr_Argon_AnnealedClr_Argon_TempClrLowE;
                                                }

                                                #endregion
                                            }
                                            else if (pnl.Panel_GlassType_Insu_Lami == "Triple Insulated")
                                            {
                                                #region Laminated

                                                #endregion
                                            }
                                        }

                                        if (GlassThcknessDesc_Holder != null)
                                        {
                                            if (GlassThcknessDesc_Holder.Contains("with Georgian Bar"))
                                            {
                                                pnl.Panel_GlassThicknessDesc = GlassThcknessDesc_Holder;
                                            }
                                        }

                                        //sealant for glass
                                        Glass_SealantWHQty_Total = (int)(Math.Ceiling((decimal)((pnl.Panel_GlassWidth + pnl.Panel_GlassHeight) * 2) / 6842));
                                        if (pnl.Panel_GlassThickness != 0.0f)
                                        {

                                            if ((wdm.WD_BaseColor == Base_Color._Ivory || wdm.WD_BaseColor == Base_Color._White) && OneSideFoil_whiteBase == false)
                                            {
                                                SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_Clear;
                                            }
                                            else if (wdm.WD_BaseColor == Base_Color._DarkBrown || OneSideFoil_whiteBase == true)
                                            {
                                                SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_BrownBlack;
                                            }
                                        }
                                        #endregion

                                        #region GlassFilm
                                        if (pnl.Panel_GlassFilm == GlassFilm_Types._4milSolarGuard ||
                                            pnl.Panel_GlassFilm == GlassFilm_Types._4milUpera)
                                        {
                                            FilmPrice += ((pnl.Panel_GlassWidth / 1000m) * (pnl.Panel_GlassHeight / 1000m)) * _4millFilmPrice_PricePerSqrMeter;
                                        }
                                        else if (pnl.Panel_GlassFilm == GlassFilm_Types._FrostedFilm)
                                        {
                                            FilmPrice += ((pnl.Panel_GlassWidth / 1000m) * (pnl.Panel_GlassHeight / 1000m)) * FrostedFilmPrice_PricePerSqrMeter;
                                        }
                                        #endregion

                                        #region GlazingAdaptor
                                        if (pnl.Panel_ChkGlazingAdaptor == true)
                                        {
                                            GlazingBeadPerimeter = (pnl.Panel_GlazingBeadHeight + pnl.Panel_GlazingBeadWidth) * 2;
                                            GlazingAdaptorPrice += (GlazingBeadPerimeter / 1000) * GlazingAdaptorPricePerMeter;
                                        }
                                        #endregion

                                        #region SecurityMesh
                                        if (pnl.Panel_GlassThicknessDesc != null)
                                        {
                                            if (pnl.Panel_GlassThicknessDesc.Contains("Security Mesh"))
                                            {
                                                SecurityMeshPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * SecurityMeshPricePerSquaremeter;
                                                pnl.Panel_GlassPricePerSqrMeter = SecurityMeshPricePerSquaremeter;
                                            }
                                            else if (pnl.Panel_GlassThicknessDesc.Contains("Wire Mesh"))
                                            {
                                                WireMeshPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * WireMeshPricePerSquaremeter;
                                                pnl.Panel_GlassPricePerSqrMeter = WireMeshPricePerSquaremeter;
                                            }
                                            else if (pnl.Panel_GlassThicknessDesc.Contains("Pet Mesh"))
                                            {
                                                PetMeshPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * PetMeshPricePerSquaremeter;
                                                pnl.Panel_GlassPricePerSqrMeter = PetMeshPricePerSquaremeter;
                                            }
                                            else if (pnl.Panel_GlassThicknessDesc.Contains("Tuff Mesh"))
                                            {
                                                TuffMeshPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * TuffMeshPricePerSquaremeter;
                                                pnl.Panel_GlassPricePerSqrMeter = TuffMeshPricePerSquaremeter;
                                            }
                                            else if (pnl.Panel_GlassThicknessDesc.Contains("Phifer Mesh"))
                                            {
                                                PhiferMeshPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * PhiferMeshPricePerSquaremeter;
                                                pnl.Panel_GlassPricePerSqrMeter = PhiferMeshPricePerSquaremeter;
                                            }

                                            if (pnl.Panel_GlassThicknessDesc.Contains("Mesh"))
                                            {
                                                AluminumFramePrice += (((pnl.Panel_GlassHeight / 1000m) + (pnl.Panel_GlassWidth / 1000m)) * 2) * AluminumFramePricePerSquaremeter;
                                            }
                                        }
                                        #endregion

                                        HandleDesc = pnl.Panel_HandleType.ToString();

                                        CostingPoints += ProfileColorPoints * 4;
                                        InstallationPoints += (ProfileColorPoints / 3) * 4;
                                    }
                                    else if (pnl.Panel_Type.Contains("Fixed"))
                                    {
                                        CostingPoints += ProfileColorPoints * 2;
                                        InstallationPoints += (ProfileColorPoints / 3) * 2;

                                        #region Glass 

                                        var GlassThcknessDesc_Holder = pnl.Panel_GlassThicknessDesc;

                                        if (GlassThcknessDesc_Holder != null)
                                        {
                                            if (GlassThcknessDesc_Holder.Contains("with Georgian Bar"))
                                            {
                                                pnl.Panel_GlassThicknessDesc = pnl.Panel_GlassThicknessDesc.Replace("with Georgian Bar", "").Replace(" ", " ");
                                            }
                                        }

                                        if (pnl.Panel_GlassType == GlassType._Single)
                                        {
                                            if (pnl.Panel_GlassType_Insu_Lami == "NA" || pnl.Panel_GlassType_Insu_Lami == "")
                                            {
                                                #region Single 

                                                if (pnl.Panel_GlassThicknessDesc.Contains("5 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmClr_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmClr_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear Oversized"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmClrOversized_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_12mmClrOversized_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Oversized"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmTempTintedOversized_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_12mmTempTintedOversized_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_12mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmTempTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_12mmTempTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealedClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealedClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealedClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealedClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealedClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealedClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Bronze") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Blue") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Green") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Bronze") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Blue") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Green") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Bronze") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Blue") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Green") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmTempClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_12mmTempClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Bronze") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Blue") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Green") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Bronze") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Blue") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Green") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Bronze") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Blue") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Green") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                                }


                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Heat-Soaked Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempHeatSoakedClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempHeatSoakedClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Heat-Soaked Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempHeatSoakedClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempHeatSoakedClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Heat-Soaked Clear Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempHeatSoakedClr_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempHeatSoakedClr_HrdCtd_LowE;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Heat-Soaked Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempHeatSoakedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempHeatSoakedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Heat-Soaked Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempHeatSoakedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempHeatSoakedClr;
                                                }


                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm  Recflective Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealed_ReflectiveClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealed_ReflectiveClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTemp_ReflectiveClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTemp_ReflectiveClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Bronze") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Blue") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Green") || pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Grey"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Gold Low-E"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_ReflectiveGold_HrdCtd_LowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTemp_ReflectiveGold_HrdCtd_LowE;
                                                }


                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmClr_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmClr_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmClr_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmClr_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmClr_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmClr_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmClr_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_12mmClr_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTemp_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_8mmTemp_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_8mmTemp_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTemp_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTemp_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmTemp_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_12mmTemp_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("15 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_15mmTemp_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_15mmTemp_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("19 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_19mmTemp_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_19mmTemp_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm PVC Sheet Wood(6-B2B)"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_12mm_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_12mm_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm PVC Sheet White"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_8mm_White_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_8mm_White_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("8 mm PVC Sheet Foiled"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_8mm_Foiled_PricePerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_8mm_Foiled_PricePerSqrMeter;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm PVC Sheet Wood"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_6mm_PricepPerSqrMeter;
                                                    pnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_6mm_PricepPerSqrMeter;
                                                }
                                                else
                                                {
                                                    GlassPrice += 0;
                                                    pnl.Panel_GlassPricePerSqrMeter = 0;
                                                }
                                                #endregion
                                            }
                                        }
                                        else if (pnl.Panel_GlassType == GlassType._Double)
                                        {

                                            if (pnl.Panel_GlassType_Insu_Lami == "Double Insulated")
                                            {
                                                #region Insulated
                                                if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Solarban Clear with Low-e + 12 Argon + 6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTemp_SolarBan;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTemp_SolarBan;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Self-Cleaning Tempered Clear + 12 Argon + 4 mm Tempered Clear with Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_20mmSelfCleaning_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_20mmSelfCleaning_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Self-Cleaning Tempered Clear + 12 Argon + 6 mm Tempered Clear with Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmSelfCleaning_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmSelfCleaning_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Bronze + 12 Argon + (3 mm Clear + 0.38 PVB + 3 Clear )"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedBronze_Argon_AnnealedClr_Argon;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedBronze_Argon_AnnealedClr_Argon;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Clear + 10 + 4 mm Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedClr_AirSS_AnnealedClrHrCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedClr_AirSS_AnnealedClrHrCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Clear + 12 Argon + 6 mm Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedClr_Argon_AnnealedClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedClr_Argon_AnnealedClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tinted + 10 Argon + 4 mm Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted + 12 Argon + 6 mm Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Clear + 10 + 4 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedClr_AirSS_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedClr_AirSS_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 + 4 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_AirSS_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_AirSS_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 Argon + 4 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_Argon_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_Argon_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Clear + 12 Argon + 6 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedClr_Argon_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedClr_Argon_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("5 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmTempClr_Argon_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmTempClr_Argon_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Tinted + 10 Argon + 4 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempTinted_Argon_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempTinted_Argon_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted + 12 Argon + 6 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempTinted_Argon_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempTinted_Argon_TempClrHrdCtdLowe;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Heat-Soaked Clear + 12 Argon + 6 mm Tempered Heat-Soaked Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempHeatSoakedClr_Argon_TempHeatSoakedClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempHeatSoakedClr_Argon_TempHeatSoakedClrHrdCtdLowe;

                                                }


                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Clear + 10 + 4 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedClr_AirSS_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedClr_AirSS_AnnealedClr;

                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("5 mm Clear + 12 + 6 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedClr_AirSS_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedClr_AirSS_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("5 mm Clear + 12 + 6 mm Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedClr_AirSS_AnnealedTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedClr_AirSS_AnnealedTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("5 mm Tinted + 12 + 6 mm Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedTinted_AirSS_AnnealedTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedTinted_AirSS_AnnealedTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 + 4 mm Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_AirSS_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_AirSS_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 Argon + 4 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_Argon_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_Argon_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempClr_Argon_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempClr_Argon_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 Argon + 4 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_Argon_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_Argon_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("5 mm Clear + 12 + 6 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedClr_AirSS_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedClr_AirSS_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 12 Argon + 6 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempClr_Argon_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempClr_Argon_TempTinted;
                                                }

                                                #endregion
                                            }
                                            else if (pnl.Panel_GlassType_Insu_Lami == "Double Laminated")
                                            {
                                                #region Laminated

                                                if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 0.89  SG InterLayer + 5 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmTempClr_SGInt_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmTempClr_SGInt_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 0.89  SG InterLayer + 6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempClr_SGInt_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempClr_SGInt_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52  SG InterLayer + 6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_SGInt_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_SGInt_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear + 1.52  SG InterLayer + 10 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_21mmTempClr_SGInt_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_21mmTempClr_SGInt_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear + 1.52  SG InterLayer + 12 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_25mmTempClr_SGInt_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_25mmTempClr_SGInt_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear with Low-e + 1.52 + 4 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClrLowe_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClrLowe_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear with Low-e + 1.52  + 6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClrLowe_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClrLowe_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear with Low-e + 3.04 + 10 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmTempClrLowe_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmTempClrLowe_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52  + 4 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52  + 5 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_10mmTempClr_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_10mmTempClr_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52  + 6 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmTempClr_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmTempClr_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 6 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Tinted + 1.52 + 4 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempTinted_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempTinted_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted + 1.52  + 5 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempTinted_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempTinted_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted + 1.52 + 6 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempTinted_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempTinted_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("5 mm Tempered Clear with Low-e + 1.52 + 6 mm Tempered Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempClrLowe_ClrPvb_TempTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempClrLowe_ClrPvb_TempTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Heat-Soaked Clear + 1.52 + 6 mm Tempered Heat-Soaked Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempHeatSoakedClr_Pvb_TempHeatSoakedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempHeatSoakedClr_Pvb_TempHeatSoakedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("3 mm  Clear + 0.38 + 3 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_6mmAnnealedClr_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_6mmAnnealedClr_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear + 0.76 + 4 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_8mmAnnealedClr_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_8mmAnnealedClr_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.76 + 5 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedClr_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedClr_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.76 + 6 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedClr_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedClr_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("10 mm  Clear + 3.04 + 8 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_21mmAnnealedClr_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_21mmAnnealedClr_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear with Low-e + 0.38 + 3 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_7mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_7mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear with Low-e + 0.76 + 5 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear with Low-e + 0.76 + 6 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear with Low-e + 0.76 + 1 mm  Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_5mmAnnealedClrLowe_ClrPvb_AnnealedTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_5mmAnnealedClrLowe_ClrPvb_AnnealedTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("3 mm  Tinted + 0.38 + 3 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_6mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_6mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted + 0.76 + 5 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted + 0.76 + 6 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("3 mm  Clear + 0.38 White PVB  + 3 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_6mmAnnealedClr_WhitePvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_6mmAnnealedClr_WhitePvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear + 0.76 White PVB  + 4 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_8mmAnnealedClr_WhitePvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_8mmAnnealedClr_WhitePvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.76 White PVB  + 5 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedClr_WhitePvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedClr_WhitePvb_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.89 SG Interlayer  + 6 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedClr_SGInt_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedClr_SGInt_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("3 mm Tempered Clear + 1.52 + 3 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_7mmTempClr_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_7mmTempClr_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52 + 4 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 4 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmTempClr_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmTempClr_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 5 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempClr_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempClr_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_ClrPvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_ClrPvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted + 0.76 + 6 mm  Tinted"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedTinted;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedTinted;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm  Tinted + 0.76 + 4 mm  Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_8mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_8mmAnnealedTinted_ClrPvb_AnnealedClr;
                                                }

                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52 White PVB + 4 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 White PVB + 6 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted  + 1.52 + 5 mm Tempered Clear Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempTinted_ClrPvb_TempClrLowe;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempTinted_ClrPvb_TempClrLowe;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52 White PVB + 4 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_WhitePvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_WhitePvb_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 White PVB + 6 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_WhitePvb_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_WhitePvb_TempClr;
                                                }


                                                #endregion
                                            }
                                        }
                                        else if (pnl.Panel_GlassType == GlassType._Triple)
                                        {
                                            if (pnl.Panel_GlassType_Insu_Lami == "Triple Insulated")
                                            {
                                                #region Insulated

                                                if (pnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear + 6 + 4 mm  Clear + 6 + 4 mm  Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmAnnealedClr_AirSS_AnnealedClr_AirSS_AnnealedClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmAnnealedClr_AirSS_AnnealedClr_AirSS_AnnealedClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 6 + 4 mm  Clear + 6 + 4 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmTempClr_AirSS_AnnealedClr_AirSS_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmTempClr_AirSS_AnnealedClr_AirSS_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 6 + 4 mm Tempered Clear + 6 + 4 mm Tempered Clear"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmTempClr_AirSs_TempClr_AirSS_TempClr;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmTempClr_AirSs_TempClr_AirSS_TempClr;
                                                }
                                                else if (pnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 6 Argon + 4 mm  Clear + 6 Argon + 4 mm Tempered Clear with Low-e"))
                                                {
                                                    GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmTempClr_Argon_AnnealedClr_Argon_TempClrLowE;
                                                    pnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmTempClr_Argon_AnnealedClr_Argon_TempClrLowE;
                                                }

                                                #endregion
                                            }
                                            else if (pnl.Panel_GlassType_Insu_Lami == "Triple Insulated")
                                            {
                                                #region Laminated

                                                #endregion
                                            }
                                        }

                                        if (GlassThcknessDesc_Holder != null)
                                        {
                                            if (GlassThcknessDesc_Holder.Contains("with Georgian Bar"))
                                            {
                                                pnl.Panel_GlassThicknessDesc = GlassThcknessDesc_Holder;
                                            }
                                        }

                                        //sealant for glass
                                        Glass_SealantWHQty_Total = (int)(Math.Ceiling((decimal)((pnl.Panel_GlassWidth + pnl.Panel_GlassHeight) * 2) / 6842));
                                        if (pnl.Panel_GlassThickness != 0.0f)
                                        {

                                            if ((wdm.WD_BaseColor == Base_Color._Ivory || wdm.WD_BaseColor == Base_Color._White) && OneSideFoil_whiteBase == false)
                                            {
                                                SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_Clear;
                                            }
                                            else if (wdm.WD_BaseColor == Base_Color._DarkBrown || OneSideFoil_whiteBase == true)
                                            {
                                                SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_BrownBlack;
                                            }
                                        }
                                        #endregion

                                        #region GeorgianBar
                                        if (pnl.Panel_GeorgianBarOptionVisibility == true)
                                        {
                                            int GBmultiplier = 1, multiplier = 1;

                                            if (cus_ref_date >= changeCondition_020323)
                                            {
                                                GBmultiplier = 2;
                                            }

                                            if (cus_ref_date >= changeCondition_072723)
                                            {
                                                multiplier = 2;
                                            }

                                            GeorgianBarHorizontalQty = pnl.Panel_GeorgianBar_HorizontalQty * GBmultiplier;
                                            GeorgianBarVerticalQty = pnl.Panel_GeorgianBar_VerticalQty * GBmultiplier;

                                            if (wdm.WD_BaseColor == Base_Color._Ivory ||
                                                wdm.WD_BaseColor == Base_Color._White)
                                            {
                                                if (pnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
                                                {
                                                    if (pnl.Panel_GeorgianBar_HorizontalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0724Price_White * multiplier;
                                                    }
                                                    if (pnl.Panel_GeorgianBar_VerticalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0724Price_White;
                                                    }
                                                    GeorgianBarPrice = GeorgianBar_0724Price_White;

                                                }
                                                else if (pnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0726)
                                                {
                                                    if (pnl.Panel_GeorgianBar_HorizontalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0726Price_White;
                                                    }
                                                    if (pnl.Panel_GeorgianBar_VerticalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0726Price_White;
                                                    }
                                                    GeorgianBarPrice = GeorgianBar_0726Price_White;
                                                }
                                            }
                                            else if (wdm.WD_BaseColor == Base_Color._DarkBrown)
                                            {
                                                if (pnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
                                                {
                                                    if (pnl.Panel_GeorgianBar_HorizontalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0724Price_Woodgrain;
                                                    }
                                                    if (pnl.Panel_GeorgianBar_VerticalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0724Price_Woodgrain;
                                                    }
                                                    GeorgianBarPrice = GeorgianBar_0724Price_Woodgrain;

                                                }
                                                else if (pnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0726)
                                                {
                                                    if (pnl.Panel_GeorgianBar_HorizontalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0726Price_Woodgrain;
                                                    }
                                                    if (pnl.Panel_GeorgianBar_VerticalQty != 0)
                                                    {
                                                        GeorgianBarCost += (((pnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0726Price_Woodgrain;
                                                    }
                                                    GeorgianBarPrice = GeorgianBar_0726Price_Woodgrain;
                                                }
                                            }

                                        }
                                        #endregion

                                        #region GlassFilm
                                        if (pnl.Panel_GlassFilm == GlassFilm_Types._4milSolarGuard ||
                                            pnl.Panel_GlassFilm == GlassFilm_Types._4milUpera)
                                        {
                                            FilmPrice += ((pnl.Panel_GlassWidth / 1000m) * (pnl.Panel_GlassHeight / 1000m)) * _4millFilmPrice_PricePerSqrMeter;
                                        }
                                        else if (pnl.Panel_GlassFilm == GlassFilm_Types._FrostedFilm)
                                        {
                                            FilmPrice += ((pnl.Panel_GlassWidth / 1000m) * (pnl.Panel_GlassHeight / 1000m)) * FrostedFilmPrice_PricePerSqrMeter;
                                        }
                                        #endregion

                                        #region GlazingAdaptor
                                        if (pnl.Panel_ChkGlazingAdaptor == true)
                                        {
                                            GlazingBeadPerimeter = (pnl.Panel_GlazingBeadHeight + pnl.Panel_GlazingBeadWidth) * 2;
                                            GlazingAdaptorPrice += (GlazingBeadPerimeter / 1000) * GlazingAdaptorPricePerMeter;
                                        }
                                        #endregion

                                        #region SecurityMesh
                                        if (pnl.Panel_GlassThicknessDesc != null)
                                        {
                                            if (pnl.Panel_GlassThicknessDesc.Contains("Security Mesh"))
                                            {
                                                SecurityMeshPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * SecurityMeshPricePerSquaremeter;
                                                pnl.Panel_GlassPricePerSqrMeter = SecurityMeshPricePerSquaremeter;
                                            }
                                            else if (pnl.Panel_GlassThicknessDesc.Contains("Wire Mesh"))
                                            {
                                                WireMeshPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * WireMeshPricePerSquaremeter;
                                                pnl.Panel_GlassPricePerSqrMeter = WireMeshPricePerSquaremeter;
                                            }
                                            else if (pnl.Panel_GlassThicknessDesc.Contains("Pet Mesh"))
                                            {
                                                PetMeshPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * PetMeshPricePerSquaremeter;
                                                pnl.Panel_GlassPricePerSqrMeter = PetMeshPricePerSquaremeter;
                                            }
                                            else if (pnl.Panel_GlassThicknessDesc.Contains("Tuff Mesh"))
                                            {
                                                TuffMeshPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * TuffMeshPricePerSquaremeter;
                                                pnl.Panel_GlassPricePerSqrMeter = TuffMeshPricePerSquaremeter;
                                            }
                                            else if (pnl.Panel_GlassThicknessDesc.Contains("Phifer Mesh"))
                                            {
                                                PhiferMeshPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * PhiferMeshPricePerSquaremeter;
                                                pnl.Panel_GlassPricePerSqrMeter = PhiferMeshPricePerSquaremeter;
                                            }

                                            if (pnl.Panel_GlassThicknessDesc.Contains("Mesh"))
                                            {
                                                AluminumFramePrice += (((pnl.Panel_GlassHeight / 1000m) + (pnl.Panel_GlassWidth / 1000m)) * 2) * AluminumFramePricePerSquaremeter;
                                            }
                                        }
                                        #endregion
                                    }
                                    else if (pnl.Panel_Type.Contains("Louver"))
                                    {
                                        #region Louver

                                        CostingPoints += ProfileColorPoints;
                                        InstallationPoints += (ProfileColorPoints / 3);
                                        if (pnl.Panel_LouverMotorizeCheck == true)
                                        {
                                            LouvreFrameWeatherStripHeadPrice += (pnl.Panel_DisplayWidth * (LouvreFrameWeatherStripHeadPricePerMeter)) / 1000m;
                                            LouvreFrameBottomWeatherStripPrice += (pnl.Panel_DisplayWidth * (LouvreFrameBottomWeatherStripPricePerMeter)) / 1000m;
                                            PlantonWeatherStripHeadPrice += (pnl.Panel_DisplayWidth * (PlantonWeatherStripHeadPricePerMeter)) / 1000m;
                                            PlantonWeatherStripSillPrice += (pnl.Panel_DisplayWidth * (PlantonWeatherStripSillPricePerMeter)) / 1000m;

                                            BubbleSealPrice += ((pnl.Panel_DisplayWidth * 2) * BubbleSealPricePerMeter * pnl.Panel_LouverBladesCount) / 1000m;
                                            PowerKitIncludingWiresPrice += 132.59m * 1.3m * 1.1m * forex;
                                        }
                                        else if (pnl.Panel_LouverMotorizeCheck == false)
                                        {
                                            LouvreFrameWeatherStripHeadPrice += (pnl.Panel_DisplayWidth * (LouvreFrameWeatherStripHeadPricePerMeter + LouvreFrameWeatherStripHeadPowderCoatingPrice)) / 1000m;
                                            LouvreFrameBottomWeatherStripPrice += (pnl.Panel_DisplayWidth * (LouvreFrameBottomWeatherStripPricePerMeter + LouvreFrameBottomWeatherStripPowderCoatingPrice)) / 1000m;
                                            PlantonWeatherStripHeadPrice += (pnl.Panel_DisplayWidth * (PlantonWeatherStripHeadPricePerMeter + PlantonWeatherStripHeadPowderCoatingPrice)) / 1000m;
                                            PlantonWeatherStripSillPrice += (pnl.Panel_DisplayWidth * (PlantonWeatherStripSillPricePerMeter + PlantonWeatherStripSillPowderCoatingPrice)) / 1000m;

                                            BubbleSealPrice += ((pnl.Panel_DisplayWidth * 2) * BubbleSealPricePerMeter * pnl.Panel_LouverBladesCount) / 1000m;
                                            GalleryAdaptorPrice += ((pnl.Panel_DisplayHeight * 2) * GalleryAdaptorPricePerMeter) / 1000m;
                                        }

                                        if (pnl.Panel_LstLouverArtNo != null)
                                        {
                                            foreach (string lvrgArtNo in pnl.Panel_LstLouverArtNo)
                                            {

                                                if (lvrgArtNo.Contains("-S-"))
                                                {
                                                    ChckHandleType = "single";
                                                }
                                                else if (lvrgArtNo.Contains("-D-") ||
                                                         lvrgArtNo.Contains("-R-"))
                                                {
                                                    ChckHandleType = "dualORringpull";
                                                }



                                                lvrgBlades = lvrgArtNo.Replace("150", string.Empty);
                                                lvrgBlades = lvrgArtNo.Replace("152", string.Empty);
                                                lvrgBlades = Regex.Match(lvrgBlades, @"\d+").Value;

                                                #region Gallery
                                                if (ChckHandleType == "single")
                                                {
                                                    if (Convert.ToInt32(lvrgBlades) == 2)
                                                    {
                                                        GalleryPrice += GalleryPrice_2blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 3)
                                                    {
                                                        GalleryPrice += GalleryPrice_3blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 4)
                                                    {
                                                        GalleryPrice += GalleryPrice_4blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 5)
                                                    {
                                                        GalleryPrice += GalleryPrice_5blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 6)
                                                    {
                                                        GalleryPrice += GalleryPrice_6blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 7)
                                                    {
                                                        GalleryPrice += GalleryPrice_7blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 8)
                                                    {
                                                        GalleryPrice += GalleryPrice_8blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 9)
                                                    {
                                                        GalleryPrice += GalleryPrice_9blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 10)
                                                    {
                                                        GalleryPrice += GalleryPrice_10blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 11)
                                                    {
                                                        GalleryPrice += GalleryPrice_11blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 12)
                                                    {
                                                        GalleryPrice += GalleryPrice_12blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 13)
                                                    {
                                                        GalleryPrice += GalleryPrice_13blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 14)
                                                    {
                                                        GalleryPrice += GalleryPrice_14blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 15)
                                                    {
                                                        GalleryPrice += GalleryPrice_15blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 16)
                                                    {
                                                        GalleryPrice += GalleryPrice_16blades_usingSingleHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 17)
                                                    {
                                                        GalleryPrice += GalleryPrice_17blades_usingSingleHandle;
                                                    }
                                                }
                                                else if (ChckHandleType == "dualORringpull")
                                                {
                                                    if (Convert.ToInt32(lvrgBlades) == 2)
                                                    {
                                                        GalleryPrice += GalleryPrice_2blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 3)
                                                    {
                                                        GalleryPrice += GalleryPrice_3blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 4)
                                                    {
                                                        GalleryPrice += GalleryPrice_4blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 5)
                                                    {
                                                        GalleryPrice += GalleryPrice_5blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 6)
                                                    {
                                                        GalleryPrice += GalleryPrice_6blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 7)
                                                    {
                                                        GalleryPrice += GalleryPrice_7blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 8)
                                                    {
                                                        GalleryPrice += GalleryPrice_8blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 9)
                                                    {
                                                        GalleryPrice += GalleryPrice_9blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 10)
                                                    {
                                                        GalleryPrice += GalleryPrice_10blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 11)
                                                    {
                                                        GalleryPrice += GalleryPrice_11blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 12)
                                                    {
                                                        GalleryPrice += GalleryPrice_12blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 13)
                                                    {
                                                        GalleryPrice += GalleryPrice_13blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 14)
                                                    {
                                                        GalleryPrice += GalleryPrice_14blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 15)
                                                    {
                                                        GalleryPrice += GalleryPrice_15blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 16)
                                                    {
                                                        GalleryPrice += GalleryPrice_16blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 17)
                                                    {
                                                        GalleryPrice += GalleryPrice_17blades_usingDualHandleOrRingpullHandle;
                                                    }
                                                }




                                                #endregion

                                                #region SecurityKitCost 
                                                if (pnl.Panel_LouverSecurityGrillCheck == true)
                                                {
                                                    if (Convert.ToInt32(lvrgBlades) == 2)
                                                    {
                                                        SecurityKitCost += SecurityKit_2blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 3)
                                                    {
                                                        SecurityKitCost += SecurityKit_3blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 4)
                                                    {
                                                        SecurityKitCost += SecurityKit_4blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 5)
                                                    {
                                                        SecurityKitCost += SecurityKit_5blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 6)
                                                    {
                                                        SecurityKitCost += SecurityKit_6blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 7)
                                                    {
                                                        SecurityKitCost += SecurityKit_7blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 8)
                                                    {
                                                        SecurityKitCost += SecurityKit_8blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 9)
                                                    {
                                                        SecurityKitCost += SecurityKit_9blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 10)
                                                    {
                                                        SecurityKitCost += SecurityKit_10blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 11)
                                                    {
                                                        SecurityKitCost += SecurityKit_11blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 12)
                                                    {
                                                        SecurityKitCost += SecurityKit_12blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 13)
                                                    {
                                                        SecurityKitCost += SecurityKit_13blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 14)
                                                    {
                                                        SecurityKitCost += SecurityKit_14blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 15)
                                                    {
                                                        SecurityKitCost += SecurityKit_15blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 16)
                                                    {
                                                        SecurityKitCost += SecurityKit_16blades * 1.20m;
                                                    }
                                                    else if (Convert.ToInt32(lvrgBlades) == 17)
                                                    {
                                                        SecurityKitCost += SecurityKit_17blades * 1.20m;
                                                    }
                                                    SecurityKitPrice += SecurityKitCost + (pnl.Panel_DisplayHeight / 1000m) * 685 * 2; // =(285+400)
                                                }
                                                #endregion

                                            }
                                        }

                                        #region RingpullLeverHandle
                                        if (pnl.Panel_LouverRPLeverHandleCheck == true)
                                        {
                                            RingpullLeverHandlePrice = RingpullLeverHandlePricePerPiece;
                                        }
                                        #endregion

                                        #region Glass 
                                        if (pnl.Panel_GlassThickness == 6.0f)
                                        {
                                            if (pnl.Panel_LouverBladeTypeOption == BladeType_Option._glass)
                                            {

                                                if (pnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                                {
                                                    if (pnl.Panel_GlassThicknessDesc.Contains("Clear"))
                                                    {
                                                        GlassBladePrice += (pnl.Panel_Width * 152m / 1000000m) * Glass_6mmTemp_PricePerSqrMeter * Convert.ToInt32(lvrgBlades);
                                                    }
                                                    else if (pnl.Panel_GlassThicknessDesc.Contains("Tinted"))
                                                    {
                                                        GlassBladePrice += (pnl.Panel_Width * 152m / 1000000m) * Glass_6mmTempTinted_PricePerSqrMeter * Convert.ToInt32(lvrgBlades);
                                                    }
                                                    pnl.Panel_GlassPricePerSqrMeter = 152m;
                                                }
                                                else
                                                {
                                                    decimal BladeUsagePerPieceOfGlass = 0, BladeUsagePerPieceOfGlassCount = 0, BladeGlassMultiplier = 0;

                                                    BladeUsagePerPieceOfGlass = (pnl.Panel_Width / 1);

                                                    if (BladeUsagePerPieceOfGlass < 800)
                                                    {
                                                        BladeUsagePerPieceOfGlassCount = 3;
                                                    }
                                                    else if (BladeUsagePerPieceOfGlass > 800)
                                                    {
                                                        BladeUsagePerPieceOfGlassCount = 2;
                                                    }

                                                    BladeGlassMultiplier = ((1 * Convert.ToInt32(lvrgBlades)) / BladeUsagePerPieceOfGlassCount);//1 = # of panel

                                                    if (pnl.Panel_GlassThicknessDesc.Contains("Clear"))
                                                    {
                                                        GlassBladePrice += ((191.21m * forex) / 40) * Math.Round(BladeGlassMultiplier);
                                                        pnl.Panel_GlassPricePerSqrMeter = ((191.21m * forex) / 40);

                                                    }
                                                    else if (pnl.Panel_GlassThicknessDesc == "6mm Acid Etched Euro Grey")
                                                    {
                                                        GlassBladePrice += ((286.81m * forex) / 40) * Math.Round(BladeGlassMultiplier);
                                                        pnl.Panel_GlassPricePerSqrMeter = ((286.81m * forex) / 40);

                                                    }
                                                    else if (pnl.Panel_GlassThicknessDesc.Contains("Acid Etched"))
                                                    {
                                                        GlassBladePrice += ((262.91m * forex) / 40) * Math.Round(BladeGlassMultiplier);
                                                        pnl.Panel_GlassPricePerSqrMeter = ((262.91m * forex) / 40);

                                                    }
                                                    else if (pnl.Panel_GlassThicknessDesc.Contains("Euro Grey"))
                                                    {
                                                        GlassBladePrice += ((215.11m * forex) / 40) * Math.Round(BladeGlassMultiplier);
                                                        pnl.Panel_GlassPricePerSqrMeter = ((215.11m * forex) / 40);

                                                    }
                                                }
                                            }
                                            else if (pnl.Panel_LouverBladeTypeOption == BladeType_Option._Aluminum)
                                            {
                                                decimal BladeUsagePerPieceOfAluminum = 0, BladeUsagePerPieceOfAluminumCount = 0, BladeAluMultiplier = 0;
                                                BladeUsagePerPieceOfAluminum = (pnl.Panel_Width / 1); // 1= # of panels

                                                if (BladeUsagePerPieceOfAluminum < 800)
                                                {
                                                    BladeUsagePerPieceOfAluminumCount = 8;
                                                }
                                                else if (BladeUsagePerPieceOfAluminum > 800)
                                                {
                                                    BladeUsagePerPieceOfAluminumCount = 6;
                                                }

                                                BladeAluMultiplier = ((1 * Convert.ToInt32(lvrgBlades)) / BladeUsagePerPieceOfAluminumCount);//1 = # of panel

                                                //OneSidedFoiledCost += 698.40m * forex;
                                                //PowderCoatedWhiteIvoryCost += 551.77m * forex;
                                                //TwoSideFoiledWoodGrainCost += 926.47m * forex;
                                                //MillFinishCost += 191.21m * forex;

                                                decimal alumBladesPrice = 0;
                                                if (wdm.WD_BaseColor == Base_Color._Ivory ||
                                                    wdm.WD_BaseColor == Base_Color._White) //2 lang pinipili ng costing Milled or woodgrain
                                                {
                                                    alumBladesPrice = 35.63m * forex;
                                                }
                                                else if (wdm.WD_BaseColor == Base_Color._DarkBrown)
                                                {
                                                    alumBladesPrice = 926.47m * 5.8m;
                                                }

                                                GlassBladePrice = alumBladesPrice * Math.Ceiling(BladeAluMultiplier);
                                                pnl.Panel_GlassPricePerSqrMeter = alumBladesPrice;
                                            }
                                        }
                                        else if (pnl.Panel_GlassThickness >= 6.0f &&
                                                 pnl.Panel_GlassThickness <= 9.0f)
                                        {
                                            if (pnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                            {
                                                GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_PricePerSqrMeter;
                                                pnl.Panel_GlassPricePerSqrMeter = Glass_6mmTemp_PricePerSqrMeter;
                                            }
                                            else
                                            {
                                                GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmClr_PricePerSqrMeter;
                                                pnl.Panel_GlassPricePerSqrMeter = Glass_6mmClr_PricePerSqrMeter;

                                            }
                                        }
                                        else if (pnl.Panel_GlassThickness == 10.0f ||
                                         pnl.Panel_GlassThickness == 11.0f)
                                        {
                                            if (pnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                            {
                                                GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTemp_PricePerSqrMeter;
                                                pnl.Panel_GlassPricePerSqrMeter = Glass_10mmTemp_PricePerSqrMeter;

                                            }
                                            else
                                            {
                                                GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmClr_PricePerSqrMeter;
                                                pnl.Panel_GlassPricePerSqrMeter = Glass_10mmClr_PricePerSqrMeter;

                                            }
                                        }
                                        else if (pnl.Panel_GlassThickness >= 12.0f)
                                        {
                                            if (pnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                            {
                                                GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmTemp_PricePerSqrMeter;
                                                pnl.Panel_GlassPricePerSqrMeter = Glass_12mmTemp_PricePerSqrMeter;

                                            }
                                            else
                                            {
                                                GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmClr_PricePerSqrMeter;
                                                pnl.Panel_GlassPricePerSqrMeter = Glass_12mmClr_PricePerSqrMeter;

                                            }
                                        }
                                        else if (pnl.Panel_GlassThickness == 0.0f)
                                        {
                                            GlassPrice += 0;
                                            pnl.Panel_GlassPricePerSqrMeter = GlassPrice;

                                        }

                                        //sealant for glass
                                        Glass_SealantWHQty_Total = (int)(Math.Ceiling((decimal)((pnl.Panel_GlassWidth + pnl.Panel_GlassHeight) * 2) / 6842));

                                        if (pnl.Panel_GlassThickness != 0.0f)
                                        {
                                            if ((wdm.WD_BaseColor == Base_Color._Ivory || wdm.WD_BaseColor == Base_Color._White) && OneSideFoil_whiteBase == false)
                                            {
                                                SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_Clear;
                                            }
                                            else if (wdm.WD_BaseColor == Base_Color._DarkBrown || OneSideFoil_whiteBase == true)
                                            {
                                                SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_BrownBlack;
                                            }
                                        }
                                        #endregion

                                        #region GlassFilm
                                        if (pnl.Panel_GlassFilm == GlassFilm_Types._4milSolarGuard ||
                                            pnl.Panel_GlassFilm == GlassFilm_Types._4milUpera)
                                        {
                                            FilmPrice += ((pnl.Panel_GlassWidth / 1000m) * (pnl.Panel_GlassHeight / 1000m)) * _4millFilmPrice_PricePerSqrMeter;
                                        }
                                        else if (pnl.Panel_GlassFilm == GlassFilm_Types._FrostedFilm)
                                        {
                                            FilmPrice += ((pnl.Panel_GlassWidth / 1000m) * (pnl.Panel_GlassHeight / 1000m)) * FrostedFilmPrice_PricePerSqrMeter;
                                        }
                                        #endregion

                                        #endregion
                                    }

                                    #region Glass Based Price

                                    //if (pnl.Panel_GlassThicknessDesc != null)
                                    //{
                                    //    Glass_HeightxWidth_Total = ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m));

                                    //    if (Glass_HeightxWidth_Total != 0)
                                    //    {
                                    //        if (glassidholder.Contains(pnl.PanelGlass_ID) == false)
                                    //        {
                                    //            glassidholder.Add(pnl.PanelGlass_ID);
                                    //            curr_mpaneID = mpnl.MPanel_ID;

                                    //            if (curr_mpaneID == 1)
                                    //            {
                                    //                if (pnl.PanelGlass_ID == 1)
                                    //                {
                                    //                    mp_arr1[pnl.PanelGlass_ID] = GlassPrice;
                                    //                    pnl.Panel_GlassPricePerSqrMeter = mp_arr1[pnl.PanelGlass_ID] / Glass_HeightxWidth_Total;
                                    //                    indexer++;
                                    //                }
                                    //                else
                                    //                {
                                    //                    var sum = mp_arr1.Aggregate((element1, element2) => element1 + element2);

                                    //                    mp_arr1[pnl.PanelGlass_ID] = GlassPrice - sum;
                                    //                    pnl.Panel_GlassPricePerSqrMeter = mp_arr1[pnl.PanelGlass_ID] / Glass_HeightxWidth_Total;
                                    //                    indexer++;
                                    //                }
                                    //            }
                                    //            else if (curr_mpaneID == 2)
                                    //            {
                                    //                if (pnl.PanelGlass_ID == 1)
                                    //                {
                                    //                    mp_arr2[pnl.PanelGlass_ID] = GlassPrice;
                                    //                    pnl.Panel_GlassPricePerSqrMeter = mp_arr2[pnl.PanelGlass_ID] / Glass_HeightxWidth_Total;
                                    //                    indexer++;
                                    //                }
                                    //                else
                                    //                {
                                    //                    var arr1_total = mp_arr1.Aggregate((element1, element2) => element1 + element2);
                                    //                    var sum = mp_arr2.Aggregate((element1, element2) => element1 + element2);

                                    //                    mp_arr2[pnl.PanelGlass_ID] = GlassPrice - (sum + arr1_total);
                                    //                    pnl.Panel_GlassPricePerSqrMeter = mp_arr2[pnl.PanelGlass_ID] / Glass_HeightxWidth_Total;
                                    //                    indexer++;
                                    //                }

                                    //            }
                                    //            else if (curr_mpaneID == 3)
                                    //            {
                                    //                if (pnl.PanelGlass_ID == 1)
                                    //                {
                                    //                    mp_arr3[0] = GlassPrice;
                                    //                    pnl.Panel_GlassPricePerSqrMeter = mp_arr3[0] / Glass_HeightxWidth_Total;
                                    //                    indexer++;
                                    //                }
                                    //                else
                                    //                {
                                    //                    var prev_GlassPrice = mp_arr1.Aggregate((element1, element2) => element1 + element2) +
                                    //                                          mp_arr2.Aggregate((element1, element2) => element1 + element2);

                                    //                    var sum = mp_arr3.Aggregate((element1, element2) => element1 + element2);

                                    //                    mp_arr3[indexer] = GlassPrice - (prev_GlassPrice + sum);
                                    //                    pnl.Panel_GlassPricePerSqrMeter = mp_arr3[indexer] / Glass_HeightxWidth_Total;
                                    //                    indexer++;
                                    //                }
                                    //            }
                                    //            else if (curr_mpaneID == 4)
                                    //            {
                                    //                if (pnl.PanelGlass_ID == 1)
                                    //                {
                                    //                    mp_arr4[0] = GlassPrice;
                                    //                    pnl.Panel_GlassPricePerSqrMeter = mp_arr4[0] / Glass_HeightxWidth_Total;
                                    //                    indexer++;
                                    //                }
                                    //                else
                                    //                {
                                    //                    var prev_glassprice = mp_arr1.Aggregate((element1, element2) => element1 + element2) +
                                    //                                          mp_arr2.Aggregate((element1, element2) => element1 + element2) +
                                    //                                          mp_arr3.Aggregate((element1, element2) => element1 + element2);

                                    //                    var sum = mp_arr4.Aggregate((element1, element2) => element1 + element2);

                                    //                    mp_arr4[indexer] = GlassPrice - (prev_glassprice + sum);
                                    //                    pnl.Panel_GlassPricePerSqrMeter = mp_arr4[indexer] / Glass_HeightxWidth_Total;
                                    //                    indexer++;
                                    //                }
                                    //            }
                                    //            else if (curr_mpaneID == 5)
                                    //            {
                                    //                if (pnl.PanelGlass_ID == 1)
                                    //                {
                                    //                    mp_arr5[0] = GlassPrice;
                                    //                    pnl.Panel_GlassPricePerSqrMeter = mp_arr5[0] / Glass_HeightxWidth_Total;
                                    //                    indexer++;
                                    //                }
                                    //                else
                                    //                {
                                    //                    var prev_glassprice = mp_arr1.Aggregate((element1, element2) => element1 + element2) +
                                    //                                          mp_arr2.Aggregate((element1, element2) => element1 + element2) +
                                    //                                          mp_arr3.Aggregate((element1, element2) => element1 + element2) +
                                    //                                          mp_arr4.Aggregate((element1, element2) => element1 + element2);

                                    //                    var sum = mp_arr5.Aggregate((element1, element2) => element1 + element2);

                                    //                    mp_arr5[indexer] = GlassPrice - (prev_glassprice + sum);
                                    //                    pnl.Panel_GlassPricePerSqrMeter = mp_arr5[indexer] / Glass_HeightxWidth_Total;
                                    //                    indexer++;
                                    //                }
                                    //            }
                                    //            else if (curr_mpaneID == 6)
                                    //            {
                                    //                if (pnl.PanelGlass_ID == 1)
                                    //                {
                                    //                    mp_arr6[0] = GlassPrice;
                                    //                    pnl.Panel_GlassPricePerSqrMeter = mp_arr6[0] / Glass_HeightxWidth_Total;
                                    //                    indexer++;
                                    //                }
                                    //                else
                                    //                {
                                    //                    var prev_glassprice = mp_arr1.Aggregate((element1, element2) => element1 + element2) +
                                    //                                          mp_arr2.Aggregate((element1, element2) => element1 + element2) +
                                    //                                          mp_arr3.Aggregate((element1, element2) => element1 + element2) +
                                    //                                          mp_arr4.Aggregate((element1, element2) => element1 + element2) +
                                    //                                          mp_arr5.Aggregate((element1, element2) => element1 + element2);

                                    //                    mp_arr6.Aggregate((element1, element2) => element1 + element2);

                                    //                    var sum = mp_arr6.Aggregate((element1, element2) => element1 + element2);

                                    //                    mp_arr6[indexer] = GlassPrice - (prev_glassprice + sum);
                                    //                    pnl.Panel_GlassPricePerSqrMeter = mp_arr6[indexer] / Glass_HeightxWidth_Total;
                                    //                    indexer++;
                                    //                }
                                    //            }
                                    //            else if (curr_mpaneID == 7)
                                    //            {
                                    //                if (pnl.PanelGlass_ID == 1)
                                    //                {
                                    //                    mp_arr7[0] = GlassPrice;
                                    //                    pnl.Panel_GlassPricePerSqrMeter = mp_arr7[0] / Glass_HeightxWidth_Total;
                                    //                    indexer++;
                                    //                }
                                    //                else
                                    //                {                                                      
                                    //                    var prev_GlassPrice = mp_arr1.Aggregate((element1, element2) => element1 + element2) + 
                                    //                                          mp_arr2.Aggregate((element1, element2) => element1 + element2) + 
                                    //                                          mp_arr3.Aggregate((element1, element2) => element1 + element2) +
                                    //                                          mp_arr4.Aggregate((element1, element2) => element1 + element2) + 
                                    //                                          mp_arr5.Aggregate((element1, element2) => element1 + element2) +
                                    //                                          mp_arr6.Aggregate((element1, element2) => element1 + element2);

                                    //                    var sum = mp_arr7.Aggregate((element1, element2) => element1 + element2);

                                    //                    mp_arr7[indexer] = GlassPrice - (sum + prev_GlassPrice);
                                    //                    pnl.Panel_GlassPricePerSqrMeter = mp_arr7[indexer] / Glass_HeightxWidth_Total;
                                    //                    indexer++;
                                    //                }
                                    //            }

                                    //        }
                                    //    }
                                    //}

                                    #endregion

                                }
                            }
                        }
                        #endregion

                        #region SinglePnl 
                        else if (fr.Lst_Panel.Count() == 1 && fr.Lst_MultiPanel.Count() == 0)//single
                        {
                            IPanelModel Singlepnl = fr.Lst_Panel[0];

                            if (Singlepnl.Panel_SashPropertyVisibility == true)
                            {
                                #region Casement 
                                if (Singlepnl.Panel_Type.Contains("Casement"))
                                {
                                    MiddleCLoserPrice += MiddleCLoserPricePerPiece * Singlepnl.Panel_MiddleCloserPairQty;

                                    if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                    {
                                        if (Singlepnl.Panel_HingeOptions == HingeOption._2DHinge)
                                        {
                                            _2DHingePrice += _2DHingePricePerPiece * Singlepnl.Panel_2DHingeQty_nonMotorized;
                                        }
                                        else if (Singlepnl.Panel_HingeOptions == HingeOption._FrictionStay)
                                        {
                                            if (Singlepnl.Panel_MotorizedOptionVisibility == true && cus_ref_date >= changeCondition_112323)
                                            {
                                                //remove fs in motorize
                                            }
                                            else
                                            {
                                                if (cus_ref_date <= changeCondition_061423)
                                                {
                                                    if (Singlepnl.Panel_SashHeight >= 800)
                                                    {
                                                        FSPrice += FS_26HD_casementPricePerPiece * 2;
                                                        FSBasePrice = FS_26HD_casementPricePerPiece;
                                                    }
                                                    else
                                                    {
                                                        FSPrice += FS_16HD_casementPricePerPiece * 2;
                                                        FSBasePrice = FS_16HD_casementPricePerPiece;
                                                    }
                                                }
                                                else
                                                {
                                                    if (Singlepnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._20HD)
                                                    {
                                                        FSPrice += FS_26HD_casementPricePerPiece * 2;
                                                        FSBasePrice = FS_26HD_casementPricePerPiece;
                                                    }
                                                    else if (Singlepnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._10HD ||
                                                             Singlepnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._12FS ||
                                                             Singlepnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._12HD ||
                                                             Singlepnl.Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._16HD)
                                                    {
                                                        FSPrice += FS_16HD_casementPricePerPiece * 2;
                                                        FSBasePrice = FS_16HD_casementPricePerPiece;
                                                    }
                                                }
                                            }
                                        }

                                        if (Singlepnl.Panel_ExtensionOptionsVisibility == true &&
                                        Singlepnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._None ||
                                        Singlepnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._None ||
                                        Singlepnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._None ||
                                        Singlepnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._None)
                                        {
                                            if (Singlepnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._630956 ||
                                                Singlepnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._630956 ||
                                                Singlepnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._630956 ||
                                                Singlepnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._630956)
                                            {
                                                ExtensionPrice += Extension_639957PricePerPiece;
                                                ExtensionBasePrice = Extension_639957PricePerPiece;
                                            }
                                        }

                                        if (Singlepnl.Panel_HandleOptionsVisibility == true)
                                        {
                                            if (Singlepnl.Panel_HandleType == Handle_Type._Rotoswing)
                                            {
                                                HandlePrice += RotoswingHanldePricePerPiece;

                                                HandleBasePrice = RotoswingHanldePricePerPiece;
                                            }
                                            else if (Singlepnl.Panel_HandleType == Handle_Type._Rotary)
                                            {
                                                //wlang price ng rotaty 
                                            }
                                        }
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                                 Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                    {
                                        #region Handle
                                        if (Singlepnl.Panel_HandleOptionsVisibility == true)
                                        {
                                            if (Singlepnl.Panel_HandleType == Handle_Type._MVD)
                                            {
                                                HandlePrice += MVDHandlePricePerPiece;

                                                LatchDeadboltStrikerPrice += LatchDeadboltStrikerPricePerPiece;
                                                HandleBasePrice = MVDHandlePricePerPiece;
                                            }
                                            else if (Singlepnl.Panel_HandleType == Handle_Type._Rio)
                                            {
                                                HandlePrice += RioHandlePricePerPiece;

                                                HandleBasePrice = RioHandlePricePerPiece;
                                            }
                                            else if (Singlepnl.Panel_HandleType == Handle_Type._Rotoline)
                                            {
                                                //wlang presyo ng rotoline
                                            }
                                        }
                                        #endregion

                                        #region ExtensionPrice 
                                        if (Singlepnl.Panel_ExtensionOptionsVisibility == true &&
                                            Singlepnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._None ||
                                            Singlepnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._None ||
                                            Singlepnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._None ||
                                            Singlepnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._None)
                                        {
                                            if (Singlepnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._630956 ||
                                                Singlepnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._630956 ||
                                                Singlepnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._630956 ||
                                                Singlepnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._630956)
                                            {
                                                ExtensionPrice += MVDExtensionPricePerPiece;
                                                ExtensionBasePrice = MVDExtensionPricePerPiece;
                                            }
                                            else if (Singlepnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._630956 ||
                                                     Singlepnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._630956 ||
                                                     Singlepnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._630956 ||
                                                     Singlepnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._630956)
                                            {
                                                ExtensionPrice += Extension_567639PricePerPiece;
                                                ExtensionBasePrice = MVDExtensionPricePerPiece;
                                            }
                                        }
                                        #endregion

                                        if (ChckDM == true)
                                        {
                                            StrikerPrice += AdjustableStrikerPricePerPiece * Singlepnl.Panel_AdjStrikerQty;
                                        }

                                        RestrictorStayPrice += RestrictorStayPricePerPiece * 2;

                                        _35mmBacksetEspagWithCylinderPrice += _35mmBacksetEspagWithCylinder;

                                        _3DHingePrice += _3DHingePricePerPiece * Singlepnl.Panel_3dHingeQty;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                    {
                                        if (Singlepnl.Panel_CenterHingeOptionsVisibility == true)
                                        {
                                            if (Singlepnl.Panel_CenterHingeOptions == CenterHingeOption._NTCenterHinge)
                                            {
                                                NTCenterHingePrice += NTCenterHingePricePerPiece;
                                            }
                                            else if (Singlepnl.Panel_CenterHingeOptions == CenterHingeOption._MiddleCloser)
                                            {
                                                MiddleCLoserPrice += MiddleCLoserPricePerPiece * Singlepnl.Panel_MiddleCloserPairQty;
                                            }
                                        }

                                        if (Singlepnl.Panel_HandleOptionsVisibility == true)
                                        {
                                            if (Singlepnl.Panel_HandleType == Handle_Type._Rotoswing)
                                            {
                                                HandlePrice += RotoswingHanldePricePerPiece;

                                                HandleBasePrice = RotoswingHanldePricePerPiece;
                                            }
                                        }

                                        StayBearingPrice += StayBearingPricePerPiece * 2;
                                        StayBearingPinPrice += StayBearingPinPricePerPiece * 2;
                                        TopCornerHingePrice += TopCornerHingePricePerPiece;
                                        CornerPivotRestPrice += CornerPivotRestPricePerPiece;
                                        CoverStayBearingPrice += CoverStayBearingPricePerPiece;
                                        CoverCornerHingePrice += CoverCornerHingePricePerPiece;
                                        CorverCornerPivotRestPrice += CorverCornerPivotRestPricePerPiece;
                                        CorverCornerPivotRestVerticalPrice += CorverCornerPivotRestVerticalPricePerPiece;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                    {
                                        SnapInKeepPrice += SnapInKeepPricePerPiece * 2;
                                    }

                                    if (Singlepnl.Panel_CornerDriveOptionsVisibility == true &&
                                        Singlepnl.Panel_CornerDriveArtNo != CornerDrive_ArticleNo._None &&
                                        Singlepnl.Panel_CornerDriveArtNo != null)
                                    {
                                        CornerDrivePrice += CornerDrivePricePerPiece * 2;
                                    }

                                }
                                #endregion
                                #region Awning 
                                else if (Singlepnl.Panel_Type.Contains("Awning"))
                                {
                                    if (Singlepnl.Panel_HingeOptions == HingeOption._2DHinge || Singlepnl.Panel_LouverMotorizeCheck == true)
                                    {
                                        _2DHingePrice += _2DHingePricePerPiece * Singlepnl.Panel_2DHingeQty_nonMotorized;
                                    }
                                    else if (cus_ref_date < changeCondition_033023)
                                    {
                                        #region FSPrice
                                        if (Singlepnl.Panel_SashHeight >= 800)
                                        {
                                            FSPrice += FS_26HD_casementPricePerPiece * 2;
                                            FSBasePrice = FS_26HD_casementPricePerPiece;
                                        }
                                        else
                                        {
                                            FSPrice += FS_16HD_casementPricePerPiece * 2;
                                            FSBasePrice = FS_16HD_casementPricePerPiece;
                                        }
                                        #endregion
                                    }
                                    else if (cus_ref_date >= changeCondition_033023 &&
                                             cus_ref_date <= changeCondition_040423)
                                    {
                                        if (Singlepnl.Panel_HingeOptions == HingeOption._2DHinge)
                                        {
                                            if (cus_ref_date <= changeCondition_061423) // Date_Assigned
                                            {
                                                #region FSPrice
                                                if (Singlepnl.Panel_SashHeight >= 800)
                                                {
                                                    FSPrice += FS_26HD_casementPricePerPiece * 2;
                                                    FSBasePrice = FS_26HD_casementPricePerPiece;
                                                }
                                                else
                                                {
                                                    FSPrice += FS_16HD_casementPricePerPiece * 2;
                                                    FSBasePrice = FS_16HD_casementPricePerPiece;
                                                }
                                                #endregion
                                            }
                                        }
                                    }
                                    else if (cus_ref_date >= changeCondition_040423 && cus_ref_date < changeCondition_061423)
                                    {
                                        if (Singlepnl.Panel_HingeOptions == HingeOption._FrictionStay)
                                        {
                                            #region FSPrice
                                            if (Singlepnl.Panel_SashHeight >= 800)
                                            {
                                                FSPrice += FS_26HD_casementPricePerPiece * 2;
                                                FSBasePrice = FS_26HD_casementPricePerPiece;
                                            }
                                            else
                                            {
                                                FSPrice += FS_16HD_casementPricePerPiece * 2;
                                                FSBasePrice = FS_16HD_casementPricePerPiece;
                                            }
                                            #endregion
                                        }
                                    }
                                    else if (cus_ref_date >= changeCondition_061423)
                                    {
                                        if (Singlepnl.Panel_MotorizedOptionVisibility == true && cus_ref_date >= changeCondition_112323)
                                        {
                                            //remove fs in motorize
                                        }
                                        else
                                        {
                                            #region FSPrice
                                            if (Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm22 ||
                                                Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm26)
                                            {
                                                FSPrice += FS_26HD_casementPricePerPiece * 2;
                                                FSBasePrice = FS_26HD_casementPricePerPiece;

                                                if (Singlepnl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                                {
                                                    SnapInKeepPrice += SnapInKeepPricePerPiece * 2;
                                                }
                                            }
                                            else if (Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm8 ||
                                                     Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._10HD ||
                                                     Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._12HD ||
                                                     Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._16HD)
                                            {
                                                FSPrice += FS_16HD_casementPricePerPiece * 2;
                                                FSBasePrice = FS_16HD_casementPricePerPiece;
                                            }
                                            #endregion
                                        }
                                    }

                                    #region OldAlgoForFS


                                    //else if (Date_Assigned <= changeCondition_040423)
                                    //{
                                    //    if (Singlepnl.Panel_HingeOptions == HingeOption._2DHinge)
                                    //    {
                                    //        if (Date_Assigned <= changeCondition_061423) // Date_Assigned
                                    //        {
                                    //            #region FSPrice
                                    //            if (Singlepnl.Panel_SashHeight >= 800)
                                    //            {
                                    //                FSPrice += FS_26HD_casementPricePerPiece * 2;
                                    //                FSBasePrice = FS_26HD_casementPricePerPiece;
                                    //            }
                                    //            else
                                    //            {
                                    //                FSPrice += FS_16HD_casementPricePerPiece * 2;
                                    //                FSBasePrice = FS_16HD_casementPricePerPiece;
                                    //            }
                                    //            #endregion
                                    //        }
                                    //        else
                                    //        {
                                    //            #region FSPrice
                                    //            if (Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm22 ||
                                    //                Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm26)
                                    //            {
                                    //                FSPrice += FS_26HD_casementPricePerPiece * 2;
                                    //                FSBasePrice = FS_26HD_casementPricePerPiece;

                                    //                if (Singlepnl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                    //                {
                                    //                    SnapInKeepPrice += SnapInKeepPricePerPiece * 2;
                                    //                }
                                    //            }
                                    //            else if (Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm8 ||
                                    //                     Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._10HD ||
                                    //                     Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._12HD ||
                                    //                     Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._16HD)
                                    //            {
                                    //                FSPrice += FS_16HD_casementPricePerPiece * 2;
                                    //                FSBasePrice = FS_16HD_casementPricePerPiece;
                                    //            }
                                    //            #endregion
                                    //        }
                                    //    }
                                    //}
                                    //else if (Singlepnl.Panel_HingeOptions == HingeOption._FrictionStay)
                                    //{
                                    //    if (Date_Assigned <= changeCondition_061423) // Date_Assigned
                                    //    {
                                    //        #region FSPrice
                                    //        if (Singlepnl.Panel_SashHeight >= 800)
                                    //        {
                                    //            FSPrice += FS_26HD_casementPricePerPiece * 2;
                                    //            FSBasePrice = FS_26HD_casementPricePerPiece;
                                    //        }
                                    //        else
                                    //        {
                                    //            FSPrice += FS_16HD_casementPricePerPiece * 2;
                                    //            FSBasePrice = FS_16HD_casementPricePerPiece;
                                    //        }
                                    //        #endregion
                                    //    }
                                    //    else
                                    //    {
                                    //        #region FSPrice
                                    //        if (Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm22 ||
                                    //            Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm26)
                                    //        {
                                    //            FSPrice += FS_26HD_casementPricePerPiece * 2;
                                    //            FSBasePrice = FS_26HD_casementPricePerPiece;

                                    //            if (Singlepnl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                    //            {
                                    //                SnapInKeepPrice += SnapInKeepPricePerPiece * 2;
                                    //            }
                                    //        }
                                    //        else if (Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm8 ||
                                    //                 Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._10HD ||
                                    //                 Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._12HD ||
                                    //                 Singlepnl.Panel_FrictionStayArtNo == FrictionStay_ArticleNo._16HD)
                                    //        {
                                    //            FSPrice += FS_16HD_casementPricePerPiece * 2;
                                    //            FSBasePrice = FS_16HD_casementPricePerPiece;
                                    //        }
                                    //        #endregion
                                    //    }
                                    //}

                                    #endregion


                                    if (Singlepnl.Panel_HandleOptionsVisibility == true)
                                    {
                                        if (Singlepnl.Panel_HandleType == Handle_Type._Rotoswing)
                                        {
                                            HandlePrice += RotoswingHanldePricePerPiece;

                                            HandleBasePrice = RotoswingHanldePricePerPiece;
                                        }
                                        else if (Singlepnl.Panel_HandleType == Handle_Type._Rotary)
                                        {
                                            //wlang price ng rotaty 
                                        }
                                    }

                                    MiddleCLoserPrice += MiddleCLoserPricePerPiece * Singlepnl.Panel_MiddleCloserPairQty;
                                }
                                #endregion
                                #region Sliding 
                                else if (Singlepnl.Panel_Type.Contains("Sliding"))
                                {
                                    #region handle
                                    if (Singlepnl.Panel_HandleOptionsVisibility == true)
                                    {
                                        if (Singlepnl.Panel_HandleType == Handle_Type._Rotoswing)
                                        {
                                            HandlePrice += RotoswingHanldePricePerPiece;

                                            HandleBasePrice = RotoswingHanldePricePerPiece;
                                        }
                                        else if (Singlepnl.Panel_HandleType == Handle_Type._RotoswingForSliding)
                                        {
                                            HandlePrice += RotoswingHanldeForSlidingPricePerPiece;

                                            HandleBasePrice = RotoswingHanldeForSlidingPricePerPiece;
                                        }
                                        else if (Singlepnl.Panel_HandleType == Handle_Type._Rio)
                                        {
                                            HandlePrice += RioHandlePricePerPiece;

                                            HandleBasePrice = RioHandlePricePerPiece;
                                        }
                                        else if (Singlepnl.Panel_HandleType == Handle_Type._PopUp)
                                        {
                                            HandlePrice += PopUpHandlePricePerPiece;

                                            HandleBasePrice = PopUpHandlePricePerPiece;
                                        }
                                        else if (Singlepnl.Panel_HandleType == Handle_Type._D)
                                        {
                                            HandlePrice += DHandlePricePerPiece;

                                            HandleBasePrice = DHandlePricePerPiece;
                                        }
                                        else if (Singlepnl.Panel_HandleType == Handle_Type._DummyD)
                                        {
                                            HandlePrice += DummyDHandlePricePerPiece;

                                            HandleBasePrice = RioHandlePricePerPiece;
                                        }
                                        else if (Singlepnl.Panel_HandleType == Handle_Type._D_IO_Locking)
                                        {
                                            HandlePrice += DHandleInOutLockingPricePerPiece;

                                            HandleBasePrice = DHandleInOutLockingPricePerPiece;
                                        }
                                    }
                                    #endregion

                                    BrushSealPrice = ((Singlepnl.Panel_Height / 1000m) * 2 * 2) * BrushSealPricePerLinearMeter; // 2qty 2perimeter

                                    if (Singlepnl.Panel_RollersTypes == RollersTypes._TandemRoller ||
                                        Singlepnl.Panel_RollersTypes == RollersTypes._HDRoller)
                                    {
                                        RollerPrice += 2 * HDRollerPricePerPiece;
                                        RollerBasePrice = HDRollerPricePerPiece;
                                    }
                                    else if (Singlepnl.Panel_RollersTypes == RollersTypes._GURoller)
                                    {
                                        RollerPrice += 2 * GURollerPricePerPiece;
                                        RollerBasePrice = GURollerPricePerPiece;
                                    }

                                    if (Singlepnl.Panel_HandleType != Handle_Type._None)
                                    {
                                        StrikerLRPrice += 1 * StrikerLRPricePerPiece;
                                    }

                                    WeatherBarPrice += (fr.Frame_Width / 1000m) * WeatherBarPricePerPiece;
                                    WeatherBarFastenerPrice += (int)(fr.Frame_Width / 300m) * BarFastenerPricePerPiece;
                                    WaterSeepagePrice += (fr.Frame_Width / 1000m) * WaterSeepagePricePerLinearMeter;
                                    GuideTrackPrice += ((GuideTrackPricePerLinearMeter / 1000m) * 2) * Singlepnl.Panel_AluminumTrackQty;
                                    AlumTrackPrice += ((AluminumTrackPricePerLinearMeter / 1000m) * 2) * Singlepnl.Panel_AluminumTrackQty;

                                    if (Singlepnl.Panel_Overlap_Sash != OverlapSash._None)
                                    {
                                        int bothOverlapQtyMultiplier = 1;
                                        if (Singlepnl.Panel_Overlap_Sash == OverlapSash._Both)
                                        {
                                            bothOverlapQtyMultiplier = 2;
                                        }

                                        InterlockPrice += (2 * bothOverlapQtyMultiplier) * InterlockPricePerPiece;
                                        ExtensionForInterlockPrice += (2 * bothOverlapQtyMultiplier) * ExtensionForInterlockPricePerPiece;
                                        SealingBlockPrice += (2 * bothOverlapQtyMultiplier) * SealingBlockPricePerPiece;
                                    }

                                    if (fr.Frame_Type == FrameModel.Frame_Padding.Door &&
                                        fr.Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                                        Singlepnl.Panel_SashHeight >= 3100)
                                    {
                                        AluminumPullHandlePrice = ((Singlepnl.Panel_SashHeight - 5) / 1000m) * AluminumPullHandlePricePerLinearMeter;
                                    }

                                }
                                #endregion

                                #region dSash 
                                if (Singlepnl.Panel_ChkText == "dSash" && Singlepnl.Panel_Type.Contains("Fixed"))
                                {
                                    #region SashPrice 
                                    SashPerimeter = (Singlepnl.Panel_SashHeight + Singlepnl.Panel_SashWidth) * 2;

                                    if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_7581_White;
                                            if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                               (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_7581_White_1sideFoil;
                                            }
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_7581_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_7581;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_374_White;
                                            if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                               (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_374_White_1sideFoil;
                                            }
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_374_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_373_White;
                                            if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                               (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_373_White_1sideFoil;
                                            }
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_373_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_395_White;
                                            if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                               (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_395_White_1sideFoil;
                                            }
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_395_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_395;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_2067_White;
                                        SashReinPricePerLinearMeter = G58ReinPricePerLinearMeter_V226;

                                        GlazingGasketPrice += (SashPerimeter / 1000m) * GlazingGasketPricePerLinearMeter;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                                    {
                                        if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_6040_White;
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_6040_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6040;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                                    {
                                        if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_6041_White;
                                            if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                               (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_6041_White_1sideFoil;
                                            }
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_6041_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6041;
                                    }



                                    SashPrice += (SashPerimeter / 1000m) * SashPricePerLinearMeter;
                                    SashReinPrice += (SashPerimeter / 1000m) * SashReinPricePerLinearMeter;
                                    GbPrice += (SashPerimeter / 1000m) * GlazingBeadPricePerLinearMeter;
                                    #endregion

                                    MiddleCLoserPrice += MiddleCLoserPricePerPiece * Singlepnl.Panel_MiddleCloserPairQty;
                                    SpacerFixSashPrice += 2 * SpacerFixSashPricePerPiece;
                                }
                                else
                                {
                                    #region SashPrice 
                                    SashPerimeter = (Singlepnl.Panel_SashHeight + Singlepnl.Panel_SashWidth) * 2;

                                    if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_7581_White;
                                            if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                               (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_7581_White_1sideFoil;
                                            }
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_7581_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_7581;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_374_White;
                                            if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                               (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_374_White_1sideFoil;
                                            }
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_374_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_373_White;
                                            if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                               (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_373_White_1sideFoil;
                                            }
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_373_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_395_White;
                                            if ((wdm.WD_InsideColor == Foil_Color._None && wdm.WD_OutsideColor != Foil_Color._None) ||
                                               (wdm.WD_InsideColor != Foil_Color._None && wdm.WD_OutsideColor == Foil_Color._None))
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_395_White_1sideFoil;
                                            }
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_395_WoodGrain;
                                        }
                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_395;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_2067_White;
                                        SashReinPricePerLinearMeter = G58ReinPricePerLinearMeter_V226;

                                        GlazingGasketPrice += (SashPerimeter / 1000m) * GlazingGasketPricePerLinearMeter;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                                    {
                                        if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_6040_White;
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_6040_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6040;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                                    {
                                        if ((wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory) && OneSideFoil_whiteBase == false)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_6041_White;
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_6041_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6041;
                                    }

                                    SashPrice += (SashPerimeter / 1000m) * SashPricePerLinearMeter;
                                    SashReinPrice += (SashPerimeter / 1000m) * SashReinPricePerLinearMeter;
                                    GbPrice += (SashPerimeter / 1000m) * GlazingBeadPricePerLinearMeter;
                                    #endregion
                                }
                                #endregion

                                if (Singlepnl.Panel_GlassThickness == 6.0f)
                                {
                                    GBSpacerPrice += GBSpacerPricePerPiece * 4;
                                }

                                if (ChckPlasticWedge == true)
                                {
                                    PlasticWedgePrice += PlasticWedgePricePerPiece;
                                }

                                #region Motorize 
                                if (Singlepnl.Panel_MotorizedOptionVisibility == true)
                                {
                                    if (Singlepnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41555B ||
                                                Singlepnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41556C)
                                    {
                                        MotorizeMechPricePerPiece = MotorizeMechPrice;
                                    }
                                    else if (Singlepnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._409990E)
                                    {
                                        MotorizeMechPricePerPiece = MotorizeMechHeavyDutyPrice;
                                    }
                                    else if (Singlepnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41731V)
                                    {
                                        MotorizeMechPricePerPiece = MotorizeMechUsingRemotePrice;


                                    }

                                    if (chckPerFrameMotorMech == true)
                                    {
                                        MotorizePrice += MotorizeMechPricePerPiece * Singlepnl.Panel_MotorizedMechQty;
                                        if (Singlepnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41731V)
                                        {
                                            RemoteForMotorizeMechPrice = MotorizeMechRemotePricePerPiece;
                                        }


                                        chckPerFrameMotorMech = false;
                                    }

                                }
                                #endregion

                                #region EspagPrice

                                if (Singlepnl.Panel_EspagnoletteOptionsVisibility == true && Singlepnl.Panel_ChkText != "dSash")
                                {
                                    if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._None &&
                                        cus_ref_date >= changeCondition_080323)
                                    {

                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A00006)
                                    {
                                        EspagPrice += TiltAndTurnEspag_N110A00006PricePerPiece;
                                        EspagBasePrice = TiltAndTurnEspag_N110A00006PricePerPiece;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A01006)
                                    {
                                        EspagPrice += TiltAndTurnEspag_N110A01006PricePerPiece;
                                        EspagBasePrice = TiltAndTurnEspag_N110A01006PricePerPiece;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206)
                                    {
                                        EspagPrice += TiltAndTurnEspag_N110A02206PricePerPiece;
                                        EspagBasePrice = TiltAndTurnEspag_N110A02206PricePerPiece;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                                    {
                                        EspagPrice += TiltAndTurnEspag_N110A03206PricePerPiece;
                                        EspagBasePrice = TiltAndTurnEspag_N110A03206PricePerPiece;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206)
                                    {
                                        EspagPrice += TiltAndTurnEspag_N110A04206PricePerPiece;
                                        EspagBasePrice = TiltAndTurnEspag_N110A04206PricePerPiece;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                                    {
                                        EspagPrice += TiltAndTurnEspag_N110A05206PricePerPiece;
                                        EspagBasePrice = TiltAndTurnEspag_N110A05206PricePerPiece;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A06206)
                                    {
                                        EspagPrice += TiltAndTurnEspag_N110A06206PricePerPiece;
                                        EspagBasePrice = TiltAndTurnEspag_N110A06206PricePerPiece;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._630963)
                                    {
                                        EspagPrice += MVDGearPricePerPiece;
                                        EspagBasePrice = MVDGearPricePerPiece;
                                    }
                                    else
                                    {
                                        EspagPrice += Espag741012_PricePerPiece;
                                        EspagBasePrice = Espag741012_PricePerPiece;
                                    }
                                }
                                #endregion

                                #region StrikerPrice
                                int Panel_StrikerQty_A = 0,
                                    Panel_StrikerQty_C = 0;


                                if (Singlepnl.Panel_Type.Contains("Awning"))
                                {
                                    if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                                        Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807 ||
                                        Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809)
                                    {
                                        Panel_StrikerQty_A += 2;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                                             Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                                    {
                                        Panel_StrikerQty_A += 3;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                                             Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                                    {
                                        Panel_StrikerQty_A += 4;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                                             Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                                    {
                                        Panel_StrikerQty_A += 1;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                                             Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                                    {
                                        Panel_StrikerQty_A += 2;
                                    }

                                    if (Singlepnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957)
                                    {
                                        Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtLeftQty);
                                    }

                                    if (Singlepnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957)
                                    {
                                        Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtLeft2Qty);
                                    }

                                    if (Singlepnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._639957)
                                    {
                                        Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtRightQty);
                                    }

                                    if (Singlepnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                                    {
                                        Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtRight2Qty);
                                    }

                                    if (Singlepnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                    {
                                        Panel_StrikerQty_A += 2;
                                    }
                                }
                                else if (Singlepnl.Panel_Type.Contains("Casement"))
                                {
                                    if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                                        Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807 ||
                                        Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809)
                                    {
                                        Panel_StrikerQty_C += 2;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                                             Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                                    {
                                        Panel_StrikerQty_C += 3;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                                             Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                                    {
                                        Panel_StrikerQty_C += 4;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                                             Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                                    {
                                        Panel_StrikerQty_C += 1;
                                    }
                                    else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                                             Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                                    {
                                        Panel_StrikerQty_C += 2;
                                    }

                                    if (Singlepnl.Panel_ExtensionTopArtNo == Extension_ArticleNo._639957)
                                    {
                                        Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtTopQty);
                                    }

                                    if (Singlepnl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._639957)
                                    {
                                        Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtTop2Qty);
                                    }

                                    if (Singlepnl.Panel_ExtensionBotArtNo == Extension_ArticleNo._639957)
                                    {
                                        Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtBotQty);
                                    }

                                    if (Singlepnl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._639957)
                                    {
                                        Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtBot2Qty);
                                    }

                                    if (Singlepnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                    {
                                        Panel_StrikerQty_C += 1;
                                    }

                                    if (Singlepnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                    {
                                        Panel_StrikerQty_A += 1;
                                    }
                                }

                                if (Panel_StrikerQty_A != 0 ||
                                    Panel_StrikerQty_C != 0)
                                {
                                    StrikerPrice += (Panel_StrikerQty_A + Panel_StrikerQty_C) * StrikerPricePerPiece;
                                }
                                #endregion

                                #region GeorgianBar
                                if (Singlepnl.Panel_GeorgianBarOptionVisibility == true)
                                {
                                    int GBmultiplier = 1, multiplier = 1;

                                    if (cus_ref_date >= changeCondition_020323)
                                    {
                                        GBmultiplier = 2;
                                    }

                                    if (cus_ref_date >= changeCondition_072723)
                                    {
                                        multiplier = 2;
                                    }

                                    GeorgianBarHorizontalQty = Singlepnl.Panel_GeorgianBar_HorizontalQty * GBmultiplier;
                                    GeorgianBarVerticalQty = Singlepnl.Panel_GeorgianBar_VerticalQty * GBmultiplier;

                                    if (wdm.WD_BaseColor == Base_Color._Ivory ||
                                        wdm.WD_BaseColor == Base_Color._White)
                                    {
                                        if (Singlepnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
                                        {
                                            if (Singlepnl.Panel_GeorgianBar_HorizontalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0724Price_White * multiplier;
                                            }
                                            if (Singlepnl.Panel_GeorgianBar_VerticalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0724Price_White;
                                            }
                                            GeorgianBarPrice = GeorgianBar_0724Price_White;

                                        }
                                        else if (Singlepnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0726)
                                        {
                                            if (Singlepnl.Panel_GeorgianBar_HorizontalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0726Price_White;
                                            }
                                            if (Singlepnl.Panel_GeorgianBar_VerticalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0726Price_White;
                                            }
                                            GeorgianBarPrice = GeorgianBar_0726Price_White;
                                        }
                                    }
                                    else if (wdm.WD_BaseColor == Base_Color._DarkBrown)
                                    {
                                        if (Singlepnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
                                        {
                                            if (Singlepnl.Panel_GeorgianBar_HorizontalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0724Price_Woodgrain;
                                            }
                                            if (Singlepnl.Panel_GeorgianBar_VerticalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0724Price_Woodgrain;
                                            }
                                            GeorgianBarPrice = GeorgianBar_0724Price_Woodgrain;

                                        }
                                        else if (Singlepnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0726)
                                        {
                                            if (Singlepnl.Panel_GeorgianBar_HorizontalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0726Price_Woodgrain;
                                            }
                                            if (Singlepnl.Panel_GeorgianBar_VerticalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0726Price_Woodgrain;
                                            }
                                            GeorgianBarPrice = GeorgianBar_0726Price_Woodgrain;
                                        }
                                    }

                                }
                                #endregion

                                #region CoverProfilePrice
                                if ((Singlepnl.Panel_Type.Contains("Sliding")))
                                {
                                    CoverProfileCost += ((Singlepnl.Panel_SashWidth / 1000m) * CoverProfile_0914Price) * 2;
                                    CoverProfilePrice = CoverProfile_0914Price;
                                }
                                else
                                {
                                    CoverProfileCost += (Singlepnl.Panel_SashWidth / 1000m) * CoverProfile_0914Price +
                                                        (Singlepnl.Panel_SashWidth / 1000m) * CoverProfile_0373Price;
                                    CoverProfilePrice = CoverProfile_0914Price + CoverProfile_0373Price;
                                }
                                #endregion

                                #region Glass 

                                var GlassThcknessDesc_Holder = Singlepnl.Panel_GlassThicknessDesc;
                                if (GlassThcknessDesc_Holder != null)
                                {
                                    if (GlassThcknessDesc_Holder.Contains("with Georgian Bar"))
                                    {
                                        Singlepnl.Panel_GlassThicknessDesc = GlassThcknessDesc_Holder.Replace("with Georgian Bar", "").Replace(" ", " ");
                                    }
                                }

                                //if (testDate <= changeCondition_022323)
                                //{
                                //    Singlepnl.Panel_GlassWidth = Singlepnl.Panel_DisplayWidth - (33 * 2) - 6;
                                //    Singlepnl.Panel_GlassHeight = Singlepnl.Panel_DisplayHeight - (33 * 2) - 6;
                                //}
                                //Console.WriteLine(Singlepnl.Panel_GlassWidth = Singlepnl.Panel_DisplayWidth - (33 * 2) - 6);
                                //Console.WriteLine(Singlepnl.Panel_GlassHeight = Singlepnl.Panel_DisplayHeight - (33 * 2) - 6);


                                if ((Singlepnl.Panel_GlassType_Insu_Lami == "NA") || Singlepnl.Panel_GlassType_Insu_Lami == "")
                                {
                                    #region Single 
                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("5 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmClr_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmClr_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear Oversized"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmClrOversized_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmClrOversized_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Oversized"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmTempTintedOversized_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmTempTintedOversized_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmTempTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmTempTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealedClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealedClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealedClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealedClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealedClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealedClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmTempClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmTempClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                    }


                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Heat-Soaked Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempHeatSoakedClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempHeatSoakedClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Heat-Soaked Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempHeatSoakedClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempHeatSoakedClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Heat-Soaked Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempHeatSoakedClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempHeatSoakedClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Heat-Soaked Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempHeatSoakedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempHeatSoakedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Heat-Soaked Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempHeatSoakedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempHeatSoakedClr;
                                    }



                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm  Recflective Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealed_ReflectiveClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealed_ReflectiveClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTemp_ReflectiveClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTemp_ReflectiveClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Gold Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_ReflectiveGold_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTemp_ReflectiveGold_HrdCtd_LowE;
                                    }


                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmClr_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmClr_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmClr_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmClr_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmClr_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmClr_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmClr_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmClr_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTemp_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTemp_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTemp_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmTemp_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("15 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_15mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_15mmTemp_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("19 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_19mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_19mmTemp_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm PVC Sheet Wood(6-B2B)"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_12mm_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_12mm_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm PVC Sheet White"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_8mm_White_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_8mm_White_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm PVC Sheet Foiled"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_8mm_Foiled_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_8mm_Foiled_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm PVC Sheet Wood"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_6mm_PricepPerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_6mm_PricepPerSqrMeter;
                                    }
                                    else
                                    {
                                        GlassPrice += 0;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = 0;
                                    }

                                    #endregion
                                }
                                else if (Singlepnl.Panel_GlassType_Insu_Lami == "Double Insulated")
                                {
                                    #region Insulated
                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Solarban Clear with Low-e + 12 Argon + 6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTemp_SolarBan;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTemp_SolarBan;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Self-Cleaning Tempered Clear + 12 Argon + 4 mm Tempered Clear with Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_20mmSelfCleaning_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_20mmSelfCleaning_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Self-Cleaning Tempered Clear + 12 Argon + 6 mm Tempered Clear with Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmSelfCleaning_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmSelfCleaning_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Bronze + 12 Argon + (3 mm Clear + 0.38 PVB + 3 Clear )"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedBronze_Argon_AnnealedClr_Argon;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedBronze_Argon_AnnealedClr_Argon;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Clear + 10 + 4 mm Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedClr_AirSS_AnnealedClrHrCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedClr_AirSS_AnnealedClrHrCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Clear + 12 Argon + 6 mm Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedClr_Argon_AnnealedClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedClr_Argon_AnnealedClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tinted + 10 Argon + 4 mm Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted + 12 Argon + 6 mm Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Clear + 10 + 4 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedClr_AirSS_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedClr_AirSS_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 + 4 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_AirSS_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_AirSS_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 Argon + 4 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_Argon_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_Argon_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Clear + 12 Argon + 6 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedClr_Argon_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedClr_Argon_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("5 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmTempClr_Argon_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmTempClr_Argon_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Tinted + 10 Argon + 4 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempTinted_Argon_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempTinted_Argon_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted + 12 Argon + 6 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempTinted_Argon_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempTinted_Argon_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Heat-Soaked Clear + 12 Argon + 6 mm Tempered Heat-Soaked Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempHeatSoakedClr_Argon_TempHeatSoakedClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempHeatSoakedClr_Argon_TempHeatSoakedClrHrdCtdLowe;

                                    }


                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Clear + 10 + 4 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedClr_AirSS_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedClr_AirSS_AnnealedClr;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("5 mm Clear + 12 + 6 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedClr_AirSS_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedClr_AirSS_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("5 mm Clear + 12 + 6 mm Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedClr_AirSS_AnnealedTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedClr_AirSS_AnnealedTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("5 mm Tinted + 12 + 6 mm Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedTinted_AirSS_AnnealedTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedTinted_AirSS_AnnealedTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 + 4 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_AirSS_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_AirSS_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 Argon + 4 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_Argon_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_Argon_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempClr_Argon_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempClr_Argon_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 Argon + 4 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_Argon_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_Argon_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("5 mm Clear + 12 + 6 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedClr_AirSS_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedClr_AirSS_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 12 Argon + 6 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempClr_Argon_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempClr_Argon_TempTinted;
                                    }

                                    #endregion
                                }
                                else if (Singlepnl.Panel_GlassType_Insu_Lami == "Double Laminated")
                                {
                                    #region Laminated

                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 0.89  SG InterLayer + 5 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmTempClr_SGInt_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmTempClr_SGInt_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 0.89  SG InterLayer + 6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempClr_SGInt_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempClr_SGInt_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52  SG InterLayer + 6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_SGInt_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_SGInt_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear + 1.52  SG InterLayer + 10 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_21mmTempClr_SGInt_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_21mmTempClr_SGInt_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear + 1.52  SG InterLayer + 12 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_25mmTempClr_SGInt_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_25mmTempClr_SGInt_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear with Low-e + 1.52 + 4 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClrLowe_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClrLowe_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear with Low-e + 1.52  + 6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClrLowe_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClrLowe_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear with Low-e + 3.04 + 10 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmTempClrLowe_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmTempClrLowe_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52  + 4 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52  + 5 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_10mmTempClr_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_10mmTempClr_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52  + 6 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmTempClr_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmTempClr_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 6 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Tinted + 1.52 + 4 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempTinted_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempTinted_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted + 1.52  + 5 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempTinted_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempTinted_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted + 1.52 + 6 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempTinted_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempTinted_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("5 mm Tempered Clear with Low-e + 1.52 + 6 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempClrLowe_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempClrLowe_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Heat-Soaked Clear + 1.52 + 6 mm Tempered Heat-Soaked Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempHeatSoakedClr_Pvb_TempHeatSoakedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempHeatSoakedClr_Pvb_TempHeatSoakedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("3 mm  Clear + 0.38 + 3 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_6mmAnnealedClr_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_6mmAnnealedClr_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear + 0.76 + 4 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_8mmAnnealedClr_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_8mmAnnealedClr_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.76 + 5 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedClr_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedClr_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.76 + 6 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedClr_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedClr_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Clear + 3.04 + 8 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_21mmAnnealedClr_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_21mmAnnealedClr_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear with Low-e + 0.38 + 3 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_7mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_7mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear with Low-e + 0.76 + 5 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear with Low-e + 0.76 + 6 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear with Low-e + 0.76 + 1 mm  Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_5mmAnnealedClrLowe_ClrPvb_AnnealedTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_5mmAnnealedClrLowe_ClrPvb_AnnealedTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("3 mm  Tinted + 0.38 + 3 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_6mmAnnealedTinted_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_6mmAnnealedTinted_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted + 0.76 + 5 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedTinted_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedTinted_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted + 0.76 + 6 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("3 mm  Clear + 0.38 White PVB  + 3 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_6mmAnnealedClr_WhitePvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_6mmAnnealedClr_WhitePvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear + 0.76 White PVB  + 4 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_8mmAnnealedClr_WhitePvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_8mmAnnealedClr_WhitePvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.76 White PVB  + 5 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedClr_WhitePvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedClr_WhitePvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.89 SG Interlayer  + 6 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedClr_SGInt_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedClr_SGInt_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("3 mm Tempered Clear + 1.52 + 3 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_7mmTempClr_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_7mmTempClr_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52 + 4 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 4 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmTempClr_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmTempClr_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 5 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempClr_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempClr_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted + 0.76 + 6 mm  Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm  Tinted + 0.76 + 4 mm  Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_8mmAnnealedTinted_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_8mmAnnealedTinted_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted  + 1.52 + 5 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempTinted_ClrPvb_TempClrLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempTinted_ClrPvb_TempClrLowe;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52 White PVB + 4 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 White PVB + 6 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52 White PVB + 4 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_WhitePvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_WhitePvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 White PVB + 6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_WhitePvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_WhitePvb_TempClr;
                                    }


                                    #endregion
                                }
                                else if (Singlepnl.Panel_GlassType_Insu_Lami == "Triple Insulated")
                                {
                                    #region Insulated

                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear + 6 + 4 mm  Clear + 6 + 4 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmAnnealedClr_AirSS_AnnealedClr_AirSS_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmAnnealedClr_AirSS_AnnealedClr_AirSS_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 6 + 4 mm  Clear + 6 + 4 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmTempClr_AirSS_AnnealedClr_AirSS_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmTempClr_AirSS_AnnealedClr_AirSS_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 6 + 4 mm Tempered Clear + 6 + 4 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmTempClr_AirSs_TempClr_AirSS_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmTempClr_AirSs_TempClr_AirSS_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 6 Argon + 4 mm  Clear + 6 Argon + 4 mm Tempered Clear with Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmTempClr_Argon_AnnealedClr_Argon_TempClrLowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmTempClr_Argon_AnnealedClr_Argon_TempClrLowE;
                                    }

                                    #endregion
                                }
                                else if (Singlepnl.Panel_GlassType_Insu_Lami == "Triple Laminated")
                                {
                                    #region Laminated

                                    #endregion
                                }

                                if (GlassThcknessDesc_Holder != null)
                                {
                                    if (GlassThcknessDesc_Holder.Contains("with Georgian Bar"))
                                    {
                                        Singlepnl.Panel_GlassThicknessDesc = GlassThcknessDesc_Holder;
                                    }
                                }


                                //sealant for glass
                                Glass_SealantWHQty_Total = (int)(Math.Ceiling((decimal)((Singlepnl.Panel_GlassWidth + Singlepnl.Panel_GlassHeight) * 2) / 6842));
                                if (Singlepnl.Panel_GlassThickness != 0.0f)
                                {

                                    if ((wdm.WD_BaseColor == Base_Color._Ivory || wdm.WD_BaseColor == Base_Color._White) && OneSideFoil_whiteBase == false)
                                    {
                                        SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_Clear;
                                    }
                                    else if (wdm.WD_BaseColor == Base_Color._DarkBrown || OneSideFoil_whiteBase == true)
                                    {
                                        SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_BrownBlack;
                                    }
                                }
                                #endregion

                                #region GlassFilm
                                if (Singlepnl.Panel_GlassFilm == GlassFilm_Types._4milSolarGuard ||
                                    Singlepnl.Panel_GlassFilm == GlassFilm_Types._4milUpera)
                                {
                                    FilmPrice += ((Singlepnl.Panel_GlassWidth / 1000m) * (Singlepnl.Panel_GlassHeight / 1000m)) * _4millFilmPrice_PricePerSqrMeter;
                                }
                                else if (Singlepnl.Panel_GlassFilm == GlassFilm_Types._FrostedFilm)
                                {
                                    FilmPrice += ((Singlepnl.Panel_GlassWidth / 1000m) * (Singlepnl.Panel_GlassHeight / 1000m)) * FrostedFilmPrice_PricePerSqrMeter;
                                }
                                #endregion

                                #region GlazingAdaptor
                                if (Singlepnl.Panel_ChkGlazingAdaptor == true)
                                {
                                    GlazingBeadPerimeter = (Singlepnl.Panel_GlazingBeadHeight + Singlepnl.Panel_GlazingBeadWidth) * 2;
                                    GlazingAdaptorPrice += (GlazingBeadPerimeter / 1000) * GlazingAdaptorPricePerMeter;
                                }
                                #endregion

                                #region SecurityMesh
                                if (Singlepnl.Panel_GlassThicknessDesc != null)
                                {
                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("Security Mesh"))
                                    {
                                        SecurityMeshPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * SecurityMeshPricePerSquaremeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = SecurityMeshPricePerSquaremeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("Wire Mesh"))
                                    {
                                        WireMeshPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * WireMeshPricePerSquaremeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = WireMeshPricePerSquaremeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("Pet Mesh"))
                                    {
                                        PetMeshPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * PetMeshPricePerSquaremeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = PetMeshPricePerSquaremeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tuff Mesh"))
                                    {
                                        TuffMeshPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * TuffMeshPricePerSquaremeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = TuffMeshPricePerSquaremeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("Phifer Mesh"))
                                    {
                                        PhiferMeshPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * PhiferMeshPricePerSquaremeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = PhiferMeshPricePerSquaremeter;
                                    }

                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("Mesh"))
                                    {
                                        AluminumFramePrice += (((Singlepnl.Panel_GlassHeight / 1000m) + (Singlepnl.Panel_GlassWidth / 1000m)) * 2) * AluminumFramePricePerSquaremeter;
                                    }
                                }
                                #endregion

                                HandleDesc = Singlepnl.Panel_HandleType.ToString();

                                CostingPoints += ProfileColorPoints * 4;
                                InstallationPoints += (ProfileColorPoints / 3) * 4;
                            }
                            else if (Singlepnl.Panel_Type.Contains("Fixed"))
                            {
                                CostingPoints += ProfileColorPoints * 2;
                                InstallationPoints += (ProfileColorPoints / 3) * 2;

                                #region Glass 
                                if (cus_ref_date >= changeCondition_022323)
                                {
                                    Singlepnl.Panel_GlassWidth = Singlepnl.Panel_DisplayWidth - (33 * 2) - 6;
                                    Singlepnl.Panel_GlassHeight = Singlepnl.Panel_DisplayHeight - (33 * 2) - 6;
                                }

                                var GlassThcknessDesc_Holder = Singlepnl.Panel_GlassThicknessDesc;
                                if (GlassThcknessDesc_Holder != null)
                                {
                                    if (GlassThcknessDesc_Holder.Contains("with Georgian Bar"))
                                    {
                                        Singlepnl.Panel_GlassThicknessDesc = GlassThcknessDesc_Holder.Replace("with Georgian Bar", "").Replace(" ", " ");
                                    }
                                }

                                if ((Singlepnl.Panel_GlassType_Insu_Lami == "NA") || Singlepnl.Panel_GlassType_Insu_Lami == "")
                                {
                                    #region Single 
                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("5 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmClr_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmClr_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear Oversized"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmClrOversized_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmClrOversized_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Oversized"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmTempTintedOversized_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmTempTintedOversized_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm  Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm  Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmAnnealedTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmTempTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmTempTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealedClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealedClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealedClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealedClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealedClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealedClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted Low-E Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tinted Low-E Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tinted Low-E Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealedTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmTempClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmTempClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted Low-E Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Tinted Low-E Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Tinted Low-E Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempTinted_HrdCtd_LowE_Brnz_Bl_Grn_Gry;
                                    }


                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Heat-Soaked Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTempHeatSoakedClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTempHeatSoakedClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Heat-Soaked Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempHeatSoakedClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempHeatSoakedClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Heat-Soaked Clear Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempHeatSoakedClr_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempHeatSoakedClr_HrdCtd_LowE;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Heat-Soaked Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTempHeatSoakedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTempHeatSoakedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Heat-Soaked Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTempHeatSoakedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTempHeatSoakedClr;
                                    }


                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm  Recflective Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmAnnealed_ReflectiveClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmAnnealed_ReflectiveClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Recflective Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Recflective Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmAnnealed_ReflectiveTinted_Brnz_Bl_Grn_Gr_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTemp_ReflectiveClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTemp_ReflectiveClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Recflective Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Bronze") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Blue") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Green") || Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Recflective Tinted Grey"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTemp_ReflectiveTinted_Brnz_Bl_Grn_Gry;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Recflective Gold Low-E"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_ReflectiveGold_HrdCtd_LowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTemp_ReflectiveGold_HrdCtd_LowE;
                                    }


                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmClr_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmClr_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmClr_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmClr_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmClr_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmClr_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmClr_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmClr_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTemp_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_8mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_8mmTemp_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTemp_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmTemp_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("15 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_15mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_15mmTemp_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("19 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_19mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_19mmTemp_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm PVC Sheet Wood(6-B2B)"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_12mm_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_12mm_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm PVC Sheet White"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_8mm_White_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_8mm_White_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("8 mm PVC Sheet Foiled"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_8mm_Foiled_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_8mm_Foiled_PricePerSqrMeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm PVC Sheet Wood"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * PVC_SheetWood_6mm_PricepPerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = PVC_SheetWood_6mm_PricepPerSqrMeter;
                                    }
                                    else
                                    {
                                        GlassPrice += 0;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = 0;
                                    }

                                    #endregion
                                }
                                else if (Singlepnl.Panel_GlassType_Insu_Lami == "Double Insulated")
                                {
                                    #region Insulated
                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Solarban Clear with Low-e + 12 Argon + 6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTemp_SolarBan;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTemp_SolarBan;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Self-Cleaning Tempered Clear + 12 Argon + 4 mm Tempered Clear with Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_20mmSelfCleaning_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_20mmSelfCleaning_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Self-Cleaning Tempered Clear + 12 Argon + 6 mm Tempered Clear with Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmSelfCleaning_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmSelfCleaning_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Bronze + 12 Argon + (3 mm Clear + 0.38 PVB + 3 Clear )"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedBronze_Argon_AnnealedClr_Argon;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedBronze_Argon_AnnealedClr_Argon;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Clear + 10 + 4 mm Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedClr_AirSS_AnnealedClrHrCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedClr_AirSS_AnnealedClrHrCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Clear + 12 Argon + 6 mm Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedClr_Argon_AnnealedClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedClr_Argon_AnnealedClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tinted + 10 Argon + 4 mm Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tinted + 12 Argon + 6 mm Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedTinted_Argon_AnnealedClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Clear + 10 + 4 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedClr_AirSS_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedClr_AirSS_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 + 4 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_AirSS_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_AirSS_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 Argon + 4 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_Argon_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_Argon_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Clear + 12 Argon + 6 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmAnnealedClr_Argon_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmAnnealedClr_Argon_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("5 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmTempClr_Argon_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmTempClr_Argon_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempClr_Argon_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Tinted + 10 Argon + 4 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempTinted_Argon_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempTinted_Argon_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted + 12 Argon + 6 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempTinted_Argon_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempTinted_Argon_TempClrHrdCtdLowe;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Heat-Soaked Clear + 12 Argon + 6 mm Tempered Heat-Soaked Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempHeatSoakedClr_Argon_TempHeatSoakedClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempHeatSoakedClr_Argon_TempHeatSoakedClrHrdCtdLowe;

                                    }


                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Clear + 10 + 4 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmAnnealedClr_AirSS_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmAnnealedClr_AirSS_AnnealedClr;

                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("5 mm Clear + 12 + 6 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedClr_AirSS_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedClr_AirSS_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("5 mm Clear + 12 + 6 mm Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedClr_AirSS_AnnealedTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedClr_AirSS_AnnealedTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("5 mm Tinted + 12 + 6 mm Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedTinted_AirSS_AnnealedTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedTinted_AirSS_AnnealedTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 + 4 mm Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_AirSS_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_AirSS_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 Argon + 4 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_Argon_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_Argon_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempClr_Argon_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempClr_Argon_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 10 Argon + 4 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_18mmTempClr_Argon_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_18mmTempClr_Argon_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("5 mm Clear + 12 + 6 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmAnnealedClr_AirSS_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmAnnealedClr_AirSS_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 12 Argon + 6 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_24mmTempClr_Argon_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_24mmTempClr_Argon_TempTinted;
                                    }

                                    #endregion
                                }
                                else if (Singlepnl.Panel_GlassType_Insu_Lami == "Double Laminated")
                                {
                                    #region Laminated

                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 0.89  SG InterLayer + 5 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmTempClr_SGInt_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmTempClr_SGInt_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 0.89  SG InterLayer + 6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempClr_SGInt_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempClr_SGInt_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52  SG InterLayer + 6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_SGInt_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_SGInt_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear + 1.52  SG InterLayer + 10 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_21mmTempClr_SGInt_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_21mmTempClr_SGInt_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("12 mm Tempered Clear + 1.52  SG InterLayer + 12 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_25mmTempClr_SGInt_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_25mmTempClr_SGInt_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear with Low-e + 1.52 + 4 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClrLowe_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClrLowe_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear with Low-e + 1.52  + 6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClrLowe_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClrLowe_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm Tempered Clear with Low-e + 3.04 + 10 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_23mmTempClrLowe_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_23mmTempClrLowe_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52  + 4 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52  + 5 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_10mmTempClr_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_10mmTempClr_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52  + 6 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmTempClr_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmTempClr_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 6 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Tinted + 1.52 + 4 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempTinted_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempTinted_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted + 1.52  + 5 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempTinted_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempTinted_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted + 1.52 + 6 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempTinted_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempTinted_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("5 mm Tempered Clear with Low-e + 1.52 + 6 mm Tempered Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempClrLowe_ClrPvb_TempTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempClrLowe_ClrPvb_TempTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Heat-Soaked Clear + 1.52 + 6 mm Tempered Heat-Soaked Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempHeatSoakedClr_Pvb_TempHeatSoakedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempHeatSoakedClr_Pvb_TempHeatSoakedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("3 mm  Clear + 0.38 + 3 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_6mmAnnealedClr_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_6mmAnnealedClr_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear + 0.76 + 4 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_8mmAnnealedClr_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_8mmAnnealedClr_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.76 + 5 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedClr_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedClr_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.76 + 6 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedClr_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedClr_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("10 mm  Clear + 3.04 + 8 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_21mmAnnealedClr_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_21mmAnnealedClr_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear with Low-e + 0.38 + 3 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_7mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_7mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear with Low-e + 0.76 + 5 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear with Low-e + 0.76 + 6 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedClrLowe_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear with Low-e + 0.76 + 1 mm  Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_5mmAnnealedClrLowe_ClrPvb_AnnealedTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_5mmAnnealedClrLowe_ClrPvb_AnnealedTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("3 mm  Tinted + 0.38 + 3 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_6mmAnnealedTinted_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_6mmAnnealedTinted_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted + 0.76 + 5 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedTinted_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedTinted_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted + 0.76 + 6 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("3 mm  Clear + 0.38 White PVB  + 3 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_6mmAnnealedClr_WhitePvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_6mmAnnealedClr_WhitePvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear + 0.76 White PVB  + 4 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_8mmAnnealedClr_WhitePvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_8mmAnnealedClr_WhitePvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.76 White PVB  + 5 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmAnnealedClr_WhitePvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmAnnealedClr_WhitePvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Clear + 0.89 SG Interlayer  + 6 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedClr_SGInt_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedClr_SGInt_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("3 mm Tempered Clear + 1.52 + 3 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_7mmTempClr_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_7mmTempClr_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52 + 4 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 4 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_11mmTempClr_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_11mmTempClr_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 5 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempClr_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempClr_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 + 6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_ClrPvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_ClrPvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm  Tinted + 0.76 + 6 mm  Tinted"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedTinted;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmAnnealedTinted_ClrPvb_AnnealedTinted;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm  Tinted + 0.76 + 4 mm  Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_8mmAnnealedTinted_ClrPvb_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_8mmAnnealedTinted_ClrPvb_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52 White PVB + 4 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 White PVB + 6 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_WhitePvb_TempClrHrdCtdLowe;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Tinted  + 1.52 + 5 mm Tempered Clear Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_12mmTempTinted_ClrPvb_TempClrLowe;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_12mmTempTinted_ClrPvb_TempClrLowe;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 1.52 White PVB + 4 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_9mmTempClr_WhitePvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_9mmTempClr_WhitePvb_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("6 mm Tempered Clear + 1.52 White PVB + 6 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Double_13mmTempClr_WhitePvb_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Double_13mmTempClr_WhitePvb_TempClr;
                                    }


                                    #endregion
                                }
                                else if (Singlepnl.Panel_GlassType_Insu_Lami == "Triple Insulated")
                                {
                                    #region Insulated

                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm  Clear + 6 + 4 mm  Clear + 6 + 4 mm  Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmAnnealedClr_AirSS_AnnealedClr_AirSS_AnnealedClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmAnnealedClr_AirSS_AnnealedClr_AirSS_AnnealedClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 6 + 4 mm  Clear + 6 + 4 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmTempClr_AirSS_AnnealedClr_AirSS_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmTempClr_AirSS_AnnealedClr_AirSS_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 6 + 4 mm Tempered Clear + 6 + 4 mm Tempered Clear"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmTempClr_AirSs_TempClr_AirSS_TempClr;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmTempClr_AirSs_TempClr_AirSS_TempClr;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("4 mm Tempered Clear + 6 Argon + 4 mm  Clear + 6 Argon + 4 mm Tempered Clear with Low-e"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_Triple_24mmTempClr_Argon_AnnealedClr_Argon_TempClrLowE;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_Triple_24mmTempClr_Argon_AnnealedClr_Argon_TempClrLowE;
                                    }

                                    #endregion
                                }
                                else if (Singlepnl.Panel_GlassType_Insu_Lami == "Triple Laminated")
                                {
                                    #region Laminated

                                    #endregion
                                }

                                if (GlassThcknessDesc_Holder != null)
                                {
                                    if (GlassThcknessDesc_Holder.Contains("with Georgian Bar"))
                                    {
                                        Singlepnl.Panel_GlassThicknessDesc = GlassThcknessDesc_Holder;
                                    }
                                }


                                //sealant for glass
                                Glass_SealantWHQty_Total = (int)(Math.Ceiling((decimal)((Singlepnl.Panel_GlassWidth + Singlepnl.Panel_GlassHeight) * 2) / 6842));
                                if (Singlepnl.Panel_GlassThickness != 0.0f)
                                {

                                    if ((wdm.WD_BaseColor == Base_Color._Ivory || wdm.WD_BaseColor == Base_Color._White) && OneSideFoil_whiteBase == false)
                                    {
                                        SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_Clear;
                                    }
                                    else if (wdm.WD_BaseColor == Base_Color._DarkBrown || OneSideFoil_whiteBase == true)
                                    {
                                        SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_BrownBlack;
                                    }
                                }
                                #endregion

                                #region GeorgianBar
                                if (Singlepnl.Panel_GeorgianBarOptionVisibility == true)
                                {
                                    int GBmultiplier = 1, multiplier = 1;

                                    if (cus_ref_date >= changeCondition_020323)
                                    {
                                        GBmultiplier = 2;
                                    }

                                    if (cus_ref_date >= changeCondition_072723)
                                    {
                                        multiplier = 2;
                                    }

                                    GeorgianBarHorizontalQty = Singlepnl.Panel_GeorgianBar_HorizontalQty * GBmultiplier;
                                    GeorgianBarVerticalQty = Singlepnl.Panel_GeorgianBar_VerticalQty * GBmultiplier;

                                    if (wdm.WD_BaseColor == Base_Color._Ivory ||
                                        wdm.WD_BaseColor == Base_Color._White)
                                    {
                                        if (Singlepnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
                                        {
                                            if (Singlepnl.Panel_GeorgianBar_HorizontalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0724Price_White * multiplier;
                                            }
                                            if (Singlepnl.Panel_GeorgianBar_VerticalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0724Price_White;
                                            }
                                            GeorgianBarPrice = GeorgianBar_0724Price_White;

                                        }
                                        else if (Singlepnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0726)
                                        {
                                            if (Singlepnl.Panel_GeorgianBar_HorizontalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0726Price_White;
                                            }
                                            if (Singlepnl.Panel_GeorgianBar_VerticalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0726Price_White;
                                            }
                                            GeorgianBarPrice = GeorgianBar_0726Price_White;
                                        }
                                    }
                                    else if (wdm.WD_BaseColor == Base_Color._DarkBrown)
                                    {
                                        if (Singlepnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
                                        {
                                            if (Singlepnl.Panel_GeorgianBar_HorizontalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0724Price_Woodgrain;
                                            }
                                            if (Singlepnl.Panel_GeorgianBar_VerticalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0724Price_Woodgrain;
                                            }
                                            GeorgianBarPrice = GeorgianBar_0724Price_Woodgrain;

                                        }
                                        else if (Singlepnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0726)
                                        {
                                            if (Singlepnl.Panel_GeorgianBar_HorizontalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassWidth + 5) / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0726Price_Woodgrain;
                                            }
                                            if (Singlepnl.Panel_GeorgianBar_VerticalQty != 0)
                                            {
                                                GeorgianBarCost += (((Singlepnl.Panel_GlassHeight + 5) / 1000m) * GeorgianBarVerticalQty) * GeorgianBar_0726Price_Woodgrain;
                                            }
                                            GeorgianBarPrice = GeorgianBar_0726Price_Woodgrain;
                                        }
                                    }

                                }
                                #endregion

                                #region GlassFilm
                                if (Singlepnl.Panel_GlassFilm == GlassFilm_Types._4milSolarGuard ||
                                    Singlepnl.Panel_GlassFilm == GlassFilm_Types._4milUpera)
                                {
                                    FilmPrice += ((Singlepnl.Panel_GlassWidth / 1000m) * (Singlepnl.Panel_GlassHeight / 1000m)) * _4millFilmPrice_PricePerSqrMeter;
                                }
                                else if (Singlepnl.Panel_GlassFilm == GlassFilm_Types._FrostedFilm)
                                {
                                    FilmPrice += ((Singlepnl.Panel_GlassWidth / 1000m) * (Singlepnl.Panel_GlassHeight / 1000m)) * FrostedFilmPrice_PricePerSqrMeter;
                                }
                                #endregion

                                #region GlazingAdaptor
                                if (Singlepnl.Panel_ChkGlazingAdaptor == true)
                                {
                                    GlazingBeadPerimeter = (Singlepnl.Panel_GlazingBeadHeight + Singlepnl.Panel_GlazingBeadWidth) * 2;
                                    GlazingAdaptorPrice += (GlazingBeadPerimeter / 1000) * GlazingAdaptorPricePerMeter;
                                }
                                #endregion

                                #region SecurityMesh
                                if (Singlepnl.Panel_GlassThicknessDesc != null)
                                {
                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("Security Mesh"))
                                    {
                                        SecurityMeshPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * SecurityMeshPricePerSquaremeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = SecurityMeshPricePerSquaremeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("Wire Mesh"))
                                    {
                                        WireMeshPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * WireMeshPricePerSquaremeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = WireMeshPricePerSquaremeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("Pet Mesh"))
                                    {
                                        PetMeshPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * PetMeshPricePerSquaremeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = PetMeshPricePerSquaremeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tuff Mesh"))
                                    {
                                        TuffMeshPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * TuffMeshPricePerSquaremeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = TuffMeshPricePerSquaremeter;
                                    }
                                    else if (Singlepnl.Panel_GlassThicknessDesc.Contains("Phifer Mesh"))
                                    {
                                        PhiferMeshPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * PhiferMeshPricePerSquaremeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = PhiferMeshPricePerSquaremeter;
                                    }

                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("Mesh"))
                                    {
                                        AluminumFramePrice += (((Singlepnl.Panel_GlassHeight / 1000m) + (Singlepnl.Panel_GlassWidth / 1000m)) * 2) * AluminumFramePricePerSquaremeter;
                                    }
                                }
                                #endregion
                            }
                            else if (Singlepnl.Panel_Type.Contains("Louver"))
                            {
                                #region Louver 
                                CostingPoints += ProfileColorPoints;
                                InstallationPoints += (ProfileColorPoints / 3);

                                if (Singlepnl.Panel_LouverMotorizeCheck == true)
                                {
                                    LouvreFrameWeatherStripHeadPrice += (Singlepnl.Panel_DisplayWidth * (LouvreFrameWeatherStripHeadPricePerMeter)) / 1000m;
                                    LouvreFrameBottomWeatherStripPrice += (Singlepnl.Panel_DisplayWidth * (LouvreFrameBottomWeatherStripPricePerMeter)) / 1000m;
                                    PlantonWeatherStripHeadPrice += (Singlepnl.Panel_DisplayWidth * (PlantonWeatherStripHeadPricePerMeter)) / 1000m;
                                    PlantonWeatherStripSillPrice += (Singlepnl.Panel_DisplayWidth * (PlantonWeatherStripSillPricePerMeter)) / 1000m;

                                    BubbleSealPrice += ((Singlepnl.Panel_DisplayWidth * 2) * BubbleSealPricePerMeter * Singlepnl.Panel_LouverBladesCount) / 1000m;
                                    PowerKitIncludingWiresPrice += 132.59m * 1.3m * 1.1m * forex;
                                }
                                else if (Singlepnl.Panel_LouverMotorizeCheck == false)
                                {
                                    LouvreFrameWeatherStripHeadPrice += (Singlepnl.Panel_DisplayWidth * (LouvreFrameWeatherStripHeadPricePerMeter + LouvreFrameWeatherStripHeadPowderCoatingPrice)) / 1000m;
                                    LouvreFrameBottomWeatherStripPrice += (Singlepnl.Panel_DisplayWidth * (LouvreFrameBottomWeatherStripPricePerMeter + LouvreFrameBottomWeatherStripPowderCoatingPrice)) / 1000m;
                                    PlantonWeatherStripHeadPrice += (Singlepnl.Panel_DisplayWidth * (PlantonWeatherStripHeadPricePerMeter + PlantonWeatherStripHeadPowderCoatingPrice)) / 1000m;
                                    PlantonWeatherStripSillPrice += (Singlepnl.Panel_DisplayWidth * (PlantonWeatherStripSillPricePerMeter + PlantonWeatherStripSillPowderCoatingPrice)) / 1000m;

                                    BubbleSealPrice += ((Singlepnl.Panel_DisplayWidth * 2) * BubbleSealPricePerMeter * Singlepnl.Panel_LouverBladesCount) / 1000m;
                                    GalleryAdaptorPrice += ((Singlepnl.Panel_DisplayHeight * 2) * GalleryAdaptorPricePerMeter) / 1000m;
                                }


                                if (Singlepnl.Panel_LstLouverArtNo != null)
                                {
                                    foreach (string lvrgArtNo in Singlepnl.Panel_LstLouverArtNo)
                                    {
                                        lvrgBlades = lvrgArtNo.Replace("150", string.Empty);
                                        lvrgBlades = lvrgArtNo.Replace("152", string.Empty);
                                        lvrgBlades = Regex.Match(lvrgBlades, @"\d+").Value;

                                        #region Gallery
                                        if (lvrgArtNo.Contains("S"))
                                        {
                                            if (Convert.ToInt32(lvrgBlades) == 2)
                                            {
                                                GalleryPrice += GalleryPrice_2blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 3)
                                            {
                                                GalleryPrice += GalleryPrice_3blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 4)
                                            {
                                                GalleryPrice += GalleryPrice_4blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 5)
                                            {
                                                GalleryPrice += GalleryPrice_5blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 6)
                                            {
                                                GalleryPrice += GalleryPrice_6blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 7)
                                            {
                                                GalleryPrice += GalleryPrice_7blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 8)
                                            {
                                                GalleryPrice += GalleryPrice_8blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 9)
                                            {
                                                GalleryPrice += GalleryPrice_9blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 10)
                                            {
                                                GalleryPrice += GalleryPrice_10blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 11)
                                            {
                                                GalleryPrice += GalleryPrice_11blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 12)
                                            {
                                                GalleryPrice += GalleryPrice_12blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 13)
                                            {
                                                GalleryPrice += GalleryPrice_13blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 14)
                                            {
                                                GalleryPrice += GalleryPrice_14blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 15)
                                            {
                                                GalleryPrice += GalleryPrice_15blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 16)
                                            {
                                                GalleryPrice += GalleryPrice_16blades_usingSingleHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 17)
                                            {
                                                GalleryPrice += GalleryPrice_17blades_usingSingleHandle;
                                            }
                                        }
                                        else if (lvrgArtNo.Contains("D") ||
                                                 lvrgArtNo.Contains("-R-"))
                                        {
                                            if (Convert.ToInt32(lvrgBlades) == 2)
                                            {
                                                GalleryPrice += GalleryPrice_2blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 3)
                                            {
                                                GalleryPrice += GalleryPrice_3blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 4)
                                            {
                                                GalleryPrice += GalleryPrice_4blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 5)
                                            {
                                                GalleryPrice += GalleryPrice_5blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 6)
                                            {
                                                GalleryPrice += GalleryPrice_6blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 7)
                                            {
                                                GalleryPrice += GalleryPrice_7blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 8)
                                            {
                                                GalleryPrice += GalleryPrice_8blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 9)
                                            {
                                                GalleryPrice += GalleryPrice_9blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 10)
                                            {
                                                GalleryPrice += GalleryPrice_10blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 11)
                                            {
                                                GalleryPrice += GalleryPrice_11blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 12)
                                            {
                                                GalleryPrice += GalleryPrice_12blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 13)
                                            {
                                                GalleryPrice += GalleryPrice_13blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 14)
                                            {
                                                GalleryPrice += GalleryPrice_14blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 15)
                                            {
                                                GalleryPrice += GalleryPrice_15blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 16)
                                            {
                                                GalleryPrice += GalleryPrice_16blades_usingDualHandleOrRingpullHandle;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 17)
                                            {
                                                GalleryPrice += GalleryPrice_17blades_usingDualHandleOrRingpullHandle;
                                            }
                                        }
                                        else if (lvrgArtNo.Contains("A"))
                                        {
                                            if (Convert.ToInt32(lvrgBlades) == 3)
                                            {
                                                GalleryPrice += GalleryPrice_3blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 4)
                                            {
                                                GalleryPrice += GalleryPrice_4blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 5)
                                            {
                                                GalleryPrice += GalleryPrice_5blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 6)
                                            {
                                                GalleryPrice += GalleryPrice_6blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 7)
                                            {
                                                GalleryPrice += GalleryPrice_7blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 8)
                                            {
                                                GalleryPrice += GalleryPrice_8blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 9)
                                            {
                                                GalleryPrice += GalleryPrice_9blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 10)
                                            {
                                                GalleryPrice += GalleryPrice_10blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 11)
                                            {
                                                GalleryPrice += GalleryPrice_11blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 12)
                                            {
                                                GalleryPrice += GalleryPrice_12blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 13)
                                            {
                                                GalleryPrice += GalleryPrice_13blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 14)
                                            {
                                                GalleryPrice += GalleryPrice_14blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 15)
                                            {
                                                GalleryPrice += GalleryPrice_15blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 16)
                                            {
                                                GalleryPrice += GalleryPrice_16blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 17)
                                            {
                                                GalleryPrice += GalleryPrice_17blades_usingMotorizeMechanism * 1.3m * 1.1m * forex;
                                            }
                                        }


                                        #endregion

                                        #region SecurityKitCost 
                                        if (Singlepnl.Panel_LouverSecurityGrillCheck == true)
                                        {
                                            if (Convert.ToInt32(lvrgBlades) == 2)
                                            {
                                                SecurityKitCost += SecurityKit_2blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 3)
                                            {
                                                SecurityKitCost += SecurityKit_3blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 4)
                                            {
                                                SecurityKitCost += SecurityKit_4blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 5)
                                            {
                                                SecurityKitCost += SecurityKit_5blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 6)
                                            {
                                                SecurityKitCost += SecurityKit_6blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 7)
                                            {
                                                SecurityKitCost += SecurityKit_7blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 8)
                                            {
                                                SecurityKitCost += SecurityKit_8blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 9)
                                            {
                                                SecurityKitCost += SecurityKit_9blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 10)
                                            {
                                                SecurityKitCost += SecurityKit_10blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 11)
                                            {
                                                SecurityKitCost += SecurityKit_11blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 12)
                                            {
                                                SecurityKitCost += SecurityKit_12blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 13)
                                            {
                                                SecurityKitCost += SecurityKit_13blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 14)
                                            {
                                                SecurityKitCost += SecurityKit_14blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 15)
                                            {
                                                SecurityKitCost += SecurityKit_15blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 16)
                                            {
                                                SecurityKitCost += SecurityKit_16blades * 1.20m;
                                            }
                                            else if (Convert.ToInt32(lvrgBlades) == 17)
                                            {
                                                SecurityKitCost += SecurityKit_17blades * 1.20m;
                                            }
                                            SecurityKitPrice += SecurityKitCost + (Singlepnl.Panel_DisplayHeight / 1000m) * 685 * 2; // =(285+400)
                                        }
                                        #endregion

                                    }
                                }

                                #region RingpullLeverHandle
                                if (Singlepnl.Panel_LouverRPLeverHandleCheck == true)
                                {
                                    RingpullLeverHandlePrice = RingpullLeverHandlePricePerPiece;
                                }
                                #endregion

                                #region Glass 
                                if (Singlepnl.Panel_GlassThickness == 6.0f)
                                {
                                    if (Singlepnl.Panel_LouverBladeTypeOption == BladeType_Option._glass)
                                    {
                                        bladeType = "Glass";
                                        if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                        {
                                            if (Singlepnl.Panel_GlassThicknessDesc.Contains("Clear"))
                                            {
                                                GlassBladePrice += (Singlepnl.Panel_Width * 152m / 1000000m) * Glass_6mmTemp_PricePerSqrMeter * Convert.ToInt32(lvrgBlades);

                                            }
                                            else if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tinted"))
                                            {
                                                GlassBladePrice += (Singlepnl.Panel_Width * 152m / 1000000m) * Glass_6mmTempTinted_PricePerSqrMeter * Convert.ToInt32(lvrgBlades);
                                            }
                                            Singlepnl.Panel_GlassPricePerSqrMeter = 152m;
                                        }
                                        else
                                        {
                                            decimal BladeUsagePerPieceOfGlass = 0, BladeUsagePerPieceOfGlassCount = 0, BladeGlassMultiplier = 0;

                                            BladeUsagePerPieceOfGlass = (Singlepnl.Panel_Width / 1);

                                            if (BladeUsagePerPieceOfGlass < 800)
                                            {
                                                BladeUsagePerPieceOfGlassCount = 3;
                                            }
                                            else if (BladeUsagePerPieceOfGlass > 800)
                                            {
                                                BladeUsagePerPieceOfGlassCount = 2;
                                            }

                                            BladeGlassMultiplier = ((1 * Convert.ToInt32(lvrgBlades)) / BladeUsagePerPieceOfGlassCount);//1 = # of panel

                                            if (Singlepnl.Panel_GlassThicknessDesc.Contains("Clear"))
                                            {
                                                GlassBladePrice += ((191.21m * forex) / 40) * Math.Ceiling(BladeGlassMultiplier);
                                                Singlepnl.Panel_GlassPricePerSqrMeter = ((191.21m * forex) / 40);
                                            }
                                            else if (Singlepnl.Panel_GlassThicknessDesc == "6mm Acid Etched Euro Grey")
                                            {
                                                GlassBladePrice += ((286.81m * forex) / 40) * Math.Ceiling(BladeGlassMultiplier);
                                                Singlepnl.Panel_GlassPricePerSqrMeter = ((286.81m * forex) / 40);
                                            }
                                            else if (Singlepnl.Panel_GlassThicknessDesc.Contains("Acid Etched"))
                                            {
                                                GlassBladePrice += ((262.91m * forex) / 40) * Math.Ceiling(BladeGlassMultiplier);
                                                Singlepnl.Panel_GlassPricePerSqrMeter = ((262.91m * forex) / 40);

                                            }
                                            else if (Singlepnl.Panel_GlassThicknessDesc.Contains("Euro Grey"))
                                            {
                                                GlassBladePrice += ((215.11m * forex) / 40) * Math.Ceiling(BladeGlassMultiplier);
                                                Singlepnl.Panel_GlassPricePerSqrMeter = ((215.11m * forex) / 40);

                                            }
                                        }
                                    }
                                    else if (Singlepnl.Panel_LouverBladeTypeOption == BladeType_Option._Aluminum)
                                    {
                                        bladeType = "Aluminum";
                                        decimal BladeUsagePerPieceOfAluminum = 0, BladeUsagePerPieceOfAluminumCount = 0, BladeAluMultiplier = 0;
                                        BladeUsagePerPieceOfAluminum = (Singlepnl.Panel_Width / 1); // 1= # of panels

                                        if (BladeUsagePerPieceOfAluminum < 800)
                                        {
                                            BladeUsagePerPieceOfAluminumCount = 8;
                                        }
                                        else if (BladeUsagePerPieceOfAluminum > 800)
                                        {
                                            BladeUsagePerPieceOfAluminumCount = 6;
                                        }

                                        BladeAluMultiplier = ((1 * Convert.ToInt32(lvrgBlades)) / BladeUsagePerPieceOfAluminumCount);//1 = # of panel

                                        //OneSidedFoiledCost += 698.40m * forex;
                                        //PowderCoatedWhiteIvoryCost += 551.77m * forex;
                                        //TwoSideFoiledWoodGrainCost += 926.47m * forex;
                                        //MillFinishCost += 191.21m * forex;

                                        decimal alumBladesPrice = 0;
                                        if (wdm.WD_BaseColor == Base_Color._Ivory ||
                                            wdm.WD_BaseColor == Base_Color._White) //2 lang pinipili ng costing Milled or woodgrain
                                        {
                                            alumBladesPrice = 35.63m * forex;
                                        }
                                        else if (wdm.WD_BaseColor == Base_Color._DarkBrown)
                                        {
                                            alumBladesPrice = 926.47m * 5.8m;
                                        }
                                        GlassBladePrice = alumBladesPrice * Math.Ceiling(BladeAluMultiplier);
                                        Singlepnl.Panel_GlassPricePerSqrMeter = alumBladesPrice;
                                    }
                                }
                                else if (Singlepnl.Panel_GlassThickness >= 6.0f &&
                                    Singlepnl.Panel_GlassThickness <= 9.0f)
                                {
                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmTemp_PricePerSqrMeter;
                                    }
                                    else
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmClr_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_6mmClr_PricePerSqrMeter;
                                    }
                                }
                                else if (Singlepnl.Panel_GlassThickness == 10.0f ||
                                 Singlepnl.Panel_GlassThickness == 11.0f)
                                {
                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmTemp_PricePerSqrMeter;

                                    }
                                    else
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmClr_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_10mmClr_PricePerSqrMeter;

                                    }
                                }
                                else if (Singlepnl.Panel_GlassThickness >= 12.0f)
                                {
                                    if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmTemp_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmTemp_PricePerSqrMeter;

                                    }
                                    else
                                    {
                                        GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmClr_PricePerSqrMeter;
                                        Singlepnl.Panel_GlassPricePerSqrMeter = Glass_12mmClr_PricePerSqrMeter;

                                    }
                                }
                                else if (Singlepnl.Panel_GlassThickness == 0.0f)
                                {
                                    GlassPrice += 0;
                                    Singlepnl.Panel_GlassPricePerSqrMeter = GlassPrice;

                                }

                                //sealant for glass
                                Glass_SealantWHQty_Total = (int)(Math.Ceiling((decimal)((Singlepnl.Panel_GlassWidth + Singlepnl.Panel_GlassHeight) * 2) / 6842));

                                if (Singlepnl.Panel_GlassThickness != 0.0f)
                                {
                                    if ((wdm.WD_BaseColor == Base_Color._Ivory || wdm.WD_BaseColor == Base_Color._White) && OneSideFoil_whiteBase == false)
                                    {
                                        SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_Clear;
                                    }
                                    else if (wdm.WD_BaseColor == Base_Color._DarkBrown || OneSideFoil_whiteBase == true)
                                    {
                                        SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_BrownBlack;
                                    }
                                }
                                #endregion

                                #region GlassFilm
                                if (Singlepnl.Panel_GlassFilm == GlassFilm_Types._4milSolarGuard ||
                                    Singlepnl.Panel_GlassFilm == GlassFilm_Types._4milUpera)
                                {
                                    FilmPrice += ((Singlepnl.Panel_GlassWidth / 1000m) * (Singlepnl.Panel_GlassHeight / 1000m)) * _4millFilmPrice_PricePerSqrMeter;
                                }
                                else if (Singlepnl.Panel_GlassFilm == GlassFilm_Types._FrostedFilm)
                                {
                                    FilmPrice += ((Singlepnl.Panel_GlassWidth / 1000m) * (Singlepnl.Panel_GlassHeight / 1000m)) * FrostedFilmPrice_PricePerSqrMeter;
                                }
                                #endregion

                                #endregion
                            }
                        }

                        #endregion

                    }

                    //CostingFactor
                    if (ProvinceIntownOrOutoftown == true)
                    {
                        provinceBaseMultiplier = 2.90m;
                    }
                    else if (ProvinceIntownOrOutoftown == false)
                    {
                        provinceBaseMultiplier = 3.00m;
                    }

                    wdm.WD_CostingPoints = CostingPoints;
                    LaborCost = CostingPoints * CostPerPoints;

                    if (OneSideFoil_whiteBase == true &&
                        wdm.WD_profile != "PremiLine Profile")
                    {
                        LaborCost = LaborCost * 1.03m;
                    }

                    InstallationCost = InstallationPoints * CostPerPoints;

                    // Math.Round( , 2) +

                    FittingAndSuppliesCost = Math.Round(FSPrice, 2) +
                                             Math.Round(RestrictorStayPrice, 2) +
                                             Math.Round(CornerDrivePrice, 2) +
                                             Math.Round(SnapInKeepPrice, 2) +
                                             Math.Round(_35mmBacksetEspagWithCylinderPrice, 2) +
                                             Math.Round(MiddleCLoserPrice, 2) +
                                             Math.Round(StayBearingPrice, 2) +
                                             Math.Round(StayBearingPinPrice, 2) +
                                             Math.Round(CoverStayBearingPrice, 2) +
                                             Math.Round(CoverCornerHingePrice, 2) +
                                             Math.Round(CornerPivotRestPrice, 2) +
                                             Math.Round(TopCornerHingePrice, 2) +
                                             Math.Round(CorverCornerPivotRestPrice, 2) +
                                             Math.Round(CorverCornerPivotRestVerticalPrice, 2) +
                                             Math.Round(HandlePrice, 2) +
                                             Math.Round(EspagPrice, 2) +
                                             Math.Round(_2DHingePrice, 2) +
                                             Math.Round(_3DHingePrice, 2) +
                                             Math.Round(NTCenterHingePrice, 2) +
                                             Math.Round(ShootBoltStrikerPrice, 2) +
                                             Math.Round(ShootBoltReversePrice, 2) +
                                             Math.Round(ShootBoltNonReversePrice, 2) +
                                             Math.Round(StrikerPrice, 2) +
                                             Math.Round(LatchDeadboltStrikerPrice, 2) +
                                             Math.Round(ExtensionPrice, 2) +
                                             Math.Round(RollerPrice, 2) +
                                             Math.Round(StrikerLRPrice, 2) +
                                             Math.Round(BrushSealPrice, 2) +
                                             Math.Round(MotorizePrice, 2) +
                                             Math.Round(RemoteForMotorizeMechPrice, 2);

                    AncillaryProfileCost = Math.Round(ThresholdPrice, 2) +
                                           Math.Round(GbPrice, 2) +
                                           Math.Round((GeorgianBarCost * provinceBaseMultiplier), 2) + // 3 = costing factor for Georgian bar
                                           Math.Round(CoverProfileCost, 2) +
                                           Math.Round(GlazingGasketPrice, 2) +
                                           Math.Round(WeatherBarPrice, 2) +
                                           Math.Round(WeatherBarFastenerPrice, 2) +
                                           Math.Round(WaterSeepagePrice, 2) +
                                           Math.Round(GuideTrackPrice, 2) +
                                           Math.Round(AlumTrackPrice, 2) +
                                           Math.Round(InterlockPrice, 2) +
                                           Math.Round(ExtensionForInterlockPrice, 2) +
                                           Math.Round(AluminumPullHandlePrice, 2) +
                                           Math.Round((GlazingAdaptorPrice * provinceBaseMultiplier), 2);// 3 = costing factor for Glazing Adaptor

                    AccesorriesCost = Math.Round(EndCapPrice, 2) +
                                      Math.Round(MechJointPrice, 2) +
                                      Math.Round(GBSpacerPrice, 2) +
                                      Math.Round(PlasticWedgePrice, 2) +
                                      Math.Round(SealingBlockPrice, 2);


                    MaterialCost = Math.Round(FramePrice, 2) +
                                   Math.Round(FrameReinPrice, 2) +
                                   Math.Round(SashPrice, 2) +
                                   Math.Round(SashReinPrice, 2) +
                                   Math.Round(DivPrice, 2) +
                                   Math.Round(DivReinPrice, 2) +
                                   Math.Round(claddingPrice, 2) +
                                   Math.Round(DMPrice, 2) +
                                   Math.Round(DMReinforcementPrice, 2) +
                                   Math.Round(ExtensionProfile15mmPrice, 2) +
                                   Math.Round(TubularPrice, 2) +
                                   Math.Round(SealantPrice, 2) +
                                   Math.Round(PUFoamingPrice, 2) +
                                   Math.Round(FittingAndSuppliesCost, 2) +
                                   Math.Round(AncillaryProfileCost, 2) +
                                   Math.Round(AccesorriesCost, 2);

                    MaterialCostBreakDownBase = MaterialCost;

                    LouverCost = Math.Round(LouvreFrameWeatherStripHeadPrice, 2) +
                                 Math.Round(LouvreFrameBottomWeatherStripPrice, 2) +
                                 Math.Round(PlantonWeatherStripHeadPrice, 2) +
                                 Math.Round(PlantonWeatherStripSillPrice, 2) +
                                 Math.Round(GalleryAdaptorPrice, 2) +
                                 Math.Round(BubbleSealPrice, 2) +
                                 Math.Round(GlassBladePrice, 2) +
                                 Math.Round(GalleryPrice, 2) +
                                 Math.Round(PowerKitIncludingWiresPrice, 2) +
                                 Math.Round(SecurityKitPrice, 2) +
                                 Math.Round(RingpullLeverHandlePrice, 2);

                    LouverPrice = LouverCost;
                    LouverCost = LouverCost * PricingFactor * 1.12m; //1.12vat


                    MeshCost = Math.Round(SecurityMeshPrice, 2) +
                               Math.Round(WireMeshPrice, 2) +
                               Math.Round(PetMeshPrice, 2) +
                               Math.Round(TuffMeshPrice, 2) +
                               Math.Round(PhiferMeshPrice, 2) +
                               Math.Round(AluminumFramePrice, 2);

                    MeshPrice = MeshCost;
                    MeshCost = MeshCost * PricingFactor * 1.10m;


                    MaterialCost = MaterialCost +
                                   (MaterialCost * 0.05m) +
                                   (MaterialCost * 0.10m) +
                                   (MaterialCost * 0.12m) +
                                   (MaterialCost * 0.16m);

                    TotaPrice = Math.Round(LaborCost, 2) +
                                Math.Round(InstallationCost, 2) +
                                Math.Round(MaterialCost, 2) +
                                Math.Round(GlassPrice, 2) +
                                Math.Round(FilmPrice, 2) +
                                Math.Round(SecurityMeshPrice, 2);

                    if (cus_ref_date >= changeCondition_072723)
                    {
                        TotaPrice = TotaPrice - Math.Round(SecurityMeshPrice, 2);
                    }

                    BaseTotalPrice = TotaPrice;

                    TotaPrice = (TotaPrice * PricingFactor) + TotaPrice;

                    BaseTotalPriceWithFactor = TotaPrice;

                    TotaPrice = TotaPrice + LouverCost + MeshCost;

                    wdm.SystemSuggestedPrice = TotaPrice;

                    wdm.WD_currentPrice = TotaPrice;

                    lstTotalPrice.Add(TotaPrice);

                    if (wdm.WD_price == 0)
                    {
                        wdm.WD_price = TotaPrice;
                    }

                    #region Price History


                    DateTime thisDay = DateTime.Now;
                    //wdm.TotalPriceHistoryStatus = "System Generated Price";
                    wdm.TotalPriceHistory = "` COMPUTATION FOR SAVING `\n\n" +

                   "oras ng pag generate ng price: " + thisDay.ToString("g", CultureInfo.CreateSpecificCulture("en-US")) +

                    "`````\n\nWD_CostingPoints: " + CostingPoints.ToString() + "\n" +
                    "LaborCost: " + LaborCost.ToString() + " = CostingPoints " + CostingPoints.ToString() + " * CostPerPoints " + CostPerPoints.ToString() + "\n" +
                    "InstallationCost: " + InstallationCost.ToString() + " = InstallationPoints " + InstallationPoints.ToString() + " * CostPerPoints " + CostPerPoints.ToString() + "\n\n" +


                    "FittingAndSuppliesCost: " + FittingAndSuppliesCost.ToString() + " = \n" +

                                             "\t FSPrice: " + Math.Round(FSPrice, 2).ToString() + "+\n" +
                                             "\t RestrictorStayPrice: " + Math.Round(RestrictorStayPrice, 2).ToString() + "+\n" +
                                             "\t CornerDrivePrice: " + Math.Round(CornerDrivePrice, 2).ToString() + "+\n" +
                                             "\t SnapInKeepPrice: " + Math.Round(SnapInKeepPrice, 2).ToString() + "+\n" +
                                             "\t 35mmBacksetEspagWithCylinderPrice: " + Math.Round(_35mmBacksetEspagWithCylinderPrice, 2).ToString() + "+\n" +
                                             "\t MiddleCLoserPrice: " + Math.Round(MiddleCLoserPrice, 2).ToString() + "+\n" +
                                             "\t StayBearingPrice: " + Math.Round(StayBearingPrice, 2).ToString() + "+\n" +
                                             "\t StayBearingPinPrice: " + Math.Round(StayBearingPinPrice, 2).ToString() + "+\n" +
                                             "\t CoverStayBearingPrice: " + Math.Round(CoverStayBearingPrice, 2).ToString() + "+\n" +
                                             "\t CoverCornerHingePrice: " + Math.Round(CoverCornerHingePrice, 2).ToString() + "+\n" +
                                             "\t CornerPivotRestPrice: " + Math.Round(CornerPivotRestPrice, 2).ToString() + "+\n" +
                                             "\t TopCornerHingePrice: " + Math.Round(TopCornerHingePrice, 2).ToString() + "+\n" +
                                             "\t CorverCornerPivotRestPrice: " + Math.Round(CorverCornerPivotRestPrice, 2).ToString() + "+\n" +
                                             "\t CorverCornerPivotRestVerticalPrice: " + Math.Round(CorverCornerPivotRestVerticalPrice, 2).ToString() + "+\n" +
                                             "\t HandlePrice: " + Math.Round(HandlePrice, 2).ToString() + "+\n" +
                                             "\t EspagPrice: " + Math.Round(EspagPrice, 2).ToString() + "+\n" +
                                             "\t _2DHingePrice: " + Math.Round(_2DHingePrice, 2).ToString() + "+\n" +
                                             "\t _3DHingePrice: " + Math.Round(_3DHingePrice, 2).ToString() + "+\n" +
                                             "\t NTCenterHingePrice: " + Math.Round(NTCenterHingePrice, 2).ToString() + "+\n" +
                                             "\t ShootBoltStrikerPrice: " + Math.Round(ShootBoltStrikerPrice, 2).ToString() + "+\n" +
                                             "\t ShootBoltReversePrice: " + Math.Round(ShootBoltReversePrice, 2).ToString() + "+\n" +
                                             "\t ShootBoltNonReversePrice: " + Math.Round(ShootBoltNonReversePrice, 2).ToString() + "+\n" +
                                             "\t StrikerPrice: " + Math.Round(StrikerPrice, 2).ToString() + "+\n" +
                                             "\t LatchDeadboltStrikerPrice: " + Math.Round(LatchDeadboltStrikerPrice, 2).ToString() + "+\n" +
                                             "\t ExtensionPrice: " + Math.Round(ExtensionPrice, 2).ToString() + "+\n" +
                                             "\t RollerPrice: " + Math.Round(RollerPrice, 2).ToString() + "+\n" +
                                             "\t StrikerLRPrice: " + Math.Round(StrikerLRPrice, 2).ToString() + "+\n" +
                                             "\t BrushSealPrice: " + Math.Round(BrushSealPrice, 2).ToString() + "+\n" +
                                             "\t MotorizePrice: " + Math.Round(MotorizePrice, 2).ToString() + "+\n" +
                                             "\t MotorizeMechRemotePricePerPiece: " + Math.Round(MotorizeMechRemotePricePerPiece, 2).ToString() + "\n\n" +

                    "AncillaryProfileCost: " + AncillaryProfileCost.ToString() + " = \n" +

                                             "\t ThresholdPrice:" + Math.Round(ThresholdPrice, 2).ToString() + "+\n" +
                                             "\t GbPrice:" + Math.Round(GbPrice, 2) + "+\n" +
                                             "\t GeorgianBarCost:" + Math.Round((GeorgianBarCost * provinceBaseMultiplier), 2) + "+\n" +
                                             "\t CoverProfileCost:" + Math.Round(CoverProfileCost, 2) + "+\n" +
                                             "\t GlazingGasketPrice:" + Math.Round(GlazingGasketPrice, 2) + "+\n" +
                                             "\t WeatherBarPrice:" + Math.Round(WeatherBarPrice, 2) + "+\n" +
                                             "\t WeatherBarFastenerPrice:" + Math.Round(WeatherBarFastenerPrice, 2) + "+\n" +
                                             "\t WaterSeepagePrice:" + Math.Round(WaterSeepagePrice, 2) + "+\n" +
                                             "\t GuideTrackPrice:" + Math.Round(GuideTrackPrice, 2) + "+\n" +
                                             "\t AlumTrackPrice:" + Math.Round(AlumTrackPrice, 2) + "+\n" +
                                             "\t InterlockPrice:" + Math.Round(InterlockPrice, 2) + "+\n" +
                                             "\t ExtensionForInterlockPrice:" + Math.Round(ExtensionForInterlockPrice, 2) + "+\n" +
                                             "\t AluminumPullHandlePrice:" + Math.Round(AluminumPullHandlePrice, 2) + "+\n" +
                                             "\t GlazingAdaptorPrice:" + Math.Round((GlazingAdaptorPrice * provinceBaseMultiplier), 2) + "\n\n" +


                    "AccesorriesCost: " + AccesorriesCost.ToString() + " = \n" +
                                             "\t EndCapPrice:" + Math.Round(EndCapPrice, 2).ToString() + "+\n" +
                                             "\t MechJointPrice:" + Math.Round(MechJointPrice, 2).ToString() + "+\n" +
                                             "\t GBSpacerPrice:" + Math.Round(GBSpacerPrice, 2).ToString() + "+\n" +
                                             "\t PlasticWedgePrice:" + Math.Round(PlasticWedgePrice, 2).ToString() + "+\n" +
                                             "\t SealingBlockPrice:" + Math.Round(SealingBlockPrice, 2).ToString() + "\n\n" +



                    "MaterialCost: " + MaterialCost.ToString() + " = \n" +

                                             "\t FramePrice:" + Math.Round(FramePrice, 2).ToString() + "+\n" +
                                             "\t FrameReinPrice:" + Math.Round(FrameReinPrice, 2).ToString() + "+\n" +
                                             "\t SashPrice:" + Math.Round(SashPrice, 2).ToString() + "+\n" +
                                             "\t SashReinPrice:" + Math.Round(SashReinPrice, 2).ToString() + "+\n" +
                                             "\t DivPrice:" + Math.Round(DivPrice, 2).ToString() + "+\n" +
                                             "\t DivReinPrice:" + Math.Round(DivReinPrice, 2).ToString() + "+\n" +
                                             "\t claddingPrice:" + Math.Round(claddingPrice, 2).ToString() + "+\n" +
                                             "\t DMPrice:" + Math.Round(DMPrice, 2).ToString() + "+\n" +
                                             "\t DMReinforcementPrice:" + Math.Round(DMReinforcementPrice, 2).ToString() + "+\n" +
                                             "\t ExtensionProfile15mmPrice:" + Math.Round(ExtensionProfile15mmPrice, 2).ToString() + "+\n" +
                                             "\t TubularPrice:" + Math.Round(TubularPrice, 2).ToString() + "+\n" +
                                             "\t SealantPrice:" + Math.Round(SealantPrice, 2).ToString() + "+\n" +
                                             "\t PUFoamingPrice:" + Math.Round(PUFoamingPrice, 2).ToString() + "+\n" +
                                             "\t FittingAndSuppliesCost:" + Math.Round(FittingAndSuppliesCost, 2).ToString() + "+\n" +
                                             "\t AncillaryProfileCost:" + Math.Round(AncillaryProfileCost, 2).ToString() + "+\n" +
                                             "\t AccesorriesCost:" + Math.Round(AccesorriesCost, 2).ToString() + "\n\n" +


                    "MaterialCostBreakDownBase: " + MaterialCost.ToString() + " \n\n" +


                    "LouverCost: " + LouverCost.ToString() + " = \n" +

                                 "\t LouvreFrameWeatherStripHeadPrice:" + Math.Round(LouvreFrameWeatherStripHeadPrice, 2).ToString() + "+\n" +
                                 "\t LouvreFrameBottomWeatherStripPrice:" + Math.Round(LouvreFrameBottomWeatherStripPrice, 2).ToString() + "+\n" +
                                 "\t PlantonWeatherStripHeadPrice:" + Math.Round(PlantonWeatherStripHeadPrice, 2).ToString() + "+\n" +
                                 "\t PlantonWeatherStripSillPrice:" + Math.Round(PlantonWeatherStripSillPrice, 2).ToString() + "+\n" +
                                 "\t GalleryAdaptorPrice:" + Math.Round(GalleryAdaptorPrice, 2).ToString() + "+\n" +
                                 "\t BubbleSealPrice:" + Math.Round(BubbleSealPrice, 2).ToString() + "+\n" +
                                 "\t GlassBladePrice:" + Math.Round(GlassBladePrice, 2).ToString() + "+\n" +
                                 "\t GalleryPrice:" + Math.Round(GalleryPrice, 2).ToString() + "+\n" +
                                 "\t PowerKitIncludingWiresPrice:" + Math.Round(PowerKitIncludingWiresPrice, 2).ToString() + "+\n" +
                                 "\t SecurityKitPrice:" + Math.Round(SecurityKitPrice, 2).ToString() + "+\n" +
                                 "\t RingpullLeverHandlePrice:" + Math.Round(RingpullLeverHandlePrice, 2).ToString() + "\n\n" +

                   "LouverPrice: " + LouverCost.ToString() + " \n\n" +

                    "LouverCost: " + LouverCost.ToString() + " = LouverCost: " + LouverCost + " * PricingFactor: " + PricingFactor + " * 1.12m\n\n" +



                    "MeshCost: " + MeshCost.ToString() + " = \n" +


                               "\t SecurityMeshPrice:" + Math.Round(SecurityMeshPrice, 2) + "+\n" +
                               "\t WireMeshPrice:" + Math.Round(WireMeshPrice, 2) + "+\n" +
                               "\t PetMeshPrice:" + Math.Round(PetMeshPrice, 2) + "+\n" +
                               "\t TuffMeshPrice:" + Math.Round(TuffMeshPrice, 2) + "+\n" +
                               "\t PhiferMeshPrice:" + Math.Round(PhiferMeshPrice, 2) + "+\n" +
                               "\t AluminumFramePrice:" + Math.Round(AluminumFramePrice, 2) + "\n\n" +


                    "MeshPrice: " + MeshCost.ToString() + " \n\n" +


                    "MeshCost = : MeshCost" + MeshCost.ToString() + " * " + PricingFactor.ToString() + " * 1.10m\n\n" +

                        "MaterialCost: " + MaterialCost.ToString() + " = \n" +
                                  "\t MaterialCost:" + MaterialCostBreakDownBase.ToString() + "+\n" +
                                   "\t (MaterialCost:" + MaterialCostBreakDownBase.ToString() + " * 0.05m) +\n" +
                                   "\t (MaterialCost:" + MaterialCostBreakDownBase.ToString() + " * 0.10m) +\n" +
                                   "\t (MaterialCost:" + MaterialCostBreakDownBase.ToString() + " * 0.12m) +\n" +
                                   "\t (MaterialCost:" + MaterialCostBreakDownBase.ToString() + " * 0.16m)  \n\n" +

                   "TotaPrice: " + BaseTotalPrice.ToString() + " = \n" +


                               "\t LaborCost:" + Math.Round(LaborCost, 2).ToString() + "+\n" +
                               "\t InstallationCost:" + Math.Round(InstallationCost, 2).ToString() + "+\n" +
                               "\t MaterialCost " + Math.Round(MaterialCost, 2).ToString() + "+\n" +
                               "\t GlassPrice:" + Math.Round(GlassPrice, 2).ToString() + "+\n" +
                               "\t FilmPrice:" + Math.Round(FilmPrice, 2).ToString() + "+\n" +
                               "\t SecurityMeshPrice:" + Math.Round(SecurityMeshPrice, 2).ToString() + "\n\n" +


                   "TotaPrice: " + BaseTotalPriceWithFactor.ToString() + " = (" + BaseTotalPrice.ToString() + " * " + PricingFactor.ToString() + ") + " + BaseTotalPrice.ToString() + ") \n\n" +

                   "TotaPrice: " + TotaPrice.ToString() + " = " + BaseTotalPriceWithFactor.ToString() + " + " + LouverCost.ToString() + " + " + MeshCost.ToString() + "\n\n" +

                    "` END OF COMPUTATION FOR SAVING `\n\n\n";
                    #endregion


                    if (BOM_Status == true)
                    {

                        #region Price Break Down 

                        decimal MaterialCostDeduction = 0, MaterialCostPriceBreakDown = 0;
                        MaterialCostDeduction = AccesorriesCost +
                                                AncillaryProfileCost +
                                                FittingAndSuppliesCost;

                        MaterialCostPriceBreakDown = MaterialCost - MaterialCostDeduction;

                        Price_List.Rows.Add("Material Cost",
                                            "",
                                            Math.Round(MaterialCostPriceBreakDown, 2).ToString("N", new CultureInfo("en-US")),
                                            Math.Round(MaterialCostPriceBreakDown * PricingFactor, 2).ToString("N", new CultureInfo("en-US")),
                                            Math.Round((MaterialCostPriceBreakDown * PricingFactor) + MaterialCostPriceBreakDown, 2).ToString("N", new CultureInfo("en-US")),
                                            "Price Break Down");

                        Price_List.Rows.Add("Accesorries",
                                            "",
                                            Math.Round(AccesorriesCost, 2).ToString("N", new CultureInfo("en-US")),
                                            Math.Round(AccesorriesCost * PricingFactor, 2).ToString("N", new CultureInfo("en-US")),
                                            Math.Round((AccesorriesCost * PricingFactor) + AccesorriesCost, 2).ToString("N", new CultureInfo("en-US")),
                                            "Price Break Down");

                        Price_List.Rows.Add("Ancillary Profile",
                                         "",
                                         Math.Round(AncillaryProfileCost, 2).ToString("N", new CultureInfo("en-US")),
                                         Math.Round(AncillaryProfileCost * PricingFactor, 2).ToString("N", new CultureInfo("en-US")),
                                         Math.Round((AncillaryProfileCost * PricingFactor) + AncillaryProfileCost, 2).ToString("N", new CultureInfo("en-US")),
                                         "Price Break Down");

                        Price_List.Rows.Add("Fitting and Supplies",
                                            "",
                                            Math.Round(FittingAndSuppliesCost, 2).ToString("N", new CultureInfo("en-US")),
                                            Math.Round(FittingAndSuppliesCost * PricingFactor, 2).ToString("N", new CultureInfo("en-US")),
                                            Math.Round((FittingAndSuppliesCost * PricingFactor) + FittingAndSuppliesCost, 2).ToString("N", new CultureInfo("en-US")),
                                            "Price Break Down");

                        Price_List.Rows.Add("Labor Cost",
                                            "",
                                            Math.Round(LaborCost, 2).ToString("N", new CultureInfo("en-US")),
                                            Math.Round(LaborCost * PricingFactor, 2).ToString("N", new CultureInfo("en-US")),
                                            Math.Round((LaborCost * PricingFactor) + LaborCost, 2).ToString("N", new CultureInfo("en-US")),
                                            "Price Break Down");

                        Price_List.Rows.Add("Installation Cost",
                                            "",
                                            Math.Round(InstallationCost, 2).ToString("N", new CultureInfo("en-US")),
                                            Math.Round(InstallationCost * PricingFactor, 2).ToString("N", new CultureInfo("en-US")),
                                            Math.Round((InstallationCost * PricingFactor) + InstallationCost, 2).ToString("N", new CultureInfo("en-US")),
                                            "Price Break Down");

                        Price_List.Rows.Add("Louver Material Cost",
                                        "",
                                        Math.Round(LouverPrice, 2).ToString("N", new CultureInfo("en-US")),
                                        Math.Round((LouverPrice * PricingFactor * 1.12m) - LouverPrice, 2).ToString("N", new CultureInfo("en-US")),
                                        Math.Round((LouverPrice * PricingFactor * 1.12m), 2).ToString("N", new CultureInfo("en-US")),
                                        "Price Break Down");


                        Price_List.Rows.Add("Mesh Cost",
                                      "",
                                      Math.Round(MeshPrice, 2).ToString("N", new CultureInfo("en-US")),
                                      Math.Round((MeshPrice * PricingFactor * 1.10m) - MeshPrice, 2).ToString("N", new CultureInfo("en-US")),
                                      Math.Round((MeshPrice * PricingFactor * 1.10m), 2).ToString("N", new CultureInfo("en-US")),
                                      "Price Break Down");

                        Price_List.Rows.Add("Glass",
                                            "",
                                            Math.Round(GlassPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            Math.Round(GlassPrice * PricingFactor, 2).ToString("N", new CultureInfo("en-US")),
                                            Math.Round((GlassPrice * PricingFactor) + GlassPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "Price Break Down");

                        //glass film
                        Price_List.Rows.Add(GlassFilm_Types._4milSolarGuard.ToString(),
                                            "",
                                            Math.Round(FilmPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            Math.Round(FilmPrice * PricingFactor, 2).ToString("N", new CultureInfo("en-US")),
                                            Math.Round((FilmPrice * PricingFactor) + FilmPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "Price Break Down");




                        Price_List.Rows.Add("",
                                            "",
                                            "",
                                            "",
                                            Math.Round(TotaPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "Price Break Down");

                        #endregion

                        #region Material Cost
                        decimal Wastage = 0,
                                contingenciesForOverheadCost = 0,
                                VAT = 0,
                                DutiesAndTaxes = 0;

                        Wastage = (MaterialCostBreakDownBase * 0.05m);
                        contingenciesForOverheadCost = (MaterialCostBreakDownBase * 0.10m);
                        VAT = (MaterialCostBreakDownBase * 0.12m);
                        DutiesAndTaxes = (MaterialCostBreakDownBase * 0.16m);


                        Price_List.Rows.Add("Frame Price",
                                            FramePricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                            Math.Round(FramePrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "",
                                            "",
                                            "Material Cost");

                        Price_List.Rows.Add("Frame Reinforcement Price",
                                            FrameReinPricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                            Math.Round(FrameReinPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "",
                                            "",
                                            "Material Cost");

                        Price_List.Rows.Add("Sash Price",
                                            SashPricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                            Math.Round(SashPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "",
                                            "",
                                            "Material Cost");

                        Price_List.Rows.Add("Sash Reinforcement Price",
                                            SashReinPricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                            Math.Round(SashReinPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "",
                                            "",
                                            "Material Cost");

                        Price_List.Rows.Add(BOM_divDesc + " Price",
                                            DividerPricePerSqrMeter.ToString("N", new CultureInfo("en-US")),
                                            Math.Round(DivPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "",
                                            "",
                                            "Material Cost");

                        Price_List.Rows.Add(BOM_divDesc + " Reinforcement Price",
                                           DividerReinPricePerSqrMeter.ToString("N", new CultureInfo("en-US")),
                                           Math.Round(DivReinPrice, 2).ToString("N", new CultureInfo("en-US")),
                                           "",
                                           "",
                                           "Material Cost");

                        Price_List.Rows.Add("Cladding with reinforcement Price",
                                           claddingPricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                           Math.Round(claddingPrice, 2).ToString("N", new CultureInfo("en-US")),
                                           "",
                                           "",
                                           "Material Cost");

                        Price_List.Rows.Add("Dummy Mullion Price",
                                           DummyMullionPricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                           Math.Round(DMPrice, 2).ToString("N", new CultureInfo("en-US")),
                                           "",
                                           "",
                                           "Material Cost");

                        Price_List.Rows.Add("Dummy Mullion Reinforcement Price",
                                           FrameReinPricePerLinearMeter_7502.ToString("N", new CultureInfo("en-US")),
                                           Math.Round(DMReinforcementPrice, 2).ToString("N", new CultureInfo("en-US")),
                                           "",
                                           "",
                                           "Material Cost");

                        Price_List.Rows.Add("15mm Extension Profile Price",
                                       ExtensionProfile15mmPricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                       Math.Round(ExtensionProfile15mmPrice, 2).ToString("N", new CultureInfo("en-US")),
                                       "",
                                       "",
                                       "Material Cost");

                        Price_List.Rows.Add("Tubular Price",
                                           TubularPricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                           Math.Round(TubularPrice, 2).ToString("N", new CultureInfo("en-US")),
                                           "",
                                           "",
                                           "Material Cost");

                        Price_List.Rows.Add("Sealant Price",
                                           SealantPricePerCan.ToString("N", new CultureInfo("en-US")),
                                           Math.Round(SealantPrice, 2).ToString("N", new CultureInfo("en-US")),
                                           "",
                                           "",
                                           "Material Cost");

                        Price_List.Rows.Add("PU Foaming Price",
                                            PUFoamingPricePerCan.ToString("N", new CultureInfo("en-US")),
                                            Math.Round(PUFoamingPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "",
                                            "",
                                            "Material Cost");

                        Price_List.Rows.Add("Wastage",
                                            "",
                                            Math.Round(Wastage, 2).ToString("N", new CultureInfo("en-US")),
                                            "",
                                            "",
                                            "Material Cost");

                        Price_List.Rows.Add("Contingencies For Over head Cost",
                                  "",
                                  Math.Round(contingenciesForOverheadCost, 2).ToString("N", new CultureInfo("en-US")),
                                  "",
                                  "",
                                  "Material Cost");

                        Price_List.Rows.Add("VAT",
                                  "",
                                  Math.Round(VAT, 2).ToString("N", new CultureInfo("en-US")),
                                  "",
                                  "",
                                  "Material Cost");

                        Price_List.Rows.Add("Duties And Taxes",
                                  "",
                                  Math.Round(DutiesAndTaxes, 2).ToString("N", new CultureInfo("en-US")),
                                  "",
                                  "",
                                  "Material Cost");

                        Price_List.Rows.Add("Total",
                                            "",
                                            Math.Round(MaterialCostPriceBreakDown, 2).ToString("N", new CultureInfo("en-US")),
                                            "",
                                            "",
                                            "Material Cost");

                        #endregion

                        #region Accesorries Cost

                        Price_List.Rows.Add("End cap Price",
                                          EndCapPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                          Math.Round(EndCapPrice, 2).ToString("N", new CultureInfo("en-US")),
                                          "",
                                          "",
                                          "Accesorries");

                        Price_List.Rows.Add("Mechanical Joint Price",
                                       MechanicalJointPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                       Math.Round(MechJointPrice, 2).ToString("N", new CultureInfo("en-US")),
                                       "",
                                       "",
                                       "Accesorries");

                        Price_List.Rows.Add("Glazing Bead Spacer Price",
                                      GBSpacerPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                      Math.Round(GBSpacerPrice, 2).ToString("N", new CultureInfo("en-US")),
                                      "",
                                      "",
                                      "Accesorries");

                        Price_List.Rows.Add("Plastic Wedge Price",
                                      PlasticWedgePricePerPiece.ToString("N", new CultureInfo("en-US")),
                                      Math.Round(PlasticWedgePrice, 2).ToString("N", new CultureInfo("en-US")),
                                      "",
                                      "",
                                      "Accesorries");

                        Price_List.Rows.Add("Sealing Block Price",
                                      SealingBlockPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                      Math.Round(SealingBlockPrice, 2).ToString("N", new CultureInfo("en-US")),
                                      "",
                                      "",
                                      "Accesorries");

                        Price_List.Rows.Add("Total",
                                           "",
                                           Math.Round(AccesorriesCost, 2).ToString("N", new CultureInfo("en-US")),
                                           "",
                                           "",
                                           "Accesorries");

                        #endregion

                        #region Ancillary Profile Cost

                        Price_List.Rows.Add("Threshold Price",
                                        FrameThresholdPricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                        Math.Round(ThresholdPrice, 2).ToString("N", new CultureInfo("en-US")),
                                        "",
                                        "",
                                        "Ancillary Profile");

                        Price_List.Rows.Add("Glazing Bead Price",
                                   GlazingBeadPricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                   Math.Round(GbPrice, 2).ToString("N", new CultureInfo("en-US")),
                                   "",
                                   "",
                                   "Ancillary Profile");

                        Price_List.Rows.Add("Georgian Bar Cost",
                                   GeorgianBarPrice.ToString("N", new CultureInfo("en-US")),
                                   Math.Round(GeorgianBarCost * 3, 2).ToString("N", new CultureInfo("en-US")),
                                   "",
                                   "",
                                   "Ancillary Profile");

                        Price_List.Rows.Add("Cover Profile Cover",
                                   CoverProfilePrice.ToString("N", new CultureInfo("en-US")),
                                   Math.Round(CoverProfileCost, 2).ToString("N", new CultureInfo("en-US")),
                                   "",
                                   "",
                                   "Ancillary Profile");

                        Price_List.Rows.Add("Glazing Gasket Price",
                                   GlazingGasketPricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                   Math.Round(GlazingGasketPrice, 2).ToString("N", new CultureInfo("en-US")),
                                   "",
                                   "",
                                   "Ancillary Profile");

                        Price_List.Rows.Add("Weather Bar Price",
                                   WeatherBarPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                   Math.Round(WeatherBarPrice, 2).ToString("N", new CultureInfo("en-US")),
                                   "",
                                   "",
                                   "Ancillary Profile");

                        Price_List.Rows.Add("Weather Bar Fastener Price",
                                   BarFastenerPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                   Math.Round(WeatherBarFastenerPrice, 2).ToString("N", new CultureInfo("en-US")),
                                   "",
                                   "",
                                   "Ancillary Profile");

                        Price_List.Rows.Add("Water Seepage Price",
                                   WaterSeepagePricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                   Math.Round(WaterSeepagePrice, 2).ToString("N", new CultureInfo("en-US")),
                                   "",
                                   "",
                                   "Ancillary Profile");

                        Price_List.Rows.Add("Guide Track Price",
                                   GuideTrackPricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                   Math.Round(GuideTrackPrice, 2).ToString("N", new CultureInfo("en-US")),
                                   "",
                                   "",
                                   "Ancillary Profile");

                        Price_List.Rows.Add("Aluminum Track Price",
                                   AluminumTrackPricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                   Math.Round(AlumTrackPrice, 2).ToString("N", new CultureInfo("en-US")),
                                   "",
                                   "",
                                   "Ancillary Profile");

                        Price_List.Rows.Add("Interlock Price",
                                   InterlockPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                   Math.Round(InterlockPrice, 2).ToString("N", new CultureInfo("en-US")),
                                   "",
                                   "",
                                   "Ancillary Profile");

                        Price_List.Rows.Add("Extension For Interlock Price",
                                   ExtensionForInterlockPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                   Math.Round(ExtensionForInterlockPrice, 2).ToString("N", new CultureInfo("en-US")),
                                   "",
                                   "",
                                   "Ancillary Profile");

                        Price_List.Rows.Add("Aluminum Pull Handle Price",
                                   AluminumPullHandlePricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                   Math.Round(AluminumPullHandlePrice, 2).ToString("N", new CultureInfo("en-US")),
                                   "",
                                   "",
                                   "Ancillary Profile");

                        Price_List.Rows.Add("Glazing Adaptor Price",
                              GlazingAdaptorPricePerMeter.ToString("N", new CultureInfo("en-US")),
                              Math.Round(GlazingAdaptorPrice, 2).ToString("N", new CultureInfo("en-US")),
                              "",
                              "",
                              "Ancillary Profile");

                        Price_List.Rows.Add("Total",
                                          "",
                                          Math.Round(AncillaryProfileCost, 2).ToString("N", new CultureInfo("en-US")),
                                          "",
                                          "",
                                          "Ancillary Profile");
                        #endregion

                        #region Fitting and Supplies Cost

                        Price_List.Rows.Add("Friction Stay Price",
                                            FSBasePrice.ToString("N", new CultureInfo("en-US")),
                                            Math.Round(FSPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "",
                                            "",
                                            "Fitting and Supplies");

                        Price_List.Rows.Add("Restrictor Stay Price",
                                            RestrictorStayPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                            Math.Round(RestrictorStayPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "",
                                            "",
                                            "Fitting and Supplies");

                        Price_List.Rows.Add("Corner Drive Price",
                                            CornerDrivePricePerPiece.ToString("N", new CultureInfo("en-US")),
                                            Math.Round(CornerDrivePrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "",
                                            "",
                                            "Fitting and Supplies");

                        Price_List.Rows.Add("Snap In Keep Price",
                                            SnapInKeepPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                            Math.Round(SnapInKeepPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "",
                                            "",
                                            "Fitting and Supplies");

                        Price_List.Rows.Add("35mm Backset Espagnolette With Cylinder Price",
                                            _35mmBacksetEspagWithCylinder.ToString("N", new CultureInfo("en-US")),
                                            Math.Round(_35mmBacksetEspagWithCylinderPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "",
                                            "",
                                            "Fitting and Supplies");

                        Price_List.Rows.Add("Middle CLoser Price",
                                          MiddleCLoserPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                          Math.Round(MiddleCLoserPrice, 2).ToString("N", new CultureInfo("en-US")),
                                          "",
                                          "",
                                          "Fitting and Supplies");

                        Price_List.Rows.Add("Stay Bearing Price",
                                          StayBearingPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                          Math.Round(StayBearingPrice, 2).ToString("N", new CultureInfo("en-US")),
                                          "",
                                          "",
                                          "Fitting and Supplies");

                        Price_List.Rows.Add("Stay Bearing Pin Price",
                                       StayBearingPinPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                       Math.Round(StayBearingPinPrice, 2).ToString("N", new CultureInfo("en-US")),
                                       "",
                                       "",
                                       "Fitting and Supplies");

                        Price_List.Rows.Add("Cover Stay Bearing Price",
                                       CoverStayBearingPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                       Math.Round(CoverStayBearingPrice, 2).ToString("N", new CultureInfo("en-US")),
                                       "",
                                       "",
                                       "Fitting and Supplies");

                        Price_List.Rows.Add("Cover Corner Hinge Price",
                                       CoverCornerHingePricePerPiece.ToString("N", new CultureInfo("en-US")),
                                       Math.Round(CoverCornerHingePrice, 2).ToString("N", new CultureInfo("en-US")),
                                       "",
                                       "",
                                       "Fitting and Supplies");

                        Price_List.Rows.Add("Corner Pivot Rest Price",
                                      CornerPivotRestPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                      Math.Round(CornerPivotRestPrice, 2).ToString("N", new CultureInfo("en-US")),
                                      "",
                                      "",
                                      "Fitting and Supplies");

                        Price_List.Rows.Add("Top Corner Hinge Price",
                                      TopCornerHingePricePerPiece.ToString("N", new CultureInfo("en-US")),
                                      Math.Round(TopCornerHingePrice, 2).ToString("N", new CultureInfo("en-US")),
                                      "",
                                      "",
                                      "Fitting and Supplies");

                        Price_List.Rows.Add("Corver Corner Pivot Rest Price",
                                     CorverCornerPivotRestPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                     Math.Round(CorverCornerPivotRestPrice, 2).ToString("N", new CultureInfo("en-US")),
                                     "",
                                     "",
                                     "Fitting and Supplies");

                        Price_List.Rows.Add("Corver Corner Pivot Rest Vertical Price",
                                    CorverCornerPivotRestVerticalPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                    Math.Round(CorverCornerPivotRestVerticalPrice, 2).ToString("N", new CultureInfo("en-US")),
                                    "",
                                    "",
                                    "Fitting and Supplies");

                        Price_List.Rows.Add(HandleDesc + " Price",
                                    HandleBasePrice.ToString("N", new CultureInfo("en-US")),
                                    Math.Round(HandlePrice, 2).ToString("N", new CultureInfo("en-US")),
                                    "",
                                    "",
                                    "Fitting and Supplies");

                        Price_List.Rows.Add("Espagnolette Price",
                                    EspagBasePrice.ToString("N", new CultureInfo("en-US")),
                                    Math.Round(EspagPrice, 2).ToString("N", new CultureInfo("en-US")),
                                    "",
                                    "",
                                    "Fitting and Supplies");

                        Price_List.Rows.Add("2D Hinge Price",
                                    _2DHingePricePerPiece.ToString("N", new CultureInfo("en-US")),
                                    Math.Round(_2DHingePrice, 2).ToString("N", new CultureInfo("en-US")),
                                    "",
                                    "",
                                    "Fitting and Supplies");

                        Price_List.Rows.Add("3D Hinge Price",
                                  _3DHingePricePerPiece.ToString("N", new CultureInfo("en-US")),
                                  Math.Round(_3DHingePrice, 2).ToString("N", new CultureInfo("en-US")),
                                  "",
                                  "",
                                  "Fitting and Supplies");

                        Price_List.Rows.Add("NT Center Hinge Price",
                                  NTCenterHingePricePerPiece.ToString("N", new CultureInfo("en-US")),
                                  Math.Round(NTCenterHingePrice, 2).ToString("N", new CultureInfo("en-US")),
                                  "",
                                  "",
                                  "Fitting and Supplies");

                        Price_List.Rows.Add("Shoot Bolt Striker Price",
                                  ShootBoltStrikerPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                  Math.Round(ShootBoltStrikerPrice, 2).ToString("N", new CultureInfo("en-US")),
                                  "",
                                  "",
                                  "Fitting and Supplies");

                        Price_List.Rows.Add("Shoot Bolt Reverse Price",
                                  ShootBoltReversePricePerPiece.ToString("N", new CultureInfo("en-US")),
                                  Math.Round(ShootBoltReversePrice, 2).ToString("N", new CultureInfo("en-US")),
                                  "",
                                  "",
                                  "Fitting and Supplies");

                        Price_List.Rows.Add("Shoot Bolt Non Reverse Price",
                                  ShootBoltNonReversePricePerPiece.ToString("N", new CultureInfo("en-US")),
                                  Math.Round(ShootBoltNonReversePrice, 2).ToString("N", new CultureInfo("en-US")),
                                  "",
                                  "",
                                  "Fitting and Supplies");

                        Price_List.Rows.Add("Striker Price",
                                  StrikerPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                  Math.Round(StrikerPrice, 2).ToString("N", new CultureInfo("en-US")),
                                  "",
                                  "",
                                  "Fitting and Supplies");

                        Price_List.Rows.Add("Latch Deadbolt Striker Price",
                                  LatchDeadboltStrikerPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                  Math.Round(LatchDeadboltStrikerPrice, 2).ToString("N", new CultureInfo("en-US")),
                                  "",
                                  "",
                                  "Fitting and Supplies");

                        Price_List.Rows.Add("Latch Deadbolt Striker Price",
                                 LatchDeadboltStrikerPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                 Math.Round(LatchDeadboltStrikerPrice, 2).ToString("N", new CultureInfo("en-US")),
                                 "",
                                 "",
                                 "Fitting and Supplies");

                        Price_List.Rows.Add("Extension Price",
                                 ExtensionBasePrice.ToString("N", new CultureInfo("en-US")),
                                 Math.Round(ExtensionPrice, 2).ToString("N", new CultureInfo("en-US")),
                                 "",
                                 "",
                                 "Fitting and Supplies");

                        Price_List.Rows.Add("Roller Price",
                                 RollerBasePrice.ToString("N", new CultureInfo("en-US")),
                                 Math.Round(RollerPrice, 2).ToString("N", new CultureInfo("en-US")),
                                 "",
                                 "",
                                 "Fitting and Supplies");

                        Price_List.Rows.Add("Striker Price",
                                 StrikerLRPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                 Math.Round(StrikerLRPrice, 2).ToString("N", new CultureInfo("en-US")),
                                 "",
                                 "",
                                 "Fitting and Supplies");

                        Price_List.Rows.Add("Brush Seal Price",
                                BrushSealPricePerLinearMeter.ToString("N", new CultureInfo("en-US")),
                                Math.Round(BrushSealPrice, 2).ToString("N", new CultureInfo("en-US")),
                                "",
                                "",
                                "Fitting and Supplies");

                        Price_List.Rows.Add("Motorize Mechanism",
                                MotorizeMechPricePerPiece.ToString("N", new CultureInfo("en-US")),
                                Math.Round(MotorizePrice, 2).ToString("N", new CultureInfo("en-US")),
                                "",
                                "",
                                "Fitting and Supplies");

                        Price_List.Rows.Add("Remote for Motor",
                               MotorizeMechRemotePricePerPiece.ToString("N", new CultureInfo("en-US")),
                               Math.Round(RemoteForMotorizeMechPrice, 2).ToString("N", new CultureInfo("en-US")),
                               "",
                               "",
                               "Fitting and Supplies");

                        Price_List.Rows.Add("Total",
                                         "",
                                         Math.Round(FittingAndSuppliesCost, 2).ToString("N", new CultureInfo("en-US")),
                                         "",
                                         "",
                                         "Fitting and Supplies");
                        #endregion

                        #region Louver Material Cost

                        Price_List.Rows.Add("Louvre Frame Weather Strip Head Price",
                                        LouvreFrameWeatherStripHeadPricePerMeter.ToString("N", new CultureInfo("en-US")),
                                        Math.Round(LouvreFrameWeatherStripHeadPrice, 2).ToString("N", new CultureInfo("en-US")),
                                        "",
                                        "",
                                        "Louver Material Cost");

                        Price_List.Rows.Add("Louvre Frame Bottom Weather Strip Price",
                                         LouvreFrameBottomWeatherStripPricePerMeter.ToString("N", new CultureInfo("en-US")),
                                         Math.Round(LouvreFrameBottomWeatherStripPrice, 2).ToString("N", new CultureInfo("en-US")),
                                         "",
                                         "",
                                         "Louver Material Cost");

                        Price_List.Rows.Add("Plant on Weather Strip Head Price",
                                         PlantonWeatherStripHeadPricePerMeter.ToString("N", new CultureInfo("en-US")),
                                         Math.Round(PlantonWeatherStripHeadPrice, 2).ToString("N", new CultureInfo("en-US")),
                                         "",
                                         "",
                                         "Louver Material Cost");

                        Price_List.Rows.Add("Plant on Weather Strip Sill Price",
                                         PlantonWeatherStripSillPricePerMeter.ToString("N", new CultureInfo("en-US")),
                                         Math.Round(PlantonWeatherStripSillPrice, 2).ToString("N", new CultureInfo("en-US")),
                                         "",
                                         "",
                                         "Louver Material Cost");

                        Price_List.Rows.Add("Bubble Seal Price",
                                         BubbleSealPricePerMeter.ToString("N", new CultureInfo("en-US")),
                                         Math.Round(BubbleSealPrice, 2).ToString("N", new CultureInfo("en-US")),
                                         "",
                                         "",
                                         "Louver Material Cost");

                        Price_List.Rows.Add("Power Kit including Wires",
                                         "",
                                         PowerKitIncludingWiresPrice.ToString("N", new CultureInfo("en-US")),
                                         "",
                                         "",
                                         "Louver Material Cost");

                        Price_List.Rows.Add("Gallery Adaptor Price",
                                         GalleryAdaptorPricePerMeter.ToString("N", new CultureInfo("en-US")),
                                         Math.Round(GalleryAdaptorPrice, 2).ToString("N", new CultureInfo("en-US")),
                                         "",
                                         "",
                                         "Louver Material Cost");

                        Price_List.Rows.Add(bladeType + " Blade Price",
                                        "",
                                        Math.Round(GlassBladePrice, 2).ToString("N", new CultureInfo("en-US")),
                                        "",
                                        "",
                                        "Louver Material Cost");

                        Price_List.Rows.Add("Gallery Price",
                                        "",
                                        Math.Round(GalleryPrice, 2).ToString("N", new CultureInfo("en-US")),
                                        "",
                                        "",
                                        "Louver Material Cost");

                        Price_List.Rows.Add("Security Grill Price",
                                        Math.Round(SecurityKitCost, 2).ToString("N", new CultureInfo("en-US")),
                                        Math.Round(SecurityKitPrice, 2).ToString("N", new CultureInfo("en-US")),
                                        "",
                                        "",
                                        "Louver Material Cost");

                        Price_List.Rows.Add("Ringpull Lever Handle Price",
                                     Math.Round(RingpullLeverHandlePricePerPiece, 2).ToString("N", new CultureInfo("en-US")),
                                     Math.Round(RingpullLeverHandlePrice, 2).ToString("N", new CultureInfo("en-US")),
                                     "",
                                     "",
                                     "Louver Material Cost");

                        Price_List.Rows.Add("Total Price",
                                       "",
                                       Math.Round(LouverPrice, 2).ToString("N", new CultureInfo("en-US")),
                                       "",
                                       "",
                                       "Louver Material Cost");

                        #endregion

                        #region Mesh Cost

                        Price_List.Rows.Add("Security Mesh Price",
                                       SecurityMeshPricePerSquaremeter.ToString("N", new CultureInfo("en-US")),
                                       Math.Round(SecurityMeshPrice, 2).ToString("N", new CultureInfo("en-US")),
                                       "",
                                       "",
                                       "Mesh Cost");

                        Price_List.Rows.Add("Wire Mesh Price",
                                          WireMeshPricePerSquaremeter.ToString("N", new CultureInfo("en-US")),
                                          Math.Round(WireMeshPrice, 2).ToString("N", new CultureInfo("en-US")),
                                          "",
                                          "",
                                          "Mesh Cost");

                        Price_List.Rows.Add("Pet Mesh Price",
                                          PetMeshPricePerSquaremeter.ToString("N", new CultureInfo("en-US")),
                                          Math.Round(PetMeshPrice, 2).ToString("N", new CultureInfo("en-US")),
                                          "",
                                          "",
                                          "Mesh Cost");

                        Price_List.Rows.Add("Tuff Mesh Price",
                                          TuffMeshPricePerSquaremeter.ToString("N", new CultureInfo("en-US")),
                                          Math.Round(TuffMeshPrice, 2).ToString("N", new CultureInfo("en-US")),
                                          "",
                                          "",
                                          "Mesh Cost");

                        Price_List.Rows.Add("Phifer Mesh Price",
                                          PhiferMeshPricePerSquaremeter.ToString("N", new CultureInfo("en-US")),
                                          Math.Round(PhiferMeshPrice, 2).ToString("N", new CultureInfo("en-US")),
                                          "",
                                          "",
                                          "Mesh Cost");

                        Price_List.Rows.Add("Aluminum Frame Price",
                                          AluminumFramePricePerSquaremeter.ToString("N", new CultureInfo("en-US")),
                                          Math.Round(AluminumFramePrice, 2).ToString("N", new CultureInfo("en-US")),
                                          "",
                                          "",
                                          "Mesh Cost");


                        Price_List.Rows.Add("Total Price",
                                            "",
                                            Math.Round(MeshPrice, 2).ToString("N", new CultureInfo("en-US")),
                                            "",
                                            "",
                                            "Mesh Cost");

                        #endregion

                        var query = from r in Price_List.AsEnumerable()
                                    where r.Field<string>("Nett") != "0.00" &&
                                     r.Field<string>("Filter") == BOM_Filter.ToString()
                                    group r by new
                                    {
                                        Description = r.Field<string>("Description"),
                                        BasePrice = r.Field<string>("Base Price"),
                                        Nett = r.Field<string>("Nett"),
                                        Markup = r.Field<string>("Mark-up"),
                                        Subtotal = r.Field<string>("Subtotal"),
                                        Filter = r.Field<string>("Filter")

                                    } into g
                                    select new
                                    {
                                        Description = g.Key.Description,
                                        BasePrice = g.Key.BasePrice,
                                        Nett = g.Key.Nett,
                                        Markup = g.Key.Markup,
                                        Subtotal = g.Key.Subtotal,
                                        Filter = g.Key.Filter
                                    };

                        DataTable dt = new DataTable();
                        dt.Columns.Add(CreateColumn("Description", "Description", "System.String"));
                        dt.Columns.Add(CreateColumn("Base Price", "Base Price", "System.String"));
                        dt.Columns.Add(CreateColumn("Nett", "Nett", "System.String"));
                        dt.Columns.Add(CreateColumn("Mark-up", "Mark-up", "System.String"));
                        dt.Columns.Add(CreateColumn("Subtotal", "Subtotal", "System.String"));
                        dt.Columns.Add(CreateColumn("Filter", "Filter", "System.String"));

                        foreach (var element in query)
                        {
                            DataRow row = dt.NewRow();
                            row["Description"] = element.Description;
                            row["Base Price"] = element.BasePrice;
                            row["Nett"] = element.Nett;
                            row["Mark-up"] = element.Markup;
                            row["Subtotal"] = element.Subtotal;
                            row["Filter"] = element.Filter;

                            dt.Rows.Add(row);
                        }

                        Price_List = dt;
                    }
                    ClearingOperation();
                }

            }
            return Price_List;
        }


        public void ClearingOperation()
        {
            OneSideFoil_whiteBase = false;

            CostingPoints = 0;
            InstallationPoints = 0;
            TotaPrice = 0;
            LaborCost = 0;
            InstallationCost = 0;

            MaterialCost = 0;
            FramePrice = 0;
            FrameReinPrice = 0;
            SashPrice = 0;
            SashReinPrice = 0;
            DivPrice = 0;
            DivReinPrice = 0;
            claddingPrice = 0;
            DMPrice = 0;
            DMReinforcementPrice = 0;
            ExtensionProfile15mmPrice = 0;
            TubularPrice = 0;
            GbPrice = 0;
            GlassPrice = 0;
            FilmPrice = 0;
            SealantPrice = 0;
            PUFoamingPrice = 0;


            FittingAndSuppliesCost = 0;
            FSPrice = 0;
            RestrictorStayPrice = 0;
            CornerDrivePrice = 0;
            SnapInKeepPrice = 0;
            _35mmBacksetEspagWithCylinderPrice = 0;
            MiddleCLoserPrice = 0;
            StayBearingPrice = 0;
            StayBearingPinPrice = 0;
            CoverStayBearingPrice = 0;
            CoverCornerHingePrice = 0;
            CornerPivotRestPrice = 0;
            TopCornerHingePrice = 0;
            CorverCornerPivotRestPrice = 0;
            CorverCornerPivotRestVerticalPrice = 0;
            HandlePrice = 0;
            EspagPrice = 0;
            _2DHingePrice = 0;
            _3DHingePrice = 0;
            NTCenterHingePrice = 0;
            ShootBoltStrikerPrice = 0;
            ShootBoltReversePrice = 0;
            ShootBoltNonReversePrice = 0;
            StrikerPrice = 0;
            LatchDeadboltStrikerPrice = 0;
            ExtensionPrice = 0;
            BrushSealPrice = 0;
            StrikerLRPrice = 0;
            RollerPrice = 0;
            MotorizePrice = 0;
            RemoteForMotorizeMechPrice = 0;

            AncillaryProfileCost = 0;
            ThresholdPrice = 0;
            GbPrice = 0;
            GeorgianBarCost = 0;
            CoverProfileCost = 0;
            GlazingGasketPrice = 0;
            WeatherBarPrice = 0;
            WeatherBarFastenerPrice = 0;
            WaterSeepagePrice = 0;
            GuideTrackPrice = 0;
            AlumTrackPrice = 0;
            InterlockPrice = 0;
            ExtensionForInterlockPrice = 0;
            AluminumPullHandlePrice = 0;
            GlazingAdaptorPrice = 0;

            AccesorriesCost = 0;
            EndCapPrice = 0;
            MechJointPrice = 0;
            GBSpacerPrice = 0;
            PlasticWedgePrice = 0;
            SealingBlockPrice = 0;

            LouvreFrameWeatherStripHeadPrice = 0;
            LouvreFrameBottomWeatherStripPrice = 0;
            PlantonWeatherStripHeadPrice = 0;
            PlantonWeatherStripSillPrice = 0;
            PowerKitIncludingWiresPrice = 0;
            SecurityKitCost = 0;
            SecurityKitPrice = 0;
            GalleryAdaptorPrice = 0;
            BubbleSealPrice = 0;
            GlassBladePrice = 0;
            GalleryPrice = 0;
            LouverPrice = 0;
            RingpullLeverHandlePrice = 0;

            MeshCost = 0;
            MeshPrice = 0;
            SecurityMeshPrice = 0;
            WireMeshPrice = 0;
            PetMeshPrice = 0;
            TuffMeshPrice = 0;
            PhiferMeshPrice = 0;
            AluminumFramePrice = 0;
        }

        public QuotationModel(string quotation_ref_no,
                            List<IWindoorModel> lst_Windoor)
        {
            Quotation_ref_no = quotation_ref_no;
            Lst_Windoor = lst_Windoor;
        }
    }
}
