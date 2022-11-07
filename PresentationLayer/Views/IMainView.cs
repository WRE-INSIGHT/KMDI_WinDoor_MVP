using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IMainView
    {
        event EventHandler MainViewLoadEventRaised;
        event EventHandler MainViewClosingEventRaised;
        event EventHandler OpenToolStripButtonClickEventRaised;
        event EventHandler NewFrameButtonClickEventRaised;
        event EventHandler SortItemButtonClickEventRaised;
        event EventHandler NewQuotationMenuItemClickEventRaised;
        event EventHandler PanelMainSizeChangedEventRaised;
        event EventHandler CreateNewItemClickEventRaised;
        event EventHandler LabelSizeClickEventRaised;
        event EventHandler ButtonPlusZoomClickEventRaised;
        event EventHandler ButtonMinusZoomClickEventRaised;
        event EventHandler DeleteToolStripButtonClickEventRaised;
        event EventHandler DuplicateToolStripButtonClickEventRaised;
        event EventHandler ViewImagerToolStripButtonClickEventRaised;
        event EventHandler ListOfMaterialsToolStripMenuItemClickEventRaised;
        event EventHandler CreateNewGlassClickEventRaised;
        event EventHandler ChangeItemColorClickEventRaised;
        event EventHandler glassTypeColorSpacerToolStripMenuItemClickEventRaised;
        event EventHandler glassBalancingToolStripMenuItemClickEventRaised;
        event EventHandler customArrowHeadToolStripMenuItemClickEventRaised;
        event EventHandler assignProjectsToolStripMenuItemClickEventRaised;
        event EventHandler addProjectsToolStripMenuItemClickEventRaised;
        event EventHandler selectProjectToolStripMenuItemClickEventRaised;
        event EventHandler existingItemToolStripMenuItemClickEventRaised;
        event EventHandler NewConcreteButtonClickEventRaised;
        event EventHandler refreshToolStripButtonClickEventRaised;
        event EventHandler CostingItemsToolStripMenuItemClickRaiseEvent;
        event EventHandler saveAsToolStripMenuItemClickEventRaised;
        event EventHandler saveToolStripButtonClickEventRaised;
        event EventHandler slidingTopViewToolStripMenuItemClickRaiseEvent;
        event DragEventHandler ItemsDragEventRaiseEvent;
        event EventHandler SetGlassToolStripMenuItemClickRaiseEvent;
        event EventHandler screenToolStripMenuItemClickEventRaised;
        event EventHandler factorToolStripMenuItemClickEventRaised;
        event EventHandler billOfMaterialToolStripMenuItemClickEventRaised;
        string Nickname { set; }
        string mainview_title { get; set; }
        float Zoom { get; set; }
        bool ItemToolStripEnabled { get; set; }
        bool CreateNewWindoorBtnEnabled { get; set; }
        int PropertiesScroll { get; set; }
        void ShowMainView();
        void ThisBinding(Dictionary<string, Binding> binding);
        void RemoveBinding();
        void RemoveBinding(Control ctrl);
        Panel GetPanelMain();
        Panel GetPanelItems();
        Panel GetPanelPropertiesBody();
        Panel GetPanelBot();
        Panel GetPanelRight();
        Panel GetPanelControlSub();
        Label GetLblSize();
        MenuStrip GetMNSMainMenu();
        ToolStrip GetTSMain();
        ToolStripLabel GetLblSelectedDivider();
        ToolStripLabel GetToolStripLabelSync();
        ToolStripLabel GetToolStripLabelLoading();
        ToolStripButton GetToolStripButtonSave();
        ToolStripMenuItem Glass_Single { get; }
        ToolStripMenuItem Glass_DoubleInsulated { get; }
        ToolStripMenuItem Glass_DoubleLaminated { get; }
        ToolStripMenuItem Glass_TripleInsulated { get; }
        ToolStripMenuItem Glass_TripleLaminated { get; }
        ToolStripMenuItem Glass_Type { get; }
        ToolStripMenuItem Spacer { get; }
        ToolStripMenuItem Color { get; }
        Form GetThis();
        SaveFileDialog GetSaveFileDialog();
        OpenFileDialog GetOpenFileDialog();
        ToolStripProgressBar GetTsProgressLoading();
        SplitContainer GetSCMain();
        void FocusOnMainForm();
        void Set_AssignProject_Visibility(bool visibility);
        void SetActiveControl(Control control);


    }
}