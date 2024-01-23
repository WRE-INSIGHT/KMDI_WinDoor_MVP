using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IGeorgianBarCustomizeDesignView
    {
        void ShowView();

        event EventHandler GeorgianBarCustomizeDesignViewLoadEventRaised;
        event EventHandler FormTimerTickEventRaised;
        event PaintEventHandler GeorgianBarCustomizeDesignViewPaintEventRaised;
        event MouseEventHandler GeorgianBarCustomizeDesignViewMouseDownEventRaised;
        event MouseEventHandler GeorgianBarCustomizeDesignViewMouseMoveEventRaised;
        event MouseEventHandler GeorgianBarCustomizeDesignViewMouseUpEventRaised;
        event MouseEventHandler GeorgianBarCustomizeDesignViewMouseClickEventRaised;

        Form GetFormView();

    }
}