using ModelLayer.Model.Quotation.Divider;
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
        int MPanel_Index_Inside_MPanel { get; set; }
        int MPanelProp_Height { get; set; }
        string MPanel_Placement { get; set; }
        IMultiPanelModel MPanel_ParentModel { get; set; }

        Control MPanel_Parent { get; set; }
        UserControl MPanel_FrameGroup { get; set; }
        Padding MPanel_Margin { get; set; }
        List<IPanelModel> MPanelLst_Panel { get; set; }
        List<IDividerModel> MPanelLst_Divider { get; set; }
        List<IMultiPanelModel> MPanelLst_MultiPanel { get; set; }
        List<Control> MPanelLst_Objects { get; set; }

        int GetNextIndex();
        int GetCount_MPanelLst_Object();
        void Reload_PanelMargin();
        void Reload_MultiPanelMargin();
        void AddControl_MPanelLstObjects(Control control, string frameType);
        void DeleteControl_MPanelLstObjects(Control control, string frameType, string placement = "");
        void Fit_MyControls();
        void Object_Indexer();
    }
}