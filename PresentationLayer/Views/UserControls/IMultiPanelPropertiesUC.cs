using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IMultiPanelPropertiesUC : IViewCommon
    {
        int MPanelID { get; set; }

        event EventHandler MultiPanelPropertiesLoadEventRaised; 
        //event EventHandler NumHeightValueChangedEventRaised;
        //event EventHandler NumWidthValueChangedEventRaised;

        void BringToFrontThis();
        FlowLayoutPanel GetMultiPanelPropertiesFLP();
    }
}