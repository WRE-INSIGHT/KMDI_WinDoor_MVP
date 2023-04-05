using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_LandCoverPropertyUC : IViewCommon
    {
        event EventHandler SPLandCoverPropertyUCLoadEventRaised;
        event EventHandler nudLandCoverValueChangedEventRaised;
        event EventHandler nudLandCoverQtyValueChangedEventRaised;
        NumericUpDown GetNudLandCover();
        NumericUpDown GetNudLandCoverQty();
       
    }
}