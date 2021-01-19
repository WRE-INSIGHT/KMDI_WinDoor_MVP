using ModelLayer.Model.Quotation.Panel;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ModelLayer.Model.Quotation.MultiPanel
{
    public interface IMultiPanelModel
    {
        int MPanel_ID { get; set; }
        string MPanel_Name { get; set; }
        string MPanel_Type { get; set; }
        DockStyle MPanel_Dock { get; set; }
        int MPanel_Width { get; set; }
        int MPanel_Height { get; set; }
        FlowDirection MPanel_FlowDirection { get; set; }
        bool MPanel_Visibility { get; set; }
        int MPanel_Divisions { get; set; }

        Control MPanel_Parent { get; set; }
        UserControl MPanel_FrameGroup { get; set; }
        List<IPanelModel> MPanelLst_Panel { get; set; }
        int GetVisiblePanel();
    }
}