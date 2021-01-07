using CommonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IFrameUC: IViewCommon
    {
        bool thisVisible { get; }
        int frameID { get; set; }
        event EventHandler frameLoadEventRaised;
        event EventHandler deleteCmenuEventRaised;
        event EventHandler frameMouseEnterEventRaised;
        event EventHandler frameMouseLeaveEventRaised;
        event EventHandler panelInnerMouseEnterEventRaised;
        event EventHandler panelInnerMouseLeaveEventRaised;
        event PaintEventHandler outerFramePaintEventRaised;
        event PaintEventHandler innerFramePaintEventRaised;
        event MouseEventHandler frameMouseClickEventRaised;
        event DragEventHandler panelInnerDragDropEventRaised;
        void InvalidateThis();
        void InvalidateThisParent();
        void InvalidateThisParentsParent();
        void InvalidatePanelInner();
        ContextMenuStrip GetFrameCmenu();
        Panel GetInnerPanel();
    }
}
