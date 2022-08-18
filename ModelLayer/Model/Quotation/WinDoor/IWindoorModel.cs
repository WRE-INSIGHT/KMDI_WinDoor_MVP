using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Frame;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation.WinDoor
{
    public interface IWindoorModel
    {
        float[] Arr_ZoomPercentage { get; }
        string WD_description { get; set; }
        string WD_profile { get; set; }
        decimal WD_discount { get; set; }
        int WD_height { get; set; }
        int WD_height_4basePlatform { get; set; }
        int WD_height_4basePlatform_forImageRenderer { get; set; }
        int WD_id { get; set; }
        string WD_name { get; set; }
        bool WD_orientation { get; set; }
        int WD_price { get; set; }
        int WD_quantity { get; set; }
        bool WD_visibility { get; set; }
        int WD_width { get; set; }
        int WD_width_4basePlatform { get; set; }
        int WD_width_4basePlatform_forImageRenderer { get; set; }
        float WD_zoom { get; set; }
        float WD_zoom_forImageRenderer { get; }
        int WD_PropertiesScroll { get; set; }

        Image WD_image { get; set; }
        Image WD_flpImage { get; set; }
        Image WD_SlidingTopViewImage { get; set; }
        bool WD_SlidingTopViewVisibility { get; set; }
        List<IFrameModel> lst_frame { get; set; }
        List<IConcreteModel> lst_concrete { get; set; }
        int frameIDCounter { get; set; }
        int concreteIDCounter { get; set; }
        int panelIDCounter { get; set; }
        int mpanelIDCounter { get; set; }
        int divIDCounter { get; set; }
        int PanelGlassID_Counter { get; set; }

        Base_Color WD_BaseColor { get; set; }
        Foil_Color WD_InsideColor { get; set; }
        Foil_Color WD_OutsideColor { get; set; }
        decimal WD_PlasticCover { get; set; }
        bool WD_CmenuDeleteVisibility { get; set; }
        bool WD_Selected { get; set; }
        Dictionary<int, decimal> Dictionary_ht_redArrowLines { get; set; }
        Dictionary<int, decimal> Dictionary_wd_redArrowLines { get; set; }

        float GetZoom_forRendering();
        void SetImageRenderingZoom();
        void SetZoom();
        void SetPanelGlassID();
        void SetMiddleCloser_onPanel();
        void SetDimensions_basePlatform();

        //custom arrow head

        //bool Pnl_ArrowHeightVisibility { get; set; }
        //bool Pnl_ArrowWidthVisibility { get; set; }
        int Lbl_ArrowHtCount { get; set; }
        int Lbl_ArrowWdCount { get; set; }
        Dictionary<int, int> Div_ArrowWdLengthList { get; set; }
        int Div_ArrowCount { get; set; }
        bool WD_customArrowToggle { get; set; }
        decimal WD_CostingPoints { get; set; }
        int WD_pboxImagerHeight { get; set; }
    }
}