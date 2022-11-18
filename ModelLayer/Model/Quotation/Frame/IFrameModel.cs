using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation.Frame
{
    public interface IFrameModel
    {
        int Frame_BasicDeduction { get; }

        int Frame_Height { get; set; }
        int Frame_HeightToBind { get; set; }
        int FrameImageRenderer_Height { get; set; }
        int Frame_ID { get; set; }
        string Frame_Name { get; set; }
        FrameModel.Frame_Padding Frame_Type { get; set; }
        int Frame_Width { get; set; }
        int Frame_WidthToBind { get; set; }
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
        BottomFrameTypes Frame_BotFrameArtNo { get; set; }
        bool Frame_BotFrameEnable { get; set; }
        bool Frame_BotFrameVisible { get; set; }

        UserControl Frame_UC { get; set; }
        UserControl Frame_PropertiesUC { get; set; }
        int[] Arr_padding_norm { get; }
        int[] Arr_padding_withmpnl { get; }

        void SetDeductFramePadding(bool mode, bool is_mpanel = true);
        void SetZoom();
        void Set_DimensionsToBind_using_FrameZoom();
        void Set_ImagerDimensions_using_ImagerZoom();
        void Set_FramePadding();
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

        FrameProfileForPremi_ArticleNo Frame_ArtNoForPremi { get; set; }
        FrameReinfForPremi_ArticleNo Frame_ReinfForPremiArtNo { get; set; }

        bool Frame_If_InwardMotorizedCasement { get; set; }
        MilledFrame_ArticleNo Frame_MilledArtNo { get; set; }
        MilledFrameReinf_ArticleNo Frame_MilledReinfArtNo { get; set; }

        int Frame_SlidingRailsQty { get; set; }
        bool Frame_SlidingRailsQtyVisibility { get; set; }
        FrameConnectionType Frame_ConnectionType { get; set; }
        bool Frame_ConnectionTypeVisibility { get; set; }
        void SetExplosionValues_Frame();
        void AdjustPropertyPanelHeight(string objtype, string mode);
        void DeductPropertyPanelHeight(int propertyHeight);
        void Insert_frameInfo_MaterialList(DataTable tbl_explosion);
        void Insert_frameInfoForPremi_MaterialList(DataTable tbl_explosion);
        void Insert_MilledFrameInfo_MaterialList(DataTable tbl_explosion);
        void Insert_BottomFrame_MaterialList(DataTable tbl_explosion);

        int Add_framePerimeter_screws4fab();
        int Add_MilledFrameWidth_screws4fab();
        void SetfrmDimensionZoom();
        #endregion
    }
}