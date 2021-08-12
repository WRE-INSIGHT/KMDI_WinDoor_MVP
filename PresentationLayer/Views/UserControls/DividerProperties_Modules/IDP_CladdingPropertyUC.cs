using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.DividerProperties_Modules
{
    public interface IDP_CladdingPropertyUC
    {
        int Cladding_Size { get; set; }
        int Cladding_ID { get; set; }
        string Divider_Type { get; set; }
        event EventHandler DPCladdingPropertyUCLoadEventRaised;
        event EventHandler numCladdingSizeValueChangedEventRaised;
        event EventHandler btnDeleteCladdingClickedEventRaised;
    }
}