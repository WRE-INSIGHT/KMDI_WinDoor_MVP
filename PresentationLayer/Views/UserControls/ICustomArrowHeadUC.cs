using System;

namespace PresentationLayer.Views.UserControls
{
    public interface ICustomArrowHeadUC
    {
        int ArrowWidthId { get; set; }
        int Arrow_Size { get; set; }

        event EventHandler NudArrowSizeValueChangeEventRaised;
        event EventHandler BtnDeleteArrowHeadClickEventRaised;
    }
}
