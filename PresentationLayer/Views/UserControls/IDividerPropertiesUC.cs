using System;
using ModelLayer.Model.Quotation.Divider;
using CommonComponents;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IDividerPropertiesUC : IViewCommon
    {
        int Div_ID { get; set; }
        DividerModel.DividerType Divider_Type { get;  set; }

        event EventHandler PanelPropertiesLoadEventRaised;
        event EventHandler CmbdivArtNoSelectedValueChangedEventRaised;

        Panel GetDividerPropertiesBodyPNL();
    }
}