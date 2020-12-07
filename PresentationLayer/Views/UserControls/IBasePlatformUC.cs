using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IBasePlatformUC
    {
        event PaintEventHandler basePlatformPaintEventRaised;
        event PaintEventHandler flpFrameDragDropPaintEventRaised;
        event EventHandler basePlatformSizeChangedEventRaised;
        event EventHandler basePlatformLoadEventRaised;
        int bp_Width { get; }
        int bp_Height { get; }
        //Point bp_Location { get; set; }
        bool thisVisibility { get; }
        void InvalidateThis();
        void PerformLayoutThis();
        void ThisBinding(Dictionary<string, Binding> binding);
        void ClearBinding(Control ctrl);
        FlowLayoutPanel GetFlpMain();
    }
}
