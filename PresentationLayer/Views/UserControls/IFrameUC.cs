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
        event PaintEventHandler outerFramePaintEventRaised;
        event PaintEventHandler innerFramePaintEventRaised;

        int fWidth { get; set; }
        int fHeight { get; set; }

        void InvalidateThis();
        FrameUC GetNewFrame();
    }
}
