using System.Windows.Forms;

namespace ModelLayer.Model.Quotation.Panel
{
    public interface IPanelModel
    {
        string Panel_ChkText { get; set; }
        DockStyle Panel_Dock { get; set; }
        Control Panel_Parent { get; set; }
        UserControl Panel_MultiPanelGroup { get; set; }
        UserControl Panel_FrameGroup { get; set; }
        UserControl Panel_FramePropertiesGroup { get; set; }
        int Panel_Height { get; set; }
        int PanelImageRenderer_Height { get; set; }
        int Panel_ID { get; set; }
        string Panel_Name { get; set; }
        bool Panel_Orient { get; set; }
        string Panel_Type { get; set; }
        int Panel_Width { get; set; }
        int PanelImageRenderer_Width { get; set; }
        bool Panel_Visibility { get; set; }
        float PanelImageRenderer_Zoom { get; set; }
        int Panel_Index_Inside_MPanel { get; set; }
        string Panel_Placement { get; set; }
        Padding Panel_Margin { get; set; }
    }
}