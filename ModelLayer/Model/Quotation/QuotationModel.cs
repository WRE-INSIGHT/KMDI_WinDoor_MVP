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
            _7536 = 0,
            _7538 = 1//,
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

                    if (frame.GetVisibleMultiPanels().Count() > 0 && frame.GetVisiblePanels().Count() == 0)
                    {
                        foreach (IMultiPanelModel mpnl in frame.GetVisibleMultiPanels())
                        {
                            foreach (IDividerModel div in mpnl.GetVisibleDividers())
                            {
                                string htORwd = "";
                                if (div.Div_Type == DividerModel.DividerType.Mullion)
                                {
                                    htORwd = "Height";
                                }
                                else if (div.Div_Type == DividerModel.DividerType.Transom)
                                {
                                    htORwd = "Width";
                                }
                                Material_List.Rows.Add(div.Div_Type.ToString() + " " + htORwd + " " + div.Div_ArtNo.ToString(),
                                                       1, "pc(s)",
                                                       div.Div_ExplosionHeight.ToString());
                                Material_List.Rows.Add(div.Div_Type.ToString() + " " + htORwd + " " + div.Div_ReinfArtNo.ToString(),
                                                       1, "pc(s)",
                                                       div.Div_ReinfHeight.ToString());
                            }
                            foreach (IPanelModel pnl in mpnl.GetVisiblePanels())
                            {

                            }
                        }

                    }
                    else if (frame.GetVisiblePanels().Count() > 0 && frame.GetVisibleMultiPanels().Count() == 0)
                    {
                        foreach (IPanelModel pnl in frame.GetVisiblePanels())
                        {
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
                    }

                    Material_List.Rows.Add("PU Foaming",
                                           frame.Frame_PUFoamingQty, "can", "");
                    Material_List.Rows.Add("Sealant-WH",
                                           frame.Frame_SealantWHQty, "pcs", "");
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
