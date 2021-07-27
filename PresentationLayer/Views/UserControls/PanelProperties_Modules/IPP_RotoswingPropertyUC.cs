using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_RotoswingPropertyUC : IViewCommon
    {
        event EventHandler PPRotoswingPropertyLoadEventRaised;
        event EventHandler cmbEspagnoletteSelectedValueEventRaised;
        event EventHandler cmbMiddleCloserSelectedValueEventRaised;
        event EventHandler cmbRotoswingNoSelectedValueEventRaised;

        FlowLayoutPanel GetRotoswingOptionFLP();
    }
}