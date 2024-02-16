using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_AliminumTrackPropertyUC : IViewCommon
    {
        NumericUpDown GetNudAluminumTrackQty();
        event EventHandler PPAliminumTrackPropertyUCLoadEventRaised;
        event EventHandler AluminumTrackQtyValueChangedEventRaised;
        event EventHandler AluminumTrackQtyValueKeyUpEventRaised;
    }
}