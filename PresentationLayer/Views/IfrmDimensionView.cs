using System;

namespace PresentationLayer.Views
{
    public interface IfrmDimensionView
    {
        event EventHandler frmDimensionLoadEventRaised;
        event EventHandler btnOKClickedEventRaised;
        event EventHandler btnCancelClickedEventRaised;
        event EventHandler cmbSystemOptionSelectedValueChangedEventRaised;
        //event EventHandler radbtnCheckChangedEventRaised;

        int InumWidth { get; set; }
        int InumHeight { get; set; }
        int dimension_height { get; set; }
        int thisHeight { set; }
        string SelectedSystem { get; set; }
        //bool c70rRadBtn_CheckState { set; }
        //bool premiLineRadBtn_CheckState { set; }
        bool ThisVisibility { get; set; }
        void ShowfrmDimension();
        void ClosefrmDimension();
    }
}
