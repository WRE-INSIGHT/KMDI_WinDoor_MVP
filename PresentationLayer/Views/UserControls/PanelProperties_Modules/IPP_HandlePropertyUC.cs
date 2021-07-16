using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_HandlePropertyUC : IViewCommon
    {
        event EventHandler cmbHandleTypeSelectedValueEventRaised;
        event EventHandler PPHandlePropertyLoadEventRaised;

        FlowLayoutPanel GetHandleTypeFLP();
    }
}