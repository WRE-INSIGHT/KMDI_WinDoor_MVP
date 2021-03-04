using CommonComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Frame;

namespace PresentationLayer.Views.UserControls
{
    public interface IFrameUC: IViewCommon
    {
        bool thisVisible { get; }
        int frameID { get; set; }
        Padding thisPadding { get; set; }

        event EventHandler frameLoadEventRaised;
        event EventHandler deleteCmenuEventRaised;
        event EventHandler frameMouseEnterEventRaised;
        event EventHandler frameMouseLeaveEventRaised;
        event PaintEventHandler outerFramePaintEventRaised;
        event MouseEventHandler frameMouseClickEventRaised;
        event DragEventHandler frameDragDropEventRaised;
        void InvalidateThisControls();
        void InvalidateThis();
        void InvalidateThisParent();
        void InvalidateThisParentsParent();
        ContextMenuStrip GetFrameCmenu();
        void DeleteControl(UserControl control);
        void PerformLayoutThis();
        Bitmap GetImageThis();
    }
}
