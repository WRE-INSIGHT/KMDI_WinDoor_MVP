using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public interface IFP_SlidingRailsPropertyUC : IViewCommon
    {
        NumericUpDown GetNudRailsQty();

        event EventHandler FPSlidingRailsPropertyUCLoadEventRaised;
        event EventHandler nudRailsQtyValueChangedEventRaised;
    }
}