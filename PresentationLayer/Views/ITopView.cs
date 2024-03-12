using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ITopView
    {
        event EventHandler TopViewSlidingViewLoadEventRaised;
        event EventHandler FormTimerTickEventRaised;
        event EventHandler TopViewSlidingViewMouseHoverEventRaised;
        event EventHandler TopViewSlidingViewButtonClickEventRaised;
        event MouseEventHandler TopViewSlidingViewMouseMoveEventRaised;
        event MouseEventHandler TopViewSlidingViewMouseUpEventRaised;
        event MouseEventHandler TopViewSlidingViewMouseDownEventRaised;
        event MouseEventHandler TopViewSlidingViewMouseClickEventRaised;
       
        event PaintEventHandler TopViewPaintEventRaised;


        PictureBox GetPbox();
        Label GetLabelTracks();
        Label GetLabelPanel();
        void CloseTopView();
        void ShowTopView();
        Form GetThis();
        ContextMenuStrip GetcmenuTopView();
    }
}
