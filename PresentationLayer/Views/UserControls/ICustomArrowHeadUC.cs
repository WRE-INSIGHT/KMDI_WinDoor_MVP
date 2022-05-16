using System;

namespace PresentationLayer.Views.UserControls
{
    public interface ICustomArrowHeadUC
    {
        int ArrowId { get; set; }
        decimal Arrow_Size { get; set; }
        int ArrowCountWD { get; set; }
        int ArrowCountHT { get; set; }
        void SetNudMaxValue();
        string ArrowHeadName { get; set; }


        event EventHandler NudArrowSizeValueChangeEventRaised;
        event EventHandler BtnDeleteArrowHeadClickEventRaised;
    }
}
