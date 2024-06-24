using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IPDFCompilerView
    {
        event EventHandler btnCompileReportsClickEventRaised;
        event EventHandler btnCompilePDFClickEventRaised;
        event EventHandler changeSyncDirToolStripMenuItemClickEventRaised;
        event FormClosedEventHandler PDFCompilerViewFormClosedEventRaised;

        void GetPDFCompilerView();
        void ClosePDFCompilerView();
        CheckBox GetPartialAdjustmentCheckbox();
        CheckBox GetAnnexCheckbox();
        OpenFileDialog GetFileDialog();

    }
}