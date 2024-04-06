using CommonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ITopViewPanelViewer :IViewCommon
    {
        event EventHandler TopViewPanelViewLoadEventRaised;
        event EventHandler TopViewPanelViewButtonClickEventRaised;
        event EventHandler TopViewPanelViewSizeChangedEventRaised;
        event PaintEventHandler pnlSlidingArrowPaintEventRaised;
        event PaintEventHandler pboxTopViewPaintEventRaised;
        event MouseEventHandler TopViewSlidingViewMouseUpEventRaised;


        string topviewpanel_title { get; set; }
        void showTopViewPanelViewer();
        void CloseTopViewPanelViewer();
        void TopView_BringtoFront();
        Form GetTopViewPanelViewer();
        PictureBox GetTopViewPictureBox();
        PictureBox GetPnlPanelViewer();
        Panel GetPnlTopViewer();
    }
}
