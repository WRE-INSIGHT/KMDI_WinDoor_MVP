using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ISetTopViewSlidingPanellingView : IViewCommon
    {
        event EventHandler SetTopViewSlidingPanellingViewLoadEventRaised;
        event PaintEventHandler pnlSlidingArrowPaintEventRaised;
        event PaintEventHandler pnlPanellingPaintEventRaised;
        event EventHandler btnAddLeftLineClickEventRaised;
        event EventHandler btnMinusLeftLineClickEventRaised;
        event EventHandler btnAddRightLineClickEventRaised;
        event EventHandler btnMinusRightLineClickEventRaised;

        PictureBox GetPbox();
        Panel GetPnlPannelling();
        void GetSetTopSlidingPanellingView();
    }
}