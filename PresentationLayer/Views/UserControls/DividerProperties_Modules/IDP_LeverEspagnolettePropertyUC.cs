using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.DividerProperties_Modules
{
    public interface IDP_LeverEspagnolettePropertyUC : IViewCommon
    {
        event EventHandler cmbLeverEspagSelectedValueChangedEventRaised;
        event EventHandler DPLeverEspagnolettePropertyUCLoadEventRaised;

        void SashPropBinding(Dictionary<string, Binding> sashBinding);
    }
}