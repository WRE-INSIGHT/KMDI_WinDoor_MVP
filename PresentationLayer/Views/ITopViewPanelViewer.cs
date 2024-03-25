using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ITopViewPanelViewer
    {
        event EventHandler TopViewPanelViewLoadEventRaised;
        event PaintEventHandler pnlSlidingArrowPaintEventRaised;
        void showTopViewPanelViewer();
        Form GetTopViewPanelViewer();
        PictureBox GetTopViewPictureBox();
        Panel GetPnlTopViewer();
    }
}
