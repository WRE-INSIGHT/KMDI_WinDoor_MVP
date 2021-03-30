using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Dividers.Imagers
{
    public interface ITransomImagerUC : IViewCommon
    {
        int Div_ID { get; set; }

        event PaintEventHandler transomUCPaintEventRaised;
        event EventHandler transomUCVisibleChangedEventRaised;
    }
}