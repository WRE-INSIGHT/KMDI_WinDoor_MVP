using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
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
        int MPanel_HeightToBind { get; set; }
        FlowDirection MPanel_FlowDirection { get; set; }
        bool MPanel_Visibility { get; set; }
        int MPanel_Divisions { get; set; }
        int MPanel_Index_Inside_MPanel { get; set; }
        int MPanelProp_Height { get; set; }
        string MPanel_Placement { get; set; }
        IMultiPanelModel MPanel_ParentModel { get; set; }
        bool MPanel_DividerEnabled { get; set; }
        float MPanelImageRenderer_Zoom { get; set; }
        Control MPanel_Parent { get; set; }
        UserControl MPanel_FrameGroup { get; set; }
        IFrameModel MPanel_FrameModelParent { get; set; }
        Padding MPanel_Margin { get; set; }
        Padding MPanelImageRenderer_Margin { get; set; }
        List<IPanelModel> MPanelLst_Panel { get; set; }
        List<IDividerModel> MPanelLst_Divider { get; set; }
        List<IMultiPanelModel> MPanelLst_MultiPanel { get; set; }
        List<Control> MPanelLst_Objects { get; set; }
        float MPanel_Zoom { get; set; }
        int MPanel_WidthToBind { get; set; }
        int MPanel_AddPixel { get; }
        int MPanel_DisplayWidth { get; set; }
        int MPanel_DisplayHeight { get; set; }

        int GetNextIndex();
        int GetCount_MPanelLst_Object();
        void Reload_PanelMargin();
        void Reload_MultiPanelMargin();
        void AddControl_MPanelLstObjects(Control control, 
                                         string frameType,
                                         bool if_auto_added = false);
        void DeleteControl_MPanelLstObjects(Control control, string frameType, string placement = "");
        void Fit_MyControls_ToBindDimensions();
        void Fit_MyControls_Dimensions();
        void Object_Indexer();
        IEnumerable<IDividerModel> GetVisibleDividers();
        IEnumerable<IPanelModel> GetVisiblePanels();
        IEnumerable<Control> GetVisibleObjects();
        IEnumerable<IMultiPanelModel> GetVisibleMultiPanels();
    }
}