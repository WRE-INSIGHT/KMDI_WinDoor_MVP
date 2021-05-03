using ModelLayer.Model.Quotation.Frame;
using System.Collections.Generic;
using System.Drawing;

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
        Image WD_image { get; set; }
        List<IFrameModel> lst_frame { get; set; }
        IEnumerable<IFrameModel> GetAllVisibleFrames();
        int GetFrameCount();
        int GetPanelCount();
        int GetMultiPanelCount();
        int GetDividerCount();
        float GetZoom_forRendering();
        void SetImageRenderingZoom();
    }
}