using ModelLayer.Model.Quotation.Frame;
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
            _7502 = 0,
        }

        public enum FrameReinf_ArticleNo
        {
            _R676 = 0,
        }

        public enum Divider_ArticleNo
        {
            _7536 = 0,
            _7538 = 1,
            _6502 = 2,
        }

        public enum DividerReinf_ArticleNo
        {
            _R677 = 0,
            _R686 = 1
        }

        public enum Glass_ArticleNo
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
            Material_List.Columns.Add(CreateColumn("Description", "Description", "System.Text"));
            Material_List.Columns.Add(CreateColumn("Qty", "Qty", "System.Int32"));
            Material_List.Columns.Add(CreateColumn("Unit", "Unit", "System.Text"));
            Material_List.Columns.Add(CreateColumn("Size", "Size", "System.Int32"));

            foreach (IWindoorModel item in Lst_Windoor.Where(wndr => wndr.WD_visibility == true))
            {
                foreach (IFrameModel frame in item.GetAllVisibleFrames())
                {
                    Material_List.Rows.Add("Frame Height " + frame.Frame_ArtNo.ToString(),
                                           2, "pcs",
                                           frame.Frame_ExplosionWidth);
                    Material_List.Rows.Add("Frame Width " + frame.Frame_ArtNo.ToString(),
                                           2, "pcs",
                                           frame.Frame_ExplosionHeight);
                    Material_List.Rows.Add("Frame Reinf Width " + frame.Frame_ReinfArtNo.ToString(),
                                           2, "pcs",
                                           frame.Frame_ReinfWidth);
                    Material_List.Rows.Add("Frame Reinf Height " + frame.Frame_ReinfArtNo.ToString(),
                                           2, "pcs",
                                           frame.Frame_ReinfHeight);

                    foreach (IPanelModel pnl in frame.GetVisiblePanels())
                    {
                        Material_List.Rows.Add("Glazing Bead Width " + pnl.PanelGlass_ArtNo.ToString(), 
                                               2, "pcs",
                                               pnl.Panel_GlazingBeadWidth);
                        Material_List.Rows.Add("Glazing Bead Height " + pnl.PanelGlass_ArtNo.ToString(),
                                               2, "pcs",
                                               pnl.Panel_GlazingBeadHeight);
                        Material_List.Rows.Add("Glass Width (" + pnl.Panel_GlassThickness + ")",
                                               1, "pcs",
                                               pnl.Panel_GlassWidth);
                        Material_List.Rows.Add("Glass Height (" + pnl.Panel_GlassThickness + ")",
                                               1, "pcs",
                                               pnl.Panel_GlassHeight);
                        Material_List.Rows.Add("Glazing Spacer (KBC70)",
                                               1, "pcs");
                    }

                    Material_List.Rows.Add("PU Foaming",
                                           2, "pcs",
                                           frame.Frame_ReinfHeight);
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
