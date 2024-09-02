using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IfrmDimensionView
    {
        event EventHandler frmDimensionLoadEventRaised;
        event EventHandler btnOKClickedEventRaised;
        event EventHandler btnCancelClickedEventRaised;
        event EventHandler cmbSystemOptionSelectedValueChangedEventRaised;
        event EventHandler cmbBaseColorOptionSelectedValueChangedEventRaised;
        event EventHandler numWidthEnterEventRaised;
        event EventHandler numHeightEnterEventRaised;
        event EventHandler nudFrameQtyValueChangedEventRaised;
        event EventHandler cmbAlutekSystemTypeSelectedValueChangedEventRaised;

        int InumWidth { get; set; }
        int InumHeight { get; set; }
        int dimension_height { get; set; }
        int thisHeight { set; }
        string SelectedSystem { get; set; }
        string SelectedBaseColor { get; set; }
        string SelectedAlutekSystemType { get; set; }
        bool ThisVisibility { get; set; }
        void ShowfrmDimension();
        void ClosefrmDimension();
        Panel GetPanelFrameQty();
        Panel GetPanelAlutekSystemType();
        NumericUpDown GetNumWidth();
        NumericUpDown GetNumHeigth();

    }
}
