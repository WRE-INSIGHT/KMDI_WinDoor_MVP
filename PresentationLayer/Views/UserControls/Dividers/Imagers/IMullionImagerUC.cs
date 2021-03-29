using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Dividers.Imagers
{
    public interface IMullionImagerUC : IViewCommon
    {
        int Div_ID { get; set; }

        event PaintEventHandler mullionUCPaintEventRaised;
        event EventHandler mullionVisibleChangedEventRaised;
    }
}