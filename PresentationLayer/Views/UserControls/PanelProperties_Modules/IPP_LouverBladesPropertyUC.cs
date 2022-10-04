using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_LouverBladesPropertyUC : IViewCommon
    {
        NumericUpDown GetNudLouverBlades();

        event EventHandler PPLouverBladesPropertyUCLoadEventRaised;
    }
}