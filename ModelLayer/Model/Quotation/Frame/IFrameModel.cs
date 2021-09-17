using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.QuotationModel;

namespace ModelLayer.Model.Quotation.Frame
{
    public interface IFrameModel
    {
        int Frame_BasicDeduction { get; }

        int Frame_Height { get; set; }
        int FrameImageRenderer_Height { get; set; }
        int Frame_ID { get; set; }
        string Frame_Name { get; set; }
        FrameModel.Frame_Padding Frame_Type { get; set; }
        int Frame_Width { get; set; }
        int FrameImageRenderer_Width { get; set; }
        bool Frame_Visible { get; set; }
        int FrameProp_Height { get; set; }
        float FrameImageRenderer_Zoom { get; set; }
        Padding Frame_Padding_int { get; set; }
        Padding FrameImageRenderer_Padding_int { get; set; }
        List<IPanelModel> Lst_Panel { get; set; }
        List<IMultiPanelModel> Lst_MultiPanel { get; set; }
        List<IDividerModel> Lst_Divider { get; set; }
        float Frame_Zoom { get; set; }
        int[] Arr_padding_norm { get; }
        int[] Arr_padding_withmpnl { get; }


        void SetDeductFramePadding(bool mode);
        int Frame_Deduction { get; }
        IWindoorModel Frame_WindoorModel { get; set; }

        #region Explosion

        FrameProfile_ArticleNo Frame_ArtNo { get; set; }
        int Frame_ExplosionWidth { get; set; }
        int Frame_ExplosionHeight { get; set; }

        FrameReinf_ArticleNo Frame_ReinfArtNo { get; set; }
        int Frame_ReinfWidth { get; set; }
        int Frame_ReinfHeight { get; set; }
        bool Frame_CmenuDeleteVisibility { get; set; }

        void SetExplosionValues_Frame();
        void AdjustPropertyPanelHeight(string objtype, string mode);

        #endregion
    }
}