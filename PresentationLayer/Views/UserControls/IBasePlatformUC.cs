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
        int bp_Width { get; set; }
        int bp_Height { get; set; }
        Point bp_Location { get; set; }

        void InvalidateThis();
        void PerformLayoutThis();
        FlowLayoutPanel GetFlpMain();
    }
}
