using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IConcreteUC : IViewCommon
    {
        int Concrete_ID { get; set; }

        event EventHandler ConcreteUCLoadEventRaised;
        event EventHandler ConcreteUCMouseEnterEventRaised;
        event EventHandler ConcreteUCMouseLeaveEventRaised;
        event EventHandler deleteToolStripMenuItemClickEventRaised;
        event PaintEventHandler ConcreteUCPaintEventRaised;

        void InvalidateThis();
    }
}