using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IFrameUC
    {
        event EventHandler frameLoadEventRaised;
        event EventHandler deleteCmenuEventRaised;
        event EventHandler frameMouseEnterEventRaised;
        event EventHandler frameMouseLeaveEventRaised;
        event EventHandler panelInnerMouseEnterEventRaised;
        event EventHandler panelInnerMouseLeaveEventRaised;
        event PaintEventHandler outerFramePaintEventRaised;
        event PaintEventHandler innerFramePaintEventRaised;
        event MouseEventHandler frameMouseClickEventRaised;
        //int fWidth { get; set; }
        //int fHeight { get; set; }
        //int fPadding { set; }
        void InvalidateThis();
        void InvalidateThisParent();
        void InvalidateThisParentsParent();
        void InvalidatePanelInner();
        void ThisBinding(Dictionary<string, Binding> binding);
        ContextMenuStrip GetFrameCmenu();
    }
}
